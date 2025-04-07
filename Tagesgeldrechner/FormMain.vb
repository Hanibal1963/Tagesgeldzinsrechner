' *************************************************************************************************
' 
' FormMain.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Tool um den Kontoverlauf eines Tagesgeldkontos zu berechnen.
'
' *************************************************************************************************

Public Class FormMain

  Private Const MONTHS_IN_YEAR As Integer = 12
  Private Const QUARTERS_IN_YEAR As Integer = 4
  Private Const PERCENT_DIVISOR As Double = 100

  Private KontoVerlauf As New List(Of KontoInfo)
  Private StartSaldo As Double = 0
  Private Zahlung As Double = 0
  Private ZinsPa As Double = 0
  Private Laufzeit As Double = 0
  Private ZinsFaktor As Double = 0
  Private ZinsTurnus As Integer = 0

  Private Event PropertyChanged()

  Public Sub New()
    Me.InitializeComponent() ' Dieser Aufruf ist für den Designer erforderlich.
    ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    Me.InitTitle() ' Titelzeile des Startfensters anpassen
    Me.InitLabels() 'Texte der Labels initialisieren
    Me.InitTextBoxes() ' Anfangsinitialisierung der Textboxen
    Me.InitComboBoxes() ' Anfangsinitialisierung der Combobox
  End Sub

  Private Sub TextBox_Text_Changed(sender As Object, e As EventArgs) Handles _
    TextBoxAnfangssaldo.TextChanged, TextBoxZinssatz.TextChanged,
    TextBoxLaufzeit.TextChanged, TextBoxEinzahlung.TextChanged

    ' Prüfen ob überhaupt etwas eingegeben wurde
    Dim TextBoxValue As String = CType(sender, TextBox).Text
    If String.IsNullOrEmpty(TextBoxValue) Then Exit Sub

    'Eingabe nach Double konvertieren
    Dim value As Double = CDbl(TextBoxValue)

    ' Variablen mit den Werten füllen
    Me.SetVariables(sender, value)

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

  <CodeAnalysis.SuppressMessage("Style", "IDE0058:Der Ausdruckswert wird niemals verwendet.", Justification:="<Ausstehend>")>
  Private Sub ShowVerlauf()

    'alte Liste löschen
    Me.ListViewKontoverlauf.Items.Clear()

    'neue Liste erzeugen
    For Each KontoInfo As KontoInfo In Me.KontoVerlauf
      Dim item = New ListViewItem(New String() {
        KontoInfo.Monat.ToString(),
        KontoInfo.Kontostand.ToString(),
        KontoInfo.Zinsen.ToString()})
      Me.ListViewKontoverlauf.Items.Add(item)
    Next

  End Sub

  ''' <summary>
  ''' Berechnet den Zinswert für den gewählten Zalungsturnus
  ''' </summary>
  Private Sub Calculate_Zinswert()
    'Welcher Turnus für die Zinszahlung wurde gewählt?
    Select Case Me.ZinsTurnus
      Case 0 : Me.SetMonthlyInterestRate() 'monatliche Zinszahlung
      Case 1 : Me.SetQuarterlyInterestRate() 'vierteljährliche Zinszahlung
      Case 2 : Me.SetYearlyInterestRate() 'jährliche Zinszahlung
    End Select
  End Sub

  ''' <summary>
  ''' Setzt den jährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
  ''' </summary>
  Private Sub SetYearlyInterestRate()
    Me.ZinsFaktor = Me.ZinsPa / PERCENT_DIVISOR
  End Sub

  ''' <summary>
  ''' Setzt den vierteljährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
  ''' </summary>
  Private Sub SetQuarterlyInterestRate()
    Me.ZinsFaktor = Me.ZinsPa / (QUARTERS_IN_YEAR * PERCENT_DIVISOR)
  End Sub

  ''' <summary>
  ''' Setzt den monatlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
  ''' </summary>
  Private Sub SetMonthlyInterestRate()
    Me.ZinsFaktor = Me.ZinsPa / (MONTHS_IN_YEAR * PERCENT_DIVISOR)
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
  ''' Initialisiert die Titelzeile des Fensters
  ''' </summary>
  Private Sub InitTitle()
    Dim title As String = My.Application.Info.Title
    Dim copyright As String = My.Application.Info.Copyright
    Dim version As String = My.Application.Info.Version.ToString
    Me.Text = $"{title} Version {version} {copyright}"
  End Sub

  ''' <summary>
  ''' Initialisiert die Texte der Labels
  ''' </summary>
  Private Sub InitLabels()
    Dim number As Integer
    Dim labeltext As String
    For Each control As Control In Me.Controls
      If TypeOf control Is Label Then
        number = CInt(Strings.Right(control.Name, 1))
        labeltext = My.Resources.ResourceManager.GetString($"LabelText{number}")
        control.Text = labeltext
      End If
    Next
  End Sub

  ''' <summary>
  ''' Initialisiert die Anfangswerte der Textboxen
  ''' </summary>
  Private Sub InitTextBoxes()
    Me.TextBoxAnfangssaldo.Text = $"0"
    Me.TextBoxEinzahlung.Text = $"0"
    Me.TextBoxLaufzeit.Text = $"0"
    Me.TextBoxZinssatz.Text = $"0"
  End Sub

  Private Sub InitComboBoxes()
    Me.ComboBoxZinszahlung.SelectedIndex = 0
  End Sub

  Private Sub SetVariables(sender As Object, value As Double)

    ' Variablen je nach Textbox setzen
    Select Case True

      'Der Anfangssaldo hat sich geändert
      Case sender Is Me.TextBoxAnfangssaldo : Me.StartSaldo = value

      'Die monatliche Einzahlung hat sich geändert
      Case sender Is Me.TextBoxEinzahlung : Me.Zahlung = value

      'Die Laufzeit hat sich geändert
      Case sender Is Me.TextBoxLaufzeit : Me.Laufzeit = value

      'Der Zinssatz hat sich geändert
      Case sender Is Me.TextBoxZinssatz : Me.ZinsPa = value

    End Select

  End Sub

  ''' <summary>
  ''' Definiert Kontoinformationen für einen Monat
  ''' </summary>
  Private Structure KontoInfo
    Public Monat As Double
    Public Kontostand As Double
    Public Zinsen As Double
  End Structure

End Class
