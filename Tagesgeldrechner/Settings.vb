
Imports System.ComponentModel
Imports System.Configuration

Namespace My

    ''' <summary>
    ''' Diese Klasse ermöglicht die Behandlung bestimmter Ereignisse der Einstellungsklasse.
    ''' </summary>
    Partial Friend NotInheritable Class MySettings

        ''' <summary>
        ''' Wird ausgelöst, nachdem der Wert einer Einstellung geändert wurde.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub MySettings_PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Handles Me.PropertyChanged

        End Sub

        ''' <summary>
        ''' Wird ausgelöst, bevor der Wert einer Einstellung geändert wird.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub MySettings_SettingChanging(sender As Object, e As SettingChangingEventArgs) Handles Me.SettingChanging

        End Sub

        ''' <summary>
        ''' Wird ausgelöst, nachdem die Einstellungswerte geladen wurden.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub MySettings_SettingsLoaded(sender As Object, e As SettingsLoadedEventArgs) Handles Me.SettingsLoaded

        End Sub

        ''' <summary>
        ''' Wird ausgelöst, bevor die Einstellungswerte gespeichert werden.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub MySettings_SettingsSaving(sender As Object, e As CancelEventArgs) Handles Me.SettingsSaving

        End Sub

    End Class

End Namespace
