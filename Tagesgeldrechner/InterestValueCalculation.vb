' *************************************************************************************************
' 
' InterestValueCalculation.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Modul zur Berechnung des Zinsfaktors für verschiedene Zinszahlungs-Turni (monatlich, vierteljährlich, halbjährlich, jährlich)
' 
' *************************************************************************************************

Module InterestValueCalculation

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
    ''' Setzt den monatlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
    ''' Beispiel: 2% p.a. -> ZinsFaktor = ZinsPa / 360 * 30 / 100 = 0,001666...
    ''' </summary>
    Private Sub SetMonthlyInterestRate()
        ' ZinsFaktor entspricht dem Zinssatz für 30 Tage (ein Monat)
        ZinsFaktor = ZinsPa / 360 * 30 / 100
    End Sub

End Module
