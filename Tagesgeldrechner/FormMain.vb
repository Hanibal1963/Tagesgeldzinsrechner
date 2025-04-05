' *************************************************************************************************
' 
' FormMain.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' 
' *************************************************************************************************

Public Class FormMain

  Private KontoVerlauf As New List(Of KontoInfo)
  Private StartSaldo As Double = 0
  Private Zahlung As Double = 0
  Private ZinsPa As Double = 0
  Private Laufzeit As Double = 0
  Private ZinsFaktor As Double = 0
  Private ZinsTurnus As Integer = 0

  Private Event PropertyChanged()

  Public Sub New()
    ' Dieser Aufruf ist für den Designer erforderlich.
    Me.InitializeComponent()
    ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    Me.TextBoxAnfangssaldo.Text = $"0"
    Me.TextBoxEinzahlung.Text = $"0"
    Me.TextBoxLaufzeit.Text = $"0"
    Me.TextBoxZinssatz.Text = $"0"
    Me.ComboBoxZinszahlung.SelectedIndex = 0
  End Sub

  Private Sub TextBox_Text_Changed(sender As Object, e As EventArgs) Handles _
    TextBoxAnfangssaldo.TextChanged, TextBoxZinssatz.TextChanged,
    TextBoxLaufzeit.TextChanged, TextBoxEinzahlung.TextChanged

    Dim TextBoxValue As String = CType(sender, TextBox).Text
    If String.IsNullOrEmpty(TextBoxValue) Then Exit Sub

    'Welche Textbox hat sich geändert?
    Select Case True
      Case sender Is Me.TextBoxAnfangssaldo 'Der Anfangssaldo hat sich geändert
        Me.StartSaldo = CDbl(TextBoxValue)

      Case sender Is Me.TextBoxEinzahlung 'Die monatliche Einzahlung hat sich geändert
        Me.Zahlung = CDbl(TextBoxValue)

      Case sender Is Me.TextBoxLaufzeit 'Die Laufzeit hat sich geändert
        Me.Laufzeit = CDbl(TextBoxValue)

      Case sender Is Me.TextBoxZinssatz 'Drer Zinssatz hat sich geändert
        Me.ZinsPa = CDbl(TextBoxValue)

    End Select

    'Ereignis auslösen
    RaiseEvent PropertyChanged()

  End Sub

  Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
    TextBoxZinssatz.KeyPress, TextBoxLaufzeit.KeyPress,
    TextBoxEinzahlung.KeyPress, TextBoxAnfangssaldo.KeyPress

    ' Überprüfen, ob die gedrückte Taste eine Zahl, ein Steuerzeichen oder ein Komma ist
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ","c Then
      e.Handled = True
    End If

    ' Überprüfen, ob bereits ein Komma in der TextBox vorhanden ist
    If e.KeyChar = ","c AndAlso DirectCast(sender, TextBox).Text.Contains(",") Then
      e.Handled = True
    End If

  End Sub

  Private Sub ComboBox_SelectedIndex_Changed(sender As Object, e As EventArgs) Handles _
    ComboBoxZinszahlung.SelectedIndexChanged

    'Index des gewählten Eintrags abfragen und speichern
    Me.ZinsTurnus = CType(sender, ComboBox).SelectedIndex

    'Ereignis auslösen
    RaiseEvent PropertyChanged()

  End Sub

  Private Sub FormMain_PropertyChanged() Handles _
    Me.PropertyChanged

    'Zinswert für Zinszahlung anpassen 
    Me.Calculate_Zinswert()

    'Kontoverlauf berechnen und speichern
    Me.KontoVerlauf = Me.Calculate_Verlauf()

    'Kontoverlauf anzeigen
    Me.ShowVerlauf()

  End Sub

  Private Sub ShowVerlauf()

    'alte Liste löschen
    Me.ListViewKontoverlauf.Items.Clear()

    'neue Liste erzeugen
    For Each KontoInfo As KontoInfo In Me.KontoVerlauf
      Dim unused = Me.ListViewKontoverlauf.Items.Add(
        New ListViewItem(
        {$"{KontoInfo.Monat}",
        $"{KontoInfo.Kontostand}",
        $"{KontoInfo.Zinsen}"}))
    Next

  End Sub

  ''' <summary>
  ''' Berechnet den Zinswert für den gewählten Zalungsturnus
  ''' </summary>
  Private Sub Calculate_Zinswert()

    'Welcher Turnus für die Zinszahlung wurde gewählt?
    Select Case Me.ZinsTurnus
      Case 0 'monatliche Zinszahlung
        Me.ZinsFaktor = Me.ZinsPa / (12 * 100)

      Case 1 'vierteljährliche Zinszahlung
        Me.ZinsFaktor = Me.ZinsPa / (4 * 100)

      Case 2 'jährliche Zinszahlung
        Me.ZinsFaktor = Me.ZinsPa / 100

    End Select

  End Sub

  ''' <summary>
  ''' Berechnet den Kontoverlauf
  ''' </summary>
  Private Function Calculate_Verlauf() As List(Of KontoInfo)

    Dim result As New List(Of KontoInfo)
    result.Clear()

    Dim Zins As Double = 0
    Dim Kontostand As Double = Me.StartSaldo

    For Monat As Double = 1 To Me.Laufzeit

      Kontostand += Me.Zahlung

      Select Case Me.ZinsTurnus

        Case 0 'monatliche Zinszahlung
          Zins = Math.Round(Kontostand * Me.ZinsFaktor, 2)
          Kontostand += Zins

        Case 1 'virteljährliche Zinszahlung
          Zins = If(Monat Mod 3 = 0, Math.Round(Kontostand * Me.ZinsFaktor, 2), 0)
          Kontostand += Zins

        Case 2 'jährliche Zinszahlung
          Zins = If(Monat Mod 12 = 0, Math.Round(Kontostand * Me.ZinsFaktor, 2), 0)
          Kontostand += Zins

      End Select

      result.Add(New KontoInfo With {.Monat = Monat, .Kontostand = Kontostand, .Zinsen = Zins})

    Next

    Return result

  End Function

  ''' <summary>
  ''' Definiert Kontoinformationen für einen Monat
  ''' </summary>
  Private Structure KontoInfo
    Public Monat As Double
    Public Kontostand As Double
    Public Zinsen As Double
  End Structure

End Class
