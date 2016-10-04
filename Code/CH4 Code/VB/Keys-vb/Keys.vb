Option Strict On

Imports System.Threading

Public Class frmKeys
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
  Friend WithEvents lblPressTime As System.Windows.Forms.Label
  Friend WithEvents label9 As System.Windows.Forms.Label
  Friend WithEvents lblPress As System.Windows.Forms.Label
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents lblUpTime As System.Windows.Forms.Label
  Friend WithEvents label10 As System.Windows.Forms.Label
  Friend WithEvents lblUpMod As System.Windows.Forms.Label
  Friend WithEvents label12 As System.Windows.Forms.Label
  Friend WithEvents lblUpValue As System.Windows.Forms.Label
  Friend WithEvents label14 As System.Windows.Forms.Label
  Friend WithEvents lblUpData As System.Windows.Forms.Label
  Friend WithEvents label16 As System.Windows.Forms.Label
  Friend WithEvents lblUpCode As System.Windows.Forms.Label
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents lblDownTime As System.Windows.Forms.Label
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents lblDownMod As System.Windows.Forms.Label
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents lblDownValue As System.Windows.Forms.Label
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents lblDownData As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents lblDownCode As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lblPressTime = New System.Windows.Forms.Label()
    Me.label9 = New System.Windows.Forms.Label()
    Me.lblPress = New System.Windows.Forms.Label()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.lblUpTime = New System.Windows.Forms.Label()
    Me.label10 = New System.Windows.Forms.Label()
    Me.lblUpMod = New System.Windows.Forms.Label()
    Me.label12 = New System.Windows.Forms.Label()
    Me.lblUpValue = New System.Windows.Forms.Label()
    Me.label14 = New System.Windows.Forms.Label()
    Me.lblUpData = New System.Windows.Forms.Label()
    Me.label16 = New System.Windows.Forms.Label()
    Me.lblUpCode = New System.Windows.Forms.Label()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.lblDownTime = New System.Windows.Forms.Label()
    Me.label7 = New System.Windows.Forms.Label()
    Me.lblDownMod = New System.Windows.Forms.Label()
    Me.label5 = New System.Windows.Forms.Label()
    Me.lblDownValue = New System.Windows.Forms.Label()
    Me.label3 = New System.Windows.Forms.Label()
    Me.lblDownData = New System.Windows.Forms.Label()
    Me.label2 = New System.Windows.Forms.Label()
    Me.lblDownCode = New System.Windows.Forms.Label()
    Me.groupBox2.SuspendLayout()
    Me.groupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblPressTime
    '
    Me.lblPressTime.BackColor = System.Drawing.Color.Linen
    Me.lblPressTime.Location = New System.Drawing.Point(48, 216)
    Me.lblPressTime.Name = "lblPressTime"
    Me.lblPressTime.Size = New System.Drawing.Size(248, 16)
    Me.lblPressTime.TabIndex = 23
    Me.lblPressTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'label9
    '
    Me.label9.Location = New System.Drawing.Point(24, 192)
    Me.label9.Name = "label9"
    Me.label9.Size = New System.Drawing.Size(104, 16)
    Me.label9.TabIndex = 22
    Me.label9.Text = "Key Press"
    '
    'lblPress
    '
    Me.lblPress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblPress.Location = New System.Drawing.Point(136, 192)
    Me.lblPress.Name = "lblPress"
    Me.lblPress.Size = New System.Drawing.Size(180, 16)
    Me.lblPress.TabIndex = 21
    '
    'groupBox2
    '
    Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblUpTime, Me.label10, Me.lblUpMod, Me.label12, Me.lblUpValue, Me.label14, Me.lblUpData, Me.label16, Me.lblUpCode})
    Me.groupBox2.Location = New System.Drawing.Point(8, 256)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(336, 160)
    Me.groupBox2.TabIndex = 20
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "KeyUp event"
    '
    'lblUpTime
    '
    Me.lblUpTime.BackColor = System.Drawing.Color.Linen
    Me.lblUpTime.Location = New System.Drawing.Point(40, 136)
    Me.lblUpTime.Name = "lblUpTime"
    Me.lblUpTime.Size = New System.Drawing.Size(248, 16)
    Me.lblUpTime.TabIndex = 16
    Me.lblUpTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'label10
    '
    Me.label10.Location = New System.Drawing.Point(12, 96)
    Me.label10.Name = "label10"
    Me.label10.Size = New System.Drawing.Size(104, 16)
    Me.label10.TabIndex = 15
    Me.label10.Text = "Key Modifiers"
    '
    'lblUpMod
    '
    Me.lblUpMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblUpMod.Location = New System.Drawing.Point(124, 96)
    Me.lblUpMod.Name = "lblUpMod"
    Me.lblUpMod.Size = New System.Drawing.Size(180, 16)
    Me.lblUpMod.TabIndex = 14
    '
    'label12
    '
    Me.label12.Location = New System.Drawing.Point(12, 72)
    Me.label12.Name = "label12"
    Me.label12.Size = New System.Drawing.Size(104, 16)
    Me.label12.TabIndex = 13
    Me.label12.Text = "Key Value"
    '
    'lblUpValue
    '
    Me.lblUpValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblUpValue.Location = New System.Drawing.Point(124, 72)
    Me.lblUpValue.Name = "lblUpValue"
    Me.lblUpValue.Size = New System.Drawing.Size(180, 16)
    Me.lblUpValue.TabIndex = 12
    '
    'label14
    '
    Me.label14.Location = New System.Drawing.Point(12, 48)
    Me.label14.Name = "label14"
    Me.label14.Size = New System.Drawing.Size(104, 16)
    Me.label14.TabIndex = 11
    Me.label14.Text = "Key Data"
    '
    'lblUpData
    '
    Me.lblUpData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblUpData.Location = New System.Drawing.Point(124, 48)
    Me.lblUpData.Name = "lblUpData"
    Me.lblUpData.Size = New System.Drawing.Size(180, 16)
    Me.lblUpData.TabIndex = 10
    '
    'label16
    '
    Me.label16.Location = New System.Drawing.Point(12, 24)
    Me.label16.Name = "label16"
    Me.label16.Size = New System.Drawing.Size(104, 16)
    Me.label16.TabIndex = 9
    Me.label16.Text = "Key Code"
    '
    'lblUpCode
    '
    Me.lblUpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblUpCode.Location = New System.Drawing.Point(124, 24)
    Me.lblUpCode.Name = "lblUpCode"
    Me.lblUpCode.Size = New System.Drawing.Size(180, 16)
    Me.lblUpCode.TabIndex = 8
    '
    'groupBox1
    '
    Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDownTime, Me.label7, Me.lblDownMod, Me.label5, Me.lblDownValue, Me.label3, Me.lblDownData, Me.label2, Me.lblDownCode})
    Me.groupBox1.Location = New System.Drawing.Point(8, 16)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(336, 160)
    Me.groupBox1.TabIndex = 19
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "KeyDown event"
    '
    'lblDownTime
    '
    Me.lblDownTime.BackColor = System.Drawing.Color.Linen
    Me.lblDownTime.Location = New System.Drawing.Point(40, 136)
    Me.lblDownTime.Name = "lblDownTime"
    Me.lblDownTime.Size = New System.Drawing.Size(248, 16)
    Me.lblDownTime.TabIndex = 16
    Me.lblDownTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'label7
    '
    Me.label7.Location = New System.Drawing.Point(12, 96)
    Me.label7.Name = "label7"
    Me.label7.Size = New System.Drawing.Size(104, 16)
    Me.label7.TabIndex = 15
    Me.label7.Text = "Key Modifiers"
    '
    'lblDownMod
    '
    Me.lblDownMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblDownMod.Location = New System.Drawing.Point(124, 96)
    Me.lblDownMod.Name = "lblDownMod"
    Me.lblDownMod.Size = New System.Drawing.Size(180, 16)
    Me.lblDownMod.TabIndex = 14
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(12, 72)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(104, 16)
    Me.label5.TabIndex = 13
    Me.label5.Text = "Key Value"
    '
    'lblDownValue
    '
    Me.lblDownValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblDownValue.Location = New System.Drawing.Point(124, 72)
    Me.lblDownValue.Name = "lblDownValue"
    Me.lblDownValue.Size = New System.Drawing.Size(180, 16)
    Me.lblDownValue.TabIndex = 12
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(12, 48)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(104, 16)
    Me.label3.TabIndex = 11
    Me.label3.Text = "Key Data"
    '
    'lblDownData
    '
    Me.lblDownData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblDownData.Location = New System.Drawing.Point(124, 48)
    Me.lblDownData.Name = "lblDownData"
    Me.lblDownData.Size = New System.Drawing.Size(180, 16)
    Me.lblDownData.TabIndex = 10
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(12, 24)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(104, 16)
    Me.label2.TabIndex = 9
    Me.label2.Text = "Key Code"
    '
    'lblDownCode
    '
    Me.lblDownCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblDownCode.Location = New System.Drawing.Point(124, 24)
    Me.lblDownCode.Name = "lblDownCode"
    Me.lblDownCode.Size = New System.Drawing.Size(180, 16)
    Me.lblDownCode.TabIndex = 8
    '
    'frmKeys
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(360, 429)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPressTime, Me.label9, Me.lblPress, Me.groupBox2, Me.groupBox1})
    Me.Name = "frmKeys"
    Me.Text = "KeyPresses"
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub frmKeys_Load(ByVal sender As System.Object, _
                           ByVal e As System.EventArgs) Handles MyBase.Load

    AddHandler Me.KeyDown, AddressOf MyKeyDown
    AddHandler Me.KeyPress, AddressOf MyKeyPress
    AddHandler Me.KeyUp, AddressOf MyKeyUp

  End Sub

#Region "events"


  Private Sub MyKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
    lblDownCode.Text = e.KeyCode.ToString()
    lblDownData.Text = e.KeyData.ToString()
    lblDownValue.Text = e.KeyValue.ToString()
    lblDownMod.Text = e.Modifiers.ToString()

    lblDownTime.Text = DateTime.Now.Ticks.ToString()
    Thread.Sleep(2)

  End Sub

  Private Sub MyKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)

    lblPress.Text = e.KeyChar.ToString()
    lblPressTime.Text = DateTime.Now.Ticks.ToString()
    Thread.Sleep(2)

  End Sub

  Private Sub MyKeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
    lblUpCode.Text = e.KeyCode.ToString()
    lblUpData.Text = e.KeyData.ToString()
    lblUpValue.Text = e.KeyValue.ToString()
    lblUpMod.Text = e.Modifiers.ToString()

    lblUpTime.Text = DateTime.Now.Ticks.ToString()
    Thread.Sleep(2)

  End Sub

#End Region


End Class
