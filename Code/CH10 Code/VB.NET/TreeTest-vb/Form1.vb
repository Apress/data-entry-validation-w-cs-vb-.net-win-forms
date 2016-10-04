Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
  Friend WithEvents cmdClear As System.Windows.Forms.Button
  Friend WithEvents lblClear As System.Windows.Forms.Label
  Friend WithEvents cmdFill As System.Windows.Forms.Button
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents txtMax As System.Windows.Forms.TextBox
  Friend WithEvents lblFill As System.Windows.Forms.Label
  Friend WithEvents Tree As System.Windows.Forms.TreeView
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdClear = New System.Windows.Forms.Button()
    Me.lblClear = New System.Windows.Forms.Label()
    Me.cmdFill = New System.Windows.Forms.Button()
    Me.label1 = New System.Windows.Forms.Label()
    Me.txtMax = New System.Windows.Forms.TextBox()
    Me.lblFill = New System.Windows.Forms.Label()
    Me.Tree = New System.Windows.Forms.TreeView()
    Me.SuspendLayout()
    '
    'cmdClear
    '
    Me.cmdClear.Location = New System.Drawing.Point(16, 400)
    Me.cmdClear.Name = "cmdClear"
    Me.cmdClear.Size = New System.Drawing.Size(224, 24)
    Me.cmdClear.TabIndex = 13
    Me.cmdClear.Text = "Clear"
    '
    'lblClear
    '
    Me.lblClear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblClear.Location = New System.Drawing.Point(16, 432)
    Me.lblClear.Name = "lblClear"
    Me.lblClear.Size = New System.Drawing.Size(224, 24)
    Me.lblClear.TabIndex = 12
    '
    'cmdFill
    '
    Me.cmdFill.Location = New System.Drawing.Point(16, 328)
    Me.cmdFill.Name = "cmdFill"
    Me.cmdFill.Size = New System.Drawing.Size(224, 24)
    Me.cmdFill.TabIndex = 11
    Me.cmdFill.Text = "Fill"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(16, 280)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(160, 16)
    Me.label1.TabIndex = 10
    Me.label1.Text = "Max nodes to fill in at one time"
    '
    'txtMax
    '
    Me.txtMax.Location = New System.Drawing.Point(16, 296)
    Me.txtMax.Name = "txtMax"
    Me.txtMax.Size = New System.Drawing.Size(88, 20)
    Me.txtMax.TabIndex = 9
    Me.txtMax.Text = "1000"
    '
    'lblFill
    '
    Me.lblFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblFill.Location = New System.Drawing.Point(16, 360)
    Me.lblFill.Name = "lblFill"
    Me.lblFill.Size = New System.Drawing.Size(224, 24)
    Me.lblFill.TabIndex = 8
    '
    'Tree
    '
    Me.Tree.ImageIndex = -1
    Me.Tree.Location = New System.Drawing.Point(16, 16)
    Me.Tree.Name = "Tree"
    Me.Tree.SelectedImageIndex = -1
    Me.Tree.Size = New System.Drawing.Size(224, 248)
    Me.Tree.TabIndex = 7
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(256, 469)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClear, Me.lblClear, Me.cmdFill, Me.label1, Me.txtMax, Me.lblFill, Me.Tree})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub cmdFill_Click(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles cmdFill.Click
    Dim tmr As DateTime = DateTime.Now
    Dim ts As TimeSpan
    Dim NumNodes As Int32 = Int32.Parse(txtMax.Text)
    Dim k As Int32

    lblFill.Text = ""
    lblClear.Text = ""
    Application.DoEvents()
    Me.Cursor = Cursors.WaitCursor
    tmr = DateTime.Now
    '    Tree.BeginUpdate()
    '--------------------------------------------------------------------
    'Add only root nodes
    'For k = 0 To NumNodes
    '  Tree.Nodes.Add("Node " + k.ToString())
    'Next
    'For k = 0 To NumNodes
    '  Tree.Nodes.Add("Node " + k.ToString())
    'Next
    '--------------------------------------------------------------------
    'Add a single root node and many child nodes
    'Dim HeaderNode As TreeNode = Tree.Nodes.Add("User Header Node")
    'For k = 0 To NumNodes
    '  HeaderNode.Nodes.Add("Node " + k.ToString())
    'Next
    'HeaderNode.Expand()
    '--------------------------------------------------------------------

    'Add nodes and show them before shutting down the tree pane update
    Dim AllowUpdate As Boolean = True
    Dim HeaderNode As TreeNode = Tree.Nodes.Add("User Header Node")
    For k = 0 To NumNodes
      If AllowUpdate AndAlso HeaderNode.Nodes.Count > Tree.VisibleCount Then
        HeaderNode.Expand()
        Application.DoEvents()
        Tree.BeginUpdate()
        AllowUpdate = False
      End If
      HeaderNode.Nodes.Add("Node " + k.ToString())
    Next

    Tree.EndUpdate()
    ts = DateTime.Now.Subtract(tmr)
    lblFill.Text = ts.TotalSeconds.ToString() + " seconds to add " + _
    NumNodes.ToString() + " Nodes "
    Me.Cursor = Cursors.Arrow

  End Sub

  Private Sub cmdClear_Click(ByVal sender As System.Object, _
                             ByVal e As System.EventArgs) Handles cmdClear.Click
    Dim tmr As DateTime = DateTime.Now
    Dim ts As TimeSpan
    Dim NodeCount As String = Tree.Nodes.Count.ToString()

    Me.Cursor = Cursors.WaitCursor
    Tree.BeginUpdate()
    Tree.Nodes.Clear()
    Tree.EndUpdate()
    Me.Cursor = Cursors.Arrow

    ts = DateTime.Now.Subtract(tmr)
    lblClear.Text = ts.TotalSeconds.ToString() + " seconds to clear " + _
                    NodeCount + " Nodes "

  End Sub
End Class
