Option Strict On

Public Class Statistics
  Inherits System.Windows.Forms.Form

#Region "locals"

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
    Init()

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
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents lblOther As System.Windows.Forms.Label
  Friend WithEvents label26 As System.Windows.Forms.Label
  Friend WithEvents lblDoubles As System.Windows.Forms.Label
  Friend WithEvents label28 As System.Windows.Forms.Label
  Friend WithEvents lblBogies As System.Windows.Forms.Label
  Friend WithEvents label30 As System.Windows.Forms.Label
  Friend WithEvents lblEagles As System.Windows.Forms.Label
  Friend WithEvents label24 As System.Windows.Forms.Label
  Friend WithEvents lblBirdies As System.Windows.Forms.Label
  Friend WithEvents label20 As System.Windows.Forms.Label
  Friend WithEvents lblPars As System.Windows.Forms.Label
  Friend WithEvents label22 As System.Windows.Forms.Label
  Friend WithEvents lblHandicap As System.Windows.Forms.Label
  Friend WithEvents label18 As System.Windows.Forms.Label
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents lblMinPutts As System.Windows.Forms.Label
  Friend WithEvents label16 As System.Windows.Forms.Label
  Friend WithEvents lblAvgPutts As System.Windows.Forms.Label
  Friend WithEvents label14 As System.Windows.Forms.Label
  Friend WithEvents lblMaxPutts As System.Windows.Forms.Label
  Friend WithEvents label12 As System.Windows.Forms.Label
  Friend WithEvents label8 As System.Windows.Forms.Label
  Friend WithEvents lblPutting As System.Windows.Forms.Label
  Friend WithEvents label10 As System.Windows.Forms.Label
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents lblGreens As System.Windows.Forms.Label
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents lblFairwaysHit As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents tvwCourse As System.Windows.Forms.TreeView
  Friend WithEvents imgIcons As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.cmdClose = New System.Windows.Forms.Button()
    Me.label1 = New System.Windows.Forms.Label()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.groupBox3 = New System.Windows.Forms.GroupBox()
    Me.lblOther = New System.Windows.Forms.Label()
    Me.label26 = New System.Windows.Forms.Label()
    Me.lblDoubles = New System.Windows.Forms.Label()
    Me.label28 = New System.Windows.Forms.Label()
    Me.lblBogies = New System.Windows.Forms.Label()
    Me.label30 = New System.Windows.Forms.Label()
    Me.lblEagles = New System.Windows.Forms.Label()
    Me.label24 = New System.Windows.Forms.Label()
    Me.lblBirdies = New System.Windows.Forms.Label()
    Me.label20 = New System.Windows.Forms.Label()
    Me.lblPars = New System.Windows.Forms.Label()
    Me.label22 = New System.Windows.Forms.Label()
    Me.lblHandicap = New System.Windows.Forms.Label()
    Me.label18 = New System.Windows.Forms.Label()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.lblMinPutts = New System.Windows.Forms.Label()
    Me.label16 = New System.Windows.Forms.Label()
    Me.lblAvgPutts = New System.Windows.Forms.Label()
    Me.label14 = New System.Windows.Forms.Label()
    Me.lblMaxPutts = New System.Windows.Forms.Label()
    Me.label12 = New System.Windows.Forms.Label()
    Me.label8 = New System.Windows.Forms.Label()
    Me.lblPutting = New System.Windows.Forms.Label()
    Me.label10 = New System.Windows.Forms.Label()
    Me.label5 = New System.Windows.Forms.Label()
    Me.lblGreens = New System.Windows.Forms.Label()
    Me.label7 = New System.Windows.Forms.Label()
    Me.label4 = New System.Windows.Forms.Label()
    Me.lblFairwaysHit = New System.Windows.Forms.Label()
    Me.label2 = New System.Windows.Forms.Label()
    Me.tvwCourse = New System.Windows.Forms.TreeView()
    Me.imgIcons = New System.Windows.Forms.ImageList(Me.components)
    Me.groupBox1.SuspendLayout()
    Me.groupBox3.SuspendLayout()
    Me.groupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmdClose
    '
    Me.cmdClose.Location = New System.Drawing.Point(564, 455)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(80, 32)
    Me.cmdClose.TabIndex = 7
    Me.cmdClose.Text = "Close"
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(20, 15)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(200, 16)
    Me.label1.TabIndex = 6
    Me.label1.Text = "Golf Games"
    Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'groupBox1
    '
    Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox3, Me.lblHandicap, Me.label18, Me.groupBox2, Me.label8, Me.lblPutting, Me.label10, Me.label5, Me.lblGreens, Me.label7, Me.label4, Me.lblFairwaysHit, Me.label2})
    Me.groupBox1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox1.Location = New System.Drawing.Point(236, 15)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(408, 424)
    Me.groupBox1.TabIndex = 5
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Statistics"
    '
    'groupBox3
    '
    Me.groupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblOther, Me.label26, Me.lblDoubles, Me.label28, Me.lblBogies, Me.label30, Me.lblEagles, Me.label24, Me.lblBirdies, Me.label20, Me.lblPars, Me.label22})
    Me.groupBox3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox3.Location = New System.Drawing.Point(24, 272)
    Me.groupBox3.Name = "groupBox3"
    Me.groupBox3.Size = New System.Drawing.Size(344, 104)
    Me.groupBox3.TabIndex = 16
    Me.groupBox3.TabStop = False
    Me.groupBox3.Text = "Totals"
    '
    'lblOther
    '
    Me.lblOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblOther.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblOther.Location = New System.Drawing.Point(296, 64)
    Me.lblOther.Name = "lblOther"
    Me.lblOther.Size = New System.Drawing.Size(32, 16)
    Me.lblOther.TabIndex = 27
    '
    'label26
    '
    Me.label26.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label26.Location = New System.Drawing.Point(232, 64)
    Me.label26.Name = "label26"
    Me.label26.Size = New System.Drawing.Size(64, 16)
    Me.label26.TabIndex = 26
    Me.label26.Text = "Other"
    '
    'lblDoubles
    '
    Me.lblDoubles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblDoubles.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblDoubles.Location = New System.Drawing.Point(176, 64)
    Me.lblDoubles.Name = "lblDoubles"
    Me.lblDoubles.Size = New System.Drawing.Size(32, 16)
    Me.lblDoubles.TabIndex = 25
    '
    'label28
    '
    Me.label28.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label28.Location = New System.Drawing.Point(112, 64)
    Me.label28.Name = "label28"
    Me.label28.Size = New System.Drawing.Size(64, 16)
    Me.label28.TabIndex = 24
    Me.label28.Text = "Dbl Bogies"
    '
    'lblBogies
    '
    Me.lblBogies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblBogies.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblBogies.Location = New System.Drawing.Point(64, 64)
    Me.lblBogies.Name = "lblBogies"
    Me.lblBogies.Size = New System.Drawing.Size(32, 16)
    Me.lblBogies.TabIndex = 23
    '
    'label30
    '
    Me.label30.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label30.Location = New System.Drawing.Point(8, 64)
    Me.label30.Name = "label30"
    Me.label30.Size = New System.Drawing.Size(64, 16)
    Me.label30.TabIndex = 22
    Me.label30.Text = "Bogies"
    '
    'lblEagles
    '
    Me.lblEagles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblEagles.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblEagles.Location = New System.Drawing.Point(296, 32)
    Me.lblEagles.Name = "lblEagles"
    Me.lblEagles.Size = New System.Drawing.Size(32, 16)
    Me.lblEagles.TabIndex = 21
    '
    'label24
    '
    Me.label24.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label24.Location = New System.Drawing.Point(232, 32)
    Me.label24.Name = "label24"
    Me.label24.Size = New System.Drawing.Size(64, 16)
    Me.label24.TabIndex = 20
    Me.label24.Text = "Eagles"
    '
    'lblBirdies
    '
    Me.lblBirdies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblBirdies.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblBirdies.Location = New System.Drawing.Point(176, 32)
    Me.lblBirdies.Name = "lblBirdies"
    Me.lblBirdies.Size = New System.Drawing.Size(32, 16)
    Me.lblBirdies.TabIndex = 19
    '
    'label20
    '
    Me.label20.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label20.Location = New System.Drawing.Point(112, 32)
    Me.label20.Name = "label20"
    Me.label20.Size = New System.Drawing.Size(64, 16)
    Me.label20.TabIndex = 18
    Me.label20.Text = "Birdies"
    '
    'lblPars
    '
    Me.lblPars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblPars.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPars.Location = New System.Drawing.Point(64, 32)
    Me.lblPars.Name = "lblPars"
    Me.lblPars.Size = New System.Drawing.Size(32, 16)
    Me.lblPars.TabIndex = 17
    '
    'label22
    '
    Me.label22.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label22.Location = New System.Drawing.Point(8, 32)
    Me.label22.Name = "label22"
    Me.label22.Size = New System.Drawing.Size(64, 16)
    Me.label22.TabIndex = 16
    Me.label22.Text = "Pars"
    '
    'lblHandicap
    '
    Me.lblHandicap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblHandicap.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblHandicap.Location = New System.Drawing.Point(168, 392)
    Me.lblHandicap.Name = "lblHandicap"
    Me.lblHandicap.Size = New System.Drawing.Size(48, 16)
    Me.lblHandicap.TabIndex = 13
    '
    'label18
    '
    Me.label18.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label18.Location = New System.Drawing.Point(24, 392)
    Me.label18.Name = "label18"
    Me.label18.Size = New System.Drawing.Size(136, 16)
    Me.label18.TabIndex = 12
    Me.label18.Text = "Raw Handicap"
    '
    'groupBox2
    '
    Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMinPutts, Me.label16, Me.lblAvgPutts, Me.label14, Me.lblMaxPutts, Me.label12})
    Me.groupBox2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(16, 144)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(192, 112)
    Me.groupBox2.TabIndex = 11
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Putts per hole"
    '
    'lblMinPutts
    '
    Me.lblMinPutts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblMinPutts.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblMinPutts.Location = New System.Drawing.Point(120, 80)
    Me.lblMinPutts.Name = "lblMinPutts"
    Me.lblMinPutts.Size = New System.Drawing.Size(48, 16)
    Me.lblMinPutts.TabIndex = 16
    '
    'label16
    '
    Me.label16.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label16.Location = New System.Drawing.Point(16, 80)
    Me.label16.Name = "label16"
    Me.label16.Size = New System.Drawing.Size(96, 16)
    Me.label16.TabIndex = 15
    Me.label16.Text = "Min."
    '
    'lblAvgPutts
    '
    Me.lblAvgPutts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblAvgPutts.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblAvgPutts.Location = New System.Drawing.Point(120, 56)
    Me.lblAvgPutts.Name = "lblAvgPutts"
    Me.lblAvgPutts.Size = New System.Drawing.Size(48, 16)
    Me.lblAvgPutts.TabIndex = 14
    '
    'label14
    '
    Me.label14.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label14.Location = New System.Drawing.Point(16, 56)
    Me.label14.Name = "label14"
    Me.label14.Size = New System.Drawing.Size(96, 16)
    Me.label14.TabIndex = 13
    Me.label14.Text = "Avg."
    '
    'lblMaxPutts
    '
    Me.lblMaxPutts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblMaxPutts.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblMaxPutts.Location = New System.Drawing.Point(120, 32)
    Me.lblMaxPutts.Name = "lblMaxPutts"
    Me.lblMaxPutts.Size = New System.Drawing.Size(48, 16)
    Me.lblMaxPutts.TabIndex = 12
    '
    'label12
    '
    Me.label12.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label12.Location = New System.Drawing.Point(16, 32)
    Me.label12.Name = "label12"
    Me.label12.Size = New System.Drawing.Size(96, 16)
    Me.label12.TabIndex = 11
    Me.label12.Text = "Max."
    '
    'label8
    '
    Me.label8.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label8.Location = New System.Drawing.Point(216, 96)
    Me.label8.Name = "label8"
    Me.label8.Size = New System.Drawing.Size(24, 16)
    Me.label8.TabIndex = 8
    Me.label8.Text = "%"
    '
    'lblPutting
    '
    Me.lblPutting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblPutting.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPutting.Location = New System.Drawing.Point(160, 96)
    Me.lblPutting.Name = "lblPutting"
    Me.lblPutting.Size = New System.Drawing.Size(48, 16)
    Me.lblPutting.TabIndex = 7
    '
    'label10
    '
    Me.label10.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label10.Location = New System.Drawing.Point(16, 96)
    Me.label10.Name = "label10"
    Me.label10.Size = New System.Drawing.Size(136, 16)
    Me.label10.TabIndex = 6
    Me.label10.Text = "Putting"
    '
    'label5
    '
    Me.label5.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label5.Location = New System.Drawing.Point(216, 64)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(24, 16)
    Me.label5.TabIndex = 5
    Me.label5.Text = "%"
    '
    'lblGreens
    '
    Me.lblGreens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblGreens.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblGreens.Location = New System.Drawing.Point(160, 64)
    Me.lblGreens.Name = "lblGreens"
    Me.lblGreens.Size = New System.Drawing.Size(48, 16)
    Me.lblGreens.TabIndex = 4
    '
    'label7
    '
    Me.label7.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label7.Location = New System.Drawing.Point(16, 64)
    Me.label7.Name = "label7"
    Me.label7.Size = New System.Drawing.Size(136, 16)
    Me.label7.TabIndex = 3
    Me.label7.Text = "Greens in regulation"
    '
    'label4
    '
    Me.label4.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label4.Location = New System.Drawing.Point(216, 32)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(24, 16)
    Me.label4.TabIndex = 2
    Me.label4.Text = "%"
    '
    'lblFairwaysHit
    '
    Me.lblFairwaysHit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblFairwaysHit.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblFairwaysHit.Location = New System.Drawing.Point(160, 32)
    Me.lblFairwaysHit.Name = "lblFairwaysHit"
    Me.lblFairwaysHit.Size = New System.Drawing.Size(48, 16)
    Me.lblFairwaysHit.TabIndex = 1
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(16, 32)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(136, 16)
    Me.label2.TabIndex = 0
    Me.label2.Text = "Fairways Hit"
    '
    'tvwCourse
    '
    Me.tvwCourse.ImageIndex = -1
    Me.tvwCourse.Location = New System.Drawing.Point(20, 31)
    Me.tvwCourse.Name = "tvwCourse"
    Me.tvwCourse.SelectedImageIndex = -1
    Me.tvwCourse.Size = New System.Drawing.Size(200, 408)
    Me.tvwCourse.TabIndex = 4
    '
    'imgIcons
    '
    Me.imgIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
    Me.imgIcons.ImageSize = New System.Drawing.Size(16, 16)
    Me.imgIcons.TransparentColor = System.Drawing.Color.Transparent
    '
    'Statistics
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(664, 503)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClose, Me.label1, Me.groupBox1, Me.tvwCourse})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "Statistics"
    Me.Text = "Statistics"
    Me.groupBox1.ResumeLayout(False)
    Me.groupBox3.ResumeLayout(False)
    Me.groupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Statistics_Load(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) Handles MyBase.Load
    mParent = CType(Me.MdiParent, GolfStat)
    SetupTree()

  End Sub

#Region "Setup"

  Private Sub Init()
    BackColor = Color.LightGreen
    cmdClose.BackColor = Color.SandyBrown
    cmdClose.Text = "&Close"
    cmdClose.TabIndex = 0
    AddHandler cmdClose.Click, New EventHandler(AddressOf CloseMe)
    imgIcons.Images.Add(Image.FromFile("flag.ico"))
  End Sub

  Private Sub SetupTree()
    Dim CourseNode As TreeNode
    Dim CardNode As TreeNode

    tvwCourse.Nodes.Clear()
    tvwCourse.BeginUpdate()

    tvwCourse.ImageList = imgIcons
    tvwCourse.ImageIndex = 0
    tvwCourse.SelectedImageIndex = 0
    Dim c As ICourseInfo
    For Each c In mParent.db.GolfCourses
      CourseNode = tvwCourse.Nodes.Add(c.Name)
      CourseNode.Tag = c
      Dim card As IScoreCardInfo
      For Each card In c.ScoreCards
        CardNode = CourseNode.Nodes.Add(card.PlayDate.ToShortDateString())
        CardNode.Tag = card
      Next
    Next

    AddHandler tvwCourse.AfterSelect, _
                         New TreeViewEventHandler(AddressOf CourseStats)
    tvwCourse.EndUpdate()
  End Sub


#End Region

#Region "events"

  Public Sub CloseMe(ByVal s As Object, ByVal e As EventArgs)
    Close()
  End Sub

  Private Sub CourseStats(ByVal s As Object, ByVal e As TreeViewEventArgs)
    Dim FairwaysHit As Single = 0
    Dim GreensInReg As Single = 0
    Dim Putting As Single = 0
    Dim MaxPutts As Single = 0
    Dim MinPutts As Single = 99
    Dim AvgPutts As Single = 0

    If TypeOf (e.Node.Tag) Is IScoreCardInfo Then

      ThisCard = CType(e.Node.Tag, IScoreCardInfo)
      Dim h As IHoleDetailInfo
      For Each h In ThisCard.holes
        If h.HitFairway Then FairwaysHit += 1
        If h.GreenInReg Then GreensInReg += 1
        Putting += h.Putts
        If h.Putts > MaxPutts Then MaxPutts = h.Putts
        If h.Putts < MinPutts Then MinPutts = h.Putts
        AvgPutts += h.Putts
      Next
      FairwaysHit /= ThisCard.holes.Count
      Putting /= (ThisCard.holes.Count * 2)
      GreensInReg /= ThisCard.holes.Count
      AvgPutts /= ThisCard.holes.Count

      lblFairwaysHit.Text = (FairwaysHit * 100).ToString()
      lblGreens.Text = (GreensInReg * 100).ToString()
      lblPutting.Text = (Putting * 100).ToString()
      lblMaxPutts.Text = MaxPutts.ToString()
      lblAvgPutts.Text = AvgPutts.ToString()
      lblMinPutts.Text = MinPutts.ToString()

      'I will let you figure out the rest of the stats. :)

    End If
  End Sub

#End Region

End Class
