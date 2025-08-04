' *************************************************************************************************
' 
' Zinsinterval.vb
' Copyright (c) 2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Definition der Auflistung für die Intervalle der Zinszahlung
' 
' *************************************************************************************************


''' <summary>
''' Definiert die möglichen Intervalle, in denen Zinsen für ein Tagesgeldkonto gutgeschrieben werden können.
''' </summary>
Friend Enum ZinsInterval

    ''' <summary>
    ''' Zinsgutschrift erfolgt jeden Monat
    ''' </summary>
    Monatlich = 0

    ''' <summary>
    ''' Zinsgutschrift erfolgt alle drei Monate (Quartal)
    ''' </summary>
    Vierteljaehrlich = 1

    ''' <summary>
    ''' Zinsgutschrift erfolgt alle sechs Monate (Halbjahr)
    ''' </summary>
    Halbjaehrlich = 2

    ''' <summary>
    ''' Zinsgutschrift erfolgt einmal pro Jahr
    ''' </summary>
    Jaehrlich = 3

End Enum
