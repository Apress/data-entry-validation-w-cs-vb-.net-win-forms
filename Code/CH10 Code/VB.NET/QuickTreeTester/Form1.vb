Option Strict On

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing.Drawing2D

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region "Class local storage"

  Private mStartPoint As Point
  Private mLastPoint As Point
  Private mPath As GraphicsPath
  Private mInvalidRect As Rectangle

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Set Drawing Panel Properties
    P1.BackColor = Color.Bisque
    AddHandler P1.Paint, New PaintEventHandler(AddressOf PanelPaint)
    AddHandler P1.MouseDown, New MouseEventHandler(AddressOf M_Down)
    AddHandler P1.MouseUp, New MouseEventHandler(AddressOf M_Up)
    AddHandler P1.MouseMove, New MouseEventHandler(AddressOf M_Move)
    mPath = New GraphicsPath()

    'Set double buffer to ameliorate screen flicker
    Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    Me.SetStyle(ControlStyles.DoubleBuffer, True)

    AddHandler cmdFill.Click, New EventHandler(AddressOf FillTree)
    AddHandler txtNodes.KeyPress, New KeyPressEventHandler(AddressOf _
                                                            AllowNumbers)
    AddHandler qt.FillComplete, New EventHandler(AddressOf TreeComplete)

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
  Friend WithEvents P1 As System.Windows.Forms.Panel
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents txtNodes As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents cmdFill As System.Windows.Forms.Button
  Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
  Friend WithEvents qt As QuickTree_vb.QuickTree
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.P1 = New System.Windows.Forms.Panel()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.txtNodes = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.cmdFill = New System.Windows.Forms.Button()
    Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
    Me.qt = New QuickTree_vb.QuickTree()
    Me.groupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'P1
    '
    Me.P1.Location = New System.Drawing.Point(300, 234)
    Me.P1.Name = "P1"
    Me.P1.Size = New System.Drawing.Size(248, 184)
    Me.P1.TabIndex = 10
    '
    'groupBox1
    '
    Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.qt, Me.label2, Me.txtNodes, Me.label1, Me.cmdFill})
    Me.groupBox1.Location = New System.Drawing.Point(20, 18)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(256, 400)
    Me.groupBox1.TabIndex = 9
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Node Tester"
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(32, 16)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(192, 16)
    Me.label2.TabIndex = 9
    Me.label2.Text = "Multithreaded Nodes"
    Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'txtNodes
    '
    Me.txtNodes.Location = New System.Drawing.Point(88, 320)
    Me.txtNodes.Name = "txtNodes"
    Me.txtNodes.Size = New System.Drawing.Size(64, 20)
    Me.txtNodes.TabIndex = 8
    Me.txtNodes.Text = "1000"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(40, 320)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(40, 16)
    Me.label1.TabIndex = 7
    Me.label1.Text = "Nodes"
    '
    'cmdFill
    '
    Me.cmdFill.Location = New System.Drawing.Point(32, 352)
    Me.cmdFill.Name = "cmdFill"
    Me.cmdFill.Size = New System.Drawing.Size(192, 32)
    Me.cmdFill.TabIndex = 6
    Me.cmdFill.Text = "Fill"
    '
    'richTextBox1
    '
    Me.richTextBox1.AcceptsTab = True
    Me.richTextBox1.Location = New System.Drawing.Point(300, 26)
    Me.richTextBox1.Name = "richTextBox1"
    Me.richTextBox1.Size = New System.Drawing.Size(248, 184)
    Me.richTextBox1.TabIndex = 8
    Me.richTextBox1.Text = "Type Some Text Here:"
    '
    'qt
    '
    Me.qt.Location = New System.Drawing.Point(32, 32)
    Me.qt.Name = "qt"
    Me.qt.Size = New System.Drawing.Size(192, 272)
    Me.qt.TabIndex = 10
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(568, 437)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.P1, Me.groupBox1, Me.richTextBox1})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.groupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

  Private Sub AllowNumbers(ByVal sender As Object, ByVal e As KeyPressEventArgs)
    If Not Char.IsNumber(e.KeyChar) AndAlso e.KeyChar <> 8.ToString() Then
      e.Handled = True
    End If
  End Sub

  Private Sub TreeComplete(ByVal sender As Object, ByVal e As EventArgs)
    MessageBox.Show("Tree is done filling")
  End Sub

  Private Sub FillTree(ByVal sender As Object, ByVal e As EventArgs)
    Dim s As ArrayList = New ArrayList()
    Dim x As Int32 = Int32.Parse(txtNodes.Text)
    Dim k As Int32

    For k = 0 To x - 1
      s.Add(k.ToString())
    Next
    s.TrimToSize()

    'Do not try to bypass the fill without knowing that it is ok
    If qt.OK2Fill Then
      qt.tree.Nodes.Clear()
      Dim n As TreeNode = qt.tree.Nodes.Add("BaseNode")
      qt.Strings = s
      qt.StartFill(n)
    End If
  End Sub

#Region "Panel Painting code"

  Private Sub PanelPaint(ByVal sender As Object, ByVal e As PaintEventArgs)
    Dim G As Graphics = e.Graphics

    G.SmoothingMode = SmoothingMode.HighSpeed

    If mPath.PointCount > 0 Then
      G.DrawPath(Pens.Black, mPath)
    End If

    G.DrawRectangle(Pens.Red, 0, 0, P1.Width - 1, P1.Height - 1)
  End Sub

  Private Sub M_Down(ByVal sender As Object, ByVal m As MouseEventArgs)
    If m.Button = MouseButtons.Left Then
      mStartPoint = New Point(m.X, m.Y)
      mLastPoint = mStartPoint
      mPath = New GraphicsPath()
      P1.Invalidate()
    End If
  End Sub

  Private Sub M_Up(ByVal sender As Object, ByVal m As MouseEventArgs)
    mPath.CloseFigure()
    P1.Cursor = Cursors.Default

    P1.Invalidate()
  End Sub

  Private Sub M_Move(ByVal sender As Object, ByVal m As MouseEventArgs)
    If m.Button = MouseButtons.Left Then
      mPath.AddLine(mLastPoint.X, mLastPoint.Y, m.X, m.Y)
      mLastPoint.X = m.X
      mLastPoint.Y = m.Y

      mInvalidRect = Rectangle.Truncate(mPath.GetBounds())
      mInvalidRect.Inflate(New Size(2, 2))
      P1.Invalidate(mInvalidRect)
    End If
  End Sub

#End Region

End Class
