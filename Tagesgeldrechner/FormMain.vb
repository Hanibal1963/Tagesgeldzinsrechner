' *************************************************************************************************
' 
' FormMain.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Tool um den Kontoverlauf eines Tagesgeldkontos zu berechnen.
'
' *************************************************************************************************

Imports SchlumpfSoft.DailyInterestCalculator.GlobalVariables

Public Class FormMain

    Private Event PropertyChanged()

    ''' <summary>
    ''' Speichert den Kontoverlauf
    ''' </summary>
    Private KontoVerlauf As New List(Of KontoInfo)

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich
        InitializeComponent()

        ' Titelzeile des Startfensters anpassen
        Dim title As String = My.Application.Info.Title
        Dim copyright As String = My.Application.Info.Copyright
        Dim version As String = My.Application.Info.Version.ToString
        Text = String.Format("{0} Version {1} {2}", title, version, copyright)

        ' Anfangsinitialisierung der Combobox und sicherstellen das auch Werte vorhanden sind
        If ComboBoxZinszahlung.Items.Count > 0 Then ComboBoxZinszahlung.SelectedIndex = 0

    End Sub

    Private Sub TextBox_Text_Changed(sender As Object, e As EventArgs) Handles _
        TextBox_Anfangssaldo.TextChanged,
        TextBox_Zinssatz.TextChanged,
        TextBox_Laufzeit.TextChanged,
        TextBox_Einzahlung.TextChanged

        ' Welche Textbox wurde geändert
        Dim tb As TextBox = CType(sender, TextBox)

        ' Prüfen ob überhaupt etwas eingegeben wurde
        If String.IsNullOrEmpty(tb.Text) Then Exit Sub

        ' Eingabe nach Double konvertieren und bei fehlerhaftem Wert abbrechen
        Dim value As Double
        If Not Double.TryParse(tb.Text, value) Then Exit Sub

        ' Variablen mit den Werten füllen
        SetVariables(tb, value)

        ' Ereignis auslösen
        RaiseEvent PropertyChanged()

    End Sub

    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
        TextBox_Zinssatz.KeyPress,
        TextBox_Laufzeit.KeyPress,
        TextBox_Einzahlung.KeyPress,
        TextBox_Anfangssaldo.KeyPress

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
        ZinsTurnus = CType(sender, ComboBox).SelectedIndex

        'Ereignis auslösen
        RaiseEvent PropertyChanged()

    End Sub

    Private Sub FormMain_PropertyChanged() Handles _
        Me.PropertyChanged

        'Zinswert für Zinszahlung anpassen
        Calculate_Zinswert()

        'Kontoverlauf berechnen und speichern
        KontoVerlauf = Calculate_Verlauf()

        'Kontoverlauf anzeigen
        ShowVerlauf()

    End Sub

    ''' <summary>
    ''' Berechnet den Kontoverlauf für ein Tagesgeldkonto.
    ''' Für jeden Monat der Laufzeit wird der aktuelle Kontostand und die erhaltenen Zinsen berechnet.
    ''' Die Zinsgutschrift erfolgt je nach gewähltem Zinsintervall (monatlich, vierteljährlich, halbjährlich, jährlich).
    ''' </summary>
    ''' <returns>Liste mit KontoInfo-Objekten für jeden Monat</returns>
    Private Function Calculate_Verlauf() As List(Of KontoInfo)

        ' Ergebnisliste für den Verlauf initialisieren
        Dim result As New List(Of KontoInfo)

        ' Variable für die Zinsen des aktuellen Monats
        Dim Zins As Double = 0

        ' Startwert für den Kontostand setzen
        Dim Kontostand As Double = StartSaldo

        ' Für jeden Monat der Laufzeit:
        For Monat As Double = 1 To Laufzeit

            ' Monatliche Einzahlung zum Kontostand addieren
            Kontostand += Zahlung

            ' Je nach ZinsTurnus wird die Zinsgutschrift unterschiedlich berechnet
            Select Case ZinsTurnus

                ' Zinsen werden jeden Monat berechnet und gutgeschrieben
                Case ZinsInterval.Monatlich
                    CalculateMonthly(Zins, Kontostand)

                ' Zinsen werden nur alle 3 Monate berechnet und gutgeschrieben
                Case ZinsInterval.Vierteljaehrlich
                    CalculateQuarterly(Zins, Kontostand, Monat)

                ' Zinsen werden nur alle 6 Monate berechnet und gutgeschrieben
                Case ZinsInterval.Halbjaehrlich
                    CalculateHalfYearly(Zins, Kontostand, Monat)

                ' Zinsen werden nur alle 12 Monate berechnet und gutgeschrieben
                Case ZinsInterval.Jaehrlich
                    CalculateYearly(Zins, Kontostand, Monat)

            End Select

            ' Für den aktuellen Monat ein KontoInfo-Objekt mit Monat, Kontostand und Zinsen zur Ergebnisliste hinzufügen
            result.Add(New KontoInfo With {.Monat = Monat, .Kontostand = Kontostand, .Zinsen = Zins})

        Next

        ' Die vollständige Verlaufsliste zurückgeben
        Return result

    End Function

    ''' <summary>
    ''' Berechnet die Zinsen und aktualisiert den Kontostand für das jährliche Zinsintervall.
    ''' Wenn der Monat ein Vielfaches von 12 ist, werden die Zinsen berechnet und dem Kontostand hinzugefügt. 
    ''' </summary>
    ''' <param name="Zins"></param>
    ''' <param name="Kontostand"></param>
    ''' <param name="Monat"></param>
    Private Sub CalculateYearly(ByRef Zins As Double, ByRef Kontostand As Double, Monat As Double)

        Zins = If(Monat Mod 12 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
        Kontostand += Zins

    End Sub

    ''' <summary>
    ''' Berechnet die Zinsen für ein Halbjahresintervall.
    ''' Wenn der Monat ein Vielfaches von 6 ist, werden die Zinsen berechnet und zum Kontostand addiert.
    ''' </summary>
    ''' <param name="Zins"></param>
    ''' <param name="Kontostand"></param>
    ''' <param name="Monat"></param>
    Private Sub CalculateHalfYearly(ByRef Zins As Double, ByRef Kontostand As Double, Monat As Double)

        Zins = If(Monat Mod 6 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
        Kontostand += Zins

    End Sub

    ''' <summary>
    ''' Berechnet die Zinsen für ein vierteljährliches Intervall.
    ''' Wenn der Monat ein Vielfaches von 3 ist, werden die Zinsen berechnet und zum Kontostand addiert.
    ''' </summary>
    ''' <param name="Zins"></param>
    ''' <param name="Kontostand"></param>
    ''' <param name="Monat"></param>
    Private Sub CalculateQuarterly(ByRef Zins As Double, ByRef Kontostand As Double, Monat As Double)

        Zins = If(Monat Mod 3 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
        Kontostand += Zins

    End Sub

    ''' <summary>
    ''' Berechnet die Zinsen für ein monatliches Intervall.
    ''' Die Zinsen werden jeden Monat berechnet und zum Kontostand addiert.
    ''' </summary>
    ''' <param name="Zins"></param>
    ''' <param name="Kontostand"></param>
    Private Sub CalculateMonthly(ByRef Zins As Double, ByRef Kontostand As Double)

        Zins = Math.Round(Kontostand * ZinsFaktor, 2)
        Kontostand += Zins

    End Sub

    ''' <summary>
    ''' Berechnet den Zinswert für den gewählten Zalungsturnus.
    ''' </summary>
    Private Sub Calculate_Zinswert()

        ' Welcher Turnus für die Zinszahlung wurde gewählt?
        ' 0 = monatlich, 1 = vierteljährlich, 2 = halbjährlich, 3 = jährlich
        Select Case ZinsTurnus

            ' monatliche Zinszahlung
            Case 0
                SetMonthlyInterestRate()

            ' vierteljährliche Zinszahlung
            Case 1
                SetQuarterlyInterestRate()

            ' halbjährliche Zinszahlung
            Case 2
                SetHalfYearlyInterestRate()

            ' jährliche Zinszahlung
            Case 3
                SetYearlyInterestRate()

        End Select

    End Sub

    Private Sub ShowVerlauf()

        ' alte Liste löschen
        ListView_Kontoverlauf.Items.Clear()

        'neue Liste erzeugen
        For Each KontoInfo As KontoInfo In KontoVerlauf

            ' Eintrag für Monat erzeugen
            Dim item = New ListViewItem(
                New String() {
                KontoInfo.Monat.ToString(),
                KontoInfo.Kontostand.ToString(),
                KontoInfo.Zinsen.ToString()})

            ' erzeugten Eintrag hinzufügen
            Dim unused = ListView_Kontoverlauf.Items.Add(item)

        Next

    End Sub

    ''' <summary>
    ''' Setzt globale Variablen abhängig davon, welche TextBox geändert wurde.
    ''' </summary>
    ''' <param name="sender">Die TextBox, deren Wert geändert wurde.</param>
    ''' <param name="value">Der neue Wert, der gesetzt werden soll.</param>
    Private Sub SetVariables(sender As TextBox, value As Double)

        ' Überprüft, welche TextBox den Wert geändert hat und weist den Wert der entsprechenden Variable zu.
        Select Case True

            ' Der Anfangssaldo wurde geändert -> Setzt den Startsaldo
            Case sender Is TextBox_Anfangssaldo
                StartSaldo = value

            ' Die monatliche Einzahlung wurde geändert -> Setzt die monatliche Einzahlung
            Case sender Is TextBox_Einzahlung
                Zahlung = value

            ' Die Laufzeit wurde geändert -> Setzt die Laufzeit
            Case sender Is TextBox_Laufzeit
                Laufzeit = value

            ' Der Zinssatz wurde geändert -> Setzt den Zinssatz pro Jahr
            Case sender Is TextBox_Zinssatz
                ZinsPa = value

        End Select

    End Sub

    ''' <summary>
    ''' Setzt den monatlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = ZinsPa / 360 * 30 / 100 = 0,001666...
    ''' </summary>
    Private Sub SetMonthlyInterestRate()

        ' ZinsFaktor entspricht dem Zinssatz für 30 Tage (ein Monat)
        ZinsFaktor = ZinsPa / 360 * 30 / 100

    End Sub

    ''' <summary>
    ''' Setzt den vierteljährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = 2 / 360 * 90 / 100 = 0,005
    ''' </summary>
    Private Sub SetQuarterlyInterestRate()

        ' ZinsFaktor entspricht dem Zinssatz für 90 Tage (ein Quartal)
        ZinsFaktor = ZinsPa / 360 * 90 / 100

    End Sub

    ''' <summary>
    ''' Setzt den halbjährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = 2 / 360 * 180 / 100 = 0,01
    ''' </summary>
    Private Sub SetHalfYearlyInterestRate()

        ' ZinsFaktor entspricht dem Zinssatz für 180 Tage (ein halbes Jahr)
        ZinsFaktor = ZinsPa / 360 * 180 / 100

    End Sub

    ''' <summary>
    ''' Setzt den jährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = 0,02
    ''' </summary>
    Private Sub SetYearlyInterestRate()

        ' ZinsFaktor entspricht dem jährlichen Zinssatz in Dezimalform
        ZinsFaktor = ZinsPa / 100

    End Sub

    ''' <summary>
    ''' Kopiert den Kontostand in die Zwischenablage
    ''' </summary>
    ''' <remarks></remarks>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripMenuItemKopieren_Click(sender As Object, e As EventArgs) Handles _
        ToolStripMenuItemKopieren.Click

        ' sicherstellen das auch wirklich ein Eintrag ausgewählt ist
        If ListView_Kontoverlauf.FocusedItem Is Nothing Then Exit Sub

        Dim copyvalue As String = ListView_Kontoverlauf.FocusedItem.SubItems.Item(1).Text
        Clipboard.SetText(copyvalue)
        Dim unused = MessageBox.Show(
            $"Der Kontostand {copyvalue} wurde in die Zwischenablage kopiert.",
            "Kopieren",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

End Class
