' *************************************************************************************************
' 
' ProgramHelpers.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
'
' Hilfsmodul mit Methoden zur Variablenzuweisung anhand von TextBox-Eingaben,
' Methoden zur Berechnung des Zinsfaktors für verschiedene Zinszahlungs-Turni (monatlich, vierteljährlich, halbjährlich, jährlich)
' und Methoden um den Verlauf eines Tagesgeldkontos über eine bestimmte Laufzeit unter Berücksichtigung
' von regelmäßigen Einzahlungen und verschiedenen Zinszahlungsintervallen zu berechnen.
'
' *************************************************************************************************

Module ProgramHelpers

    ''' <summary>
    ''' Setzt globale Variablen abhängig davon, welche TextBox geändert wurde.
    ''' </summary>
    ''' <param name="sender">Die TextBox, deren Wert geändert wurde.</param>
    ''' <param name="value">Der neue Wert, der gesetzt werden soll.</param>
    Friend Sub SetVariables(sender As TextBox, value As Double)
        ' Überprüft, welche TextBox den Wert geändert hat und weist den Wert der entsprechenden Variable zu.
        Select Case sender.Name
            Case $"TextBoxAnfangssaldo" ' Der Anfangssaldo wurde geändert
                StartSaldo = value      ' Setzt den Startsaldo
            Case $"TextBoxEinzahlung"   ' Die monatliche Einzahlung wurde geändert
                Zahlung = value         ' Setzt die monatliche Einzahlung
            Case $"TextBoxLaufzeit"     ' Die Laufzeit wurde geändert
                Laufzeit = value        ' Setzt die Laufzeit
            Case $"TextBoxZinssatz"     ' Der Zinssatz wurde geändert
                ZinsPa = value          ' Setzt den Zinssatz pro Jahr
        End Select
    End Sub

    ''' <summary>
    ''' Berechnet den Zinswert für den gewählten Zalungsturnus.
    ''' </summary>
    Friend Sub Calculate_Zinswert()
        ' Welcher Turnus für die Zinszahlung wurde gewählt?
        ' 0 = monatlich, 1 = vierteljährlich, 2 = halbjährlich, 3 = jährlich
        Select Case ZinsTurnus
            Case 0 : SetMonthlyInterestRate()      ' monatliche Zinszahlung
            Case 1 : SetQuarterlyInterestRate()    ' vierteljährliche Zinszahlung
            Case 2 : SetHalfYearlyInterestRate()   ' halbjährliche Zinszahlung
            Case 3 : SetYearlyInterestRate()       ' jährliche Zinszahlung
        End Select
    End Sub
    ''' <summary>
    ''' Berechnet den Kontoverlauf für ein Tagesgeldkonto.
    ''' Für jeden Monat der Laufzeit wird der aktuelle Kontostand und die erhaltenen Zinsen berechnet.
    ''' Die Zinsgutschrift erfolgt je nach gewähltem Zinsintervall (monatlich, vierteljährlich, halbjährlich, jährlich).
    ''' </summary>
    ''' <returns>Liste mit KontoInfo-Objekten für jeden Monat</returns>
    Friend Function Calculate_Verlauf() As List(Of KontoInfo)
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
                Case ZinsIntervall.Monatlich ' Zinsen werden jeden Monat berechnet und gutgeschrieben
                    CalculateMonthly(Zins, Kontostand)
                Case ZinsIntervall.Vierteljaehrlich ' Zinsen werden nur alle 3 Monate berechnet und gutgeschrieben
                    CalculateQuarterly(Zins, Kontostand, Monat)
                Case ZinsIntervall.Halbjaehrlich ' Zinsen werden nur alle 6 Monate berechnet und gutgeschrieben
                    CalculateHalfYearly(Zins, Kontostand, Monat)
                Case ZinsIntervall.Jaehrlich ' Zinsen werden nur alle 12 Monate berechnet und gutgeschrieben
                    CalculateYearly(Zins, Kontostand, Monat)
            End Select
            ' Für den aktuellen Monat ein KontoInfo-Objekt mit Monat, Kontostand und Zinsen zur Ergebnisliste hinzufügen
            result.Add(New KontoInfo With {.Monat = Monat, .Kontostand = Kontostand, .Zinsen = Zins})
        Next
        ' Die vollständige Verlaufsliste zurückgeben
        Return result
    End Function

    ''' <summary>
    ''' Setzt den jährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = 0,02
    ''' </summary>
    Private Sub SetYearlyInterestRate()
        ' ZinsFaktor entspricht dem jährlichen Zinssatz in Dezimalform
        ZinsFaktor = ZinsPa / 100
    End Sub

    ''' <summary>
    ''' Setzt den vierteljährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = 2 / 360 * 90 / 100 = 0,005
    ''' </summary>
    Private Sub SetQuarterlyInterestRate()
        ZinsFaktor = ZinsPa / 360 * 90 / 100 ' ZinsFaktor entspricht dem Zinssatz für 90 Tage (ein Quartal)
    End Sub

    ''' <summary>
    ''' Setzt den halbjährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = 2 / 360 * 180 / 100 = 0,01
    ''' </summary>
    Private Sub SetHalfYearlyInterestRate()
        ZinsFaktor = ZinsPa / 360 * 180 / 100 ' ZinsFaktor entspricht dem Zinssatz für 180 Tage (ein halbes Jahr)
    End Sub

    ''' <summary>
    ''' Setzt den monatlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = ZinsPa / 360 * 30 / 100 = 0,001666...
    ''' </summary>
    Private Sub SetMonthlyInterestRate()
        ZinsFaktor = ZinsPa / 360 * 30 / 100 ' ZinsFaktor entspricht dem Zinssatz für 30 Tage (ein Monat)
    End Sub
    ''' <summary>
    ''' Berechnet die Zinsen und aktualisiert den Kontostand für das jährliche Zinsintervall.
    ''' Wenn der Monat ein Vielfaches von 12 ist, werden die Zinsen berechnet und dem Kontostand hinzugefügt. 
    ''' </summary>
    ''' <param name="Zins"></param>
    ''' <param name="Kontostand"></param>
    ''' <param name="Monat"></param>
    <CodeAnalysis.SuppressMessage("Style", "IDE0045:In bedingten Ausdruck konvertieren", Justification:="<Ausstehend>")>
    Private Sub CalculateYearly(ByRef Zins As Double, ByRef Kontostand As Double, Monat As Double)
        If Monat Mod 12 = 0 Then
            Zins = Math.Round(Kontostand * ZinsFaktor, 2)
        Else
            Zins = 0
        End If
        Kontostand += Zins
    End Sub

    ''' <summary>
    ''' Berechnet die Zinsen für ein Halbjahresintervall.
    ''' Wenn der Monat ein Vielfaches von 6 ist, werden die Zinsen berechnet und zum Kontostand addiert.
    ''' </summary>
    ''' <param name="Zins"></param>
    ''' <param name="Kontostand"></param>
    ''' <param name="Monat"></param>
    <CodeAnalysis.SuppressMessage("Style", "IDE0045:In bedingten Ausdruck konvertieren", Justification:="<Ausstehend>")>
    Private Sub CalculateHalfYearly(ByRef Zins As Double, ByRef Kontostand As Double, Monat As Double)
        If Monat Mod 6 = 0 Then
            Zins = Math.Round(Kontostand * ZinsFaktor, 2)
        Else
            Zins = 0
        End If
        Kontostand += Zins
    End Sub

    ''' <summary>
    ''' Berechnet die Zinsen für ein vierteljährliches Intervall.
    ''' Wenn der Monat ein Vielfaches von 3 ist, werden die Zinsen berechnet und zum Kontostand addiert.
    ''' </summary>
    ''' <param name="Zins"></param>
    ''' <param name="Kontostand"></param>
    ''' <param name="Monat"></param>
    <CodeAnalysis.SuppressMessage("Style", "IDE0045:In bedingten Ausdruck konvertieren", Justification:="<Ausstehend>")>
    Private Sub CalculateQuarterly(ByRef Zins As Double, ByRef Kontostand As Double, Monat As Double)
        If Monat Mod 3 = 0 Then
            Zins = Math.Round(Kontostand * ZinsFaktor, 2)
        Else
            Zins = 0
        End If
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

End Module
