Option Strict On

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    'Fill the tree view
    Dim node As TreeNode = New TreeNode("Base Inventory")
    node.Nodes.Add("Laptop 234")
    node.Nodes.Add("Desktop 831")
    node.Nodes.Add("68030 Emulator")
    node.Expand()
    T1.Nodes.Add(node)

    ' uncomment this next line to make the aspect ratio of bitmap real
    'Pic.SizeMode = PictureBoxSizeMode.AutoSize;
    Pic.Size = panel1.Size
    'Comment this next line of code out for correct aspect ratio
    Pic.SizeMode = PictureBoxSizeMode.StretchImage
    Pic.Image = Image.FromFile("floorplan.bmp")

    '      me.Resize += new EventHandler(this.DisplaySize);
    Dim c As Control
    For Each c In Me.Controls
      AddHandler c.Resize, New EventHandler(AddressOf DisplaySize)
    Next

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
  Friend WithEvents panel1 As System.Windows.Forms.Panel
  Friend WithEvents Pic As System.Windows.Forms.PictureBox
  Friend WithEvents splitter2 As System.Windows.Forms.Splitter
  Friend WithEvents T1 As System.Windows.Forms.TreeView
  Friend WithEvents splitter1 As System.Windows.Forms.Splitter
  Friend WithEvents rcT As System.Windows.Forms.RichTextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.panel1 = New System.Windows.Forms.Panel()
    Me.Pic = New System.Windows.Forms.PictureBox()
    Me.splitter2 = New System.Windows.Forms.Splitter()
    Me.T1 = New System.Windows.Forms.TreeView()
    Me.splitter1 = New System.Windows.Forms.Splitter()
    Me.rcT = New System.Windows.Forms.RichTextBox()
    Me.panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'panel1
    '
    Me.panel1.AutoScroll = True
    Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Pic})
    Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.panel1.Location = New System.Drawing.Point(144, 0)
    Me.panel1.Name = "panel1"
    Me.panel1.Size = New System.Drawing.Size(456, 366)
    Me.panel1.TabIndex = 9
    '
    'Pic
    '
    Me.Pic.BackColor = System.Drawing.Color.LightCyan
    Me.Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Pic.Location = New System.Drawing.Point(16, 24)
    Me.Pic.Name = "Pic"
    Me.Pic.Size = New System.Drawing.Size(224, 200)
    Me.Pic.TabIndex = 0
    Me.Pic.TabStop = False
    '
    'splitter2
    '
    Me.splitter2.BackColor = System.Drawing.Color.Fuchsia
    Me.splitter2.Location = New System.Drawing.Point(136, 0)
    Me.splitter2.Name = "splitter2"
    Me.splitter2.Size = New System.Drawing.Size(8, 366)
    Me.splitter2.TabIndex = 8
    Me.splitter2.TabStop = False
    '
    'T1
    '
    Me.T1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.T1.Dock = System.Windows.Forms.DockStyle.Left
    Me.T1.ImageIndex = -1
    Me.T1.Name = "T1"
    Me.T1.SelectedImageIndex = -1
    Me.T1.Size = New System.Drawing.Size(136, 366)
    Me.T1.TabIndex = 7
    '
    'splitter1
    '
    Me.splitter1.BackColor = System.Drawing.Color.Fuchsia
    Me.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit
    Me.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.splitter1.Location = New System.Drawing.Point(0, 366)
    Me.splitter1.Name = "splitter1"
    Me.splitter1.Size = New System.Drawing.Size(600, 8)
    Me.splitter1.TabIndex = 6
    Me.splitter1.TabStop = False
    '
    'rcT
    '
    Me.rcT.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.rcT.Location = New System.Drawing.Point(0, 374)
    Me.rcT.Name = "rcT"
    Me.rcT.Size = New System.Drawing.Size(600, 104)
    Me.rcT.TabIndex = 5
    Me.rcT.Text = "richTextBox1"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(600, 478)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panel1, Me.splitter2, Me.T1, Me.splitter1, Me.rcT})
    Me.MinimumSize = New System.Drawing.Size(200, 200)
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region


  Private Sub DisplaySize(ByVal sender As Object, ByVal e As EventArgs)
    rcT.AppendText("Picture Size = " + Pic.Size.ToString() + "\n")
    rcT.AppendText("Panel size = " + panel1.Size.ToString() + "\n\n")
  End Sub

End Class
