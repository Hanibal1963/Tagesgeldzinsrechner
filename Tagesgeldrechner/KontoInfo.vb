' *************************************************************************************************
' 
' KontoInfo.vb
' Copyright (c) 2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Definiert die Datenstuktur für die Kontoinformationen für einen Monat
'
' *************************************************************************************************

''' <summary>
''' Definiert Kontoinformationen für einen Monat
''' </summary>
Friend Structure KontoInfo

    ''' <summary>
    ''' Speichert den Monat für die Kontoinformationen
    ''' </summary>
    Public Monat As Double

    ''' <summary>
    ''' Speichert den Kontostand für den Monat
    ''' </summary>
    Public Kontostand As Double

    ''' <summary>
    ''' Speichert die Zinsen, die für den Monat gutgeschrieben wurden
    ''' </summary>
    Public Zinsen As Double

End Structure
