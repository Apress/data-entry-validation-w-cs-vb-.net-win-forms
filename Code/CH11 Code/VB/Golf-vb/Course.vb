Option Strict On

Imports System.Data
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class Course
  Inherits System.Windows.Forms.Form

#Region "Class Local Variables"

  Private mParent As GolfStat
  Private ThisCourse As ICourseInfo
  Private ThisCard As IScoreCardInfo
  Private ThisHole As IHoleDetailInfo

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Dont forget to initailize tab order and speedkeys, etc

    AddHandler cmdQuit.Click, New EventHandler(AddressOf CloseProgram)

    Dim f As Font = CType(Font.Clone(), Font)
    Font = New Font("Comic Sans MS", 10)
    Text = "Golf Course Score Tracker"
    Font = CType(f.Clone(), Font)

    Anchor = AnchorStyles.Left And AnchorStyles.Top

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
  Friend WithEvents TC As System.Windows.Forms.TabControl
  Friend WithEvents tp1 As System.Windows.Forms.TabPage
  Friend WithEvents lblLength As System.Windows.Forms.Label
  Friend WithEvents cmdEdit As System.Windows.Forms.Button
  Friend WithEvents lstTees As System.Windows.Forms.ListView
  Friend WithEvents cmdNew As System.Windows.Forms.Button
  Friend WithEvents cmbCourseName As System.Windows.Forms.ComboBox
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents cmbPar As System.Windows.Forms.ComboBox
  Friend WithEvents cmbHoles As System.Windows.Forms.ComboBox
  Friend WithEvents label6 As System.Windows.Forms.Label
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents txtSlope As System.Windows.Forms.TextBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents tp2 As System.Windows.Forms.TabPage
  Friend WithEvents cmdNewCard As System.Windows.Forms.Button
  Friend WithEvents dg1 As System.Windows.Forms.DataGrid
  Friend WithEvents err As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Course))
    Me.cmdQuit = New System.Windows.Forms.Button()
    Me.TC = New System.Windows.Forms.TabControl()
    Me.tp1 = New System.Windows.Forms.TabPage()
    Me.lblLength = New System.Windows.Forms.Label()
    Me.cmdEdit = New System.Windows.Forms.Button()
    Me.lstTees = New System.Windows.Forms.ListView()
    Me.cmdNew = New System.Windows.Forms.Button()
    Me.cmbCourseName = New System.Windows.Forms.ComboBox()
    Me.cmdSave = New System.Windows.Forms.Button()
    Me.cmbPar = New System.Windows.Forms.ComboBox()
    Me.cmbHoles = New System.Windows.Forms.ComboBox()
    Me.label6 = New System.Windows.Forms.Label()
    Me.label5 = New System.Windows.Forms.Label()
    Me.label4 = New System.Windows.Forms.Label()
    Me.txtSlope = New System.Windows.Forms.TextBox()
    Me.label3 = New System.Windows.Forms.Label()
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.tp2 = New System.Windows.Forms.TabPage()
    Me.cmdNewCard = New System.Windows.Forms.Button()
    Me.dg1 = New System.Windows.Forms.DataGrid()
    Me.err = New System.Windows.Forms.ErrorProvider()
    Me.TC.SuspendLayout()
    Me.tp1.SuspendLayout()
    Me.tp2.SuspendLayout()
    CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cmdQuit
    '
    Me.cmdQuit.Location = New System.Drawing.Point(694, 392)
    Me.cmdQuit.Name = "cmdQuit"
    Me.cmdQuit.Size = New System.Drawing.Size(60, 30)
    Me.cmdQuit.TabIndex = 3
    Me.cmdQuit.Text = "Quit"
    '
    'TC
    '
    Me.TC.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp1, Me.tp2})
    Me.TC.Location = New System.Drawing.Point(14, 16)
    Me.TC.Name = "TC"
    Me.TC.SelectedIndex = 0
    Me.TC.Size = New System.Drawing.Size(736, 360)
    Me.TC.TabIndex = 2
    '
    'tp1
    '
    Me.tp1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLength, Me.cmdEdit, Me.lstTees, Me.cmdNew, Me.cmbCourseName, Me.cmdSave, Me.cmbPar, Me.cmbHoles, Me.label6, Me.label5, Me.label4, Me.txtSlope, Me.label3, Me.label2, Me.label1})
    Me.tp1.Location = New System.Drawing.Point(4, 22)
    Me.tp1.Name = "tp1"
    Me.tp1.Size = New System.Drawing.Size(728, 334)
    Me.tp1.TabIndex = 0
    Me.tp1.Text = "Course Setup"
    '
    'lblLength
    '
    Me.lblLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblLength.Location = New System.Drawing.Point(72, 64)
    Me.lblLength.Name = "lblLength"
    Me.lblLength.Size = New System.Drawing.Size(48, 20)
    Me.lblLength.TabIndex = 16
    '
    'cmdEdit
    '
    Me.cmdEdit.Location = New System.Drawing.Point(560, 288)
    Me.cmdEdit.Name = "cmdEdit"
    Me.cmdEdit.Size = New System.Drawing.Size(64, 32)
    Me.cmdEdit.TabIndex = 15
    Me.cmdEdit.Text = "Edit"
    '
    'lstTees
    '
    Me.lstTees.Location = New System.Drawing.Point(16, 144)
    Me.lstTees.Name = "lstTees"
    Me.lstTees.Size = New System.Drawing.Size(696, 120)
    Me.lstTees.TabIndex = 14
    '
    'cmdNew
    '
    Me.cmdNew.Image = CType(resources.GetObject("cmdNew.Image"), System.Drawing.Bitmap)
    Me.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.cmdNew.Location = New System.Drawing.Point(424, 24)
    Me.cmdNew.Name = "cmdNew"
    Me.cmdNew.Size = New System.Drawing.Size(64, 24)
    Me.cmdNew.TabIndex = 13
    Me.cmdNew.Text = "New"
    '
    'cmbCourseName
    '
    Me.cmbCourseName.Location = New System.Drawing.Point(72, 24)
    Me.cmbCourseName.Name = "cmbCourseName"
    Me.cmbCourseName.Size = New System.Drawing.Size(344, 21)
    Me.cmbCourseName.TabIndex = 12
    '
    'cmdSave
    '
    Me.cmdSave.Location = New System.Drawing.Point(648, 288)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(64, 32)
    Me.cmdSave.TabIndex = 11
    Me.cmdSave.Text = "Save"
    '
    'cmbPar
    '
    Me.cmbPar.Location = New System.Drawing.Point(280, 104)
    Me.cmbPar.Name = "cmbPar"
    Me.cmbPar.Size = New System.Drawing.Size(64, 21)
    Me.cmbPar.TabIndex = 10
    '
    'cmbHoles
    '
    Me.cmbHoles.Location = New System.Drawing.Point(280, 64)
    Me.cmbHoles.Name = "cmbHoles"
    Me.cmbHoles.Size = New System.Drawing.Size(64, 21)
    Me.cmbHoles.TabIndex = 9
    '
    'label6
    '
    Me.label6.Location = New System.Drawing.Point(224, 104)
    Me.label6.Name = "label6"
    Me.label6.Size = New System.Drawing.Size(56, 16)
    Me.label6.TabIndex = 8
    Me.label6.Text = "Par"
    '
    'label5
    '
    Me.label5.Location = New System.Drawing.Point(224, 64)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(56, 16)
    Me.label5.TabIndex = 7
    Me.label5.Text = "Holes"
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(128, 64)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(56, 16)
    Me.label4.TabIndex = 6
    Me.label4.Text = "Yards"
    '
    'txtSlope
    '
    Me.txtSlope.Location = New System.Drawing.Point(72, 104)
    Me.txtSlope.Name = "txtSlope"
    Me.txtSlope.Size = New System.Drawing.Size(32, 20)
    Me.txtSlope.TabIndex = 5
    Me.txtSlope.Text = ""
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(16, 104)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(56, 16)
    Me.label3.TabIndex = 3
    Me.label3.Text = "Slope"
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(16, 64)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(56, 16)
    Me.label2.TabIndex = 2
    Me.label2.Text = "Length"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(16, 24)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(56, 16)
    Me.label1.TabIndex = 0
    Me.label1.Text = "Name"
    '
    'tp2
    '
    Me.tp2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdNewCard, Me.dg1})
    Me.tp2.Location = New System.Drawing.Point(4, 22)
    Me.tp2.Name = "tp2"
    Me.tp2.Size = New System.Drawing.Size(728, 334)
    Me.tp2.TabIndex = 1
    Me.tp2.Text = "Course scores"
    Me.tp2.Visible = False
    '
    'cmdNewCard
    '
    Me.cmdNewCard.Image = CType(resources.GetObject("cmdNewCard.Image"), System.Drawing.Bitmap)
    Me.cmdNewCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.cmdNewCard.Location = New System.Drawing.Point(608, 288)
    Me.cmdNewCard.Name = "cmdNewCard"
    Me.cmdNewCard.Size = New System.Drawing.Size(104, 32)
    Me.cmdNewCard.TabIndex = 14
    Me.cmdNewCard.Text = "New Card"
    '
    'dg1
    '
    Me.dg1.DataMember = ""
    Me.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dg1.Location = New System.Drawing.Point(16, 16)
    Me.dg1.Name = "dg1"
    Me.dg1.Size = New System.Drawing.Size(696, 248)
    Me.dg1.TabIndex = 0
    '
    'Course
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(768, 438)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdQuit, Me.TC})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Course"
    Me.Text = "Course"
    Me.TC.ResumeLayout(False)
    Me.tp1.ResumeLayout(False)
    Me.tp2.ResumeLayout(False)
    CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Course_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) Handles MyBase.Load
    mParent = CType(Me.MdiParent, GolfStat)
    TabSetup()
    GolfCourseTabSetup()

  End Sub

#Region "Setup routines"

  Private Sub AddScoreCardStyle()

    'First clear the existing one out
    dg1.TableStyles.Clear()

    Dim ts1 As DataGridTableStyle = New DataGridTableStyle()
    ts1.MappingName = "Course Score"
    ' Set other properties.
    ts1.AlternatingBackColor = Color.LightGray
    '
    ' Add textbox column style so we can catch textbox mouse clicks
    Dim TextCol As DataGridTextBoxColumn = New DataGridTextBoxColumn()
    TextCol.MappingName = "Date"
    TextCol.HeaderText = "Date"
    TextCol.Width = 100
    AddHandler TextCol.TextBox.Validating, _
                    New CancelEventHandler(AddressOf DateCellValidating)
    AddHandler TextCol.TextBox.DoubleClick, _
                    New EventHandler(AddressOf CellDateClick)
    AddHandler TextCol.TextBox.KeyPress, _
                    New KeyPressEventHandler(AddressOf CellDateKeyPress)
    ts1.GridColumnStyles.Add(TextCol)

    TextCol = New DataGridTextBoxColumn()
    TextCol.MappingName = "Score"
    TextCol.HeaderText = "Score"
    TextCol.Width = 50
    TextCol.TextBox.Enabled = False
    ts1.GridColumnStyles.Add(TextCol)

    Dim k As Int32
    For k = 1 To ThisCourse.NumberOfHoles + 1
      TextCol = New DataGridTextBoxColumn()
      TextCol.MappingName = k.ToString()
      TextCol.HeaderText = k.ToString()
      TextCol.Width = 50
      TextCol.TextBox.MaxLength = 2
      AddHandler TextCol.TextBox.DoubleClick, _
                    New EventHandler(AddressOf HoleScoreDblClick)
      AddHandler TextCol.TextBox.KeyPress, _
                    New KeyPressEventHandler(AddressOf HoleScoreEntry)
      AddHandler TextCol.TextBox.Validating, _
                    New CancelEventHandler(AddressOf HoleScoreValidate)
      ts1.GridColumnStyles.Add(TextCol)
    Next
    dg1.TableStyles.Add(ts1)
  End Sub

  Private Sub SetupScoreCardDatagrid()
    'This must be set up based upon the scorecard collection within 
    'the thiscourse object. as each cell is clicked it brings up a hole 
    'detail. If the user chooses not to click a cell he can in-place edit 
    'just the total score. Either way any time a cell is edited I will need 
    'to change something in the iholedetail object that belongs to this hole.

    Debug.Assert(Not ThisCourse Is Nothing, "Must have a valid course")

    'Generate a column style collection that makes each cell a text box.
    AddScoreCardStyle()

    Dim dc As DataColumn
    'Set the datasource to null at start.
    dg1.DataSource = Nothing
    Dim DS As DataSet = New DataSet()

    'Top level table
    Dim DT As DataTable = New DataTable("Course Score")
    dc = New DataColumn("Date", System.Type.GetType("System.DateTime"))
    DT.Columns.Add(dc)
    dc = New DataColumn("Score", System.Type.GetType("System.Int32"))
    DT.Columns.Add(dc)
    Dim k As Int32
    For k = 1 To ThisCourse.NumberOfHoles
      dc = New DataColumn(k.ToString(), System.Type.GetType("System.Int32"))
      DT.Columns.Add(dc)
    Next

    '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    'Add something here to catch if the number of holedetail objects exceeds 
    'the number of holes in the course If so then write to an error file.
    '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    Dim scores As ArrayList = New ArrayList()
    Dim s As IScoreCardInfo
    For Each s In ThisCourse.ScoreCards

      scores.Clear()
      scores.Add(s.PlayDate.ToShortDateString())
      scores.Add(s.RoundScore)
      Dim h As IHoleDetailInfo
      For Each h In s.holes
        'Remember that the basis for this collection is a SortedList so it 
        'should come out in order.
        scores.Add(h.TotalShots)
      Next
      DT.Rows.Add(scores.ToArray())
    Next

    DS.Tables.Add(DT)

    dg1.CaptionText = cmbCourseName.Text + " / Date of play and Hole score "
    dg1.CaptionFont = New Font("Comic Sans MS", 10)
    dg1.Font = New Font("Arial", 8)
    dg1.DataSource = DS
    dg1.DataMember = "Course Score"
    AddHandler dg1.CurrentCellChanged, New EventHandler(AddressOf CellChanged)

    'Remember binding the property of one control to the property of another.
    'This was managed by a PropertyManager object.  When you have an 
    'object that derives from the IList interface such as a collection, 
    'then each of these objects has a CurrencyManager. I am changing the 
    'data view object that belongs to this data source's datamember 
    '(The table name in this case).  I am making sure that the user cannot 
    'add a new row using this dataview.  See the online help 
    '"Consumers of Data on Windows Forms" for more explanation.
    Dim cm As CurrencyManager = CType(Me.BindingContext(dg1.DataSource, _
                                                        dg1.DataMember), _
                                                        CurrencyManager)
    Dim dv As DataView = CType(cm.List, DataView)
    dv.AllowNew = False

    cmdNewCard.BackColor = Color.SandyBrown
    AddHandler cmdNewCard.Click, New EventHandler(AddressOf NewCard)

  End Sub

  Private Sub GolfCourseTabSetup()

    lblLength.BackColor = Color.LightGray

    'Slope must be between 55 and 155
    txtSlope.MaxLength = Globals.SlopeLen
    AddHandler txtSlope.KeyPress, New KeyPressEventHandler(AddressOf SlopeKeyPress)
    AddHandler txtSlope.Validating, New CancelEventHandler(AddressOf SlopeValidate)

    cmdNew.BackColor = Color.SandyBrown
    cmdNew.Font = cmdQuit.Font
    cmdNew.Image = Image.FromFile("new.ico")
    AddHandler cmdNew.Click, New EventHandler(AddressOf NewCourse)

    cmdSave.BackColor = Color.SandyBrown
    cmdSave.Font = cmdQuit.Font
    AddHandler cmdSave.Click, New EventHandler(AddressOf SaveCourse)
    cmdSave.Enabled = False

    cmdEdit.BackColor = Color.SandyBrown
    cmdEdit.Font = cmdQuit.Font
    AddHandler cmdEdit.Click, New EventHandler(AddressOf EditCourse)

    cmbPar.DropDownStyle = ComboBoxStyle.DropDownList

    cmbHoles.DropDownStyle = ComboBoxStyle.DropDownList
    cmbHoles.Items.Add(Globals.NineHoles)
    cmbHoles.Items.Add(Globals.EighteenHoles)
    AddHandler cmbHoles.SelectedIndexChanged, _
                            New EventHandler(AddressOf SelectPar)
    cmbHoles.SelectedIndex = 1

    cmbCourseName.MaxLength = 60
    cmbCourseName.DropDownStyle = ComboBoxStyle.DropDownList
    AddHandler cmbCourseName.SelectedIndexChanged, _
                             New EventHandler(AddressOf ChangeCourse)
    Dim c As ICourseInfo
    For Each c In mParent.db.GolfCourses

      cmbCourseName.Items.Add(c)
    Next
    If cmbCourseName.Items.Count > 0 Then
      cmbCourseName.SelectedIndex = 0
    End If

    AddHandler lstTees.MouseUp, New MouseEventHandler(AddressOf EditTeeBox)
  End Sub

  Private Sub TabSetup()
    tp1.BorderStyle = BorderStyle.FixedSingle
    tp1.BackColor = Color.LightGreen

    tp2.BorderStyle = BorderStyle.FixedSingle
    tp2.BackColor = Color.LightGreen

    TC.Font = New Font("Comic Sans MS", 10)
    TC.Alignment = TabAlignment.Bottom
    TC.Appearance = TabAppearance.Normal
    AddHandler TC.SelectedIndexChanged, New EventHandler(AddressOf ChangeTabPage)
  End Sub

  Private Sub SetupTeeList()
    lstTees.View = View.Details
    lstTees.GridLines = True
    lstTees.BeginUpdate()
    lstTees.Clear()
    lstTees.Columns.Add("Stats", 100, HorizontalAlignment.Left)
    Dim k As Int32
    For k = 0 To CType(cmbHoles.SelectedItem, Int32) - 1
      lstTees.Columns.Add((k + 1).ToString(), 50, HorizontalAlignment.Center)
    Next

    Dim Blue As ListViewItem = lstTees.Items.Add("Blue Tee")
    Blue.ForeColor = Color.Blue
    Dim White As ListViewItem = lstTees.Items.Add("White Tee")
    Dim Red As ListViewItem = lstTees.Items.Add("Red Tee")
    Red.ForeColor = Color.Red
    Dim Par As ListViewItem = lstTees.Items.Add("Par")

    If Not cmbCourseName.SelectedItem Is Nothing Then
      ThisCourse = CType(cmbCourseName.SelectedItem, ICourseInfo)
      Dim tee As Tees
      For Each tee In ThisCourse.Hole
        Blue.SubItems.Add(tee.BlueDistance.ToString(), Color.Blue, Color.Linen, lstTees.Font)
        White.SubItems.Add(tee.WhiteDistance.ToString(), Color.Black, Color.Linen, lstTees.Font)
        Red.SubItems.Add(tee.RedDistance.ToString(), Color.Red, Color.Linen, lstTees.Font)
        Par.SubItems.Add(tee.Par.ToString())
      Next
    End If
    lstTees.EndUpdate()
  End Sub

#End Region

#Region "DataGrid associated events"

  Private Sub CellDateClick(ByVal sender As Object, ByVal e As EventArgs)
    'Handle double clicking on the date field
    'If you want you can bring up a calendar dialog here to make it 
    'easy for the user to pick a date
  End Sub

  Private Sub CellDateKeyPress(ByVal sender As Object, _
                                ByVal e As KeyPressEventArgs)
    'Handle entering data in the date field
    If Not Regex.IsMatch(e.KeyChar.ToString(), "[0-9/-]") Then
      e.Handled = True
    End If
  End Sub

  Private Sub DateCellValidating(ByVal sender As Object, _
                                  ByVal e As CancelEventArgs)
    Debug.Assert(TypeOf (sender) Is TextBox, _
        "Sender must be a datagrid cell that is a textbox")

    Dim DateMatch As String = "[0-1]?[0-9]/[0-3]?[0-9]/[0-9]{4}$"
    If Regex.IsMatch((CType(sender, TextBox)).Text, DateMatch) Then
      If Not ThisCard Is Nothing Then
        ThisCard.PlayDate = DateTime.Parse((CType(sender, TextBox)).Text)
      Else
        e.Cancel = True
      End If
    End If
  End Sub

  Private Sub HoleScoreEntry(ByVal sender As Object, _
                                  ByVal e As KeyPressEventArgs)
    If Not Char.IsDigit(e.KeyChar) Then
      e.Handled = True
    End If
  End Sub

  Private Sub HoleScoreValidate(ByVal sender As Object, _
                                  ByVal e As CancelEventArgs)
    Debug.Assert(TypeOf (sender) Is TextBox, _
                 "Sender must be a datagrid cell that is a textbox")

    If Not ThisCard Is Nothing AndAlso Not ThisHole Is Nothing Then
      ThisHole.TotalShots = Int32.Parse((CType(sender, TextBox).Text))
      dg1(dg1.CurrentCell.RowNumber, 1) = ThisCard.RoundScore
    End If
  End Sub

  Private Sub CellChanged(ByVal sender As Object, ByVal e As EventArgs)
    Try
      ThisCard = ThisCourse.ScoreCards.Item(dg1.CurrentCell.RowNumber)
      ThisHole = ThisCard.holes.Item(dg1.CurrentCell.ColumnNumber - 2)
    Catch
      ThisCard = Nothing
      ThisHole = Nothing
    End Try
  End Sub

  Private Sub HoleScoreDblClick(ByVal sender As Object, ByVal e As EventArgs)
    Debug.Assert(TypeOf (sender) Is TextBox, _
                  "Sender must be a datagrid cell that is a textbox")

    'Get the scorecard and then get the holedetail for the scorecard
    If Not ThisCourse Is Nothing And Not ThisHole Is Nothing Then

      Dim detail As HoleDetail = New HoleDetail(ThisCourse, ThisHole)
      detail.ShowDialog()
      If detail.DialogResult = DialogResult.OK Then

        'change the underlying dataset here
        CType(sender, TextBox).Text = ThisHole.TotalShots.ToString()
      End If
      detail.Close()
      dg1.Update()
    End If
  End Sub

  Private Sub NewCard(ByVal sender As Object, ByVal e As EventArgs)
    Dim card As IScoreCardInfo = New IScoreCardInfo(ThisCourse.NumberOfHoles)
    ThisCourse.ScoreCards.Add(card)

    Dim scores As ArrayList = New ArrayList()
    scores.Add(card.PlayDate.ToShortDateString())
    scores.Add(card.RoundScore)
    Dim h As IHoleDetailInfo
    For Each h In card.holes
      h.Par = CType(ThisCourse.Hole(h.Hole - 1), Tees).Par
      scores.Add(h.TotalShots)
    Next

    Dim ds As DataSet = CType(dg1.DataSource, DataSet)
    Dim DT As DataTable = ds.Tables(dg1.DataMember)
    DT.Rows.Add(scores.ToArray())
  End Sub

#End Region

#Region "Tab Control Events"

  Private Sub ChangeTabPage(ByVal sender As Object, ByVal e As EventArgs)
    If TC.SelectedIndex = 1 Then
      If cmbCourseName.Text = String.Empty Then
        MessageBox.Show("You must choose a valid golf course.", _
                        "No Course Chosen", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Error)
        TC.SelectedIndex = 0
      Else
        'If we were editing at the time we changed tabs
        'then too bad.  We lost the edit.
        AllowEdit(False)
        SetupScoreCardDatagrid()
      End If
    End If
  End Sub

#End Region

#Region "First Tab event handlers"

  Private Sub NewCourse(ByVal sender As Object, ByVal e As EventArgs)
    Dim frm As NewCourseDlg = New NewCourseDlg()
    Try
      frm.ShowDialog()
      If frm.DialogResult = DialogResult.OK Then
        cmbCourseName.Items.Add(New ICourseInfo(frm.NewName))
        cmbCourseName.SelectedIndex = cmbCourseName.Items.Count - 1
      End If
    Finally
      'Unload and dispose of dialog
      If Not frm Is Nothing Then
        frm.Close()
      End If
    End Try
  End Sub

  Private Sub ChangeCourse(ByVal sender As Object, ByVal e As EventArgs)
    ThisCourse = CType(cmbCourseName.SelectedItem, ICourseInfo)
    'Do the holes
    Dim x As Int32
    For x = 0 To cmbHoles.Items.Count - 1
      If CType(cmbHoles.Items(x), Int32) = ThisCourse.NumberOfHoles Then
        cmbHoles.SelectedIndex = x
        Exit For
      End If
    Next
    lblLength.Text = ThisCourse.Length.ToString()
    'Do the par
    For x = 0 To cmbPar.Items.Count - 1
      If CType(cmbPar.Items(x), Int32) = CType(ThisCourse.Par, Int32) Then
        cmbPar.SelectedIndex = x
        Exit For
      End If
    Next
    'Do the Slope/length
    SetupTeeList()
    txtSlope.Text = ThisCourse.Slope.ToString()
    AllowEdit(False)
  End Sub

  Private Sub EditTeeBox(ByVal sender As Object, ByVal e As MouseEventArgs)
    Dim l As ListViewItem = lstTees.GetItemAt(e.X, e.Y)
    If Not l Is Nothing Then
      MessageBox.Show("====== " + l.Text + " ======" + vbCrLf + vbCrLf + _
        "Add code or another dialog box here to edit " + vbCrLf + _
        "the values for the subitems of this item")
    End If
  End Sub

  Private Sub SlopeKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
    Debug.Assert(sender Is txtSlope, _
                  "SlopeKeyPress method called by wrong control")

    If e.KeyChar < "0" Or e.KeyChar > "9" Then
      e.Handled = True
    End If

    '0 cannot be leading digit
    If txtSlope.Text = "" AndAlso e.KeyChar = "0" Then
      e.Handled = True
    End If
  End Sub

  Private Sub SlopeValidate(ByVal sender As Object, ByVal e As CancelEventArgs)
    Debug.Assert(sender Is txtSlope, _
                "SlopeValidate method called by wrong control")

    Try
      Dim slope As Int32 = Int32.Parse(txtSlope.Text)
      If slope < Globals.MinSlope Or slope > Globals.MaxSlope Then
        err.SetError(txtSlope, "Slope must be between 55 and 155")
        e.Cancel = True
      End If
    Catch
      err.SetError(txtSlope, "BUG: Slope must be an integer")
      e.Cancel = True
    End Try

    If (e.Cancel) Then
      txtSlope.SelectAll()
    Else
      err.SetError(txtSlope, "")
    End If
  End Sub

  Private Sub CloseProgram(ByVal sender As Object, ByVal e As EventArgs)
    Debug.Assert(sender Is cmdQuit, _
                "CloseProgram method called by wrong control")

    Close() 'Close causes disposal
  End Sub

  Private Sub SaveCourse(ByVal sender As Object, ByVal e As EventArgs)
    AllowEdit(False)

    ThisCourse.Par = CType(cmbPar.SelectedItem, CoursePar)
    ThisCourse.Slope = Int32.Parse(txtSlope.Text)

    'Since I did not add code to change the tee distances I am not going to
    'add code to save them either.
    'If you want to do this then you will need to add code here
    'to enumerate through the ThisCourse.Hole arraylist.

    mParent.db.SaveCourse(ThisCourse)
  End Sub

  Private Sub EditCourse(ByVal sender As Object, ByVal e As EventArgs)
    AllowEdit(True)
  End Sub

  Private Sub AllowEdit(ByVal state As Boolean)
    cmdEdit.Enabled = Not state
    cmdSave.Enabled = state

    lstTees.Enabled = state
    txtSlope.Enabled = state
    cmbPar.Enabled = state
    cmbHoles.Enabled = state
    cmbCourseName.Enabled = Not state
    cmdNew.Enabled = Not state
  End Sub

  Private Sub SelectPar(ByVal sender As Object, ByVal e As EventArgs)
    Debug.Assert(sender Is cmbHoles, _
                "SelectPar method called by wrong control")

    cmbPar.BeginUpdate()
    cmbPar.Items.Clear()
    If CType(cmbHoles.SelectedItem, Int32) = Globals.NineHoles Then

      cmbPar.Items.Add(CType(CoursePar._36, Int32))
      cmbPar.Items.Add(CType(CoursePar._35, Int32))
      cmbPar.Items.Add(CType(CoursePar._27, Int32))

    Else
      cmbPar.Items.Add((CType(CoursePar._72, Int32)))
      cmbPar.Items.Add(CType(CoursePar._71, Int32))
      cmbPar.Items.Add(CType(CoursePar._70, Int32))
      cmbPar.Items.Add(CType(CoursePar._54, Int32))
    End If
    cmbPar.SelectedIndex = 0
    cmbPar.EndUpdate()

    'While I am in here I need to create the listview on the fly
    'The listview depends upon the number of holes

    If Not ThisCourse Is Nothing And Not cmdEdit.Enabled Then
      ThisCourse.NumberOfHoles = CType(cmbHoles.SelectedItem, Int32)
    End If

    SetupTeeList()
  End Sub

#End Region

End Class
