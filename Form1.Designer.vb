<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StudentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComputersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SitesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JointTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllInfoviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Location = New System.Drawing.Point(12, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(799, 443)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(486, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "THIS IS PLACE WHERE THE COMPUTERS ARE TO BE REGISTERED TO ALL THE GATE SITES"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentsToolStripMenuItem, Me.ComputersToolStripMenuItem, Me.SitesToolStripMenuItem, Me.JointTableToolStripMenuItem, Me.AllInfoviewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(799, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'StudentsToolStripMenuItem
        '
        Me.StudentsToolStripMenuItem.Name = "StudentsToolStripMenuItem"
        Me.StudentsToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.StudentsToolStripMenuItem.Text = "Students"
        '
        'ComputersToolStripMenuItem
        '
        Me.ComputersToolStripMenuItem.Name = "ComputersToolStripMenuItem"
        Me.ComputersToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.ComputersToolStripMenuItem.Text = "Computers"
        '
        'SitesToolStripMenuItem
        '
        Me.SitesToolStripMenuItem.Name = "SitesToolStripMenuItem"
        Me.SitesToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SitesToolStripMenuItem.Text = "Sites"
        '
        'JointTableToolStripMenuItem
        '
        Me.JointTableToolStripMenuItem.Name = "JointTableToolStripMenuItem"
        Me.JointTableToolStripMenuItem.Size = New System.Drawing.Size(119, 20)
        Me.JointTableToolStripMenuItem.Text = "Student_Computer"
        '
        'AllInfoviewToolStripMenuItem
        '
        Me.AllInfoviewToolStripMenuItem.Name = "AllInfoviewToolStripMenuItem"
        Me.AllInfoviewToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.AllInfoviewToolStripMenuItem.Text = "Site_Computers"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 434)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents StudentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComputersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SitesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JointTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllInfoviewToolStripMenuItem As ToolStripMenuItem
End Class
