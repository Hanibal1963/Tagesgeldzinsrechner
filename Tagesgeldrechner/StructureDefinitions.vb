' *************************************************************************************************
' 
' StructureDefinitions.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' 
' *************************************************************************************************

Module StructureDefinitions

  ''' <summary>
  ''' Definiert Kontoinformationen für einen Monat
  ''' </summary>
  Friend Structure KontoInfo
    Public Monat As Double
    Public Kontostand As Double
    Public Zinsen As Double
  End Structure

End Module
