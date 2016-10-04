Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    AddHandler chkSelect.CheckedChanged, AddressOf FlipSelect



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
  Friend WithEvents chkSelect As System.Windows.Forms.CheckBox
  Friend WithEvents cmdQuit As System.Windows.Forms.Button
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents t3 As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents t2 As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents t1 As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.chkSelect = New System.Windows.Forms.CheckBox()
    Me.cmdQuit = New System.Windows.Forms.Button()
    Me.label3 = New System.Windows.Forms.Label()
    Me.t3 = New System.Windows.Forms.TextBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.t2 = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.t1 = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'chkSelect
    '
    Me.chkSelect.Location = New System.Drawing.Point(16, 16)
    Me.chkSelect.Name = "chkSelect"
    Me.chkSelect.Size = New System.Drawing.Size(144, 16)
    Me.chkSelect.TabIndex = 17
    Me.chkSelect.Text = "Select"
    '
    'cmdQuit
    '
    Me.cmdQuit.Location = New System.Drawing.Point(80, 200)
    Me.cmdQuit.Name = "cmdQuit"
    Me.cmdQuit.Size = New System.Drawing.Size(72, 32)
    Me.cmdQuit.TabIndex = 16
    Me.cmdQuit.Text = "Quit"
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(16, 144)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(136, 16)
    Me.label3.TabIndex = 15
    Me.label3.Text = "10 characters"
    '
    't3
    '
    Me.t3.Location = New System.Drawing.Point(16, 160)
    Me.t3.MaxLength = 10
    Me.t3.Name = "t3"
    Me.t3.Size = New System.Drawing.Size(136, 20)
    Me.t3.TabIndex = 14
    Me.t3.Text = "1-10"
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(16, 96)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(136, 16)
    Me.label2.TabIndex = 13
    Me.label2.Text = "10 characters"
    '
    't2
    '
    Me.t2.Location = New System.Drawing.Point(16, 112)
    Me.t2.MaxLength = 10
    Me.t2.Name = "t2"
    Me.t2.Size = New System.Drawing.Size(136, 20)
    Me.t2.TabIndex = 12
    Me.t2.Text = "1-10"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(16, 48)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(136, 16)
    Me.label1.TabIndex = 11
    Me.label1.Text = "Unlimited Text"
    '
    't1
    '
    Me.t1.Location = New System.Drawing.Point(16, 64)
    Me.t1.Name = "t1"
    Me.t1.Size = New System.Drawing.Size(136, 20)
    Me.t1.TabIndex = 10
    Me.t1.Text = "The quick brown fox jumped over the lazy dog"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(168, 245)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkSelect, Me.cmdQuit, Me.label3, Me.t3, Me.label2, Me.t2, Me.label1, Me.t1})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

#Region "events"

  Private Sub FlipSelect(ByVal sender As Object, ByVal e As EventArgs)
    If chkSelect.Checked Then
      AddHandler t1.GotFocus, AddressOf Me.SelectMe
      AddHandler t2.GotFocus, AddressOf Me.SelectMe
      AddHandler t3.GotFocus, AddressOf Me.SelectMe
    Else
      RemoveHandler t1.GotFocus, AddressOf Me.SelectMe
      RemoveHandler t2.GotFocus, AddressOf Me.SelectMe
      RemoveHandler t3.GotFocus, AddressOf Me.SelectMe
    End If

  End Sub

  Private Sub SelectMe(ByVal sender As Object, ByVal e As EventArgs)
    t1.Select(0, t1.TextLength)
    t2.Select(0, t2.TextLength)
    t3.Select(0, t3.TextLength)
  End Sub

#End Region

  Private Sub cmdQuit_Click(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles cmdQuit.Click
    Me.Close()
  End Sub
End Class
