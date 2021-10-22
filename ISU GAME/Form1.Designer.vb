<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.STARTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PAUSEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuQuit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNURECORD = New System.Windows.Forms.ToolStripMenuItem()
        Me.HELPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNUSCORE = New System.Windows.Forms.ToolStripMenuItem()
        Me.PICSHOW = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PICSHOW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuStart, Me.MnuQuit, Me.MNURECORD, Me.HELPToolStripMenuItem, Me.MNUSCORE})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuStart
        '
        Me.MnuStart.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.STARTToolStripMenuItem, Me.PAUSEToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MnuStart.Name = "MnuStart"
        Me.MnuStart.Size = New System.Drawing.Size(62, 24)
        Me.MnuStart.Text = "START"
        '
        'STARTToolStripMenuItem
        '
        Me.STARTToolStripMenuItem.Name = "STARTToolStripMenuItem"
        Me.STARTToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.STARTToolStripMenuItem.Text = "START"
        '
        'PAUSEToolStripMenuItem
        '
        Me.PAUSEToolStripMenuItem.Name = "PAUSEToolStripMenuItem"
        Me.PAUSEToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.PAUSEToolStripMenuItem.Text = "PAUSE"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(216, 26)
        Me.ToolStripMenuItem1.Text = "GOO"
        '
        'MnuQuit
        '
        Me.MnuQuit.Name = "MnuQuit"
        Me.MnuQuit.Size = New System.Drawing.Size(54, 24)
        Me.MnuQuit.Text = "EXIT "
        '
        'MNURECORD
        '
        Me.MNURECORD.Name = "MNURECORD"
        Me.MNURECORD.Size = New System.Drawing.Size(78, 24)
        Me.MNURECORD.Text = "RECORD"
        '
        'HELPToolStripMenuItem
        '
        Me.HELPToolStripMenuItem.Name = "HELPToolStripMenuItem"
        Me.HELPToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.HELPToolStripMenuItem.Text = "HELP"
        '
        'MNUSCORE
        '
        Me.MNUSCORE.Name = "MNUSCORE"
        Me.MNUSCORE.Size = New System.Drawing.Size(66, 24)
        Me.MNUSCORE.Text = "SCORE"
        '
        'PICSHOW
        '
        Me.PICSHOW.Location = New System.Drawing.Point(31, 67)
        Me.PICSHOW.Name = "PICSHOW"
        Me.PICSHOW.Size = New System.Drawing.Size(460, 331)
        Me.PICSHOW.TabIndex = 1
        Me.PICSHOW.TabStop = False
        '
        'Timer1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PICSHOW)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PICSHOW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MnuStart As ToolStripMenuItem
    Friend WithEvents MnuQuit As ToolStripMenuItem
    Friend WithEvents MNURECORD As ToolStripMenuItem
    Friend WithEvents HELPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PICSHOW As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents MNUSCORE As ToolStripMenuItem
    Friend WithEvents STARTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PAUSEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
End Class
