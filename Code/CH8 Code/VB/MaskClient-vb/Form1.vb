Imports CustomMask_vb

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
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents me1 As CustomMask_vb.MaskedTextBox_VB
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.me1 = New CustomMask_vb.MaskedTextBox_VB()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(120, 144)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(152, 20)
    Me.TextBox1.TabIndex = 1
    Me.TextBox1.Text = "TextBox1"
    '
    'me1
    '
    Me.me1.Format = CustomMask_vb.MaskedTextBox_VB.FormatType.None
    Me.me1.Location = New System.Drawing.Point(24, 24)
    Me.me1.Mask = "##/##/##"
    Me.me1.Name = "me1"
    Me.me1.Size = New System.Drawing.Size(192, 20)
    Me.me1.TabIndex = 0
    Me.me1.Text = "__/__/__"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(32, 72)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(168, 20)
    Me.TextBox2.TabIndex = 1
    Me.TextBox2.Text = "TextBox2"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(240, 173)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox2, Me.me1})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
    AddHandler me1.ValidationError, _
               New ValidationErrorEventHandler(AddressOf Valid)
  End Sub

  Private Sub Valid(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
    MessageBox.Show(e.Mask + "  " + e.Text)
  End Sub
End Class
