' *************************************************************************************************
' 
' VariableDefinitions.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' 
' Dieses Modul enthält die Definitionen für die Variablen und Strukturen, die im Tagesgeldrechner verwendet werden.
' Es definiert die globalen Variablen, die für die Berechnung des Kontoverlaufs und der Zinsen benötigt werden.
' Es enthält auch ein Enum für die Zinsintervalle und eine Struktur für die Kontoinformationen.
' Dieses Modul ist Teil des Tagesgeldrechners und wird in der Hauptanwendung verwendet, um die Berechnungen durchzuführen.
'
' *************************************************************************************************

Module Definitions

#Region "Globale Variablen"
    Friend KontoVerlauf As New List(Of KontoInfo) 'Speichert den Kontoverlauf
    Friend StartSaldo As Double = 0 'Speichert den Anfangkontostand
    Friend Zahlung As Double = 0 'Speichert die monatliche Einzahlung
    Friend ZinsPa As Double = 0 'Speichert den jährlichen Zinssatz
    Friend Laufzeit As Double = 0 'Speichert die Laufzeit für die die Berechnung ausgeführt werden soll
    Friend ZinsFaktor As Double = 0 'Speichert den Zinssatz für einen Zinszahlungsturnus
    Friend ZinsTurnus As Integer = 0 'Speichert den Zinszahlungsturnus
#End Region

    ''' <summary>
    ''' Das Enum ZinsIntervall definiert die möglichen Intervalle, in denen Zinsen für ein Tagesgeldkonto gutgeschrieben werden können.
    ''' </summary>
    Friend Enum ZinsIntervall
        Monatlich = 0          ' Zinsgutschrift erfolgt jeden Monat
        Vierteljaehrlich = 1   ' Zinsgutschrift erfolgt alle drei Monate (Quartal)
        Halbjaehrlich = 2      ' Zinsgutschrift erfolgt alle sechs Monate (Halbjahr)
        Jaehrlich = 3          ' Zinsgutschrift erfolgt einmal pro Jahr
    End Enum

    ''' <summary>
    ''' Definiert Kontoinformationen für einen Monat
    ''' </summary>
    Friend Structure KontoInfo
        Public Monat As Double ' Speichert den Monat für die Kontoinformationen
        Public Kontostand As Double ' Speichert den Kontostand für den Monat
        Public Zinsen As Double ' Speichert die Zinsen, die für den Monat gutgeschrieben wurden
    End Structure

End Module
