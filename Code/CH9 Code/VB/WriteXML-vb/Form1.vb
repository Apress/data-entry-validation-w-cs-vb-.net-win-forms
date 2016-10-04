Option Strict On
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Data


Public Class Form1
  Inherits System.Windows.Forms.Form

#Region "vars"

  Private fname As String = "Output.xml"
  Enum MODE
    None
    OnLine
    OffLine
    Dumb
  End Enum

  'Added for read
  Enum CONFIG_STATE
    C_UNKNOWN
    C_DATE
    C_IP
    C_MODE
    C_PASS
    C_OFFSET
      C_RELAY
  End Enum

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    lblDate.Text = DateTime.Now.ToLongDateString()
    cmbMode.Items.Add(MODE.Dumb)
    cmbMode.Items.Add(MODE.OffLine)
    cmbMode.Items.Add(MODE.OnLine)
    cmbMode.Items.Add(MODE.None)
    cmbMode.SelectedIndex = 0

    txtIP.Text = "123.456.789.13"
    txtPass.Text = "Abc56def"
    txtOffset.Text = "-34"
    txtRelay.Text = "21.8"

    AddHandler cmdWrite.Click, New EventHandler(AddressOf Me.WriteXMLFile)

    '=========== New read code =============
    cmdRead.Enabled = False
    AddHandler cmdRead.Click, New EventHandler(AddressOf Me.ReadXMLFile)

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
  Friend WithEvents txtRelay As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents txtPass As System.Windows.Forms.TextBox
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents cmbMode As System.Windows.Forms.ComboBox
  Friend WithEvents txtOffset As System.Windows.Forms.TextBox
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents lblDate As System.Windows.Forms.Label
  Friend WithEvents txtIP As System.Windows.Forms.TextBox
  Friend WithEvents lblFirst As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents cmdWrite As System.Windows.Forms.Button
  Friend WithEvents cmdRead As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.txtRelay = New System.Windows.Forms.TextBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.txtPass = New System.Windows.Forms.TextBox()
    Me.label5 = New System.Windows.Forms.Label()
    Me.cmbMode = New System.Windows.Forms.ComboBox()
    Me.txtOffset = New System.Windows.Forms.TextBox()
    Me.label4 = New System.Windows.Forms.Label()
    Me.label3 = New System.Windows.Forms.Label()
    Me.lblDate = New System.Windows.Forms.Label()
    Me.txtIP = New System.Windows.Forms.TextBox()
    Me.lblFirst = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.cmdWrite = New System.Windows.Forms.Button()
    Me.cmdRead = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'txtRelay
    '
    Me.txtRelay.Location = New System.Drawing.Point(24, 203)
    Me.txtRelay.Name = "txtRelay"
    Me.txtRelay.Size = New System.Drawing.Size(128, 20)
    Me.txtRelay.TabIndex = 29
    Me.txtRelay.Text = ""
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(24, 187)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(128, 16)
    Me.label2.TabIndex = 28
    Me.label2.Text = "Relay Delay"
    '
    'txtPass
    '
    Me.txtPass.Location = New System.Drawing.Point(24, 147)
    Me.txtPass.Name = "txtPass"
    Me.txtPass.Size = New System.Drawing.Size(128, 20)
    Me.txtPass.TabIndex = 27
    Me.txtPass.Text = ""
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(24, 131)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(128, 16)
    Me.label5.TabIndex = 26
    Me.label5.Text = "Password"
    '
    'cmbMode
    '
    Me.cmbMode.Location = New System.Drawing.Point(184, 91)
    Me.cmbMode.Name = "cmbMode"
    Me.cmbMode.Size = New System.Drawing.Size(128, 21)
    Me.cmbMode.TabIndex = 25
    '
    'txtOffset
    '
    Me.txtOffset.Location = New System.Drawing.Point(184, 147)
    Me.txtOffset.Name = "txtOffset"
    Me.txtOffset.Size = New System.Drawing.Size(128, 20)
    Me.txtOffset.TabIndex = 24
    Me.txtOffset.Text = ""
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(184, 131)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(128, 16)
    Me.label4.TabIndex = 23
    Me.label4.Text = "Time zone offset"
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(184, 75)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(128, 16)
    Me.label3.TabIndex = 22
    Me.label3.Text = "Mode"
    '
    'lblDate
    '
    Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblDate.Location = New System.Drawing.Point(24, 35)
    Me.lblDate.Name = "lblDate"
    Me.lblDate.Size = New System.Drawing.Size(184, 16)
    Me.lblDate.TabIndex = 21
    '
    'txtIP
    '
    Me.txtIP.Location = New System.Drawing.Point(24, 91)
    Me.txtIP.Name = "txtIP"
    Me.txtIP.Size = New System.Drawing.Size(128, 20)
    Me.txtIP.TabIndex = 20
    Me.txtIP.Text = ""
    '
    'lblFirst
    '
    Me.lblFirst.Location = New System.Drawing.Point(24, 75)
    Me.lblFirst.Name = "lblFirst"
    Me.lblFirst.Size = New System.Drawing.Size(128, 16)
    Me.lblFirst.TabIndex = 19
    Me.lblFirst.Text = "IP Address"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(24, 19)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(184, 16)
    Me.label1.TabIndex = 18
    Me.label1.Text = "Configuration  Date"
    '
    'cmdWrite
    '
    Me.cmdWrite.Location = New System.Drawing.Point(200, 195)
    Me.cmdWrite.Name = "cmdWrite"
    Me.cmdWrite.Size = New System.Drawing.Size(112, 32)
    Me.cmdWrite.TabIndex = 17
    Me.cmdWrite.Text = "Write XML"
    '
    'cmdRead
    '
    Me.cmdRead.Location = New System.Drawing.Point(200, 240)
    Me.cmdRead.Name = "cmdRead"
    Me.cmdRead.Size = New System.Drawing.Size(112, 32)
    Me.cmdRead.TabIndex = 30
    Me.cmdRead.Text = "Read XML"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(336, 286)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRead, Me.txtRelay, Me.label2, Me.txtPass, Me.label5, Me.cmbMode, Me.txtOffset, Me.label4, Me.label3, Me.lblDate, Me.txtIP, Me.lblFirst, Me.label1, Me.cmdWrite})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region



  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub WriteXMLFile(ByVal sender As Object, ByVal e As EventArgs)
    Dim RelayDelay As Double
    Dim dte As DateTime
    Dim IP As String
    Dim mode As MODE
    Dim TZ_Offset As Int32
    Dim Pword As String

    'I am going to be really bad here and assume that all user filled in 
    'fields are going to convert properly
    dte = Convert.ToDateTime(lblDate.Text)
    IP = txtIP.Text
    mode = CType(cmbMode.SelectedItem, MODE)
    TZ_Offset = Int32.Parse(txtOffset.Text)
    Pword = Classify.Encrypt(txtPass.Text)
    RelayDelay = Convert.ToDouble(txtRelay.Text)

    'This is your basic well formed XMl file.
    Dim w As XmlTextWriter = New XmlTextWriter(fname, Encoding.UTF8)
    w.Formatting = Formatting.Indented

    w.WriteStartDocument()
    w.WriteStartElement("Device_Configuration")

    w.WriteElementString("ConfigDate", XmlConvert.ToString(dte))
    w.WriteElementString("IP", txtIP.Text)
    w.WriteElementString("Mode", cmbMode.SelectedItem.ToString())
    w.WriteElementString("PassWord", Pword)
    w.WriteElementString("TimeZoneOffset", XmlConvert.ToString(TZ_Offset))
    w.WriteElementString("RelayDelay", XmlConvert.ToString(RelayDelay))

    w.WriteEndElement()
    w.WriteEndDocument()

    w.Flush()
    w.Close()

    'enable read code
    cmbMode.SelectedIndex = 3
    cmdRead.Enabled = True
    cmdWrite.Enabled = False
    txtIP.Text = ""
    txtPass.Text = ""
    txtOffset.Text = ""
    txtRelay.Text = ""
    lblDate.Text = ""

  End Sub

  Private Sub ReadXMLFile(ByVal sender As Object, ByVal e As EventArgs)
    Dim RelayDelay As Double = 0.0
    Dim dte As DateTime = DateTime.Today.AddYears(-28)
    Dim IP As String = "INVALID IP"
    Dim mode As MODE = mode.None
    Dim TZ_Offset As Int32 = 0
    Dim Pword As String = String.Empty
    Dim Config As Boolean = False
    Dim cs As CONFIG_STATE = CONFIG_STATE.C_UNKNOWN

    'I use a state machine based upon the CONFIG_STATE value.
    'This is but one way to do this.
    Dim r As XmlTextReader = New XmlTextReader(fname)
    'Ignore all whitespace
    r.WhitespaceHandling = WhitespaceHandling.None
    While r.Read()
      Select Case r.NodeType
        Case XmlNodeType.Element
          If r.Name = "Device_Configuration" Then
            Config = True
          Else
            If Config Then
              Select Case r.Name
                Case "ConfigDate"
                  cs = CONFIG_STATE.C_DATE
                Case "IP"
                  cs = CONFIG_STATE.C_IP
                Case "Mode"
                  cs = CONFIG_STATE.C_MODE
                Case "PassWord"
                  cs = CONFIG_STATE.C_PASS
                Case "TimeZoneOffset"
                  cs = CONFIG_STATE.C_OFFSET
                Case "RelayDelay"
                  cs = CONFIG_STATE.C_RELAY
              End Select
            End If
            End If
          case XmlNodeType.Text:
          If Config Then
            Select Case cs
              Case CONFIG_STATE.C_DATE
                dte = XmlConvert.ToDateTime(r.Value)
              Case CONFIG_STATE.C_IP
                If Regex.IsMatch(r.Value, _
                                 "^\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}$") Then
                  IP = r.Value
                End If
              Case CONFIG_STATE.C_MODE
                Select Case r.Value
                  Case "Dumb"
                    mode = mode.Dumb
                  Case "OnLine"
                    mode = mode.OnLine
                  Case "OffLine"
                    mode = mode.OffLine
                  Case "None"
                    mode = mode.None
                End Select
              Case CONFIG_STATE.C_PASS
                Pword = Classify.Decrypt(r.Value)
              Case CONFIG_STATE.C_OFFSET
                'Do some validation
                If Regex.IsMatch(r.Value, "^[0-9+-]+$") Then
                  TZ_Offset = XmlConvert.ToInt32(r.Value)
                End If
                case CONFIG_STATE.C_RELAY:
                  'Do some validation
                  If Regex.IsMatch(r.Value, "^[0-9+-.]+$") Then
                    RelayDelay = XmlConvert.ToDouble(r.Value)
                End If
            End Select
          End If
      End Select
    End While
    r.Close()
    txtIP.Text = IP
    txtPass.Text = Pword
    txtOffset.Text = TZ_Offset.ToString()
    txtRelay.Text = RelayDelay.ToString()
    lblDate.Text = dte.ToLongDateString()
    Dim k As Int32
    For k = 0 To cmbMode.Items.Count - 1
      If CType(cmbMode.Items(k), MODE) = mode Then
        cmbMode.SelectedIndex = k
        Exit For
      End If
    Next
    cmdWrite.Enabled = True
    cmdRead.Enabled = False

  End Sub

End Class
