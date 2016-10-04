Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    cmbMaxLen.TabIndex = 0
    txtUpper.TabIndex = 1
    txtPassword.TabIndex = 2
    txtMultiLine.TabStop = False
    txtCentered.TabIndex = 3
    cmdClose.TabIndex = 4

    cmbMaxLen.Items.Clear()
    cmbMaxLen.Items.Add("5")
    cmbMaxLen.Items.Add("10")
    cmbMaxLen.Items.Add("15")
    cmbMaxLen.Items.Add("20")
    AddHandler cmbMaxLen.SelectedIndexChanged, AddressOf Me.ChangeLen
    cmbMaxLen.SelectedIndex = 0

    txtUpper.CharacterCasing = CharacterCasing.Upper
    txtPassword.PasswordChar = "*"c
    txtCentered.TextAlign = HorizontalAlignment.Center
    txtMultiLine.Multiline = True
    txtMultiLine.ScrollBars = ScrollBars.Vertical
    txtMultiLine.WordWrap = True
    txtMultiLine.AcceptsReturn = True
    txtMultiLine.AcceptsTab = True

    Me.AcceptButton = cmdClose
    AddHandler cmdClose.Click, AddressOf Me.CloseMe

    'Event based input resricted controls
    txtAlpha.CharacterCasing = CharacterCasing.Lower
    txtMixed.CharacterCasing = CharacterCasing.Upper
    AddHandler txtAlpha.KeyPress, AddressOf Me.InputValidator
    AddHandler txtNumber.KeyPress, AddressOf Me.InputValidator
    AddHandler txtMixed.KeyPress, AddressOf Me.InputValidator

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
  Friend WithEvents label8 As System.Windows.Forms.Label
  Friend WithEvents txtMultiLine As System.Windows.Forms.TextBox
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents txtCentered As System.Windows.Forms.TextBox
  Friend WithEvents label6 As System.Windows.Forms.Label
  Friend WithEvents txtPassword As System.Windows.Forms.TextBox
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents txtUpper As System.Windows.Forms.TextBox
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents cmbMaxLen As System.Windows.Forms.ComboBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents txtMixed As System.Windows.Forms.TextBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents txtNumber As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents txtAlpha As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.label8 = New System.Windows.Forms.Label()
    Me.txtMultiLine = New System.Windows.Forms.TextBox()
    Me.label7 = New System.Windows.Forms.Label()
    Me.txtCentered = New System.Windows.Forms.TextBox()
    Me.label6 = New System.Windows.Forms.Label()
    Me.txtPassword = New System.Windows.Forms.TextBox()
    Me.label5 = New System.Windows.Forms.Label()
    Me.txtUpper = New System.Windows.Forms.TextBox()
    Me.cmdClose = New System.Windows.Forms.Button()
    Me.cmbMaxLen = New System.Windows.Forms.ComboBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.label4 = New System.Windows.Forms.Label()
    Me.txtMixed = New System.Windows.Forms.TextBox()
    Me.label3 = New System.Windows.Forms.Label()
    Me.txtNumber = New System.Windows.Forms.TextBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.txtAlpha = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'label8
    '
    Me.label8.Location = New System.Drawing.Point(32, 135)
    Me.label8.Name = "label8"
    Me.label8.Size = New System.Drawing.Size(120, 16)
    Me.label8.TabIndex = 27
    Me.label8.Text = "Multi Line"
    '
    'txtMultiLine
    '
    Me.txtMultiLine.Location = New System.Drawing.Point(32, 151)
    Me.txtMultiLine.Multiline = True
    Me.txtMultiLine.Name = "txtMultiLine"
    Me.txtMultiLine.Size = New System.Drawing.Size(120, 112)
    Me.txtMultiLine.TabIndex = 26
    Me.txtMultiLine.Text = ""
    '
    'label7
    '
    Me.label7.Location = New System.Drawing.Point(168, 135)
    Me.label7.Name = "label7"
    Me.label7.Size = New System.Drawing.Size(120, 16)
    Me.label7.TabIndex = 25
    Me.label7.Text = "Centered"
    '
    'txtCentered
    '
    Me.txtCentered.Location = New System.Drawing.Point(168, 151)
    Me.txtCentered.Name = "txtCentered"
    Me.txtCentered.Size = New System.Drawing.Size(120, 20)
    Me.txtCentered.TabIndex = 24
    Me.txtCentered.Text = ""
    '
    'label6
    '
    Me.label6.Location = New System.Drawing.Point(168, 79)
    Me.label6.Name = "label6"
    Me.label6.Size = New System.Drawing.Size(120, 16)
    Me.label6.TabIndex = 23
    Me.label6.Text = "Password"
    '
    'txtPassword
    '
    Me.txtPassword.Location = New System.Drawing.Point(168, 95)
    Me.txtPassword.Name = "txtPassword"
    Me.txtPassword.Size = New System.Drawing.Size(120, 20)
    Me.txtPassword.TabIndex = 22
    Me.txtPassword.Text = ""
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(32, 79)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(120, 16)
    Me.label5.TabIndex = 21
    Me.label5.Text = "Upper Case"
    '
    'txtUpper
    '
    Me.txtUpper.Location = New System.Drawing.Point(32, 95)
    Me.txtUpper.Name = "txtUpper"
    Me.txtUpper.Size = New System.Drawing.Size(120, 20)
    Me.txtUpper.TabIndex = 20
    Me.txtUpper.Text = ""
    '
    'cmdClose
    '
    Me.cmdClose.Location = New System.Drawing.Point(224, 344)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(64, 32)
    Me.cmdClose.TabIndex = 19
    Me.cmdClose.Text = "Close"
    '
    'cmbMaxLen
    '
    Me.cmbMaxLen.Location = New System.Drawing.Point(32, 39)
    Me.cmbMaxLen.Name = "cmbMaxLen"
    Me.cmbMaxLen.Size = New System.Drawing.Size(56, 21)
    Me.cmbMaxLen.TabIndex = 18
    Me.cmbMaxLen.Text = "comboBox1"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(32, 23)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(96, 16)
    Me.label1.TabIndex = 17
    Me.label1.Text = "Max Text Length"
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(32, 336)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(120, 16)
    Me.label4.TabIndex = 33
    Me.label4.Text = "Mixed"
    '
    'txtMixed
    '
    Me.txtMixed.Location = New System.Drawing.Point(32, 352)
    Me.txtMixed.Name = "txtMixed"
    Me.txtMixed.Size = New System.Drawing.Size(120, 20)
    Me.txtMixed.TabIndex = 32
    Me.txtMixed.Text = ""
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(176, 280)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(120, 16)
    Me.label3.TabIndex = 31
    Me.label3.Text = "Number"
    '
    'txtNumber
    '
    Me.txtNumber.Location = New System.Drawing.Point(176, 296)
    Me.txtNumber.Name = "txtNumber"
    Me.txtNumber.Size = New System.Drawing.Size(120, 20)
    Me.txtNumber.TabIndex = 30
    Me.txtNumber.Text = ""
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(32, 280)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(120, 16)
    Me.label2.TabIndex = 29
    Me.label2.Text = "Alpha"
    '
    'txtAlpha
    '
    Me.txtAlpha.Location = New System.Drawing.Point(32, 296)
    Me.txtAlpha.Name = "txtAlpha"
    Me.txtAlpha.Size = New System.Drawing.Size(120, 20)
    Me.txtAlpha.TabIndex = 28
    Me.txtAlpha.Text = ""
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(320, 390)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label4, Me.txtMixed, Me.label3, Me.txtNumber, Me.label2, Me.txtAlpha, Me.label8, Me.txtMultiLine, Me.label7, Me.txtCentered, Me.label6, Me.txtPassword, Me.label5, Me.txtUpper, Me.cmdClose, Me.cmbMaxLen, Me.label1})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

#Region "control events"

  Private Sub ChangeLen(ByVal sender As Object, ByVal e As EventArgs)
    txtUpper.MaxLength = Convert.ToInt32(cmbMaxLen.Text)
    txtPassword.MaxLength = txtUpper.MaxLength
    txtCentered.MaxLength = txtUpper.MaxLength
    txtMixed.MaxLength = txtUpper.MaxLength
    txtNumber.MaxLength = txtUpper.MaxLength
    txtAlpha.MaxLength = txtUpper.MaxLength
  End Sub

  Private Sub CloseMe(ByVal sender As Object, ByVal e As EventArgs)
    Me.Close()
  End Sub

  Private Sub InputValidator(ByVal sender As Object, _
                             ByVal e As KeyPressEventArgs)
    Dim t As TextBox
    If sender.GetType() Is GetType(TextBox) Then
      t = CType(sender, TextBox)
      If t.Name = txtAlpha.Name Then
        'If it is not a letter then disallow the character
        If (Not Char.IsLetter(e.KeyChar) And _
                e.KeyChar <> Microsoft.VisualBasic.ChrW(8)) Then
          e.Handled = True
        End If
      End If
      If t.Name = txtNumber.Name Then
        'If it is not a letter then disallow the character
        If (Not Char.IsNumber(e.KeyChar) And _
                e.KeyChar <> Microsoft.VisualBasic.ChrW(8)) Then
          e.Handled = True
        End If
      End If
      If t.Name = txtMixed.Name Then
        'Allow only 0-9,A-F,<>?=
        If (Char.IsNumber(e.KeyChar)) Then
          e.Handled = False
        ElseIf (Char.ToUpper(e.KeyChar) >= "A"c And _
                Char.ToUpper(e.KeyChar) <= "F"c) Then
          e.Handled = False
        ElseIf (e.KeyChar = "<"c Or e.KeyChar = ">"c Or _
                e.KeyChar = "?" Or e.KeyChar = "="c) Then
          e.Handled = False
        Else
          e.Handled = True
        End If
      End If
    End If
  End Sub


#End Region


End Class
