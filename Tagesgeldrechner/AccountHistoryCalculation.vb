' *************************************************************************************************
' 
' AccountHistoryCalculation.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' 
' *************************************************************************************************

Module AccountHistoryCalculation

  ''' <summary>
  ''' Berechnet den Kontoverlauf
  ''' </summary>
  Friend Function Calculate_Verlauf() As List(Of KontoInfo)

    Dim result As New List(Of KontoInfo)
    result.Clear()

    Dim Zins As Double = 0
    Dim Kontostand As Double = StartSaldo

    For Monat As Double = 1 To Laufzeit

      Kontostand += Zahlung

      Select Case ZinsTurnus

        Case 0 'monatliche Zinszahlung
          Zins = Math.Round(Kontostand * ZinsFaktor, 2)
          Kontostand += Zins

        Case 1 'virteljährliche Zinszahlung
          Zins = If(Monat Mod 3 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
          Kontostand += Zins

        Case 2 'halbjährliche Zinszahlung
          Zins = If(Monat Mod 6 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
          Kontostand += Zins

        Case 3 'jährliche Zinszahlung
          Zins = If(Monat Mod 12 = 0, Math.Round(Kontostand * ZinsFaktor, 2), 0)
          Kontostand += Zins

      End Select

      result.Add(New KontoInfo With {.Monat = Monat, .Kontostand = Kontostand, .Zinsen = Zins})

    Next

    Return result

  End Function

End Module
