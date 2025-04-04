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
  Private Laufzeit As Integer = 0
  Private ZinsPa As Double = 0
  Private ZinsTurnus As Integer = 0
  Private KontoVerlauf As New List(Of KontoInfo)

  Sub Main()
    GetKontoInfo()
    Console.Clear()
    ShowProgrammInfo()
    KontoVerlauf = Calculate()
    Console.WriteLine($"Hier ist die Berechnung des Kontoverlaufs nach Deinen Angaben:")
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
    Console.WriteLine($"Wie hoch ist Dein Startguthaben?")
    Dim input As String = Console.ReadLine
    Dim result As Double
    While Not Double.TryParse(input, result)
      Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl ein:")
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage der monatlichen Einzahlung
  ''' </summary>
  Private Function GetZahlung() As Double
    Console.WriteLine($"Wieviel möchtest Du monatlich investieren?")
    Dim input As String = Console.ReadLine
    Dim result As Double
    While Not Double.TryParse(input, result)
      Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl ein:")
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage der Laufzeit
  ''' </summary>
  Private Function GetLaufzeit() As Integer
    Console.WriteLine($"Für wieviele Monate soll der Kontoverlauf berechnet werden?")
    Dim input As String = Console.ReadLine
    Dim result As Integer
    While Not Integer.TryParse(input, result)
      Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl ein:")
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage des Zinssatz
  ''' </summary>
  Private Function GetZinsPa() As Double
    Console.WriteLine($"Wie hoch ist der jährliche Zinssatz?")
    Dim input As String = Console.ReadLine
    Dim result As Double
    While Not Double.TryParse(input, result)
      Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl ein:")
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage des Zinsturnus
  ''' </summary>
  Private Function GetZinsTurnus() As Integer
    Console.WriteLine($"In welchem Turnus erfolgt die Zinszahlung?")
    Console.WriteLine($"1 für monatlich,2 für virteljährlich und 3 für jährlich.")
    Dim input As String = Console.ReadLine
    Dim result As Integer
    While Not Integer.TryParse(input, result) OrElse (result <> 1 AndAlso result <> 2 AndAlso result <> 3)
      Console.WriteLine("Ungültige Eingabe. Bitte gib nur 1, 2 oder 3 ein:")
      input = Console.ReadLine()
    End While
    Return result
  End Function

  ''' <summary>
  ''' Abfrage ob Zinsseszins gezahlt wird
  ''' </summary>
  Private Function GetZinsesZins() As Boolean
    Console.WriteLine($"Wird Zinseszins gezahlt?")
    Console.WriteLine($"[J]a oder [N]ein.")
    Dim result As Boolean
    Dim input As ConsoleKeyInfo
    Do
      input = Console.ReadKey(True)
      If input.Key = ConsoleKey.J Then
        result = True
      ElseIf input.Key = ConsoleKey.N Then
        result = False
      Else
        Console.WriteLine("Ungültige Eingabe. Bitte drücke [J] für ja oder [N] für nein.")
      End If
    Loop While input.Key <> ConsoleKey.J AndAlso input.Key <> ConsoleKey.N
    Return result
  End Function

  ''' <summary>
  ''' Anzeige der Zusammenfassung und Abfrage auf Richtigkeit
  ''' </summary>
  ''' <returns></returns>
  Private Function ShowInputInfo() As Boolean
    Console.WriteLine($"Zusammenfassung der von Dir eingegebenen Daten:{vbCrLf}")
    Console.WriteLine($"Dein Anfangskontostand: {Startsaldo} Euro")
    Console.WriteLine($"Deine monatliche Einzahlung: {Zahlung} Euro")
    Console.WriteLine($"Die Laufzeit des Kontos: {Laufzeit} Monate")
    Console.WriteLine($"Der Zinssatz pro Jahr: {ZinsPa} Prozent")
    Select Case ZinsTurnus
      Case 1
        Console.WriteLine($"Jährliche Zinszahlung.")
      Case 4
        Console.WriteLine($"Virteljährliche Zinszahlung.")
      Case 12
        Console.WriteLine($"Monatliche Zinszahlung.")
    End Select
    Console.WriteLine($"{vbCrLf}Sind Diese Angaben richtig?")
    Console.WriteLine($"[J]a oder [N]ein.")
    Dim result As Boolean
    Dim input As ConsoleKeyInfo
    Do
      input = Console.ReadKey(True)
      If input.Key = ConsoleKey.J Then
        result = True
      ElseIf input.Key = ConsoleKey.N Then
        result = False
      Else
        Console.WriteLine("Ungültige Eingabe. Bitte drücke [J] für ja oder [N] für nein.")
      End If
    Loop While input.Key <> ConsoleKey.J AndAlso input.Key <> ConsoleKey.N
    Return result
  End Function

  ''' <summary>
  ''' Zeigt den gesamten Kontoverlauf an
  ''' </summary>
  Private Sub ShowHistory()
    Console.WriteLine($"Monat{vbTab}Kontostand{vbTab}Zinsen{vbTab}")
    For Each info As KontoInfo In KontoVerlauf
      Console.WriteLine($"{info.Monat}{vbTab}{info.Kontostand}{vbTab}{vbTab}{vbTab}{vbTab}{info.Zinsen}")
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
      Case 1 'jährliche Zinszahlung
        Zinsfaktor = ZinsPa / 100

      Case 2 'virteljährliche Zinszahlung
        Zinsfaktor = ZinsPa / (4 * 100)

      Case 3 'monatliche Zinszahlung
        Zinsfaktor = ZinsPa / (12 * 100)

    End Select

    For Monat As Integer = 1 To Laufzeit
      Kontostand += Zahlung
      Select Case ZinsTurnus

        Case 1 'monatliche Zinszahlung
          Zins = Math.Round(Kontostand * Zinsfaktor, 2)
          Kontostand += Zins

        Case 2 'virteljährliche Zinszahlung
          If Monat Mod 3 = 0 Then 'Monat mit Zinszahlung
            Zins = Math.Round(Kontostand * Zinsfaktor, 2)
          Else 'Monat ohne Zinszahlung
            Zins = 0
          End If
          Kontostand += Zins

        Case 3 'jährliche Zinszahlung
          If Monat Mod 12 = 0 Then 'Monat mit Zinszahlung
            Zins = Math.Round(Kontostand * Zinsfaktor, 2)
          Else 'Monat ohne Zinszahlung
            Zins = 0
          End If
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
    Public Monat As Integer
    Public Kontostand As Double
    Public Zinsen As Double
  End Structure

End Module
