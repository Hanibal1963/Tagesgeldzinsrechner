' *************************************************************************************************
' 
' InterestValueCalculation.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' 
' *************************************************************************************************

Module InterestValueCalculation

  ''' <summary>
  ''' Berechnet den Zinswert für den gewählten Zalungsturnus
  ''' </summary>
  Friend Sub Calculate_Zinswert()

    'Welcher Turnus für die Zinszahlung wurde gewählt?
    Select Case ZinsTurnus
      Case 0 : SetMonthlyInterestRate() 'monatliche Zinszahlung
      Case 1 : SetQuarterlyInterestRate() 'vierteljährliche Zinszahlung
      Case 2 : SetYearlyInterestRate() 'jährliche Zinszahlung
    End Select

  End Sub

  ''' <summary>
  ''' Setzt den jährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
  ''' </summary>
  Private Sub SetYearlyInterestRate()
    ZinsFaktor = ZinsPa / 100
  End Sub

  ''' <summary>
  ''' Setzt den vierteljährlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
  ''' </summary>
  Private Sub SetQuarterlyInterestRate()
    ZinsFaktor = ((ZinsPa / 360) * 90) / 100
  End Sub

  ''' <summary>
  ''' Setzt den monatlichen Zinssatzfaktor basierend auf dem angegebenen Zinssatz.
  ''' </summary>
  Private Sub SetMonthlyInterestRate()
    ZinsFaktor = ((ZinsPa / 360) * 30) / 100
  End Sub

End Module
