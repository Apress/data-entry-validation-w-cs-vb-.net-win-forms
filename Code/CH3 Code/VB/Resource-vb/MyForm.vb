Option Strict On

Imports System
Imports System.Resources
Imports System.Threading
Imports System.Globalization

Public Class Multilingual
  Inherits System.Windows.Forms.Form

#Region "class local variables"

  Private Enum LANG
    LANG_USA
    LANG_FRA
  End Enum

  Dim cash As Single = 0.0F
  Dim miles As Single = 0.0F

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    AddHandler txtMiles.KeyPress, AddressOf InputValidator
    AddHandler txtMiles.KeyUp, AddressOf CalculateCash

    picUSA.BackColor = Color.Transparent
    picUSA.SizeMode = PictureBoxSizeMode.StretchImage
    picUSA.Image = Image.FromFile("usa.ico")
    AddHandler picUSA.Click, AddressOf NewLanguage

    picFRA.BackColor = Color.Transparent
    picFRA.SizeMode = PictureBoxSizeMode.StretchImage
    picFRA.Image = Image.FromFile("fra.ico")
    AddHandler picFRA.Click, AddressOf NewLanguage

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
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents picFRA As System.Windows.Forms.PictureBox
  Friend WithEvents picUSA As System.Windows.Forms.PictureBox
  Friend WithEvents lblCash As System.Windows.Forms.Label
  Friend WithEvents lblOwed As System.Windows.Forms.Label
  Friend WithEvents txtMiles As System.Windows.Forms.TextBox
  Friend WithEvents lblMiles As System.Windows.Forms.Label
  Friend WithEvents lblEnd As System.Windows.Forms.Label
  Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
  Friend WithEvents lblStart As System.Windows.Forms.Label
  Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents gb1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtAddr3 As System.Windows.Forms.TextBox
  Friend WithEvents lblAddr3 As System.Windows.Forms.Label
  Friend WithEvents txtAddr2 As System.Windows.Forms.TextBox
  Friend WithEvents lblAddr2 As System.Windows.Forms.Label
  Friend WithEvents txtAddr1 As System.Windows.Forms.TextBox
  Friend WithEvents lblAddr1 As System.Windows.Forms.Label
  Friend WithEvents lblDOB As System.Windows.Forms.Label
  Friend WithEvents dtBirth As System.Windows.Forms.DateTimePicker
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents lblName As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.label1 = New System.Windows.Forms.Label()
    Me.picFRA = New System.Windows.Forms.PictureBox()
    Me.picUSA = New System.Windows.Forms.PictureBox()
    Me.lblCash = New System.Windows.Forms.Label()
    Me.lblOwed = New System.Windows.Forms.Label()
    Me.txtMiles = New System.Windows.Forms.TextBox()
    Me.lblMiles = New System.Windows.Forms.Label()
    Me.lblEnd = New System.Windows.Forms.Label()
    Me.dtEnd = New System.Windows.Forms.DateTimePicker()
    Me.lblStart = New System.Windows.Forms.Label()
    Me.dtStart = New System.Windows.Forms.DateTimePicker()
    Me.gb1 = New System.Windows.Forms.GroupBox()
    Me.txtAddr3 = New System.Windows.Forms.TextBox()
    Me.lblAddr3 = New System.Windows.Forms.Label()
    Me.txtAddr2 = New System.Windows.Forms.TextBox()
    Me.lblAddr2 = New System.Windows.Forms.Label()
    Me.txtAddr1 = New System.Windows.Forms.TextBox()
    Me.lblAddr1 = New System.Windows.Forms.Label()
    Me.lblDOB = New System.Windows.Forms.Label()
    Me.dtBirth = New System.Windows.Forms.DateTimePicker()
    Me.txtName = New System.Windows.Forms.TextBox()
    Me.lblName = New System.Windows.Forms.Label()
    Me.gb1.SuspendLayout()
    Me.SuspendLayout()
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(207, 319)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(72, 24)
    Me.label1.TabIndex = 31
    Me.label1.Text = "* .35 ="
    '
    'picFRA
    '
    Me.picFRA.BackColor = System.Drawing.Color.Linen
    Me.picFRA.Location = New System.Drawing.Point(15, 63)
    Me.picFRA.Name = "picFRA"
    Me.picFRA.Size = New System.Drawing.Size(32, 32)
    Me.picFRA.TabIndex = 30
    Me.picFRA.TabStop = False
    '
    'picUSA
    '
    Me.picUSA.BackColor = System.Drawing.Color.Linen
    Me.picUSA.Location = New System.Drawing.Point(15, 23)
    Me.picUSA.Name = "picUSA"
    Me.picUSA.Size = New System.Drawing.Size(32, 32)
    Me.picUSA.TabIndex = 29
    Me.picUSA.TabStop = False
    '
    'lblCash
    '
    Me.lblCash.BackColor = System.Drawing.Color.Linen
    Me.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCash.Location = New System.Drawing.Point(287, 319)
    Me.lblCash.Name = "lblCash"
    Me.lblCash.Size = New System.Drawing.Size(56, 24)
    Me.lblCash.TabIndex = 28
    '
    'lblOwed
    '
    Me.lblOwed.Location = New System.Drawing.Point(287, 303)
    Me.lblOwed.Name = "lblOwed"
    Me.lblOwed.Size = New System.Drawing.Size(168, 16)
    Me.lblOwed.TabIndex = 27
    Me.lblOwed.Text = "Amount Owed"
    '
    'txtMiles
    '
    Me.txtMiles.Location = New System.Drawing.Point(15, 319)
    Me.txtMiles.Name = "txtMiles"
    Me.txtMiles.Size = New System.Drawing.Size(176, 20)
    Me.txtMiles.TabIndex = 26
    Me.txtMiles.Text = ""
    '
    'lblMiles
    '
    Me.lblMiles.Location = New System.Drawing.Point(15, 303)
    Me.lblMiles.Name = "lblMiles"
    Me.lblMiles.Size = New System.Drawing.Size(168, 16)
    Me.lblMiles.TabIndex = 25
    Me.lblMiles.Text = "Miles Traveled"
    '
    'lblEnd
    '
    Me.lblEnd.Location = New System.Drawing.Point(239, 247)
    Me.lblEnd.Name = "lblEnd"
    Me.lblEnd.Size = New System.Drawing.Size(160, 16)
    Me.lblEnd.TabIndex = 24
    Me.lblEnd.Text = "Travel end time"
    '
    'dtEnd
    '
    Me.dtEnd.Location = New System.Drawing.Point(239, 263)
    Me.dtEnd.Name = "dtEnd"
    Me.dtEnd.Size = New System.Drawing.Size(168, 20)
    Me.dtEnd.TabIndex = 23
    '
    'lblStart
    '
    Me.lblStart.Location = New System.Drawing.Point(15, 247)
    Me.lblStart.Name = "lblStart"
    Me.lblStart.Size = New System.Drawing.Size(160, 16)
    Me.lblStart.TabIndex = 22
    Me.lblStart.Text = "Travel start time"
    '
    'dtStart
    '
    Me.dtStart.Location = New System.Drawing.Point(15, 263)
    Me.dtStart.Name = "dtStart"
    Me.dtStart.Size = New System.Drawing.Size(168, 20)
    Me.dtStart.TabIndex = 21
    '
    'gb1
    '
    Me.gb1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtAddr3, Me.lblAddr3, Me.txtAddr2, Me.lblAddr2, Me.txtAddr1, Me.lblAddr1})
    Me.gb1.Location = New System.Drawing.Point(15, 111)
    Me.gb1.Name = "gb1"
    Me.gb1.Size = New System.Drawing.Size(456, 120)
    Me.gb1.TabIndex = 20
    Me.gb1.TabStop = False
    Me.gb1.Text = "Address"
    '
    'txtAddr3
    '
    Me.txtAddr3.Location = New System.Drawing.Point(112, 72)
    Me.txtAddr3.Name = "txtAddr3"
    Me.txtAddr3.Size = New System.Drawing.Size(304, 20)
    Me.txtAddr3.TabIndex = 7
    Me.txtAddr3.Text = ""
    '
    'lblAddr3
    '
    Me.lblAddr3.Location = New System.Drawing.Point(16, 72)
    Me.lblAddr3.Name = "lblAddr3"
    Me.lblAddr3.Size = New System.Drawing.Size(96, 16)
    Me.lblAddr3.TabIndex = 6
    Me.lblAddr3.Text = "Address 3"
    Me.lblAddr3.TextAlign = System.Drawing.ContentAlignment.BottomRight
    '
    'txtAddr2
    '
    Me.txtAddr2.Location = New System.Drawing.Point(112, 48)
    Me.txtAddr2.Name = "txtAddr2"
    Me.txtAddr2.Size = New System.Drawing.Size(304, 20)
    Me.txtAddr2.TabIndex = 5
    Me.txtAddr2.Text = ""
    '
    'lblAddr2
    '
    Me.lblAddr2.Location = New System.Drawing.Point(16, 48)
    Me.lblAddr2.Name = "lblAddr2"
    Me.lblAddr2.Size = New System.Drawing.Size(96, 16)
    Me.lblAddr2.TabIndex = 4
    Me.lblAddr2.Text = "Address 2"
    Me.lblAddr2.TextAlign = System.Drawing.ContentAlignment.BottomRight
    '
    'txtAddr1
    '
    Me.txtAddr1.Location = New System.Drawing.Point(112, 24)
    Me.txtAddr1.Name = "txtAddr1"
    Me.txtAddr1.Size = New System.Drawing.Size(304, 20)
    Me.txtAddr1.TabIndex = 3
    Me.txtAddr1.Text = ""
    '
    'lblAddr1
    '
    Me.lblAddr1.Location = New System.Drawing.Point(16, 24)
    Me.lblAddr1.Name = "lblAddr1"
    Me.lblAddr1.Size = New System.Drawing.Size(96, 16)
    Me.lblAddr1.TabIndex = 2
    Me.lblAddr1.Text = "Address 1"
    Me.lblAddr1.TextAlign = System.Drawing.ContentAlignment.BottomRight
    '
    'lblDOB
    '
    Me.lblDOB.Location = New System.Drawing.Point(319, 23)
    Me.lblDOB.Name = "lblDOB"
    Me.lblDOB.Size = New System.Drawing.Size(160, 16)
    Me.lblDOB.TabIndex = 19
    Me.lblDOB.Text = "Date of Birth"
    '
    'dtBirth
    '
    Me.dtBirth.Location = New System.Drawing.Point(319, 39)
    Me.dtBirth.Name = "dtBirth"
    Me.dtBirth.Size = New System.Drawing.Size(168, 20)
    Me.dtBirth.TabIndex = 18
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(79, 39)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(176, 20)
    Me.txtName.TabIndex = 17
    Me.txtName.Text = ""
    '
    'lblName
    '
    Me.lblName.Location = New System.Drawing.Point(79, 23)
    Me.lblName.Name = "lblName"
    Me.lblName.Size = New System.Drawing.Size(168, 16)
    Me.lblName.TabIndex = 16
    Me.lblName.Text = "Name"
    '
    'Multilingual
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(502, 366)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label1, Me.picFRA, Me.picUSA, Me.lblCash, Me.lblOwed, Me.txtMiles, Me.lblMiles, Me.lblEnd, Me.dtEnd, Me.lblStart, Me.dtStart, Me.gb1, Me.lblDOB, Me.dtBirth, Me.txtName, Me.lblName})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Multilingual"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Car Mileage Expense"
    Me.gb1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region


  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub


  Private Sub InitStrings()
    Dim rs As ResourceSet

    If Thread.CurrentThread.CurrentCulture.Name = "fr-FR" Then
      rs = New ResourceSet("French.resources")
    Else
      rs = New ResourceSet("English.resources")
    End If

    Me.Text = rs.GetString("CAPTION")
    lblName.Text = rs.GetString("NAME")
    lblDOB.Text = rs.GetString("DOB")
    gb1.Text = rs.GetString("ADDR")
    lblAddr1.Text = rs.GetString("ADDR1")
    lblAddr2.Text = rs.GetString("ADDR2")
    lblAddr3.Text = rs.GetString("ADDR3")
    lblStart.Text = rs.GetString("STARTTIME")
    lblEnd.Text = rs.GetString("ENDTIME")
    lblMiles.Text = rs.GetString("MILES")
    lblOwed.Text = rs.GetString("CASHBACK")

    rs.Close()
    rs.Dispose()

    'Adjust the date and time displayed in the pickers
    Dim dtf As DateTimeFormatInfo = New DateTimeFormatInfo()
    dtf = Thread.CurrentThread.CurrentCulture.DateTimeFormat

    dtBirth.CustomFormat = dtf.ShortDatePattern
    dtBirth.Format = DateTimePickerFormat.Custom

    dtStart.CustomFormat = dtf.ShortTimePattern
    dtStart.Format = DateTimePickerFormat.Custom
    dtStart.ShowUpDown = True

    dtEnd.CustomFormat = dtf.ShortTimePattern
    dtEnd.Format = DateTimePickerFormat.Custom
    dtEnd.ShowUpDown = True

    lblCash.Text = cash.ToString("N", Thread.CurrentThread.CurrentCulture)
    txtMiles.Text = miles.ToString("N", Thread.CurrentThread.CurrentCulture)

    Refresh()
  End Sub

#Region "events"


  Private Sub NewLanguage(ByVal sender As Object, ByVal e As EventArgs)
    Dim l As LANG = LANG.LANG_USA

    If sender.GetType() Is GetType(PictureBox) Then
      If sender Is picFRA Then
        l = LANG.LANG_FRA
      End If
    End If


    If l = LANG.LANG_FRA Then
      Thread.CurrentThread.CurrentCulture = New CultureInfo("fr-FR")
      Thread.CurrentThread.CurrentUICulture = New CultureInfo("fr-FR")
    Else
      Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
      Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")
    End If

    InitStrings()
  End Sub


  Private Sub InputValidator(ByVal sender As Object, _
                             ByVal e As KeyPressEventArgs)
    Dim t As TextBox
    Dim nf As NumberFormatInfo = _
              Thread.CurrentThread.CurrentCulture.NumberFormat

    If sender.GetType() Is GetType(TextBox) Then
      t = CType(sender, TextBox)
      If t Is txtMiles Then
        'Allow only 0-9 and decimal separator
        If (Char.IsNumber(e.KeyChar)) Then
          e.Handled = False
        ElseIf (e.KeyChar = Convert.ToChar(nf.NumberDecimalSeparator)) Then
          If (t.Text.IndexOf(Convert.ToChar _
                             (nf.NumberDecimalSeparator)) >= 0) Then
            e.Handled = True
          Else
            e.Handled = False
          End If
        Else
          e.Handled = True
        End If
      End If
    End If
  End Sub

  Private Sub CalculateCash(ByVal sender As Object, ByVal e As KeyEventArgs)
    Dim t As TextBox

    If sender.GetType() Is GetType(TextBox) Then
      t = CType(sender, TextBox)
      If t Is txtMiles Then
        Try
          miles = Single.Parse(txtMiles.Text)
          cash = miles * 0.35F
          lblCash.Text = cash.ToString("N", Thread.CurrentThread.CurrentCulture)
        Catch
          lblCash.Text = ""
        End Try
      End If
    End If

  End Sub

#End Region

End Class
