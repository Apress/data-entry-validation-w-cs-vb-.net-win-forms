Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
    InitializeComponent()


    AddHandler cmdQuit.Click, AddressOf Me.CloseMe

    'This is the tab for the red wines
    txtCab.CausesValidation = True
    AddHandler txtCab.Validating, AddressOf Me.ValidateRed
    AddHandler txtCab.KeyPress, AddressOf Me.InputValidator

    txtMerlot.CausesValidation = True
    AddHandler txtMerlot.Validating, AddressOf Me.ValidateRed
    AddHandler txtMerlot.KeyPress, AddressOf Me.InputValidator

    txtShiraz.CausesValidation = True
    AddHandler txtShiraz.Validating, AddressOf Me.ValidateRed
    AddHandler txtShiraz.KeyPress, AddressOf Me.InputValidator

    txtCab.Text = "0"
    txtMerlot.Text = "0"
    txtShiraz.Text = "0"

    'This is the tab for the white wines
    txtChardonay.CausesValidation = True
    AddHandler txtChardonay.Validating, AddressOf Me.ValidateWhite
    AddHandler txtChardonay.KeyPress, AddressOf Me.InputValidator

    txtPino.CausesValidation = True
    AddHandler txtPino.Validating, AddressOf Me.ValidateWhite
    AddHandler txtPino.KeyPress, AddressOf Me.InputValidator

    txtChablis.CausesValidation = True
    AddHandler txtChablis.Validating, AddressOf Me.ValidateWhite
    AddHandler txtChablis.KeyPress, AddressOf Me.InputValidator

    txtChardonay.Text = "0"
    txtPino.Text = "0"
    txtChablis.Text = "0"

    'Do the data binding summaries
    txtTotRed.DataBindings.Add("Text", txtRed, "Text")
    txtTotWhite.DataBindings.Add("Text", txtWhite, "Text")

    'Call the delegate to start totals
    ValidateRed(New Object(), New System.ComponentModel.CancelEventArgs())
    ValidateWhite(New Object(), New System.ComponentModel.CancelEventArgs())

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
  Friend WithEvents cmdQuit As System.Windows.Forms.Button
  Friend WithEvents txtTotWhite As System.Windows.Forms.TextBox
  Friend WithEvents label10 As System.Windows.Forms.Label
  Friend WithEvents txtTotRed As System.Windows.Forms.TextBox
  Friend WithEvents label9 As System.Windows.Forms.Label
  Friend WithEvents tc As System.Windows.Forms.TabControl
  Friend WithEvents t1 As System.Windows.Forms.TabPage
  Friend WithEvents txtRed As System.Windows.Forms.TextBox
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents txtShiraz As System.Windows.Forms.TextBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents txtMerlot As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents txtCab As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents t2 As System.Windows.Forms.TabPage
  Friend WithEvents txtWhite As System.Windows.Forms.TextBox
  Friend WithEvents label8 As System.Windows.Forms.Label
  Friend WithEvents txtChablis As System.Windows.Forms.TextBox
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents txtPino As System.Windows.Forms.TextBox
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents txtChardonay As System.Windows.Forms.TextBox
  Friend WithEvents label6 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdQuit = New System.Windows.Forms.Button()
    Me.txtTotWhite = New System.Windows.Forms.TextBox()
    Me.label10 = New System.Windows.Forms.Label()
    Me.txtTotRed = New System.Windows.Forms.TextBox()
    Me.label9 = New System.Windows.Forms.Label()
    Me.tc = New System.Windows.Forms.TabControl()
    Me.t1 = New System.Windows.Forms.TabPage()
    Me.txtRed = New System.Windows.Forms.TextBox()
    Me.label7 = New System.Windows.Forms.Label()
    Me.txtShiraz = New System.Windows.Forms.TextBox()
    Me.label3 = New System.Windows.Forms.Label()
    Me.txtMerlot = New System.Windows.Forms.TextBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.txtCab = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.t2 = New System.Windows.Forms.TabPage()
    Me.txtWhite = New System.Windows.Forms.TextBox()
    Me.label8 = New System.Windows.Forms.Label()
    Me.txtChablis = New System.Windows.Forms.TextBox()
    Me.label4 = New System.Windows.Forms.Label()
    Me.txtPino = New System.Windows.Forms.TextBox()
    Me.label5 = New System.Windows.Forms.Label()
    Me.txtChardonay = New System.Windows.Forms.TextBox()
    Me.label6 = New System.Windows.Forms.Label()
    Me.tc.SuspendLayout()
    Me.t1.SuspendLayout()
    Me.t2.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmdQuit
    '
    Me.cmdQuit.Location = New System.Drawing.Point(268, 207)
    Me.cmdQuit.Name = "cmdQuit"
    Me.cmdQuit.Size = New System.Drawing.Size(64, 32)
    Me.cmdQuit.TabIndex = 22
    Me.cmdQuit.Text = "Quit"
    '
    'txtTotWhite
    '
    Me.txtTotWhite.Location = New System.Drawing.Point(268, 127)
    Me.txtTotWhite.Name = "txtTotWhite"
    Me.txtTotWhite.Size = New System.Drawing.Size(64, 20)
    Me.txtTotWhite.TabIndex = 21
    Me.txtTotWhite.Text = ""
    '
    'label10
    '
    Me.label10.Location = New System.Drawing.Point(268, 111)
    Me.label10.Name = "label10"
    Me.label10.Size = New System.Drawing.Size(88, 16)
    Me.label10.TabIndex = 20
    Me.label10.Text = "Total white"
    '
    'txtTotRed
    '
    Me.txtTotRed.Location = New System.Drawing.Point(268, 63)
    Me.txtTotRed.Name = "txtTotRed"
    Me.txtTotRed.Size = New System.Drawing.Size(64, 20)
    Me.txtTotRed.TabIndex = 19
    Me.txtTotRed.Text = ""
    '
    'label9
    '
    Me.label9.Location = New System.Drawing.Point(268, 47)
    Me.label9.Name = "label9"
    Me.label9.Size = New System.Drawing.Size(88, 16)
    Me.label9.TabIndex = 18
    Me.label9.Text = "Total Red"
    '
    'tc
    '
    Me.tc.Controls.AddRange(New System.Windows.Forms.Control() {Me.t1, Me.t2})
    Me.tc.Location = New System.Drawing.Point(12, 23)
    Me.tc.Name = "tc"
    Me.tc.SelectedIndex = 0
    Me.tc.Size = New System.Drawing.Size(232, 224)
    Me.tc.TabIndex = 17
    '
    't1
    '
    Me.t1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtRed, Me.label7, Me.txtShiraz, Me.label3, Me.txtMerlot, Me.label2, Me.txtCab, Me.label1})
    Me.t1.Location = New System.Drawing.Point(4, 22)
    Me.t1.Name = "t1"
    Me.t1.Size = New System.Drawing.Size(224, 198)
    Me.t1.TabIndex = 0
    Me.t1.Text = "Red Wine"
    '
    'txtRed
    '
    Me.txtRed.Location = New System.Drawing.Point(128, 152)
    Me.txtRed.Name = "txtRed"
    Me.txtRed.Size = New System.Drawing.Size(64, 20)
    Me.txtRed.TabIndex = 7
    Me.txtRed.Text = ""
    '
    'label7
    '
    Me.label7.Location = New System.Drawing.Point(128, 136)
    Me.label7.Name = "label7"
    Me.label7.Size = New System.Drawing.Size(88, 16)
    Me.label7.TabIndex = 6
    Me.label7.Text = "Total Red"
    '
    'txtShiraz
    '
    Me.txtShiraz.Location = New System.Drawing.Point(24, 152)
    Me.txtShiraz.Name = "txtShiraz"
    Me.txtShiraz.Size = New System.Drawing.Size(64, 20)
    Me.txtShiraz.TabIndex = 5
    Me.txtShiraz.Text = ""
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(24, 136)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(88, 16)
    Me.label3.TabIndex = 4
    Me.label3.Text = "Shiraz count"
    '
    'txtMerlot
    '
    Me.txtMerlot.Location = New System.Drawing.Point(24, 96)
    Me.txtMerlot.Name = "txtMerlot"
    Me.txtMerlot.Size = New System.Drawing.Size(64, 20)
    Me.txtMerlot.TabIndex = 3
    Me.txtMerlot.Text = ""
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(24, 80)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(88, 16)
    Me.label2.TabIndex = 2
    Me.label2.Text = "Merlot count"
    '
    'txtCab
    '
    Me.txtCab.Location = New System.Drawing.Point(24, 40)
    Me.txtCab.Name = "txtCab"
    Me.txtCab.Size = New System.Drawing.Size(64, 20)
    Me.txtCab.TabIndex = 1
    Me.txtCab.Text = ""
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(24, 24)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(88, 16)
    Me.label1.TabIndex = 0
    Me.label1.Text = "Cabernet count"
    '
    't2
    '
    Me.t2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWhite, Me.label8, Me.txtChablis, Me.label4, Me.txtPino, Me.label5, Me.txtChardonay, Me.label6})
    Me.t2.Location = New System.Drawing.Point(4, 22)
    Me.t2.Name = "t2"
    Me.t2.Size = New System.Drawing.Size(224, 198)
    Me.t2.TabIndex = 1
    Me.t2.Text = "White wine"
    Me.t2.Visible = False
    '
    'txtWhite
    '
    Me.txtWhite.Location = New System.Drawing.Point(128, 152)
    Me.txtWhite.Name = "txtWhite"
    Me.txtWhite.Size = New System.Drawing.Size(64, 20)
    Me.txtWhite.TabIndex = 13
    Me.txtWhite.Text = ""
    '
    'label8
    '
    Me.label8.Location = New System.Drawing.Point(128, 136)
    Me.label8.Name = "label8"
    Me.label8.Size = New System.Drawing.Size(88, 16)
    Me.label8.TabIndex = 12
    Me.label8.Text = "Total white"
    '
    'txtChablis
    '
    Me.txtChablis.Location = New System.Drawing.Point(24, 152)
    Me.txtChablis.Name = "txtChablis"
    Me.txtChablis.Size = New System.Drawing.Size(64, 20)
    Me.txtChablis.TabIndex = 11
    Me.txtChablis.Text = ""
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(24, 136)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(88, 16)
    Me.label4.TabIndex = 10
    Me.label4.Text = "Chablis count"
    '
    'txtPino
    '
    Me.txtPino.Location = New System.Drawing.Point(24, 96)
    Me.txtPino.Name = "txtPino"
    Me.txtPino.Size = New System.Drawing.Size(64, 20)
    Me.txtPino.TabIndex = 9
    Me.txtPino.Text = ""
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(24, 80)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(104, 16)
    Me.label5.TabIndex = 8
    Me.label5.Text = "Pinot Grigio count"
    '
    'txtChardonay
    '
    Me.txtChardonay.Location = New System.Drawing.Point(24, 40)
    Me.txtChardonay.Name = "txtChardonay"
    Me.txtChardonay.Size = New System.Drawing.Size(64, 20)
    Me.txtChardonay.TabIndex = 7
    Me.txtChardonay.Text = ""
    '
    'label6
    '
    Me.label6.Location = New System.Drawing.Point(24, 24)
    Me.label6.Name = "label6"
    Me.label6.Size = New System.Drawing.Size(104, 16)
    Me.label6.TabIndex = 6
    Me.label6.Text = "Chardonay count"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(368, 270)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdQuit, Me.txtTotWhite, Me.label10, Me.txtTotRed, Me.label9, Me.tc})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Property Binding"
    Me.tc.ResumeLayout(False)
    Me.t1.ResumeLayout(False)
    Me.t2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

#Region "events"

  Private Sub CloseMe(ByVal sender As Object, ByVal e As EventArgs)
    Me.Close()
  End Sub

  Private Sub ValidateRed(ByVal sender As Object, _
                          ByVal e As System.ComponentModel.CancelEventArgs)
    Dim reds As Int32 = 0
    Dim t As TextBox
    Dim msg As String

    'Remeber we call this once with a generic object
    If (sender.GetType() Is GetType(TextBox)) Then
      t = CType(sender, TextBox)
      msg = t.Name + " Needs a number."
    Else
      msg = "Wine count cannot be blank"
    End If

    If (txtCab.Text = "" Or _
       txtMerlot.Text = "" Or _
       txtShiraz.Text = "") Then
      MessageBox.Show(msg)
      e.Cancel = True
      Return
    End If

    reds = Convert.ToInt32(txtCab.Text)
    reds += Convert.ToInt32(txtMerlot.Text)
    reds += Convert.ToInt32(txtShiraz.Text)

    txtRed.Text = reds.ToString()
  End Sub

  Private Sub ValidateWhite(ByVal sender As Object, _
                            ByVal e As System.ComponentModel.CancelEventArgs)
    Dim whites As Int32 = 0

    If (txtChardonay.Text = "" Or _
       txtPino.Text = "" Or _
       txtChablis.Text = "") Then

      e.Cancel = True
      Return
    End If

    whites = Convert.ToInt32(txtChardonay.Text)
    whites += Convert.ToInt32(txtPino.Text)
    whites += Convert.ToInt32(txtChablis.Text)

    txtWhite.Text = whites.ToString()
  End Sub

  Private Sub InputValidator(ByVal sender As Object, ByVal e As KeyPressEventArgs)
    If (Not Char.IsNumber(e.KeyChar) And e.KeyChar <> "8"c) Then
      e.Handled = True
    End If
  End Sub

#End Region

End Class
