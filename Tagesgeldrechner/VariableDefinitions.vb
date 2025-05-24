' *************************************************************************************************
' 
' VariableDefinitions.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' 
' *************************************************************************************************

Module VariableDefinitions
    Friend KontoVerlauf As New List(Of KontoInfo) 'Speichert den Kontoverlauf
    Friend StartSaldo As Double = 0 'Speichert den Anfangkontostand
    Friend Zahlung As Double = 0 'Speichert die monatliche Einzahlung
    Friend ZinsPa As Double = 0 'Speichert den jährlichen Zinssatz
    Friend Laufzeit As Double = 0 'Speichert die Laufzeit für die die Berechnung ausgeführt werden soll
    Friend ZinsFaktor As Double = 0 'Speichert den Zinssatz für einen Zinszahlungsturnus
    Friend ZinsTurnus As Integer = 0 'Speichert den Zinszahlungsturnus
End Module
