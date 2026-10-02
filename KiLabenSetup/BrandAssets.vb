Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection

Friend Module BrandAssets
    Public Function LoadLogo() As Bitmap
        Using stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("KiLabenSetup.Assets.Logo.png")
            If stream Is Nothing Then Throw New InvalidDataException("Logoressursen mangler. Bygg prosjektet på nytt med den offisielle logoen i Assets.")
            Using source As New Bitmap(stream)
                If source.Width < 32 OrElse source.Height < 32 Then
                    Throw New InvalidDataException("Logoen er for liten. Et 1 x 1-bilde er ikke en gyldig KI-Laben-logo.")
                End If
                Dim result As New Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb)
                Dim transparentSource As Boolean = False
                For y As Integer = 0 To source.Height - 1
                    For x As Integer = 0 To source.Width - 1
                        If source.GetPixel(x, y).A < 250 Then
                            transparentSource = True
                            Exit For
                        End If
                    Next
                    If transparentSource Then Exit For
                Next
                Dim ink As Long = 0L
                For y As Integer = 0 To source.Height - 1
                    For x As Integer = 0 To source.Width - 1
                        Dim pixel = source.GetPixel(x, y)
                        Dim alpha As Integer = CInt(pixel.A)
                        ' Keep transparency; remove white paper from opaque black-on-white logos.
                        If Not transparentSource Then alpha = 255 - CInt((CInt(pixel.R) + CInt(pixel.G) + CInt(pixel.B)) / 3.0R)
                        result.SetPixel(x, y, Color.FromArgb(alpha, 255, 255, 255))
                        If alpha > 20 Then ink += 1L
                    Next
                Next
                If ink < 20 Then
                    result.Dispose()
                    Throw New InvalidDataException("Logoen er tom eller gjennomsiktig. Bruk den offisielle PNG-filen.")
                End If
                Return result
            End Using
        End Using
    End Function
End Module
