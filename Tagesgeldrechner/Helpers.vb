' *************************************************************************************************
' 
' Helpers.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' Hilfsmodul mit Methoden zur Variablenzuweisung anhand von TextBox-Eingaben.
' 
' *************************************************************************************************

Module Helpers

    ''' <summary>
    ''' Setzt globale Variablen abhängig davon, welche TextBox geändert wurde.
    ''' </summary>
    ''' <param name="sender">Die TextBox, deren Wert geändert wurde.</param>
    ''' <param name="value">Der neue Wert, der gesetzt werden soll.</param>
    Friend Sub SetVariables(sender As TextBox, value As Double)
        ' Überprüft, welche TextBox den Wert geändert hat und weist den Wert der entsprechenden Variable zu.
        Select Case sender.Name
            Case $"TextBoxAnfangssaldo" ' Der Anfangssaldo wurde geändert
                StartSaldo = value      ' Setzt den Startsaldo
            Case $"TextBoxEinzahlung"   ' Die monatliche Einzahlung wurde geändert
                Zahlung = value         ' Setzt die monatliche Einzahlung
            Case $"TextBoxLaufzeit"     ' Die Laufzeit wurde geändert
                Laufzeit = value        ' Setzt die Laufzeit
            Case $"TextBoxZinssatz"     ' Der Zinssatz wurde geändert
                ZinsPa = value          ' Setzt den Zinssatz pro Jahr
        End Select
    End Sub

End Module
