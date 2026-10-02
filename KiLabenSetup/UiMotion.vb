Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Friend NotInheritable Class UiMotion
    Implements IDisposable
    Private ReadOnly _form As Form
    Private ReadOnly _indicator As Panel
    Private ReadOnly _track As Panel
    Private ReadOnly _fill As Panel
    Private ReadOnly _art As Panel
    Private ReadOnly _timer As New System.Windows.Forms.Timer With {.Interval = 33}
    Private ReadOnly _clock As Stopwatch = Stopwatch.StartNew()
    Private ReadOnly _buttons As New Dictionary(Of Button, Color)
    Private _targetTop As Integer
    Private _targetPercent As Double
    Private _enabled As Boolean = True
    Private _activity As Boolean
    Private _disposed As Boolean
    Private ReadOnly _hover As New HashSet(Of Button)

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SystemParametersInfo(uiAction As UInteger, uiParam As UInteger, ByRef value As Boolean, flags As UInteger) As Boolean
    End Function

    Public Shared Function SystemAllowsMotion() As Boolean
        Dim allowed = True
        Try
            SystemParametersInfo(&H1042UI, 0UI, allowed, 0UI)
        Catch ex As DllNotFoundException
        End Try
        Return allowed AndAlso Not SystemInformation.HighContrast
    End Function

    Public Sub New(form As Form, indicator As Panel, track As Panel, fill As Panel, art As Panel)
        _form = form : _indicator = indicator : _track = track : _fill = fill : _art = art
        _targetTop = indicator.Top
        AddHandler _timer.Tick, AddressOf Animate
        AddHandler _art.Paint, AddressOf PaintArt
        AddHandler _track.SizeChanged, Sub() SetProgressWidthSafely()
        _timer.Start()
    End Sub

    Public Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value AndAlso Not SystemInformation.HighContrast
            If Not _enabled Then
                _indicator.Top = _targetTop
                SetProgressWidthSafely()
                _art.Invalidate()
            End If
        End Set
    End Property

    Public Property Busy As Boolean
        Get
            Return _activity
        End Get
        Set(value As Boolean)
            _activity = value
        End Set
    End Property

    Public Sub Target(top As Integer, percent As Double)
        _targetTop = top
        _targetPercent = Math.Clamp(percent, 0, 1)
        If Not _enabled Then
            _indicator.Top = top : SetProgressWidthSafely()
        End If
    End Sub

    Public Sub Register(b As Button)
        _buttons(b) = b.BackColor
        AddHandler b.MouseEnter, Sub() _hover.Add(b)
        AddHandler b.GotFocus, Sub() _hover.Add(b)
        AddHandler b.MouseLeave, Sub() _hover.Remove(b)
        AddHandler b.LostFocus, Sub() _hover.Remove(b)
    End Sub

    Private Sub Animate(sender As Object, e As EventArgs)
        If _disposed OrElse Not _form.Visible OrElse _form.WindowState = FormWindowState.Minimized Then Return
        Try
            Dim rate As Double = If(_enabled, 0.2R, 1.0R)

            ' Use Long/Double math before clamping back to WinForms Integer coordinates.
            Dim topGap As Long = CLng(_targetTop) - CLng(_indicator.Top)
            Dim topStep As Long = CLng(Math.Round(CDbl(topGap) * rate))
            Dim nextTop As Long = CLng(_indicator.Top) + topStep
            _indicator.Top = SafeInt(nextTop)

            Dim target As Integer = SafeProgressWidth()
            Dim gap As Long = CLng(target) - CLng(_fill.Width)
            If Math.Abs(gap) < 3L Then
                _fill.Width = target
            Else
                Dim widthStep As Long = CLng(Math.Round(CDbl(gap) * rate))
                Dim nextWidth As Long = CLng(_fill.Width) + widthStep
                _fill.Width = Math.Clamp(SafeInt(nextWidth), 0, Math.Max(0, _track.ClientSize.Width))
            End If

            For Each pair In _buttons
                If pair.Key.IsDisposed Then Continue For
                Dim baseColor = pair.Value
                Dim wanted = If(_hover.Contains(pair.Key), Blend(baseColor, Color.White, 0.12R), baseColor)
                pair.Key.BackColor = Blend(pair.Key.BackColor, wanted, If(_enabled, 0.3R, 1.0R))
            Next
            If _enabled Then _art.Invalidate()
        Catch ex As OverflowException
            ' Animation is decoration only. Disable it rather than crashing onboarding.
            _enabled = False
            _indicator.Top = _targetTop
            SetProgressWidthSafely()
        Catch ex As ArgumentException
            _enabled = False
            _indicator.Top = _targetTop
            SetProgressWidthSafely()
        End Try
    End Sub

    Private Function SafeProgressWidth() As Integer
        Dim width As Integer = Math.Max(0, _track.ClientSize.Width)
        Dim percent As Double = Math.Clamp(_targetPercent, 0.0R, 1.0R)
        Dim raw As Double = CDbl(width) * percent
        If Double.IsNaN(raw) OrElse Double.IsInfinity(raw) Then Return 0
        Return Math.Clamp(CInt(Math.Round(raw)), 0, width)
    End Function

    Private Sub SetProgressWidthSafely()
        Try
            _fill.Width = SafeProgressWidth()
        Catch
            _fill.Width = 0
        End Try
    End Sub

    Private Shared Function SafeInt(value As Long) As Integer
        If value > Integer.MaxValue Then Return Integer.MaxValue
        If value < Integer.MinValue Then Return Integer.MinValue
        Return CInt(value)
    End Function

    Private Shared Function Blend(a As Color, b As Color, t As Double) As Color
        If Double.IsNaN(t) OrElse Double.IsInfinity(t) Then t = 0.0R
        t = Math.Clamp(t, 0.0R, 1.0R)
        Dim r = Math.Clamp(CInt(Math.Round(CDbl(a.R) + (CDbl(b.R) - CDbl(a.R)) * t)), 0, 255)
        Dim g = Math.Clamp(CInt(Math.Round(CDbl(a.G) + (CDbl(b.G) - CDbl(a.G)) * t)), 0, 255)
        Dim bl = Math.Clamp(CInt(Math.Round(CDbl(a.B) + (CDbl(b.B) - CDbl(a.B)) * t)), 0, 255)
        Return Color.FromArgb(r, g, bl)
    End Function

    Private Sub PaintArt(sender As Object, e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim t = If(_enabled, _clock.Elapsed.TotalSeconds, 0.0R)
        Dim cx = _art.ClientSize.Width / 2.0F
        Dim cy = _art.ClientSize.Height / 2.0F
        For i As Integer = 0 To 2
            Dim radius As Single = 22.0F + i * 16.0F
            Dim speed As Double = If(_activity, 80.0R, 17.0R)
            Dim direction As Double = If(i Mod 2 = 0, 1.0R, -1.0R)
            Dim phase As Double = ((t Mod 3600.0R) * speed * direction + CDbl(i) * 100.0R) Mod 360.0R
            Dim angle As Single = CSng(phase)
            Using pen As New Pen(Color.FromArgb(75 + i * 38, If(i = 1, 163, 98), If(i = 1, 142, 229), If(i = 1, 255, 214)), 2.0F)
                g.DrawArc(pen, cx - radius, cy - radius, 2 * radius, 2 * radius, angle, 255)
            End Using
            Dim r = angle * Math.PI / 180
            Using dot As New SolidBrush(Color.FromArgb(98, 229, 214))
                g.FillEllipse(dot, CSng(cx + Math.Cos(r) * radius - 3), CSng(cy + Math.Sin(r) * radius - 3), 6, 6)
            End Using
        Next
        Using pen As New Pen(Color.FromArgb(230, 241, 255), 2)
            g.DrawLine(pen, cx - 8, cy, cx + 8, cy)
            g.DrawLine(pen, cx, cy - 8, cx, cy + 8)
        End Using
    End Sub

    Public Shared Sub Round(control As Control, radius As Integer)
        If control.Width < radius * 2 OrElse control.Height < radius * 2 Then Return
        Using path As New GraphicsPath()
            Dim diameter = radius * 2
            path.AddArc(0, 0, diameter, diameter, 180, 90)
            path.AddArc(control.Width - diameter - 1, 0, diameter, diameter, 270, 90)
            path.AddArc(control.Width - diameter - 1, control.Height - diameter - 1, diameter, diameter, 0, 90)
            path.AddArc(0, control.Height - diameter - 1, diameter, diameter, 90, 90)
            path.CloseFigure()
            Dim old = control.Region
            control.Region = New Region(path)
            If old IsNot Nothing Then old.Dispose()
        End Using
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _disposed Then Return
        _disposed = True
        _timer.Stop() : _timer.Dispose()
        RemoveHandler _art.Paint, AddressOf PaintArt
    End Sub
End Class
