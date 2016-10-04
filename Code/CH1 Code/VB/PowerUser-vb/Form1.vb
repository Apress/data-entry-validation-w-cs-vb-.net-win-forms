Public Class Form1
    Inherits System.Windows.Forms.Form

  ' This project details a number of design elements that go into 
  ' making a form both usable and easy to use.  Can be used by both 
  ' sophisticated and unsophisticated users.

#Region "Class Local Variables"

  Dim tb1 As ToolBar
  Dim mnu As MainMenu

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Close the program when OK/Cancel/Help buttons are pressed
    cmdOK.Text = "&OK"
    cmdOK.Enabled = False
    AddHandler cmdOK.Click, AddressOf ApplyChanges
    cmdCancel.Text = "&Cancel"
    cmdCancel.Enabled = False
    AddHandler cmdCancel.Click, AddressOf ApplyChanges
    cmdHelp.Text = "&Help"
    cmdEdit.Text = "&Edit"
    AddHandler cmdEdit.Click, AddressOf EditFields

    'Do the menu
    mnu = New MainMenu()
    Me.Menu = mnu
    Dim Top As MenuItem = New MenuItem("&File")
    mnu.MenuItems.Add(Top)
    Dim Nxt As MenuItem = New MenuItem("&New", _
                          New EventHandler(AddressOf MenuHandler))
    Nxt.Shortcut = Shortcut.F5
    Top.MenuItems.Add(Nxt)
    Nxt = New MenuItem("&Save", New EventHandler(AddressOf MenuHandler))
    Nxt.Shortcut = Shortcut.F6
    Top.MenuItems.Add(Nxt)
    Nxt = New MenuItem("-")
    Top.MenuItems.Add(Nxt)
    Nxt = New MenuItem("E&xit", New EventHandler(AddressOf MenuHandler))
    Nxt.Shortcut = Shortcut.F12
    Top.MenuItems.Add(Nxt)

    Top = New MenuItem("&Record")
    mnu.MenuItems.Add(Top)
    Nxt = New MenuItem("&Previous", New EventHandler(AddressOf MenuHandler))
    Nxt.Shortcut = Shortcut.F7
    Top.MenuItems.Add(Nxt)
    Nxt = New MenuItem("N&ext", New EventHandler(AddressOf MenuHandler))
    Nxt.Shortcut = Shortcut.F8
    Top.MenuItems.Add(Nxt)

    Top = New MenuItem("&Help")
    mnu.MenuItems.Add(Top)
    Nxt = New MenuItem("&Help", New EventHandler(AddressOf MenuHandler))
    Nxt.Shortcut = Shortcut.F1
    Top.MenuItems.Add(Nxt)
    Nxt = New MenuItem("&About", New EventHandler(AddressOf MenuHandler))
    Top.MenuItems.Add(Nxt)

    'Do the images for the toolbar and buttons
    imgToolBar.Images.Clear()
    imgToolBar.Images.Add(Image.FromFile("new.ico"))
    imgToolBar.Images.Add(Image.FromFile("save.ico"))
    imgToolBar.Images.Add(Image.FromFile("delete.ico"))
    imgToolBar.Images.Add(Image.FromFile("prev.ico"))
    imgToolBar.Images.Add(Image.FromFile("next.ico"))
    imgToolBar.Images.Add(Image.FromFile("help.ico"))
    imgToolBar.Images.Add(Image.FromFile("search.ico"))

    'Do the toolbar
    tb1 = New ToolBar()
    Me.Controls.Add(tb1)
    tb1.ImageList = imgToolBar
    tb1.Appearance = ToolBarAppearance.Flat
    AddHandler tb1.ButtonClick, AddressOf ToolBarHandler

    'Make a space that we can add when we want to
    Dim btnSpacer As ToolBarButton = New ToolBarButton()
    btnSpacer.Style = ToolBarButtonStyle.Separator

    Dim btn As ToolBarButton = New ToolBarButton()
    btn.ImageIndex = 0
    btn.ToolTipText = "New Employee"
    btn.Tag = "N"c
    tb1.Buttons.Add(btn)

    btn = New ToolBarButton()
    btn.ImageIndex = 1
    btn.ToolTipText = "Save Record"
    btn.Tag = "S"c
    tb1.Buttons.Add(btn)

    btn = New ToolBarButton()
    btn.ImageIndex = 2
    btn.ToolTipText = "Delete Employee"
    btn.Tag = "D"c
    tb1.Buttons.Add(btn)
    tb1.Buttons.Add(btnSpacer)

    btn = New ToolBarButton()
    btn.ImageIndex = 3
    btn.ToolTipText = "Previous Record"
    btn.Tag = "P"c
    tb1.Buttons.Add(btn)

    btn = New ToolBarButton()
    btn.ImageIndex = 4
    btn.ToolTipText = "Next Record"
    btn.Tag = "E"c
    tb1.Buttons.Add(btn)
    tb1.Buttons.Add(btnSpacer)

    btn = New ToolBarButton()
    btn.ImageIndex = 5
    btn.ToolTipText = "Help"
    btn.Tag = "H"c
    tb1.Buttons.Add(btn)

    'Set up the list view of employees
    lstEmps.SmallImageList = imgToolBar
    lstEmps.View = View.List

    'Do the buttons
    cmdListByEmp.FlatStyle = FlatStyle.Popup
    cmdListByEmp.Height = txtEmp.Height
    cmdListByEmp.Top = txtEmp.Top
    cmdListByEmp.ImageList = imgToolBar
    cmdListByEmp.ImageIndex = 6
    cmdListByEmp.ImageAlign = ContentAlignment.MiddleCenter
    cmdListByEmp.Tag = True
    AddHandler cmdListByEmp.Click, AddressOf CallEmployees

    cmdListByNum.FlatStyle = FlatStyle.Popup
    cmdListByNum.Height = txtNum.Height
    cmdListByNum.Top = txtNum.Top
    cmdListByNum.ImageList = imgToolBar
    cmdListByNum.ImageIndex = 6
    cmdListByNum.ImageAlign = ContentAlignment.MiddleCenter
    cmdListByNum.Tag = False
    AddHandler cmdListByNum.Click, AddressOf CallEmployees

    'Do the status bar
    Dim sb As StatusBarPanel = New StatusBarPanel()
    sb.AutoSize = StatusBarPanelAutoSize.Spring
    sb.BorderStyle = StatusBarPanelBorderStyle.Sunken
    sb.Text = "Employee:"
    sb1.Panels.Add(sb)

    sb = New StatusBarPanel()
    sb.AutoSize = StatusBarPanelAutoSize.Contents
    sb.Text = DateTime.Today.ToLongDateString()
    sb1.Panels.Add(sb)
    sb1.ShowPanels = True

    txtEmp.ReadOnly = True
    txtNum.ReadOnly = True

    dtHire.Format = DateTimePickerFormat.Short
    dtHire.MaxDate = DateTime.Today
    AddHandler dtHire.ValueChanged, AddressOf CalcTime

    'Do the tabindexes on the form itself
    txtEmp.TabIndex = 0
    cmdListByEmp.TabIndex = 1
    txtNum.TabIndex = 2
    cmdListByNum.TabIndex = 3
    cmdEdit.TabIndex = 4
    tc1.TabIndex = 5    'Doing this starts the tabbing on the tab page
    cmdOK.TabIndex = 6
    cmdCancel.TabIndex = 7
    cmdHelp.TabIndex = 8
    'Do the tabindexes on the first tab page
    txtLast.TabIndex = 0
    txtFirst.TabIndex = 1
    txtMI.TabIndex = 2
    dtHire.TabIndex = 3
    txtDept.TabIndex = 4
    'Do the tabindexes on the second tab page
    cmbPay.TabIndex = 0
    chkManager.TabIndex = 1
    optHourly.TabIndex = 2
    optSalary.TabIndex = 3
    lstEmps.TabIndex = 4
    'Do the tabindexes on the third tab page
    dtBirthday.TabIndex = 0
    txtCar1.TabIndex = 1
    txtLic1.TabIndex = 2
    txtCar2.TabIndex = 3
    txtLic2.TabIndex = 4
    cmbParking.TabIndex = 5

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
  Friend WithEvents cmdEdit As System.Windows.Forms.Button
  Friend WithEvents cmdListByNum As System.Windows.Forms.Button
  Friend WithEvents cmdListByEmp As System.Windows.Forms.Button
  Friend WithEvents txtNum As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents txtEmp As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents cmdOK As System.Windows.Forms.Button
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdHelp As System.Windows.Forms.Button
  Friend WithEvents tc1 As System.Windows.Forms.TabControl
  Friend WithEvents tp1 As System.Windows.Forms.TabPage
  Friend WithEvents lblYears As System.Windows.Forms.Label
  Friend WithEvents txtDept As System.Windows.Forms.TextBox
  Friend WithEvents label17 As System.Windows.Forms.Label
  Friend WithEvents txtTitle As System.Windows.Forms.TextBox
  Friend WithEvents label8 As System.Windows.Forms.Label
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents label6 As System.Windows.Forms.Label
  Friend WithEvents dtHire As System.Windows.Forms.DateTimePicker
  Friend WithEvents txtMI As System.Windows.Forms.TextBox
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents txtFirst As System.Windows.Forms.TextBox
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents txtLast As System.Windows.Forms.TextBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents tp2 As System.Windows.Forms.TabPage
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents optSalary As System.Windows.Forms.RadioButton
  Friend WithEvents optHourly As System.Windows.Forms.RadioButton
  Friend WithEvents chkManager As System.Windows.Forms.CheckBox
  Friend WithEvents label15 As System.Windows.Forms.Label
  Friend WithEvents cmbPay As System.Windows.Forms.ComboBox
  Friend WithEvents label16 As System.Windows.Forms.Label
  Friend WithEvents lstEmps As System.Windows.Forms.ListView
  Friend WithEvents tp3 As System.Windows.Forms.TabPage
  Friend WithEvents pic As System.Windows.Forms.PictureBox
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtLic2 As System.Windows.Forms.TextBox
  Friend WithEvents label14 As System.Windows.Forms.Label
  Friend WithEvents txtLic1 As System.Windows.Forms.TextBox
  Friend WithEvents label13 As System.Windows.Forms.Label
  Friend WithEvents txtCar2 As System.Windows.Forms.TextBox
  Friend WithEvents txtCar1 As System.Windows.Forms.TextBox
  Friend WithEvents label12 As System.Windows.Forms.Label
  Friend WithEvents label11 As System.Windows.Forms.Label
  Friend WithEvents cmbParking As System.Windows.Forms.ComboBox
  Friend WithEvents label10 As System.Windows.Forms.Label
  Friend WithEvents label9 As System.Windows.Forms.Label
  Friend WithEvents dtBirthday As System.Windows.Forms.DateTimePicker
  Friend WithEvents sb1 As System.Windows.Forms.StatusBar
  Friend WithEvents imgToolBar As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Nom Text", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))}, -1)
    Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "No Text", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))}, -1)
    Me.cmdEdit = New System.Windows.Forms.Button()
    Me.cmdListByNum = New System.Windows.Forms.Button()
    Me.cmdListByEmp = New System.Windows.Forms.Button()
    Me.txtNum = New System.Windows.Forms.TextBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.txtEmp = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.cmdOK = New System.Windows.Forms.Button()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdHelp = New System.Windows.Forms.Button()
    Me.tc1 = New System.Windows.Forms.TabControl()
    Me.tp1 = New System.Windows.Forms.TabPage()
    Me.lblYears = New System.Windows.Forms.Label()
    Me.txtDept = New System.Windows.Forms.TextBox()
    Me.label17 = New System.Windows.Forms.Label()
    Me.txtTitle = New System.Windows.Forms.TextBox()
    Me.label8 = New System.Windows.Forms.Label()
    Me.label7 = New System.Windows.Forms.Label()
    Me.label6 = New System.Windows.Forms.Label()
    Me.dtHire = New System.Windows.Forms.DateTimePicker()
    Me.txtMI = New System.Windows.Forms.TextBox()
    Me.label5 = New System.Windows.Forms.Label()
    Me.txtFirst = New System.Windows.Forms.TextBox()
    Me.label4 = New System.Windows.Forms.Label()
    Me.txtLast = New System.Windows.Forms.TextBox()
    Me.label3 = New System.Windows.Forms.Label()
    Me.tp2 = New System.Windows.Forms.TabPage()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.optSalary = New System.Windows.Forms.RadioButton()
    Me.optHourly = New System.Windows.Forms.RadioButton()
    Me.chkManager = New System.Windows.Forms.CheckBox()
    Me.label15 = New System.Windows.Forms.Label()
    Me.cmbPay = New System.Windows.Forms.ComboBox()
    Me.label16 = New System.Windows.Forms.Label()
    Me.lstEmps = New System.Windows.Forms.ListView()
    Me.tp3 = New System.Windows.Forms.TabPage()
    Me.pic = New System.Windows.Forms.PictureBox()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.txtLic2 = New System.Windows.Forms.TextBox()
    Me.label14 = New System.Windows.Forms.Label()
    Me.txtLic1 = New System.Windows.Forms.TextBox()
    Me.label13 = New System.Windows.Forms.Label()
    Me.txtCar2 = New System.Windows.Forms.TextBox()
    Me.txtCar1 = New System.Windows.Forms.TextBox()
    Me.label12 = New System.Windows.Forms.Label()
    Me.label11 = New System.Windows.Forms.Label()
    Me.cmbParking = New System.Windows.Forms.ComboBox()
    Me.label10 = New System.Windows.Forms.Label()
    Me.label9 = New System.Windows.Forms.Label()
    Me.dtBirthday = New System.Windows.Forms.DateTimePicker()
    Me.sb1 = New System.Windows.Forms.StatusBar()
    Me.imgToolBar = New System.Windows.Forms.ImageList(Me.components)
    Me.tc1.SuspendLayout()
    Me.tp1.SuspendLayout()
    Me.tp2.SuspendLayout()
    Me.groupBox2.SuspendLayout()
    Me.tp3.SuspendLayout()
    Me.groupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmdEdit
    '
    Me.cmdEdit.Location = New System.Drawing.Point(440, 48)
    Me.cmdEdit.Name = "cmdEdit"
    Me.cmdEdit.Size = New System.Drawing.Size(64, 24)
    Me.cmdEdit.TabIndex = 38
    Me.cmdEdit.Text = "Edit"
    '
    'cmdListByNum
    '
    Me.cmdListByNum.Location = New System.Drawing.Point(368, 48)
    Me.cmdListByNum.Name = "cmdListByNum"
    Me.cmdListByNum.Size = New System.Drawing.Size(32, 24)
    Me.cmdListByNum.TabIndex = 37
    '
    'cmdListByEmp
    '
    Me.cmdListByEmp.Location = New System.Drawing.Point(224, 48)
    Me.cmdListByEmp.Name = "cmdListByEmp"
    Me.cmdListByEmp.Size = New System.Drawing.Size(32, 24)
    Me.cmdListByEmp.TabIndex = 36
    '
    'txtNum
    '
    Me.txtNum.Location = New System.Drawing.Point(296, 48)
    Me.txtNum.Name = "txtNum"
    Me.txtNum.Size = New System.Drawing.Size(72, 20)
    Me.txtNum.TabIndex = 1
    Me.txtNum.Text = ""
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(296, 32)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(88, 16)
    Me.label2.TabIndex = 34
    Me.label2.Text = "Clock Number"
    '
    'txtEmp
    '
    Me.txtEmp.Location = New System.Drawing.Point(24, 48)
    Me.txtEmp.Name = "txtEmp"
    Me.txtEmp.Size = New System.Drawing.Size(200, 20)
    Me.txtEmp.TabIndex = 1
    Me.txtEmp.Text = ""
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(24, 32)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(144, 16)
    Me.label1.TabIndex = 32
    Me.label1.Text = "Employee Name"
    '
    'cmdOK
    '
    Me.cmdOK.Location = New System.Drawing.Point(312, 336)
    Me.cmdOK.Name = "cmdOK"
    Me.cmdOK.Size = New System.Drawing.Size(64, 24)
    Me.cmdOK.TabIndex = 31
    Me.cmdOK.Text = "OK"
    '
    'cmdCancel
    '
    Me.cmdCancel.Location = New System.Drawing.Point(392, 336)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(64, 24)
    Me.cmdCancel.TabIndex = 30
    Me.cmdCancel.Text = "Cancel"
    '
    'cmdHelp
    '
    Me.cmdHelp.Location = New System.Drawing.Point(472, 336)
    Me.cmdHelp.Name = "cmdHelp"
    Me.cmdHelp.Size = New System.Drawing.Size(64, 24)
    Me.cmdHelp.TabIndex = 29
    Me.cmdHelp.Text = "Help"
    '
    'tc1
    '
    Me.tc1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp1, Me.tp2, Me.tp3})
    Me.tc1.Location = New System.Drawing.Point(16, 80)
    Me.tc1.Name = "tc1"
    Me.tc1.SelectedIndex = 0
    Me.tc1.Size = New System.Drawing.Size(520, 240)
    Me.tc1.TabIndex = 28
    '
    'tp1
    '
    Me.tp1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblYears, Me.txtDept, Me.label17, Me.txtTitle, Me.label8, Me.label7, Me.label6, Me.dtHire, Me.txtMI, Me.label5, Me.txtFirst, Me.label4, Me.txtLast, Me.label3})
    Me.tp1.Location = New System.Drawing.Point(4, 22)
    Me.tp1.Name = "tp1"
    Me.tp1.Size = New System.Drawing.Size(512, 214)
    Me.tp1.TabIndex = 0
    Me.tp1.Text = "Basic Data"
    '
    'lblYears
    '
    Me.lblYears.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblYears.Location = New System.Drawing.Point(292, 97)
    Me.lblYears.Name = "lblYears"
    Me.lblYears.Size = New System.Drawing.Size(40, 16)
    Me.lblYears.TabIndex = 46
    '
    'txtDept
    '
    Me.txtDept.Location = New System.Drawing.Point(292, 161)
    Me.txtDept.Name = "txtDept"
    Me.txtDept.Size = New System.Drawing.Size(136, 20)
    Me.txtDept.TabIndex = 45
    Me.txtDept.Text = ""
    '
    'label17
    '
    Me.label17.Location = New System.Drawing.Point(292, 145)
    Me.label17.Name = "label17"
    Me.label17.Size = New System.Drawing.Size(144, 16)
    Me.label17.TabIndex = 44
    Me.label17.Text = "Department"
    '
    'txtTitle
    '
    Me.txtTitle.Location = New System.Drawing.Point(20, 161)
    Me.txtTitle.Name = "txtTitle"
    Me.txtTitle.Size = New System.Drawing.Size(144, 20)
    Me.txtTitle.TabIndex = 43
    Me.txtTitle.Text = ""
    '
    'label8
    '
    Me.label8.Location = New System.Drawing.Point(20, 145)
    Me.label8.Name = "label8"
    Me.label8.Size = New System.Drawing.Size(144, 16)
    Me.label8.TabIndex = 42
    Me.label8.Text = "Title"
    '
    'label7
    '
    Me.label7.Location = New System.Drawing.Point(292, 81)
    Me.label7.Name = "label7"
    Me.label7.Size = New System.Drawing.Size(120, 16)
    Me.label7.TabIndex = 41
    Me.label7.Text = "Years with Company"
    '
    'label6
    '
    Me.label6.Location = New System.Drawing.Point(292, 33)
    Me.label6.Name = "label6"
    Me.label6.Size = New System.Drawing.Size(200, 16)
    Me.label6.TabIndex = 40
    Me.label6.Text = "Date of Hire"
    '
    'dtHire
    '
    Me.dtHire.Location = New System.Drawing.Point(292, 49)
    Me.dtHire.Name = "dtHire"
    Me.dtHire.Size = New System.Drawing.Size(136, 20)
    Me.dtHire.TabIndex = 39
    '
    'txtMI
    '
    Me.txtMI.Location = New System.Drawing.Point(180, 97)
    Me.txtMI.Name = "txtMI"
    Me.txtMI.Size = New System.Drawing.Size(40, 20)
    Me.txtMI.TabIndex = 38
    Me.txtMI.Text = ""
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(180, 81)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(24, 16)
    Me.label5.TabIndex = 37
    Me.label5.Text = "M.I."
    '
    'txtFirst
    '
    Me.txtFirst.Location = New System.Drawing.Point(20, 97)
    Me.txtFirst.Name = "txtFirst"
    Me.txtFirst.Size = New System.Drawing.Size(144, 20)
    Me.txtFirst.TabIndex = 36
    Me.txtFirst.Text = ""
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(20, 81)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(144, 16)
    Me.label4.TabIndex = 35
    Me.label4.Text = "First Name"
    '
    'txtLast
    '
    Me.txtLast.Location = New System.Drawing.Point(20, 49)
    Me.txtLast.Name = "txtLast"
    Me.txtLast.Size = New System.Drawing.Size(200, 20)
    Me.txtLast.TabIndex = 34
    Me.txtLast.Text = ""
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(20, 33)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(200, 16)
    Me.label3.TabIndex = 33
    Me.label3.Text = "Last Name"
    '
    'tp2
    '
    Me.tp2.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox2, Me.label16, Me.lstEmps})
    Me.tp2.Location = New System.Drawing.Point(4, 22)
    Me.tp2.Name = "tp2"
    Me.tp2.Size = New System.Drawing.Size(512, 214)
    Me.tp2.TabIndex = 1
    Me.tp2.Text = "Position"
    Me.tp2.Visible = False
    '
    'groupBox2
    '
    Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.optSalary, Me.optHourly, Me.chkManager, Me.label15, Me.cmbPay})
    Me.groupBox2.Location = New System.Drawing.Point(16, 24)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(192, 168)
    Me.groupBox2.TabIndex = 4
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Employee Type"
    '
    'optSalary
    '
    Me.optSalary.Location = New System.Drawing.Point(24, 112)
    Me.optSalary.Name = "optSalary"
    Me.optSalary.Size = New System.Drawing.Size(96, 16)
    Me.optSalary.TabIndex = 6
    Me.optSalary.Text = "Salary"
    '
    'optHourly
    '
    Me.optHourly.Location = New System.Drawing.Point(24, 96)
    Me.optHourly.Name = "optHourly"
    Me.optHourly.Size = New System.Drawing.Size(96, 16)
    Me.optHourly.TabIndex = 5
    Me.optHourly.Text = "Hourly"
    '
    'chkManager
    '
    Me.chkManager.Location = New System.Drawing.Point(24, 64)
    Me.chkManager.Name = "chkManager"
    Me.chkManager.Size = New System.Drawing.Size(120, 16)
    Me.chkManager.TabIndex = 4
    Me.chkManager.Text = "Manager"
    '
    'label15
    '
    Me.label15.Location = New System.Drawing.Point(16, 24)
    Me.label15.Name = "label15"
    Me.label15.Size = New System.Drawing.Size(40, 16)
    Me.label15.TabIndex = 3
    Me.label15.Text = "Code"
    Me.label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '
    'cmbPay
    '
    Me.cmbPay.Location = New System.Drawing.Point(56, 24)
    Me.cmbPay.Name = "cmbPay"
    Me.cmbPay.Size = New System.Drawing.Size(64, 21)
    Me.cmbPay.TabIndex = 2
    '
    'label16
    '
    Me.label16.Location = New System.Drawing.Point(224, 16)
    Me.label16.Name = "label16"
    Me.label16.Size = New System.Drawing.Size(272, 16)
    Me.label16.TabIndex = 3
    Me.label16.Text = "Reporting Staff"
    Me.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lstEmps
    '
    Me.lstEmps.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
    Me.lstEmps.Location = New System.Drawing.Point(224, 32)
    Me.lstEmps.Name = "lstEmps"
    Me.lstEmps.Size = New System.Drawing.Size(272, 160)
    Me.lstEmps.TabIndex = 2
    Me.lstEmps.View = System.Windows.Forms.View.List
    '
    'tp3
    '
    Me.tp3.Controls.AddRange(New System.Windows.Forms.Control() {Me.pic, Me.groupBox1, Me.label9, Me.dtBirthday})
    Me.tp3.Location = New System.Drawing.Point(4, 22)
    Me.tp3.Name = "tp3"
    Me.tp3.Size = New System.Drawing.Size(512, 214)
    Me.tp3.TabIndex = 2
    Me.tp3.Text = "Personal"
    Me.tp3.Visible = False
    '
    'pic
    '
    Me.pic.Location = New System.Drawing.Point(48, 64)
    Me.pic.Name = "pic"
    Me.pic.Size = New System.Drawing.Size(100, 130)
    Me.pic.TabIndex = 16
    Me.pic.TabStop = False
    '
    'groupBox1
    '
    Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtLic2, Me.label14, Me.txtLic1, Me.label13, Me.txtCar2, Me.txtCar1, Me.label12, Me.label11, Me.cmbParking, Me.label10})
    Me.groupBox1.Location = New System.Drawing.Point(216, 16)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(288, 176)
    Me.groupBox1.TabIndex = 14
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Automobile"
    '
    'txtLic2
    '
    Me.txtLic2.Location = New System.Drawing.Point(152, 88)
    Me.txtLic2.Name = "txtLic2"
    Me.txtLic2.Size = New System.Drawing.Size(120, 20)
    Me.txtLic2.TabIndex = 9
    Me.txtLic2.Text = ""
    '
    'label14
    '
    Me.label14.Location = New System.Drawing.Point(152, 72)
    Me.label14.Name = "label14"
    Me.label14.Size = New System.Drawing.Size(112, 16)
    Me.label14.TabIndex = 8
    Me.label14.Text = "License"
    '
    'txtLic1
    '
    Me.txtLic1.Location = New System.Drawing.Point(16, 88)
    Me.txtLic1.Name = "txtLic1"
    Me.txtLic1.Size = New System.Drawing.Size(120, 20)
    Me.txtLic1.TabIndex = 7
    Me.txtLic1.Text = ""
    '
    'label13
    '
    Me.label13.Location = New System.Drawing.Point(16, 72)
    Me.label13.Name = "label13"
    Me.label13.Size = New System.Drawing.Size(112, 16)
    Me.label13.TabIndex = 6
    Me.label13.Text = "License"
    '
    'txtCar2
    '
    Me.txtCar2.Location = New System.Drawing.Point(152, 40)
    Me.txtCar2.Name = "txtCar2"
    Me.txtCar2.Size = New System.Drawing.Size(120, 20)
    Me.txtCar2.TabIndex = 5
    Me.txtCar2.Text = ""
    '
    'txtCar1
    '
    Me.txtCar1.Location = New System.Drawing.Point(16, 40)
    Me.txtCar1.Name = "txtCar1"
    Me.txtCar1.Size = New System.Drawing.Size(120, 20)
    Me.txtCar1.TabIndex = 4
    Me.txtCar1.Text = ""
    '
    'label12
    '
    Me.label12.Location = New System.Drawing.Point(152, 24)
    Me.label12.Name = "label12"
    Me.label12.Size = New System.Drawing.Size(56, 16)
    Me.label12.TabIndex = 3
    Me.label12.Text = "Car 2"
    '
    'label11
    '
    Me.label11.Location = New System.Drawing.Point(16, 24)
    Me.label11.Name = "label11"
    Me.label11.Size = New System.Drawing.Size(56, 16)
    Me.label11.TabIndex = 2
    Me.label11.Text = "Car 1"
    '
    'cmbParking
    '
    Me.cmbParking.Location = New System.Drawing.Point(16, 144)
    Me.cmbParking.Name = "cmbParking"
    Me.cmbParking.Size = New System.Drawing.Size(104, 21)
    Me.cmbParking.TabIndex = 1
    '
    'label10
    '
    Me.label10.Location = New System.Drawing.Point(16, 128)
    Me.label10.Name = "label10"
    Me.label10.Size = New System.Drawing.Size(104, 16)
    Me.label10.TabIndex = 0
    Me.label10.Text = "Parking Space"
    '
    'label9
    '
    Me.label9.Location = New System.Drawing.Point(16, 16)
    Me.label9.Name = "label9"
    Me.label9.Size = New System.Drawing.Size(168, 16)
    Me.label9.TabIndex = 13
    Me.label9.Text = "Birthday"
    '
    'dtBirthday
    '
    Me.dtBirthday.Location = New System.Drawing.Point(16, 32)
    Me.dtBirthday.Name = "dtBirthday"
    Me.dtBirthday.Size = New System.Drawing.Size(192, 20)
    Me.dtBirthday.TabIndex = 12
    '
    'sb1
    '
    Me.sb1.Location = New System.Drawing.Point(0, 377)
    Me.sb1.Name = "sb1"
    Me.sb1.Size = New System.Drawing.Size(552, 16)
    Me.sb1.TabIndex = 39
    Me.sb1.Text = "StatusBar1"
    '
    'imgToolBar
    '
    Me.imgToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
    Me.imgToolBar.ImageSize = New System.Drawing.Size(16, 16)
    Me.imgToolBar.TransparentColor = System.Drawing.Color.Transparent
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(552, 393)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sb1, Me.cmdEdit, Me.cmdListByNum, Me.cmdListByEmp, Me.txtNum, Me.label2, Me.txtEmp, Me.label1, Me.cmdOK, Me.cmdCancel, Me.cmdHelp, Me.tc1})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.tc1.ResumeLayout(False)
    Me.tp1.ResumeLayout(False)
    Me.tp2.ResumeLayout(False)
    Me.groupBox2.ResumeLayout(False)
    Me.tp3.ResumeLayout(False)
    Me.groupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
    Dim p As TabPage
    Dim c As Control

    FillList()

    For Each p In tc1.TabPages
      For Each c In p.Controls
        c.Enabled = False
      Next
    Next

  End Sub

  Private Sub FillList()
    txtEmp.Text = "John Smith"
    txtNum.Text = "504"
    txtLast.Text = "Smith"
    txtFirst.Text = "John"
    txtMI.Text = "Q"
    txtTitle.Text = "Marketing Manager"
    txtDept.Text = "Marketing"
    dtHire.Value = DateTime.Parse("6/23/97")

    cmbPay.Items.Clear()
    cmbPay.Items.Add("W01")
    cmbPay.Items.Add("W02")
    cmbPay.Items.Add("W03")
    cmbPay.Items.Add("W04")
    cmbPay.Items.Add("B01")
    cmbPay.SelectedIndex = 0

    lstEmps.Items.Clear()
    lstEmps.Items.Add("Grunt 1", 0)
    lstEmps.Items.Add("Grunt 2", 0)
    lstEmps.Items.Add("Grunt 3", 0)

    txtCar1.Text = "Pickup Truck"
    txtLic1.Text = "NOBUGS"

    cmbParking.Items.Clear()
    cmbParking.Items.Add("A1")
    cmbParking.Items.Add("A2")
    cmbParking.Items.Add("A3")
    cmbParking.Items.Add("A4")
    cmbParking.Items.Add("B1")
    cmbParking.Items.Add("B2")
    cmbParking.Items.Add("B3")
    cmbParking.Items.Add("B4")
    cmbParking.Items.Add("-NA-")
    cmbParking.SelectedIndex = 0

    chkManager.Checked = True
    optSalary.Checked = True

    pic.SizeMode = PictureBoxSizeMode.StretchImage
    pic.Image = Image.FromFile("nick symmonds.jpg")

  End Sub

#Region "Events"

  Private Sub CalcTime(ByVal sender As Object, ByVal e As EventArgs)
    lblYears.Text = (DateTime.Today.Year - dtHire.Value.Year).ToString()
  End Sub

  Private Sub CallEmployees(ByVal sender As Object, ByVal e As EventArgs)
    Dim b As Button = CType(sender, Button)

    Dim frm As EmpList = New EmpList(CType(b.Tag, Boolean))
    frm.ShowDialog()
  End Sub

  Private Sub ApplyChanges(ByVal sender As Object, ByVal e As EventArgs)
    Dim p As TabPage
    Dim c As Control

    For Each p In tc1.TabPages
      For Each c In p.Controls
        c.Enabled = False
      Next
    Next
    cmdEdit.Enabled = True
    cmdOK.Enabled = False
    cmdCancel.Enabled = False
  End Sub

  Private Sub EditFields(ByVal sender As Object, ByVal e As EventArgs)
    Dim p As TabPage
    Dim c As Control

    For Each p In tc1.TabPages
      For Each c In p.Controls
        c.Enabled = True
      Next
    Next
    cmdEdit.Enabled = False
    cmdOK.Enabled = True
    cmdCancel.Enabled = True
  End Sub

  Private Sub ToolBarHandler(ByVal sender As Object, _
                            ByVal e As ToolBarButtonClickEventArgs)
    Select Case (CType(e.Button.Tag, Char))
      Case "N"c 'New
        'Your code here.
      Case "S"c   'Save
        'Your code here.
      Case "D"   'Delete
        'Your code here.
      Case "X"   'Exit
        Me.Close()
      Case "P"   'Previous
        'Your code here.
      Case "E"   'Next
        'Your code here.
      Case "H"   'Help
        'Your code here.
      Case "A"   'About
        'Your code here.
    End Select

  End Sub

  Private Sub MenuHandler(ByVal sender As Object, ByVal e As EventArgs)
    Dim m As MenuItem

    If (sender.GetType Is GetType(MenuItem)) Then
      m = CType(sender, MenuItem)
    Else
      Return
    End If

    Select Case m.Mnemonic
      Case "N"   'New
        'Your code here.
      Case "S   'Save"
        'Your code here.
      Case "D"   'Delete
        'Your code here.
      Case "X"   'Exit
        Me.Close()
      Case "P"   'Previous
        'Your code here.
      Case "E"   'Next
        'Your code here.
      Case "H"   'Help
        'Your code here.
      Case "A"   'About
        'Your code here.
    End Select

  End Sub
#End Region

End Class
