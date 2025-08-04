<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Label_Startsaldo = New System.Windows.Forms.Label()
        Me.TextBox_Anfangssaldo = New System.Windows.Forms.TextBox()
        Me.Label_Einzahlung = New System.Windows.Forms.Label()
        Me.TextBox_Einzahlung = New System.Windows.Forms.TextBox()
        Me.Label_Zinssatz = New System.Windows.Forms.Label()
        Me.Label_Laufzeit = New System.Windows.Forms.Label()
        Me.TextBox_Zinssatz = New System.Windows.Forms.TextBox()
        Me.TextBox_Laufzeit = New System.Windows.Forms.TextBox()
        Me.Label_Zinszahlung = New System.Windows.Forms.Label()
        Me.ComboBoxZinszahlung = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStripKontoverlauf = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemKopieren = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label_Info = New System.Windows.Forms.Label()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ListView_Kontoverlauf = New System.Windows.Forms.ListView()
        Me.ColumnHeader_Monat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader_Kontostand = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader_Zinsen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripKontoverlauf.SuspendLayout()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_Startsaldo
        '
        Me.Label_Startsaldo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Startsaldo.Location = New System.Drawing.Point(3, 117)
        Me.Label_Startsaldo.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Startsaldo.Name = "Label_Startsaldo"
        Me.Label_Startsaldo.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label_Startsaldo.Size = New System.Drawing.Size(152, 23)
        Me.Label_Startsaldo.TabIndex = 6
        Me.Label_Startsaldo.Text = "StartSaldo:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label_Startsaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox_Anfangssaldo
        '
        Me.TextBox_Anfangssaldo.Dock = System.Windows.Forms.DockStyle.Top
        Me.HelpProvider.SetHelpString(Me.TextBox_Anfangssaldo, "anfänglicher Kontostand (ohne Währungszeichen)")
        Me.TextBox_Anfangssaldo.Location = New System.Drawing.Point(161, 117)
        Me.TextBox_Anfangssaldo.Name = "TextBox_Anfangssaldo"
        Me.TextBox_Anfangssaldo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.HelpProvider.SetShowHelp(Me.TextBox_Anfangssaldo, True)
        Me.TextBox_Anfangssaldo.Size = New System.Drawing.Size(152, 20)
        Me.TextBox_Anfangssaldo.TabIndex = 0
        Me.TextBox_Anfangssaldo.Text = "0"
        Me.TextBox_Anfangssaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_Anfangssaldo.WordWrap = False
        '
        'Label_Einzahlung
        '
        Me.Label_Einzahlung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Einzahlung.Location = New System.Drawing.Point(319, 117)
        Me.Label_Einzahlung.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Einzahlung.Name = "Label_Einzahlung"
        Me.Label_Einzahlung.Size = New System.Drawing.Size(152, 23)
        Me.Label_Einzahlung.TabIndex = 7
        Me.Label_Einzahlung.Text = "monatliche Zahlung:"
        Me.Label_Einzahlung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox_Einzahlung
        '
        Me.TextBox_Einzahlung.Dock = System.Windows.Forms.DockStyle.Top
        Me.HelpProvider.SetHelpString(Me.TextBox_Einzahlung, "Höhe der monatlichen Einzahlungen (ohne Währungszeichen)")
        Me.TextBox_Einzahlung.Location = New System.Drawing.Point(477, 117)
        Me.TextBox_Einzahlung.Name = "TextBox_Einzahlung"
        Me.TextBox_Einzahlung.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.HelpProvider.SetShowHelp(Me.TextBox_Einzahlung, True)
        Me.TextBox_Einzahlung.Size = New System.Drawing.Size(154, 20)
        Me.TextBox_Einzahlung.TabIndex = 1
        Me.TextBox_Einzahlung.Text = "0"
        Me.TextBox_Einzahlung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_Einzahlung.WordWrap = False
        '
        'Label_Zinssatz
        '
        Me.Label_Zinssatz.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Zinssatz.Location = New System.Drawing.Point(3, 146)
        Me.Label_Zinssatz.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Zinssatz.Name = "Label_Zinssatz"
        Me.Label_Zinssatz.Size = New System.Drawing.Size(152, 23)
        Me.Label_Zinssatz.TabIndex = 8
        Me.Label_Zinssatz.Text = "jährlicher Zinssatz:"
        Me.Label_Zinssatz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Laufzeit
        '
        Me.Label_Laufzeit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Laufzeit.Location = New System.Drawing.Point(319, 146)
        Me.Label_Laufzeit.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Laufzeit.Name = "Label_Laufzeit"
        Me.Label_Laufzeit.Size = New System.Drawing.Size(152, 23)
        Me.Label_Laufzeit.TabIndex = 9
        Me.Label_Laufzeit.Text = "Laufzeit (Monate):"
        Me.Label_Laufzeit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox_Zinssatz
        '
        Me.TextBox_Zinssatz.Dock = System.Windows.Forms.DockStyle.Top
        Me.HelpProvider.SetHelpString(Me.TextBox_Zinssatz, "Der jährliche Zinssatz (ohne %-Zeichen)")
        Me.TextBox_Zinssatz.Location = New System.Drawing.Point(161, 146)
        Me.TextBox_Zinssatz.Name = "TextBox_Zinssatz"
        Me.TextBox_Zinssatz.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.HelpProvider.SetShowHelp(Me.TextBox_Zinssatz, True)
        Me.TextBox_Zinssatz.Size = New System.Drawing.Size(152, 20)
        Me.TextBox_Zinssatz.TabIndex = 2
        Me.TextBox_Zinssatz.Text = "0"
        Me.TextBox_Zinssatz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_Zinssatz.WordWrap = False
        '
        'TextBox_Laufzeit
        '
        Me.TextBox_Laufzeit.Dock = System.Windows.Forms.DockStyle.Top
        Me.HelpProvider.SetHelpString(Me.TextBox_Laufzeit, "die Laufzeit des zu berechnenden Kontoverlaufs  (in Monaten)")
        Me.TextBox_Laufzeit.Location = New System.Drawing.Point(477, 146)
        Me.TextBox_Laufzeit.Name = "TextBox_Laufzeit"
        Me.TextBox_Laufzeit.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.HelpProvider.SetShowHelp(Me.TextBox_Laufzeit, True)
        Me.TextBox_Laufzeit.Size = New System.Drawing.Size(154, 20)
        Me.TextBox_Laufzeit.TabIndex = 3
        Me.TextBox_Laufzeit.Text = "0"
        Me.TextBox_Laufzeit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_Laufzeit.WordWrap = False
        '
        'Label_Zinszahlung
        '
        Me.Label_Zinszahlung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Zinszahlung.Location = New System.Drawing.Point(3, 175)
        Me.Label_Zinszahlung.Margin = New System.Windows.Forms.Padding(3)
        Me.Label_Zinszahlung.Name = "Label_Zinszahlung"
        Me.Label_Zinszahlung.Size = New System.Drawing.Size(152, 24)
        Me.Label_Zinszahlung.TabIndex = 10
        Me.Label_Zinszahlung.Text = "Zinszahlung:"
        Me.Label_Zinszahlung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBoxZinszahlung
        '
        Me.ComboBoxZinszahlung.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBoxZinszahlung.FormattingEnabled = True
        Me.HelpProvider.SetHelpString(Me.ComboBoxZinszahlung, "Turnus der Zinszahlungen")
        Me.ComboBoxZinszahlung.Items.AddRange(New Object() {"monatlich", "vierteljährlich", "halbjährlich", "jährlich"})
        Me.ComboBoxZinszahlung.Location = New System.Drawing.Point(161, 175)
        Me.ComboBoxZinszahlung.Name = "ComboBoxZinszahlung"
        Me.HelpProvider.SetShowHelp(Me.ComboBoxZinszahlung, True)
        Me.ComboBoxZinszahlung.Size = New System.Drawing.Size(152, 21)
        Me.ComboBoxZinszahlung.TabIndex = 4
        '
        'ContextMenuStripKontoverlauf
        '
        Me.ContextMenuStripKontoverlauf.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemKopieren})
        Me.ContextMenuStripKontoverlauf.Name = "ContextMenuStripKontoverlauf"
        Me.ContextMenuStripKontoverlauf.Size = New System.Drawing.Size(121, 26)
        '
        'ToolStripMenuItemKopieren
        '
        Me.ToolStripMenuItemKopieren.Name = "ToolStripMenuItemKopieren"
        Me.ToolStripMenuItemKopieren.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItemKopieren.Text = "kopieren"
        '
        'Label_Info
        '
        Me.Label_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel.SetColumnSpan(Me.Label_Info, 4)
        Me.Label_Info.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label_Info.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Info.Image = Global.SchlumpfSoft.DailyInterestCalculator.My.Resources.Resources.Info
        Me.Label_Info.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_Info.Location = New System.Drawing.Point(3, 0)
        Me.Label_Info.Name = "Label_Info"
        Me.Label_Info.Size = New System.Drawing.Size(628, 114)
        Me.Label_Info.TabIndex = 5
        Me.Label_Info.Text = resources.GetString("Label_Info.Text")
        Me.Label_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 4
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.Controls.Add(Me.ListView_Kontoverlauf, 0, 4)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Info, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Startsaldo, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.TextBox_Anfangssaldo, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.ComboBoxZinszahlung, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Einzahlung, 2, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Zinszahlung, 0, 3)
        Me.TableLayoutPanel.Controls.Add(Me.TextBox_Einzahlung, 3, 1)
        Me.TableLayoutPanel.Controls.Add(Me.TextBox_Laufzeit, 3, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Zinssatz, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.TextBox_Zinssatz, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.Label_Laufzeit, 2, 2)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.MinimumSize = New System.Drawing.Size(600, 450)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 5
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(634, 511)
        Me.TableLayoutPanel.TabIndex = 12
        '
        'ListView_Kontoverlauf
        '
        Me.ListView_Kontoverlauf.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader_Monat, Me.ColumnHeader_Kontostand, Me.ColumnHeader_Zinsen})
        Me.TableLayoutPanel.SetColumnSpan(Me.ListView_Kontoverlauf, 4)
        Me.ListView_Kontoverlauf.ContextMenuStrip = Me.ContextMenuStripKontoverlauf
        Me.ListView_Kontoverlauf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_Kontoverlauf.FullRowSelect = True
        Me.ListView_Kontoverlauf.GridLines = True
        Me.ListView_Kontoverlauf.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView_Kontoverlauf.HideSelection = False
        Me.ListView_Kontoverlauf.LabelWrap = False
        Me.ListView_Kontoverlauf.Location = New System.Drawing.Point(5, 207)
        Me.ListView_Kontoverlauf.Margin = New System.Windows.Forms.Padding(5)
        Me.ListView_Kontoverlauf.MultiSelect = False
        Me.ListView_Kontoverlauf.Name = "ListView_Kontoverlauf"
        Me.ListView_Kontoverlauf.ShowGroups = False
        Me.ListView_Kontoverlauf.Size = New System.Drawing.Size(624, 299)
        Me.ListView_Kontoverlauf.TabIndex = 11
        Me.ListView_Kontoverlauf.TabStop = False
        Me.ListView_Kontoverlauf.UseCompatibleStateImageBehavior = False
        Me.ListView_Kontoverlauf.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader_Monat
        '
        Me.ColumnHeader_Monat.Text = "Monat"
        Me.ColumnHeader_Monat.Width = 100
        '
        'ColumnHeader_Kontostand
        '
        Me.ColumnHeader_Kontostand.Text = "Kontostand"
        Me.ColumnHeader_Kontostand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader_Kontostand.Width = 150
        '
        'ColumnHeader_Zinsen
        '
        Me.ColumnHeader_Zinsen.Text = "Zinsen"
        Me.ColumnHeader_Zinsen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader_Zinsen.Width = 100
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 511)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(650, 550)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ContextMenuStripKontoverlauf.ResumeLayout(False)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Label_Startsaldo As Label
    Private WithEvents TextBox_Anfangssaldo As TextBox
    Private WithEvents Label_Einzahlung As Label
    Private WithEvents TextBox_Einzahlung As TextBox
    Private WithEvents Label_Info As Label
    Private WithEvents Label_Zinssatz As Label
    Private WithEvents Label_Laufzeit As Label
    Private WithEvents TextBox_Zinssatz As TextBox
    Private WithEvents TextBox_Laufzeit As TextBox
    Private WithEvents Label_Zinszahlung As Label
    Private WithEvents ComboBoxZinszahlung As ComboBox
    Private WithEvents HelpProvider As HelpProvider
    Private WithEvents ContextMenuStripKontoverlauf As ContextMenuStrip
    Private WithEvents ToolStripMenuItemKopieren As ToolStripMenuItem
    Private WithEvents TableLayoutPanel As TableLayoutPanel
    Private WithEvents ListView_Kontoverlauf As ListView
    Private WithEvents ColumnHeader_Monat As ColumnHeader
    Private WithEvents ColumnHeader_Kontostand As ColumnHeader
    Private WithEvents ColumnHeader_Zinsen As ColumnHeader
End Class
