' *************************************************************************************************
' 
' AccountHistoryCalculation.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Berechnet den Verlauf eines Tagesgeldkontos über eine bestimmte Laufzeit unter Berücksichtigung
' von regelmäßigen Einzahlungen und verschiedenen Zinszahlungsintervallen.
' 
' *************************************************************************************************

Module AccountHistoryCalculation

    ''' <summary>
    ''' Berechnet den Kontoverlauf für ein Tagesgeldkonto.
    ''' Für jeden Monat der Laufzeit wird der aktuelle Kontostand und die erhaltenen Zinsen berechnet.
    ''' Die Zinsgutschrift erfolgt je nach gewähltem Zinsintervall (monatlich, vierteljährlich, halbjährlich, jährlich).
    ''' </summary>
    ''' <returns>Liste mit KontoInfo-Objekten für jeden Monat</returns>
    Friend Function Calculate_Verlauf() As List(Of KontoInfo)
        ' Ergebnisliste für den Verlauf initialisieren
        Dim result As New List(Of KontoInfo)
        result.Clear()
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
                Case ZinsIntervall.Monatlich
                    ' Zinsen werden jeden Monat berechnet und gutgeschrieben
                    Zins = Math.Round(Kontostand * ZinsFaktor, 2)
                    Kontostand += Zins
                Case ZinsIntervall.Vierteljaehrlich
                    ' Zinsen werden nur alle 3 Monate berechnet und gutgeschrieben
                    Zins = If(Monat Mod 3 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
                    Kontostand += Zins
                Case ZinsIntervall.Halbjaehrlich
                    ' Zinsen werden nur alle 6 Monate berechnet und gutgeschrieben
                    Zins = If(Monat Mod 6 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
                    Kontostand += Zins
                Case ZinsIntervall.Jaehrlich
                    ' Zinsen werden nur alle 12 Monate berechnet und gutgeschrieben
                    Zins = If(Monat Mod 12 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
                    Kontostand += Zins
            End Select
            ' Für den aktuellen Monat ein KontoInfo-Objekt mit Monat, Kontostand und Zinsen zur Ergebnisliste hinzufügen
            result.Add(New KontoInfo With {.Monat = Monat, .Kontostand = Kontostand, .Zinsen = Zins})
        Next
        ' Die vollständige Verlaufsliste zurückgeben
        Return result
    End Function

End Module
