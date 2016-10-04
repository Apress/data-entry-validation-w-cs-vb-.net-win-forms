Option Strict On

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    AddHandler Tree.MouseDown, AddressOf RightClick
    AddHandler chkP1.MouseDown, AddressOf RightClick
    AddHandler chkP2.MouseDown, AddressOf RightClick
    AddHandler chkP3.MouseDown, AddressOf RightClick
    AddHandler picA.MouseDown, AddressOf RightClick
    AddHandler picB.MouseDown, AddressOf RightClick
    AddHandler picC.MouseDown, AddressOf RightClick
    Dim part As SomePart

    'Put the first part in the tree and the checkbox and the image
    part = New SomePart()
    Dim Node As TreeNode = New TreeNode()
    Node.Text = part.ID
    Node.Tag = part
    Tree.Nodes.Add(Node)
    chkP1.Text = part.ID
    chkP1.Tag = part
    picA.Image = part.img
    picA.Tag = part

    part = New SomePart()
    Node = New TreeNode()
    Node.Text = part.ID
    Node.Tag = part
    Tree.Nodes.Add(Node)
    chkP2.Text = part.ID
    chkP2.Tag = part
    picB.Image = part.img
    picB.Tag = part

    part = New SomePart()
    Node = New TreeNode()
    Node.Text = part.ID
    Node.Tag = part
    Tree.Nodes.Add(Node)
    chkP3.Text = part.ID
    chkP3.Tag = part
    picC.Image = part.img
    picC.Tag = part

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
  Friend WithEvents picC As System.Windows.Forms.PictureBox
  Friend WithEvents picB As System.Windows.Forms.PictureBox
  Friend WithEvents picA As System.Windows.Forms.PictureBox
  Friend WithEvents cmdQuit As System.Windows.Forms.Button
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents chkP3 As System.Windows.Forms.CheckBox
  Friend WithEvents chkP2 As System.Windows.Forms.CheckBox
  Friend WithEvents chkP1 As System.Windows.Forms.CheckBox
  Friend WithEvents Tree As System.Windows.Forms.TreeView
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.picC = New System.Windows.Forms.PictureBox()
    Me.picB = New System.Windows.Forms.PictureBox()
    Me.picA = New System.Windows.Forms.PictureBox()
    Me.cmdQuit = New System.Windows.Forms.Button()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.chkP3 = New System.Windows.Forms.CheckBox()
    Me.chkP2 = New System.Windows.Forms.CheckBox()
    Me.chkP1 = New System.Windows.Forms.CheckBox()
    Me.Tree = New System.Windows.Forms.TreeView()
    Me.groupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'picC
    '
    Me.picC.BackColor = System.Drawing.Color.Linen
    Me.picC.Location = New System.Drawing.Point(364, 179)
    Me.picC.Name = "picC"
    Me.picC.Size = New System.Drawing.Size(32, 32)
    Me.picC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.picC.TabIndex = 11
    Me.picC.TabStop = False
    '
    'picB
    '
    Me.picB.BackColor = System.Drawing.Color.Linen
    Me.picB.Location = New System.Drawing.Point(300, 179)
    Me.picB.Name = "picB"
    Me.picB.Size = New System.Drawing.Size(32, 32)
    Me.picB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.picB.TabIndex = 10
    Me.picB.TabStop = False
    '
    'picA
    '
    Me.picA.BackColor = System.Drawing.Color.Linen
    Me.picA.Location = New System.Drawing.Point(236, 179)
    Me.picA.Name = "picA"
    Me.picA.Size = New System.Drawing.Size(32, 32)
    Me.picA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.picA.TabIndex = 9
    Me.picA.TabStop = False
    '
    'cmdQuit
    '
    Me.cmdQuit.Location = New System.Drawing.Point(332, 227)
    Me.cmdQuit.Name = "cmdQuit"
    Me.cmdQuit.Size = New System.Drawing.Size(72, 32)
    Me.cmdQuit.TabIndex = 8
    Me.cmdQuit.Text = "Quit"
    '
    'groupBox1
    '
    Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkP3, Me.chkP2, Me.chkP1})
    Me.groupBox1.Location = New System.Drawing.Point(236, 19)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(168, 144)
    Me.groupBox1.TabIndex = 7
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Parts"
    '
    'chkP3
    '
    Me.chkP3.BackColor = System.Drawing.Color.SeaShell
    Me.chkP3.Location = New System.Drawing.Point(16, 96)
    Me.chkP3.Name = "chkP3"
    Me.chkP3.Size = New System.Drawing.Size(136, 16)
    Me.chkP3.TabIndex = 6
    '
    'chkP2
    '
    Me.chkP2.BackColor = System.Drawing.Color.SeaShell
    Me.chkP2.Location = New System.Drawing.Point(16, 64)
    Me.chkP2.Name = "chkP2"
    Me.chkP2.Size = New System.Drawing.Size(136, 16)
    Me.chkP2.TabIndex = 5
    '
    'chkP1
    '
    Me.chkP1.BackColor = System.Drawing.Color.SeaShell
    Me.chkP1.Location = New System.Drawing.Point(16, 32)
    Me.chkP1.Name = "chkP1"
    Me.chkP1.Size = New System.Drawing.Size(136, 16)
    Me.chkP1.TabIndex = 4
    '
    'Tree
    '
    Me.Tree.BackColor = System.Drawing.Color.Linen
    Me.Tree.ImageIndex = -1
    Me.Tree.Location = New System.Drawing.Point(36, 19)
    Me.Tree.Name = "Tree"
    Me.Tree.SelectedImageIndex = -1
    Me.Tree.Size = New System.Drawing.Size(184, 224)
    Me.Tree.TabIndex = 6
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(440, 278)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.picC, Me.picB, Me.picA, Me.cmdQuit, Me.groupBox1, Me.Tree})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.groupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Dim Engine As SomePart

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

#Region "Mouse Events"

  Private Sub RightClick(ByVal sender As Object, ByVal e As MouseEventArgs)

    If e.Button <> MouseButtons.Right Then Return

    If sender.GetType() Is GetType(TreeView) Then
      Engine = CType(Tree.SelectedNode.Tag, SomePart)
    ElseIf sender.GetType() Is GetType(PictureBox) Then
      Dim p As PictureBox = CType(sender, PictureBox)
      Engine = CType(p.Tag, SomePart)
    ElseIf sender.GetType() Is GetType(CheckBox) Then
      Dim c As CheckBox = CType(sender, CheckBox)
      Engine = CType(c.Tag, SomePart)
    End If

    Engine.ShowMenu(CType(sender, Control), New Point(e.X, e.Y))

  End Sub

#End Region

  Private Sub cmdQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuit.Click
    Me.Close()
  End Sub
End Class
