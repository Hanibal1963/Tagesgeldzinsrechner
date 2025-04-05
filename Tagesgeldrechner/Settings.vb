
Imports System.ComponentModel
Imports System.Configuration

Namespace My

  'Diese Klasse ermöglicht die Behandlung bestimmter Ereignisse der Einstellungsklasse:
  ' Das SettingChanging-Ereignis wird ausgelöst, bevor der Wert einer Einstellung geändert wird.
  ' Das PropertyChanged-Ereignis wird ausgelöst, nachdem der Wert einer Einstellung geändert wurde.
  ' Das SettingsLoaded-Ereignis wird ausgelöst, nachdem die Einstellungswerte geladen wurden.
  ' Das SettingsSaving-Ereignis wird ausgelöst, bevor die Einstellungswerte gespeichert werden.
  Partial Friend NotInheritable Class MySettings
    Private Sub MySettings_PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Handles Me.PropertyChanged

    End Sub

    Private Sub MySettings_SettingChanging(sender As Object, e As SettingChangingEventArgs) Handles Me.SettingChanging

    End Sub

    Private Sub MySettings_SettingsLoaded(sender As Object, e As SettingsLoadedEventArgs) Handles Me.SettingsLoaded

    End Sub

    Private Sub MySettings_SettingsSaving(sender As Object, e As CancelEventArgs) Handles Me.SettingsSaving

    End Sub

  End Class

End Namespace
