﻿' *************************************************************************************************
' 
' FormMain.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Tool um den Kontoverlauf eines Tagesgeldkontos zu berechnen.
'
' *************************************************************************************************

Public Class FormMain

  Private Event PropertyChanged()

    Public Sub New()
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        InitTitle() ' Titelzeile des Startfensters anpassen
        InitLabels() 'Texte der Labels initialisieren
        InitTextBoxes() ' Anfangsinitialisierung der Textboxen
        InitComboBoxes() ' Anfangsinitialisierung der Combobox
    End Sub

    Private Sub TextBox_Text_Changed(sender As Object, e As EventArgs) Handles _
        TextBoxAnfangssaldo.TextChanged, TextBoxZinssatz.TextChanged, TextBoxLaufzeit.TextChanged, TextBoxEinzahlung.TextChanged
        ' Prüfen ob überhaupt etwas eingegeben wurde
        Dim tb As TextBox = CType(sender, TextBox)
        Dim TextBoxValue As String = tb.Text
        If String.IsNullOrEmpty(TextBoxValue) Then Exit Sub
        'Eingabe nach Double konvertieren
        Dim value As Double = CDbl(TextBoxValue)
        ' Variablen mit den Werten füllen
        SetVariables(tb, value)
        'Ereignis auslösen
        RaiseEvent PropertyChanged()
    End Sub

    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
        TextBoxZinssatz.KeyPress, TextBoxLaufzeit.KeyPress, TextBoxEinzahlung.KeyPress, TextBoxAnfangssaldo.KeyPress
        ' Überprüfen, ob die gedrückte Taste eine Zahl, ein Steuerzeichen oder ein Komma ist
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ","c Then
            e.Handled = True
        End If
        ' Überprüfen, ob bereits ein Komma in der TextBox vorhanden ist
        If e.KeyChar = ","c AndAlso DirectCast(sender, TextBox).Text.Contains(",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox_SelectedIndex_Changed(sender As Object, e As EventArgs) Handles ComboBoxZinszahlung.SelectedIndexChanged
        'Index des gewählten Eintrags abfragen und speichern
        ZinsTurnus = CType(sender, ComboBox).SelectedIndex
        'Ereignis auslösen
        RaiseEvent PropertyChanged()
    End Sub

    Private Sub FormMain_PropertyChanged() Handles Me.PropertyChanged
        'Zinswert für Zinszahlung anpassen 
        Calculate_Zinswert()
        'Kontoverlauf berechnen und speichern
        KontoVerlauf = Calculate_Verlauf()
        'Kontoverlauf anzeigen
        ShowVerlauf()
    End Sub

    <CodeAnalysis.SuppressMessage("Style", "IDE0058:Der Ausdruckswert wird niemals verwendet.", Justification:="<Ausstehend>")>
    Private Sub ShowVerlauf()
        'alte Liste löschen
        ListViewKontoverlauf.Items.Clear()
        'neue Liste erzeugen
        For Each KontoInfo As KontoInfo In KontoVerlauf
            Dim item = New ListViewItem(New String() {KontoInfo.Monat.ToString(), KontoInfo.Kontostand.ToString(), KontoInfo.Zinsen.ToString()})
            ListViewKontoverlauf.Items.Add(item)
        Next
    End Sub

    ''' <summary>
    ''' Initialisiert die Titelzeile des Fensters
    ''' </summary>
    Private Sub InitTitle()
        Dim title As String = My.Application.Info.Title
        Dim copyright As String = My.Application.Info.Copyright
        Dim version As String = My.Application.Info.Version.ToString
        Text = String.Format("{0} Version {1} {2}", title, version, copyright)
    End Sub

    ''' <summary>
    ''' Initialisiert die Texte der Labels
    ''' </summary>
    Private Sub InitLabels()
        Dim number As Integer
        Dim labeltext As String
        For Each control As Control In Controls
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
        TextBoxAnfangssaldo.Text = $"0"
        TextBoxEinzahlung.Text = $"0"
        TextBoxLaufzeit.Text = $"0"
        TextBoxZinssatz.Text = $"0"
    End Sub

    ''' <summary>
    ''' Initialisiert die Combobox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitComboBoxes()
        ComboBoxZinszahlung.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Kopiert den Kontostand in die Zwischenablage
    ''' </summary>
    ''' <remarks></remarks>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripMenuItemKopieren_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemKopieren.Click
        Dim copyvalue As String = ListViewKontoverlauf.FocusedItem.SubItems.Item(1).Text
        Clipboard.SetText(copyvalue)
        Dim unused = MessageBox.Show($"Der Kontostand {copyvalue} wurde in die Zwischenablage kopiert.", "Kopieren", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
