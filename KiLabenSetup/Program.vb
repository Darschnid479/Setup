Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Text

Friend Module Program
    <STAThread>
    Public Sub Main()
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
        AddHandler Application.ThreadException, AddressOf HandleUiException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf HandleDomainException
        Try
            Application.Run(New MainForm())
        Catch ex As Exception
            WriteCrashLog(ex)
            MessageBox.Show("KI-Laben Setup kunne ikke starte. Detaljer er lagret i crash.log." & Environment.NewLine & Environment.NewLine & ex.Message,
                            "KI-Laben Setup", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HandleUiException(sender As Object, e As Threading.ThreadExceptionEventArgs)
        WriteCrashLog(e.Exception)
        MessageBox.Show("KI-Laben Setup traff en uventet feil. Programmet har lagret crash.log i programmappen." & Environment.NewLine & Environment.NewLine &
                        e.Exception.Message, "KI-Laben Setup", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub HandleDomainException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex = TryCast(e.ExceptionObject, Exception)
        If ex IsNot Nothing Then WriteCrashLog(ex)
    End Sub

    Private Sub WriteCrashLog(ex As Exception)
        Try
            Dim crashLogPath As String = System.IO.Path.Combine(AppContext.BaseDirectory, "crash.log")
            Dim text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & Environment.NewLine & ex.ToString() & Environment.NewLine & New String("-"c, 70) & Environment.NewLine
            File.AppendAllText(crashLogPath, text, Encoding.UTF8)
        Catch
        End Try
    End Sub

End Module
