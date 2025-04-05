Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices

Namespace My
  ' Für MyApplication sind folgende Ereignisse verfügbar:
  ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
  ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst.  Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
  ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
  ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
  ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
  Partial Friend Class MyApplication
    Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged

    End Sub

    Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown

    End Sub

    Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
      Application.MainForm = New FormMain
    End Sub

    Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
      Dim unused = MessageBox.Show("Es läuft bereits eine Instanz dieser Anwendung!", Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException

    End Sub

  End Class

End Namespace
