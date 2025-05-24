' *************************************************************************************************
' 
' Enumsdefinitions.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Definition von Enums für das Projekt Tagesgeldrechner.
' 
' *************************************************************************************************

''' <summary>
''' Das Enum ZinsIntervall definiert die möglichen Intervalle, in denen Zinsen für ein Tagesgeldkonto gutgeschrieben werden können.
''' </summary>
Friend Enum ZinsIntervall
    Monatlich = 0          ' Zinsgutschrift erfolgt jeden Monat
    Vierteljaehrlich = 1   ' Zinsgutschrift erfolgt alle drei Monate (Quartal)
    Halbjaehrlich = 2      ' Zinsgutschrift erfolgt alle sechs Monate (Halbjahr)
    Jaehrlich = 3          ' Zinsgutschrift erfolgt einmal pro Jahr
End Enum
