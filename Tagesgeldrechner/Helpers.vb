' *************************************************************************************************
' 
' Helpers.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' 
' *************************************************************************************************

Module Helpers

    ''' <summary>
    ''' Variablen je nach Textbox setzen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="value"></param>
    Friend Sub SetVariables(sender As TextBox, value As Double)
        'Der Inhalt welcher Textbox hat sich geändert
        Select Case sender.Name
            Case $"TextBoxAnfangssaldo" 'Der Anfangssaldo hat sich geändert
                StartSaldo = value
            Case $"TextBoxEinzahlung" 'Die monatliche Einzahlung hat sich geändert
                Zahlung = value
            Case $"TextBoxLaufzeit" 'Die Laufzeit hat sich geändert
                Laufzeit = value
            Case $"TextBoxZinssatz" 'Der Zinssatz hat sich geändert
                ZinsPa = value
        End Select
    End Sub

End Module
