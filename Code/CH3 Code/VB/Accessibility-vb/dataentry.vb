Public Class dataentry
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
  Friend WithEvents textBox1 As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents button1 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.textBox1 = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.button1 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'textBox1
    '
    Me.textBox1.AccessibleDescription = "Name of Employee"
    Me.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text
    Me.textBox1.Location = New System.Drawing.Point(88, 75)
    Me.textBox1.Name = "textBox1"
    Me.textBox1.Size = New System.Drawing.Size(128, 20)
    Me.textBox1.TabIndex = 5
    Me.textBox1.Text = ""
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(88, 59)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(120, 16)
    Me.label1.TabIndex = 4
    Me.label1.Text = "Name"
    '
    'button1
    '
    Me.button1.AccessibleDescription = "Program Exit Button"
    Me.button1.AccessibleName = "Exit Button"
    Me.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
    Me.button1.Location = New System.Drawing.Point(144, 139)
    Me.button1.Name = "button1"
    Me.button1.Size = New System.Drawing.Size(88, 32)
    Me.button1.TabIndex = 3
    Me.button1.Text = "Exit"
    '
    'dataentry
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(320, 230)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.label1, Me.button1})
    Me.Name = "dataentry"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Data Entry"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private SpyForm As Spy

  Private Sub dataentry_Load(ByVal sender As System.Object, _
                             ByVal e As System.EventArgs) Handles MyBase.Load
    SpyForm = New Spy()
    SpyForm.Owner = Me

    SpyForm.Show()

  End Sub
End Class
