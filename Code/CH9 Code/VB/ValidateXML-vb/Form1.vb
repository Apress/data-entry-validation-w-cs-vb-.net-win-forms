Option Strict On

Imports System.Xml
Imports System.IO
Imports System.Xml.Schema

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region "vars"

  Private XMLfname As String = "ConfigDevice.xml"
  Private XSDfname As String = "ConfigDevice.xsd"
  Private nmSpace As String = "http://tempuri.org/ConfigDevice.xsd"
  Private Enum MODE
    None
    OnLine
    OffLine
    Dumb
  End Enum

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
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
  Friend WithEvents rcResults As System.Windows.Forms.RichTextBox
  Friend WithEvents label6 As System.Windows.Forms.Label
  Friend WithEvents cmdRead As System.Windows.Forms.Button
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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.rcResults = New System.Windows.Forms.RichTextBox()
    Me.label6 = New System.Windows.Forms.Label()
    Me.cmdRead = New System.Windows.Forms.Button()
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
    Me.SuspendLayout()
    '
    'rcResults
    '
    Me.rcResults.Location = New System.Drawing.Point(328, 35)
    Me.rcResults.Name = "rcResults"
    Me.rcResults.Size = New System.Drawing.Size(360, 224)
    Me.rcResults.TabIndex = 50
    Me.rcResults.Text = ""
    '
    'label6
    '
    Me.label6.Location = New System.Drawing.Point(336, 19)
    Me.label6.Name = "label6"
    Me.label6.Size = New System.Drawing.Size(352, 16)
    Me.label6.TabIndex = 49
    Me.label6.Text = "Read Results"
    Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'cmdRead
    '
    Me.cmdRead.Location = New System.Drawing.Point(192, 243)
    Me.cmdRead.Name = "cmdRead"
    Me.cmdRead.Size = New System.Drawing.Size(112, 32)
    Me.cmdRead.TabIndex = 48
    Me.cmdRead.Text = "Read XML"
    '
    'txtRelay
    '
    Me.txtRelay.Location = New System.Drawing.Point(16, 203)
    Me.txtRelay.Name = "txtRelay"
    Me.txtRelay.Size = New System.Drawing.Size(128, 20)
    Me.txtRelay.TabIndex = 47
    Me.txtRelay.Text = ""
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(16, 187)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(128, 16)
    Me.label2.TabIndex = 46
    Me.label2.Text = "Relay Delay"
    '
    'txtPass
    '
    Me.txtPass.Location = New System.Drawing.Point(16, 147)
    Me.txtPass.Name = "txtPass"
    Me.txtPass.Size = New System.Drawing.Size(128, 20)
    Me.txtPass.TabIndex = 45
    Me.txtPass.Text = ""
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(16, 131)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(128, 16)
    Me.label5.TabIndex = 44
    Me.label5.Text = "Password"
    '
    'cmbMode
    '
    Me.cmbMode.Location = New System.Drawing.Point(176, 91)
    Me.cmbMode.Name = "cmbMode"
    Me.cmbMode.Size = New System.Drawing.Size(128, 21)
    Me.cmbMode.TabIndex = 43
    '
    'txtOffset
    '
    Me.txtOffset.Location = New System.Drawing.Point(176, 147)
    Me.txtOffset.Name = "txtOffset"
    Me.txtOffset.Size = New System.Drawing.Size(128, 20)
    Me.txtOffset.TabIndex = 42
    Me.txtOffset.Text = ""
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(176, 131)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(128, 16)
    Me.label4.TabIndex = 41
    Me.label4.Text = "Time zone offset"
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(176, 75)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(128, 16)
    Me.label3.TabIndex = 40
    Me.label3.Text = "Mode"
    '
    'lblDate
    '
    Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblDate.Location = New System.Drawing.Point(16, 35)
    Me.lblDate.Name = "lblDate"
    Me.lblDate.Size = New System.Drawing.Size(184, 16)
    Me.lblDate.TabIndex = 39
    '
    'txtIP
    '
    Me.txtIP.Location = New System.Drawing.Point(16, 91)
    Me.txtIP.Name = "txtIP"
    Me.txtIP.Size = New System.Drawing.Size(128, 20)
    Me.txtIP.TabIndex = 38
    Me.txtIP.Text = ""
    '
    'lblFirst
    '
    Me.lblFirst.Location = New System.Drawing.Point(16, 75)
    Me.lblFirst.Name = "lblFirst"
    Me.lblFirst.Size = New System.Drawing.Size(128, 16)
    Me.lblFirst.TabIndex = 37
    Me.lblFirst.Text = "IP Address"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(16, 19)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(184, 16)
    Me.label1.TabIndex = 36
    Me.label1.Text = "Configuration  Date"
    '
    'cmdWrite
    '
    Me.cmdWrite.Location = New System.Drawing.Point(192, 195)
    Me.cmdWrite.Name = "cmdWrite"
    Me.cmdWrite.Size = New System.Drawing.Size(112, 32)
    Me.cmdWrite.TabIndex = 35
    Me.cmdWrite.Text = "Write XML"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(704, 294)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.rcResults, Me.label6, Me.cmdRead, Me.txtRelay, Me.label2, Me.txtPass, Me.label5, Me.cmbMode, Me.txtOffset, Me.label4, Me.label3, Me.lblDate, Me.txtIP, Me.lblFirst, Me.label1, Me.cmdWrite})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub WriteXMLFile()
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
    Pword = txtPass.Text
    RelayDelay = Convert.ToDouble(txtRelay.Text)

    'This is your basic well formed XMl file.
    Dim w As XmlTextWriter = New XmlTextWriter(XMLfname, Nothing)
    w.Formatting = Formatting.Indented
    w.WriteStartDocument()

    w.WriteStartElement("Device_Configuration", nmSpace)

    'Uncomment the short date line and comment the one above to cause
    'an XML validation error in the read routine
    w.WriteStartElement("ConfigDate")
    w.WriteString(XmlConvert.ToString(dte))
    'w.WriteString(dte.ToShortDateString())
    w.WriteEndElement()

    w.WriteStartElement("IP")
    w.WriteString(txtIP.Text)
    w.WriteEndElement()

    w.WriteStartElement("Mode")
    w.WriteString(cmbMode.SelectedItem.ToString())
    w.WriteEndElement()

    w.WriteStartElement("PassWord")
    w.WriteString(Pword)
    w.WriteEndElement()

    w.WriteStartElement("TimeZoneOffset")
    w.WriteString(XmlConvert.ToString(TZ_Offset))
    w.WriteEndElement()

    w.WriteStartElement("RelayDelay")
    w.WriteString(XmlConvert.ToString(RelayDelay))
    w.WriteEndElement()

    w.WriteEndElement()
    w.WriteEndDocument()
    w.Flush()
    w.Close()

    'enable read code
    cmbMode.SelectedIndex = 3
    cmdRead.Enabled = True
    cmdWrite.Enabled = False
  End Sub

#Region "Read XML file"

  Private Sub ReadXML()
    Dim RelayDelay As Double
    Dim dte As DateTime
    Dim IP As String
    Dim mode As MODE
    Dim TZ_Offset As Decimal
    Dim Pword As String

    Try
      'open up a stream and fed it to the XmlTextReader
      Dim sRdr As StreamReader = New StreamReader(XMLfname)
      Dim tRdr As XmlTextReader = New XmlTextReader(sRdr)

      'Instantiate a new schemas collection
      'Add this one schema to the collection
      'A collection means that you can validate this XML file against any
      'number of schemas.  You would do this if you were reading the file 
      'piecemeal
      Dim Schemas As XmlSchemaCollection = New XmlSchemaCollection()
      Schemas.Add(Nothing, XSDfname)

      'Instantiate a new validating reader.  This validates for data type
      'and presence.
      'Add the schemas collection to the validating reader and funnel the 
      'XmlTextReader through it.
      'wire up an ad-hoc validation delegate to catch any validation errors
      Dim vRdr As XmlValidatingReader = New XmlValidatingReader(tRdr)
      vRdr.ValidationType = ValidationType.Schema
      AddHandler vRdr.ValidationEventHandler, New ValidationEventHandler(AddressOf ValXML)
      vRdr.Schemas.Add(Schemas)

      'Read the XML file through the validator
      Dim node As Object
      While vRdr.Read()
        node = Nothing
        If vRdr.LocalName.Equals("ConfigDate") Then
          node = vRdr.ReadTypedValue()
          If Not node Is Nothing Then
            dte = CType(node, DateTime)
          End If
        End If
        If vRdr.LocalName.Equals("RelayDelay") Then
          node = vRdr.ReadTypedValue()
          If Not node Is Nothing Then
            RelayDelay = CType(node, Double)
          End If
        End If
        If vRdr.LocalName.Equals("TimeZoneOffset") Then
          node = vRdr.ReadTypedValue()
          If Not node Is Nothing Then
            TZ_Offset = CType(node, Decimal)
          End If
        End If

        If vRdr.LocalName.Equals("PassWord") Then
          node = vRdr.ReadTypedValue()
          If Not node Is Nothing Then
            Pword = CType(node, String)
          End If
        End If
        If (vRdr.LocalName.Equals("Mode")) Then
          node = vRdr.ReadTypedValue()
          '            mode = (string)node;
        End If
        If vRdr.LocalName.Equals("IP") Then
          node = vRdr.ReadTypedValue()
          If Not node Is Nothing Then
            IP = CType(node, String)
          End If
        End If
        If Not node Is Nothing Then
          rcResults.AppendText(vRdr.LocalName + vbCrLf)
          rcResults.AppendText(node.GetType().ToString() + vbCrLf)
          rcResults.AppendText(node.ToString() + vbCrLf + vbCrLf)
        End If

      End While
      vRdr.Close()
      tRdr.Close()
      sRdr.Close()
    Catch e As Exception
      'The handler will catch mal-formed xml docs.  
      'It is not intended to catch bad data.  That is the delegates job
      MessageBox.Show("Exception analyzing Config file: " + e.Message)
    End Try
  End Sub

  Private Sub ValXML(ByVal sender As Object, ByVal e As ValidationEventArgs)
    'This delegate will ONLY catch bad data.  It will not catch 
    'a mal-formed XML document!!
    rcResults.AppendText(e.Message + vbCrLf + vbCrLf)
  End Sub

#End Region

#Region "events"

  Private Sub cmdWrite_Click_1(ByVal sender As System.Object, _
                               ByVal e As System.EventArgs) _
                               Handles cmdWrite.Click
    WriteXMLFile()
  End Sub

  Private Sub cmdRead_Click_1(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) _
                              Handles cmdRead.Click
    ReadXML()
  End Sub

#End Region

End Class
