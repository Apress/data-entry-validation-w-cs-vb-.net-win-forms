
'/// For example purposes this is the list of possibilities.
'/// 9600,7,o,1
'/// 9600,7,e,2
'/// 9600,8,n,1
'/// 4800,6,m,1
'/// 4800,7,s,1
'/// 4800,7,s,2
'/// 2400,5,o,1
'/// 2400,5,e,1
'/// 2400,5,e,1.5
'/// 2400,6,o,1
'/// Any type of flow control

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    Me.StartPosition = FormStartPosition.CenterScreen

    'Handle the click events for each combo box
    AddHandler cmbSpeed.SelectedIndexChanged, AddressOf Speed
    AddHandler cmbLen.SelectedIndexChanged, AddressOf DataLen
    AddHandler cmbParity.SelectedIndexChanged, AddressOf Parity
    AddHandler cmdClose.Click, AddressOf CloseMe

    cmbSpeed.DropDownStyle = ComboBoxStyle.DropDownList
    cmbSpeed.Items.Add("9,600")
    cmbSpeed.Items.Add("4,800")
    cmbSpeed.Items.Add("2,400")
    cmbSpeed.SelectedIndex = 0

    cmbFlow.DropDownStyle = ComboBoxStyle.DropDownList
    cmbFlow.Items.Add("NONE")
    cmbFlow.Items.Add("XON/XOFF")
    cmbFlow.Items.Add("HARDWARE")
    cmbFlow.SelectedIndex = 0


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
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents cmbFlow As System.Windows.Forms.ComboBox
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents cmbStop As System.Windows.Forms.ComboBox
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents cmbParity As System.Windows.Forms.ComboBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents cmbLen As System.Windows.Forms.ComboBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents cmbSpeed As System.Windows.Forms.ComboBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdClose = New System.Windows.Forms.Button()
    Me.cmbFlow = New System.Windows.Forms.ComboBox()
    Me.label5 = New System.Windows.Forms.Label()
    Me.cmbStop = New System.Windows.Forms.ComboBox()
    Me.label4 = New System.Windows.Forms.Label()
    Me.cmbParity = New System.Windows.Forms.ComboBox()
    Me.label3 = New System.Windows.Forms.Label()
    Me.cmbLen = New System.Windows.Forms.ComboBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.cmbSpeed = New System.Windows.Forms.ComboBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'cmdClose
    '
    Me.cmdClose.Location = New System.Drawing.Point(104, 312)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(64, 24)
    Me.cmdClose.TabIndex = 21
    Me.cmdClose.Text = "Close"
    '
    'cmbFlow
    '
    Me.cmbFlow.Location = New System.Drawing.Point(24, 256)
    Me.cmbFlow.Name = "cmbFlow"
    Me.cmbFlow.Size = New System.Drawing.Size(144, 21)
    Me.cmbFlow.TabIndex = 20
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(24, 240)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(144, 16)
    Me.label5.TabIndex = 19
    Me.label5.Text = "Flow Control"
    '
    'cmbStop
    '
    Me.cmbStop.Location = New System.Drawing.Point(24, 200)
    Me.cmbStop.Name = "cmbStop"
    Me.cmbStop.Size = New System.Drawing.Size(144, 21)
    Me.cmbStop.TabIndex = 18
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(24, 184)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(144, 16)
    Me.label4.TabIndex = 17
    Me.label4.Text = "Stop Bits"
    '
    'cmbParity
    '
    Me.cmbParity.Location = New System.Drawing.Point(24, 144)
    Me.cmbParity.Name = "cmbParity"
    Me.cmbParity.Size = New System.Drawing.Size(144, 21)
    Me.cmbParity.TabIndex = 16
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(24, 128)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(144, 16)
    Me.label3.TabIndex = 15
    Me.label3.Text = "Parity"
    '
    'cmbLen
    '
    Me.cmbLen.Location = New System.Drawing.Point(24, 88)
    Me.cmbLen.Name = "cmbLen"
    Me.cmbLen.Size = New System.Drawing.Size(144, 21)
    Me.cmbLen.TabIndex = 14
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(24, 72)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(144, 16)
    Me.label2.TabIndex = 13
    Me.label2.Text = "Data Length"
    '
    'cmbSpeed
    '
    Me.cmbSpeed.Location = New System.Drawing.Point(24, 40)
    Me.cmbSpeed.Name = "cmbSpeed"
    Me.cmbSpeed.Size = New System.Drawing.Size(144, 21)
    Me.cmbSpeed.TabIndex = 12
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(24, 24)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(144, 16)
    Me.label1.TabIndex = 11
    Me.label1.Text = "Speed"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(192, 350)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClose, Me.cmbFlow, Me.label5, Me.cmbStop, Me.label4, Me.cmbParity, Me.label3, Me.cmbLen, Me.label2, Me.cmbSpeed, Me.label1})
    Me.Name = "Form1"
    Me.Text = "Terminal Setup"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

  Private Sub Speed(ByVal Sender As Object, ByVal e As EventArgs)

    Select Case (cmbSpeed.Text)
      Case "9,600"
        cmbLen.Items.Clear()
        cmbLen.Items.Add("7 Bits")
        cmbLen.Items.Add("8 Bits")
      Case "4,800"
        cmbLen.Items.Clear()
        cmbLen.Items.Add("6 Bits")
        cmbLen.Items.Add("7 Bits")
      Case "2,400"
        cmbLen.Items.Clear()
        cmbLen.Items.Add("5 Bits")
        cmbLen.Items.Add("6 Bits")
      Case "1,200"
        cmbLen.Items.Clear()
        cmbLen.Items.Add("8 Bits")
    End Select
    cmbLen.SelectedIndex = 0

  End Sub

  Private Sub DataLen(ByVal Sender As Object, ByVal e As EventArgs)

    Select Case (cmbLen.Text)

      Case "5 Bits"
        If cmbSpeed.Text = "2,400" Then
          cmbParity.Items.Clear()
          cmbParity.Items.Add("ODD")
          cmbParity.Items.Add("EVEN")
        End If
      Case "6 Bits"
        If cmbSpeed.Text = "4,800" Then
          cmbParity.Items.Clear()
          cmbParity.Items.Add("MARK")
        End If
        If cmbSpeed.Text = "2,400" Then
          cmbParity.Items.Clear()
          cmbParity.Items.Add("ODD")
        End If
      Case "7 Bits"
        If cmbSpeed.Text = "9,600" Then
          cmbParity.Items.Clear()
          cmbParity.Items.Add("ODD")
          cmbParity.Items.Add("EVEN")
        End If
        If cmbSpeed.Text = "4,800" Then
          cmbParity.Items.Clear()
          cmbParity.Items.Add("SPACE")
        End If
      Case "8 Bits"
        If cmbSpeed.Text = "9,600" Then
          cmbParity.Items.Clear()
          cmbParity.Items.Add("NONE")
        End If
    End Select
    cmbParity.SelectedIndex = 0

  End Sub

  Private Sub Parity(ByVal Sender As Object, ByVal e As EventArgs)

    Select Case (cmbParity.Text)
      Case "NONE"
        If cmbLen.Text = "8 Bits" Then
          cmbStop.Items.Clear()
          cmbStop.Items.Add("1")
        End If
      Case "ODD"
        If cmbLen.Text = "5 Bits" Then
          cmbStop.Items.Clear()
          cmbStop.Items.Add("1")
        End If
        If cmbLen.Text = "6 Bits" Then
          cmbStop.Items.Clear()
          cmbStop.Items.Add("1")
        End If
        If cmbLen.Text = "7 Bits" Then
          cmbStop.Items.Clear()
          cmbStop.Items.Add("1")
        End If
      Case "EVEN"
        If cmbLen.Text = "5 Bits" Then
          cmbStop.Items.Clear()
          cmbStop.Items.Add("1")
          cmbStop.Items.Add("1.5")
        End If
        If cmbLen.Text = "7 Bits" Then
          cmbStop.Items.Clear()
          cmbStop.Items.Add("2")
        End If
      Case "SPACE"
        If cmbLen.Text = "7 Bits" Then
          cmbStop.Items.Clear()
          cmbStop.Items.Add("1")
          cmbStop.Items.Add("2")
        End If
      Case "MARK"
        If cmbLen.Text = "6 Bits" Then
          cmbStop.Items.Clear()
          cmbStop.Items.Add("1")
        End If
    End Select
    cmbStop.SelectedIndex = 0

  End Sub

  Private Sub CloseMe(ByVal Sender As Object, ByVal e As EventArgs)

    Me.Close()

  End Sub
End Class
