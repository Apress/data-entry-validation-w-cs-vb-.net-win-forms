Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.MenuItem2 = New System.Windows.Forms.MenuItem()
    Me.MenuItem3 = New System.Windows.Forms.MenuItem()
    Me.MenuItem4 = New System.Windows.Forms.MenuItem()
    Me.MenuItem5 = New System.Windows.Forms.MenuItem()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.TabPage3 = New System.Windows.Forms.TabPage()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.TabPage4 = New System.Windows.Forms.TabPage()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TextBox6 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TextBox7 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TextBox8 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TextBox9 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    Me.TabPage3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5})
    Me.MenuItem1.Text = "File"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 0
    Me.MenuItem2.Text = "Exit"
    '
    'MenuItem3
    '
    Me.MenuItem3.Index = 1
    Me.MenuItem3.Text = "Load"
    '
    'MenuItem4
    '
    Me.MenuItem4.Index = 2
    Me.MenuItem4.Text = "Help"
    '
    'MenuItem5
    '
    Me.MenuItem5.Index = 3
    Me.MenuItem5.Text = "Save"
    '
    'TabControl1
    '
    Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3, Me.TabPage4})
    Me.TabControl1.Location = New System.Drawing.Point(16, 16)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(464, 208)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox5, Me.Label5, Me.TextBox4, Me.Label4, Me.TextBox3, Me.Label3, Me.TextBox2, Me.Label2, Me.TextBox1, Me.Label1})
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Size = New System.Drawing.Size(456, 182)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "Basic"
    '
    'TabPage2
    '
    Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.TextBox6, Me.Label6})
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Size = New System.Drawing.Size(456, 182)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "Advanced"
    '
    'TabPage3
    '
    Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox9, Me.Label9})
    Me.TabPage3.Location = New System.Drawing.Point(4, 22)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Size = New System.Drawing.Size(456, 182)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.Text = "Other"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(152, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Employee Name"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(16, 32)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(152, 20)
    Me.TextBox1.TabIndex = 1
    Me.TextBox1.Text = "Smith, John"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(208, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(88, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "DOB"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(208, 32)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(88, 20)
    Me.TextBox2.TabIndex = 3
    Me.TextBox2.Text = "6/8/61"
    '
    'TabPage4
    '
    Me.TabPage4.Location = New System.Drawing.Point(4, 22)
    Me.TabPage4.Name = "TabPage4"
    Me.TabPage4.Size = New System.Drawing.Size(456, 182)
    Me.TabPage4.TabIndex = 3
    Me.TabPage4.Text = "Misc"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(328, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 16)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Age"
    '
    'TextBox3
    '
    Me.TextBox3.Location = New System.Drawing.Point(328, 32)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(56, 20)
    Me.TextBox3.TabIndex = 5
    Me.TextBox3.Text = "41"
    '
    'TextBox4
    '
    Me.TextBox4.Location = New System.Drawing.Point(16, 96)
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Size = New System.Drawing.Size(152, 20)
    Me.TextBox4.TabIndex = 7
    Me.TextBox4.Text = "Marketing"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(16, 80)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(152, 16)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "Department"
    '
    'TextBox5
    '
    Me.TextBox5.Location = New System.Drawing.Point(208, 96)
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(152, 20)
    Me.TextBox5.TabIndex = 9
    Me.TextBox5.Text = "Chief Kahoona"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(208, 80)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(152, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Title"
    '
    'TextBox6
    '
    Me.TextBox6.Location = New System.Drawing.Point(24, 40)
    Me.TextBox6.Name = "TextBox6"
    Me.TextBox6.Size = New System.Drawing.Size(64, 20)
    Me.TextBox6.TabIndex = 9
    Me.TextBox6.Text = "2/4/89"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(24, 24)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(64, 16)
    Me.Label6.TabIndex = 8
    Me.Label6.Text = "Start Date"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox8, Me.Label8, Me.TextBox7, Me.Label7})
    Me.GroupBox1.Location = New System.Drawing.Point(144, 32)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(192, 136)
    Me.GroupBox1.TabIndex = 10
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Vehicle"
    '
    'TextBox7
    '
    Me.TextBox7.Location = New System.Drawing.Point(16, 40)
    Me.TextBox7.Name = "TextBox7"
    Me.TextBox7.Size = New System.Drawing.Size(152, 20)
    Me.TextBox7.TabIndex = 9
    Me.TextBox7.Text = "dodge viper"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(16, 24)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(152, 16)
    Me.Label7.TabIndex = 8
    Me.Label7.Text = "Car Make/Model"
    '
    'TextBox8
    '
    Me.TextBox8.Location = New System.Drawing.Point(16, 96)
    Me.TextBox8.Name = "TextBox8"
    Me.TextBox8.Size = New System.Drawing.Size(152, 20)
    Me.TextBox8.TabIndex = 11
    Me.TextBox8.Text = "IMAGOD"
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(16, 80)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(152, 16)
    Me.Label8.TabIndex = 10
    Me.Label8.Text = "License #"
    '
    'TextBox9
    '
    Me.TextBox9.Location = New System.Drawing.Point(16, 40)
    Me.TextBox9.Name = "TextBox9"
    Me.TextBox9.Size = New System.Drawing.Size(152, 20)
    Me.TextBox9.TabIndex = 9
    Me.TextBox9.Text = "Employee of Month"
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(16, 24)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(152, 16)
    Me.Label9.TabIndex = 8
    Me.Label9.Text = "Parking Space"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(504, 257)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Employee Record"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage3.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

  End Sub

  Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

  End Sub
End Class
