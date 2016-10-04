Public Class HoleDetail
    Inherits System.Windows.Forms.Form

#Region "locals"

  Private mHole As IHoleDetailInfo
  Private distance As Tees
  Private TeeBox As YardMarker

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New(ByRef ThisCourse As ICourseInfo, ByRef hole As IHoleDetailInfo)
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Dont forget to initailize tab order and speedkeys, etc
    BackColor = Color.LightGreen
    cmdSave.BackColor = Color.SandyBrown
    cmdCancel.BackColor = Color.SandyBrown

    mHole = hole
    lblCourse.Text = ThisCourse.Name
    Dim Tee As Tees
    For Each Tee In ThisCourse.Hole
      If Tee.HoleNumber = mHole.Hole Then
        distance = Tee
        Exit For
      End If
    Next

    lblHole.Text = "Hole: " + mHole.Hole.ToString()
    lblPar.Text = "Par: " + mHole.Par.ToString()

    AddHandler optBlue.CheckedChanged, New EventHandler(AddressOf YardClick)
    AddHandler optWhite.CheckedChanged, New EventHandler(AddressOf YardClick)
    AddHandler optRed.CheckedChanged, New EventHandler(AddressOf YardClick)
    Select Case hole.TeeBox
      Case YardMarker.Blue
        optBlue.Checked = True
        TeeBox = YardMarker.Blue
      Case YardMarker.Red
        optRed.Checked = True
        TeeBox = YardMarker.Red
      Case YardMarker.White
        optWhite.Checked = True
        TeeBox = YardMarker.White
    End Select

    'This is how you enumerate an enumeration
    'Bet you didn't know you could do this.
    Dim G As GolfClubs = GolfClubs.One_iron
    While G <= GolfClubs.Putter
      cmbFirstClub.Items.Add(G)
      If mHole.TeeClub = G Then
        cmbFirstClub.SelectedIndex = cmbFirstClub.Items.Count - 1
      End If

      cmbSecondClub.Items.Add(G)
      If mHole.ScondClub = G Then
        cmbSecondClub.SelectedIndex = cmbSecondClub.Items.Count - 1
      End If

      G += 1
    End While

    cmdSave.DialogResult = DialogResult.OK
    cmdCancel.DialogResult = DialogResult.Cancel
    AddHandler cmdSave.Click, New EventHandler(AddressOf SaveHole)

    chkFairway.Checked = hole.HitFairway
    chkGoodHit.Checked = hole.GoodSecondShot
    txtShots2Green.MaxLength = 3
    txtShots2Green.Text = hole.ShotsToGreen.ToString()
    AddHandler txtShots2Green.KeyPress, _
                          New KeyPressEventHandler(AddressOf OnlyNumbers)
    txtPutts.MaxLength = 3
    txtPutts.Text = hole.Putts.ToString()
    AddHandler txtPutts.KeyPress, _
                          New KeyPressEventHandler(AddressOf OnlyNumbers)
    txtTotal.MaxLength = 3
    txtTotal.Text = hole.TotalShots.ToString()
    AddHandler txtTotal.KeyPress, _
                          New KeyPressEventHandler(AddressOf OnlyNumbers)

    'Consider adding a databinding or validation to the totals text box 
    'so it automatically totals the shots2green and putts TextBoxes.

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
  Friend WithEvents lblCourse As System.Windows.Forms.Label
  Friend WithEvents lblHole As System.Windows.Forms.Label
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents chkGoodHit As System.Windows.Forms.CheckBox
  Friend WithEvents txtTotal As System.Windows.Forms.TextBox
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents txtPutts As System.Windows.Forms.TextBox
  Friend WithEvents label6 As System.Windows.Forms.Label
  Friend WithEvents txtShots2Green As System.Windows.Forms.TextBox
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents cmbSecondClub As System.Windows.Forms.ComboBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents chkFairway As System.Windows.Forms.CheckBox
  Friend WithEvents cmbFirstClub As System.Windows.Forms.ComboBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtYards As System.Windows.Forms.Label
  Friend WithEvents label9 As System.Windows.Forms.Label
  Friend WithEvents optWhite As System.Windows.Forms.RadioButton
  Friend WithEvents optRed As System.Windows.Forms.RadioButton
  Friend WithEvents optBlue As System.Windows.Forms.RadioButton
  Friend WithEvents lblPar As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lblCourse = New System.Windows.Forms.Label()
    Me.lblHole = New System.Windows.Forms.Label()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdSave = New System.Windows.Forms.Button()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.chkGoodHit = New System.Windows.Forms.CheckBox()
    Me.txtTotal = New System.Windows.Forms.TextBox()
    Me.label7 = New System.Windows.Forms.Label()
    Me.txtPutts = New System.Windows.Forms.TextBox()
    Me.label6 = New System.Windows.Forms.Label()
    Me.txtShots2Green = New System.Windows.Forms.TextBox()
    Me.label5 = New System.Windows.Forms.Label()
    Me.cmbSecondClub = New System.Windows.Forms.ComboBox()
    Me.label3 = New System.Windows.Forms.Label()
    Me.label4 = New System.Windows.Forms.Label()
    Me.chkFairway = New System.Windows.Forms.CheckBox()
    Me.cmbFirstClub = New System.Windows.Forms.ComboBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.txtYards = New System.Windows.Forms.Label()
    Me.label9 = New System.Windows.Forms.Label()
    Me.optWhite = New System.Windows.Forms.RadioButton()
    Me.optRed = New System.Windows.Forms.RadioButton()
    Me.optBlue = New System.Windows.Forms.RadioButton()
    Me.lblPar = New System.Windows.Forms.Label()
    Me.groupBox2.SuspendLayout()
    Me.groupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblCourse
    '
    Me.lblCourse.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCourse.Location = New System.Drawing.Point(28, 19)
    Me.lblCourse.Name = "lblCourse"
    Me.lblCourse.Size = New System.Drawing.Size(472, 16)
    Me.lblCourse.TabIndex = 27
    Me.lblCourse.Text = "Tunxis Red Course"
    Me.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lblHole
    '
    Me.lblHole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblHole.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblHole.Location = New System.Drawing.Point(372, 59)
    Me.lblHole.Name = "lblHole"
    Me.lblHole.Size = New System.Drawing.Size(96, 24)
    Me.lblHole.TabIndex = 26
    Me.lblHole.Text = "Hole:"
    '
    'cmdCancel
    '
    Me.cmdCancel.BackColor = System.Drawing.Color.SandyBrown
    Me.cmdCancel.Location = New System.Drawing.Point(428, 411)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(88, 32)
    Me.cmdCancel.TabIndex = 21
    Me.cmdCancel.Text = "&Cancel"
    '
    'cmdSave
    '
    Me.cmdSave.BackColor = System.Drawing.Color.SandyBrown
    Me.cmdSave.Location = New System.Drawing.Point(316, 411)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(88, 32)
    Me.cmdSave.TabIndex = 25
    Me.cmdSave.Text = "&Save Hole"
    '
    'groupBox2
    '
    Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkGoodHit, Me.txtTotal, Me.label7, Me.txtPutts, Me.label6, Me.txtShots2Green, Me.label5, Me.cmbSecondClub, Me.label3, Me.label4, Me.chkFairway, Me.cmbFirstClub, Me.label2, Me.label1})
    Me.groupBox2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(20, 179)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(496, 216)
    Me.groupBox2.TabIndex = 24
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Shots"
    '
    'chkGoodHit
    '
    Me.chkGoodHit.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.chkGoodHit.Location = New System.Drawing.Point(344, 88)
    Me.chkGoodHit.Name = "chkGoodHit"
    Me.chkGoodHit.Size = New System.Drawing.Size(112, 16)
    Me.chkGoodHit.TabIndex = 26
    Me.chkGoodHit.Text = "Good Hit"
    '
    'txtTotal
    '
    Me.txtTotal.BackColor = System.Drawing.Color.Linen
    Me.txtTotal.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtTotal.Location = New System.Drawing.Point(384, 160)
    Me.txtTotal.Name = "txtTotal"
    Me.txtTotal.Size = New System.Drawing.Size(40, 26)
    Me.txtTotal.TabIndex = 25
    Me.txtTotal.Text = ""
    '
    'label7
    '
    Me.label7.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label7.Location = New System.Drawing.Point(232, 168)
    Me.label7.Name = "label7"
    Me.label7.Size = New System.Drawing.Size(128, 16)
    Me.label7.TabIndex = 24
    Me.label7.Text = "Total Shots"
    '
    'txtPutts
    '
    Me.txtPutts.BackColor = System.Drawing.Color.Linen
    Me.txtPutts.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtPutts.Location = New System.Drawing.Point(176, 160)
    Me.txtPutts.Name = "txtPutts"
    Me.txtPutts.Size = New System.Drawing.Size(40, 26)
    Me.txtPutts.TabIndex = 23
    Me.txtPutts.Text = ""
    '
    'label6
    '
    Me.label6.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label6.Location = New System.Drawing.Point(24, 168)
    Me.label6.Name = "label6"
    Me.label6.Size = New System.Drawing.Size(128, 16)
    Me.label6.TabIndex = 22
    Me.label6.Text = "Putts"
    '
    'txtShots2Green
    '
    Me.txtShots2Green.BackColor = System.Drawing.Color.Linen
    Me.txtShots2Green.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtShots2Green.Location = New System.Drawing.Point(176, 120)
    Me.txtShots2Green.Name = "txtShots2Green"
    Me.txtShots2Green.Size = New System.Drawing.Size(40, 26)
    Me.txtShots2Green.TabIndex = 21
    Me.txtShots2Green.Text = ""
    '
    'label5
    '
    Me.label5.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label5.Location = New System.Drawing.Point(24, 128)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(136, 16)
    Me.label5.TabIndex = 20
    Me.label5.Text = "Shots To Green"
    '
    'cmbSecondClub
    '
    Me.cmbSecondClub.BackColor = System.Drawing.Color.Linen
    Me.cmbSecondClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbSecondClub.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmbSecondClub.Location = New System.Drawing.Point(176, 80)
    Me.cmbSecondClub.Name = "cmbSecondClub"
    Me.cmbSecondClub.Size = New System.Drawing.Size(128, 26)
    Me.cmbSecondClub.TabIndex = 19
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(120, 88)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(56, 16)
    Me.label3.TabIndex = 18
    Me.label3.Text = "Club"
    '
    'label4
    '
    Me.label4.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label4.Location = New System.Drawing.Point(24, 88)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(72, 16)
    Me.label4.TabIndex = 17
    Me.label4.Text = "2nd Shot:"
    '
    'chkFairway
    '
    Me.chkFairway.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.chkFairway.Location = New System.Drawing.Point(344, 40)
    Me.chkFairway.Name = "chkFairway"
    Me.chkFairway.Size = New System.Drawing.Size(112, 16)
    Me.chkFairway.TabIndex = 16
    Me.chkFairway.Text = "Hit Fairway"
    '
    'cmbFirstClub
    '
    Me.cmbFirstClub.BackColor = System.Drawing.Color.Linen
    Me.cmbFirstClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbFirstClub.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmbFirstClub.Location = New System.Drawing.Point(176, 32)
    Me.cmbFirstClub.Name = "cmbFirstClub"
    Me.cmbFirstClub.Size = New System.Drawing.Size(128, 26)
    Me.cmbFirstClub.TabIndex = 15
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(120, 40)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(56, 16)
    Me.label2.TabIndex = 14
    Me.label2.Text = "Club"
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(24, 40)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(72, 16)
    Me.label1.TabIndex = 13
    Me.label1.Text = "Tee Shot:"
    '
    'groupBox1
    '
    Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtYards, Me.label9, Me.optWhite, Me.optRed, Me.optBlue})
    Me.groupBox1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox1.Location = New System.Drawing.Point(20, 51)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(320, 112)
    Me.groupBox1.TabIndex = 23
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Distance"
    '
    'txtYards
    '
    Me.txtYards.BackColor = System.Drawing.Color.Linen
    Me.txtYards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.txtYards.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtYards.Location = New System.Drawing.Point(144, 56)
    Me.txtYards.Name = "txtYards"
    Me.txtYards.Size = New System.Drawing.Size(96, 16)
    Me.txtYards.TabIndex = 4
    '
    'label9
    '
    Me.label9.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label9.Location = New System.Drawing.Point(144, 40)
    Me.label9.Name = "label9"
    Me.label9.Size = New System.Drawing.Size(88, 16)
    Me.label9.TabIndex = 3
    Me.label9.Text = "Yardage"
    '
    'optWhite
    '
    Me.optWhite.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.optWhite.Location = New System.Drawing.Point(24, 56)
    Me.optWhite.Name = "optWhite"
    Me.optWhite.Size = New System.Drawing.Size(96, 16)
    Me.optWhite.TabIndex = 2
    Me.optWhite.Text = "White Tees"
    '
    'optRed
    '
    Me.optRed.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.optRed.Location = New System.Drawing.Point(24, 80)
    Me.optRed.Name = "optRed"
    Me.optRed.Size = New System.Drawing.Size(96, 16)
    Me.optRed.TabIndex = 1
    Me.optRed.Text = "Red Tees"
    '
    'optBlue
    '
    Me.optBlue.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.optBlue.Location = New System.Drawing.Point(24, 32)
    Me.optBlue.Name = "optBlue"
    Me.optBlue.Size = New System.Drawing.Size(96, 16)
    Me.optBlue.TabIndex = 0
    Me.optBlue.Text = "Blue Tees"
    '
    'lblPar
    '
    Me.lblPar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblPar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPar.Location = New System.Drawing.Point(372, 91)
    Me.lblPar.Name = "lblPar"
    Me.lblPar.Size = New System.Drawing.Size(96, 24)
    Me.lblPar.TabIndex = 22
    Me.lblPar.Text = "Par:"
    '
    'HoleDetail
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(536, 462)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCourse, Me.lblHole, Me.cmdCancel, Me.cmdSave, Me.groupBox2, Me.groupBox1, Me.lblPar})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "HoleDetail"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "HoleDetail"
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "events"

  Private Sub OnlyNumbers(ByVal sender As Object, ByVal e As KeyPressEventArgs)
    'Allow only positive numbers
    If Not Char.IsDigit(e.KeyChar) Then
      e.Handled = True
    End If
  End Sub

  Private Sub YardClick(ByVal sender As Object, ByVal e As EventArgs)
    If optBlue.Checked Then
      txtYards.Text = distance.BlueDistance.ToString()
      TeeBox = YardMarker.Blue
    ElseIf optWhite.Checked Then
      txtYards.Text = distance.WhiteDistance.ToString()
      TeeBox = YardMarker.White
    ElseIf optRed.Checked Then
      txtYards.Text = distance.RedDistance.ToString()
      TeeBox = YardMarker.Blue
    End If
  End Sub

  Private Sub SaveHole(ByVal sender As Object, ByVal e As EventArgs)
    mHole.GoodSecondShot = chkFairway.Checked
    mHole.GoodSecondShot = chkGoodHit.Checked
    mHole.Putts = Int32.Parse(txtPutts.Text)
    mHole.ScondClub = CType(cmbSecondClub.SelectedItem, GolfClubs)
    mHole.ShotsToGreen = Int32.Parse(txtShots2Green.Text)
    mHole.TeeBox = TeeBox
    mHole.TeeClub = CType(cmbFirstClub.SelectedItem, GolfClubs)
    mHole.TotalShots = Int32.Parse(txtTotal.Text)
  End Sub

#End Region

End Class
