' *************************************************************************************************
' 
' Programm.vb
' Copyright (c)2025 by Andreas Sauer 
'
' Kurzbeschreibung:
' 
' *************************************************************************************************

Imports System.Security.Principal

Module Programm

  Private Startsaldo As Double = 0
  Private Zahlung As Double = 0
  Private Laufzeit As Double = 0
  Private ZinsPa As Double = 0
  Private ZinsTurnus As Double = 0
  Private KontoVerlauf As New List(Of KontoInfo)

  Sub Main()
    GetKontoInfo()
    Console.Clear()
    ShowProgrammInfo()
    KontoVerlauf = Calculate()
    Console.WriteLine(My.Resources.Meldung01)
    ShowHistory()
  End Sub

  ''' <summary>
  ''' Fragt die Infos zum zu berechnenden Konto ab
  ''' </summary>
  Private Sub GetKontoInfo()
    Dim repeat As Boolean = True
    While repeat
      Console.Clear()
      ShowProgrammInfo()
      DataQuery()
      Console.Clear()
      ShowProgrammInfo()
      repeat = Not ShowInputInfo()
    End While
  End Sub

  ''' <summary>
  ''' Zeigt die Programminformationen
  ''' </summary>
  Private Sub ShowProgrammInfo()
    Dim Name As String = My.Application.Info.AssemblyName
    Dim Copyright As String = My.Application.Info.Copyright
    Dim Version As String = My.Application.Info.Version.ToString()
    Dim Description As String = My.Application.Info.Description
    Console.WriteLine($"{Name} V{Version} {Copyright}{vbCrLf}{Description}")
    Console.WriteLine($"{New String("="c, Len(Description))}{vbCrLf}")
  End Sub

  ''' <summary>
  ''' Führt eien Datenabfrage durch
  ''' </summary>
  Private Sub DataQuery()
    Startsaldo = GetStartSaldo()
    Zahlung = GetZahlung()
    Laufzeit = GetLaufzeit()
    ZinsPa = GetZinsPa()
    ZinsTurnus = GetZinsTurnus()
  End Sub

  ''' <summary>
  ''' Abfrage des Anfangskapitals
  ''' </summary>
  Private Function GetStartSaldo() As Double
    Console.WriteLine(My.Resources.Frage01)
    Dim input As String = Console.ReadLine
    Dim result As Double
    While Not Double.TryParse(input, result)
      Console.WriteLine(My.Resources.Meldung02)
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage der monatlichen Einzahlung
  ''' </summary>
  Private Function GetZahlung() As Double
    Console.WriteLine(My.Resources.Frage02)
    Dim input As String = Console.ReadLine
    Dim result As Double
    While Not Double.TryParse(input, result)
      Console.WriteLine(My.Resources.Meldung02)
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage der Laufzeit
  ''' </summary>
  Private Function GetLaufzeit() As Double
    Console.WriteLine(My.Resources.Frage03)
    Dim input As String = Console.ReadLine
    Dim result As Double
    While Not Double.TryParse(input, result)
      Console.WriteLine(My.Resources.Meldung02)
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage des Zinssatz
  ''' </summary>
  Private Function GetZinsPa() As Double
    Console.WriteLine(My.Resources.Frage04)
    Dim input As String = Console.ReadLine
    Dim result As Double
    While Not Double.TryParse(input, result)
      Console.WriteLine(My.Resources.Meldung02)
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage des Zinsturnus
  ''' </summary>
  Private Function GetZinsTurnus() As Double
    Console.WriteLine(My.Resources.Frage05)
    Console.WriteLine(My.Resources.Frage05_Hinweis)
    Dim input As String = Console.ReadLine
    Dim result As Double
    While Not Double.TryParse(input, result) OrElse (result <> 1 AndAlso result <> 2 AndAlso result <> 3)
      Console.WriteLine(My.Resources.Meldung03)
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Anzeige der Zusammenfassung und Abfrage auf Richtigkeit
  ''' </summary>
  ''' <returns></returns>
  Private Function ShowInputInfo() As Boolean
    Console.WriteLine($"{My.Resources.Meldung04}{vbCrLf}")
    Console.WriteLine($"{My.Resources.Meldung08} {Startsaldo} {My.Resources.Wort04}")
    Console.WriteLine($"{My.Resources.Meldung09} {Zahlung} {My.Resources.Wort04}")
    Console.WriteLine($"{My.Resources.Meldung10} {Laufzeit} {My.Resources.Wort05}")
    Console.WriteLine($"{My.Resources.Meldung11} {ZinsPa} {My.Resources.Wort06}")
    Select Case ZinsTurnus
      Case 1
        Console.WriteLine(My.Resources.Meldung05)
      Case 4
        Console.WriteLine(My.Resources.Meldung06)
      Case 12
        Console.WriteLine(My.Resources.Meldung07)
    End Select
    Console.WriteLine($"{vbCrLf}{My.Resources.Frage06}")
    Console.WriteLine(My.Resources.Ja_Nein_Hinweis01)
    Dim result As Boolean
    Dim input As ConsoleKeyInfo
    Do
      input = Console.ReadKey(True)
      If input.Key = ConsoleKey.J Then
        result = True
      ElseIf input.Key = ConsoleKey.N Then
        result = False
      Else
        Console.WriteLine(My.Resources.ja_Nein_Hinweis02)
      End If
    Loop While input.Key <> ConsoleKey.J AndAlso input.Key <> ConsoleKey.N
    Return result
  End Function

  ''' <summary>
  ''' Zeigt den gesamten Kontoverlauf an
  ''' </summary>
  Private Sub ShowHistory()
    Console.WriteLine(String.Format("{0,-10}{1,10:F2}{2,15:F2}", My.Resources.Wort01, My.Resources.Wort02, My.Resources.Wort03))
    For Each info As KontoInfo In KontoVerlauf
      Console.WriteLine(String.Format("{0,-10}{1,10:F2}{2,15:F2}", info.Monat, info.Kontostand, info.Zinsen))
    Next
  End Sub

  ''' <summary>
  ''' Berechnet den Kontoverlauf
  ''' </summary>
  Private Function Calculate() As List(Of KontoInfo)
    Dim result As New List(Of KontoInfo)
    result.Clear()
    Dim Zinsfaktor As Double
    Dim Zins As Double = 0
    Dim Kontostand As Double = Startsaldo

    Select Case ZinsTurnus
      Case 1 'monatliche Zinszahlung
        Zinsfaktor = ZinsPa / (12 * 100)

      Case 2 'virteljährliche Zinszahlung
        Zinsfaktor = ZinsPa / (4 * 100)

      Case 3 'jährliche Zinszahlung
        Zinsfaktor = ZinsPa / 100

    End Select

    For Monat As Double = 1 To Laufzeit
      Kontostand += Zahlung
      Select Case ZinsTurnus

        Case 1 'monatliche Zinszahlung
          Zins = Math.Round(Kontostand * Zinsfaktor, 2)
          Kontostand += Zins

        Case 2 'virteljährliche Zinszahlung
          Zins = If(Monat Mod 3 = 0, Math.Round(Kontostand * Zinsfaktor, 2), 0)
          Kontostand += Zins

        Case 3 'jährliche Zinszahlung
          Zins = If(Monat Mod 12 = 0, Math.Round(Kontostand * Zinsfaktor, 2), 0)
          Kontostand += Zins

      End Select
      result.Add(New KontoInfo With {.Monat = Monat, .Kontostand = Kontostand, .Zinsen = Zins})
    Next
    Return result
  End Function

  ''' <summary>
  ''' Definiert Kontoinformationen für einen Monat
  ''' </summary>
  Private Structure KontoInfo
    Public Monat As Double
    Public Kontostand As Double
    Public Zinsen As Double
  End Structure

End Module
