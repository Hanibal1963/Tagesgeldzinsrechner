<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
  Inherits System.Windows.Forms.Form

  'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Wird vom Windows Form-Designer benötigt.
  Private components As System.ComponentModel.IContainer

  'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
  'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
  'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBoxAnfangssaldo = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TextBoxEinzahlung = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TextBoxZinssatz = New System.Windows.Forms.TextBox()
    Me.TextBoxLaufzeit = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.ComboBoxZinszahlung = New System.Windows.Forms.ComboBox()
    Me.ListViewKontoverlauf = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Label2"
        '
        'TextBoxAnfangssaldo
        '
        Me.HelpProvider.SetHelpString(Me.TextBoxAnfangssaldo, "anfänglicher Kontostand (ohne Währungszeichen)")
        Me.TextBoxAnfangssaldo.Location = New System.Drawing.Point(112, 60)
        Me.TextBoxAnfangssaldo.Name = "TextBoxAnfangssaldo"
        Me.TextBoxAnfangssaldo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.HelpProvider.SetShowHelp(Me.TextBoxAnfangssaldo, True)
        Me.TextBoxAnfangssaldo.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxAnfangssaldo.TabIndex = 0
        Me.TextBoxAnfangssaldo.WordWrap = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(229, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Label3"
        '
        'TextBoxEinzahlung
        '
        Me.HelpProvider.SetHelpString(Me.TextBoxEinzahlung, "Höhe der monatlichen Einzahlungen (ohne Währungszeichen)")
        Me.TextBoxEinzahlung.Location = New System.Drawing.Point(338, 60)
        Me.TextBoxEinzahlung.Name = "TextBoxEinzahlung"
        Me.TextBoxEinzahlung.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.HelpProvider.SetShowHelp(Me.TextBoxEinzahlung, True)
        Me.TextBoxEinzahlung.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxEinzahlung.TabIndex = 1
        Me.TextBoxEinzahlung.WordWrap = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(229, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Label5"
        '
        'TextBoxZinssatz
        '
        Me.HelpProvider.SetHelpString(Me.TextBoxZinssatz, "Der jährliche Zinssatz (ohne %-Zeichen)")
        Me.TextBoxZinssatz.Location = New System.Drawing.Point(112, 93)
        Me.TextBoxZinssatz.Name = "TextBoxZinssatz"
        Me.TextBoxZinssatz.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.HelpProvider.SetShowHelp(Me.TextBoxZinssatz, True)
        Me.TextBoxZinssatz.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxZinssatz.TabIndex = 2
        Me.TextBoxZinssatz.WordWrap = False
        '
        'TextBoxLaufzeit
        '
        Me.HelpProvider.SetHelpString(Me.TextBoxLaufzeit, "die Laufzeit des zu berechnenden Kontoverlaufs  (in Monaten)")
        Me.TextBoxLaufzeit.Location = New System.Drawing.Point(338, 96)
        Me.TextBoxLaufzeit.Name = "TextBoxLaufzeit"
        Me.TextBoxLaufzeit.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.HelpProvider.SetShowHelp(Me.TextBoxLaufzeit, True)
        Me.TextBoxLaufzeit.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxLaufzeit.TabIndex = 3
        Me.TextBoxLaufzeit.WordWrap = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Label6"
        '
        'ComboBoxZinszahlung
        '
        Me.ComboBoxZinszahlung.FormattingEnabled = True
        Me.HelpProvider.SetHelpString(Me.ComboBoxZinszahlung, "Turnus der Zinszahlungen")
        Me.ComboBoxZinszahlung.Items.AddRange(New Object() {"monatlich", "vierteljährlich", "halbjährlich", "jährlich"})
        Me.ComboBoxZinszahlung.Location = New System.Drawing.Point(112, 127)
        Me.ComboBoxZinszahlung.Name = "ComboBoxZinszahlung"
        Me.HelpProvider.SetShowHelp(Me.ComboBoxZinszahlung, True)
        Me.ComboBoxZinszahlung.Size = New System.Drawing.Size(100, 21)
        Me.ComboBoxZinszahlung.TabIndex = 4
        '
        'ListViewKontoverlauf
        '
        Me.ListViewKontoverlauf.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListViewKontoverlauf.GridLines = True
        Me.ListViewKontoverlauf.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewKontoverlauf.HideSelection = False
        Me.ListViewKontoverlauf.LabelWrap = False
        Me.ListViewKontoverlauf.Location = New System.Drawing.Point(15, 154)
        Me.ListViewKontoverlauf.MultiSelect = False
        Me.ListViewKontoverlauf.Name = "ListViewKontoverlauf"
        Me.ListViewKontoverlauf.ShowGroups = False
        Me.ListViewKontoverlauf.Size = New System.Drawing.Size(423, 276)
        Me.ListViewKontoverlauf.TabIndex = 11
        Me.ListViewKontoverlauf.TabStop = False
        Me.ListViewKontoverlauf.UseCompatibleStateImageBehavior = False
        Me.ListViewKontoverlauf.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Monat"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Kontostand"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Zinsen"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 100
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Image = Global.SchlumpfSoft.My.Resources.Resources.Info
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(427, 43)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 441)
        Me.Controls.Add(Me.ListViewKontoverlauf)
        Me.Controls.Add(Me.ComboBoxZinszahlung)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxLaufzeit)
        Me.Controls.Add(Me.TextBoxZinssatz)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxEinzahlung)
        Me.Controls.Add(Me.TextBoxAnfangssaldo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Label2 As Label
  Private WithEvents TextBoxAnfangssaldo As TextBox
  Private WithEvents Label3 As Label
  Private WithEvents TextBoxEinzahlung As TextBox
  Private WithEvents Label1 As Label
  Private WithEvents Label4 As Label
  Private WithEvents Label5 As Label
  Private WithEvents TextBoxZinssatz As TextBox
  Private WithEvents TextBoxLaufzeit As TextBox
  Private WithEvents Label6 As Label
  Private WithEvents ComboBoxZinszahlung As ComboBox
  Private WithEvents ListViewKontoverlauf As ListView
  Private WithEvents ColumnHeader1 As ColumnHeader
  Private WithEvents ColumnHeader2 As ColumnHeader
  Private WithEvents ColumnHeader3 As ColumnHeader
    Private WithEvents HelpProvider As HelpProvider
End Class
