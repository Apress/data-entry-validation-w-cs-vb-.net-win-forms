Option Strict On
Imports System.Diagnostics
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region "class local variables"

  Dim Piclist As PhotoList

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    Piclist = New PhotoList()

    pic.SizeMode = PictureBoxSizeMode.StretchImage
    SetupListView()
    SetupTree()

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
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents pic As System.Windows.Forms.PictureBox
  Friend WithEvents lvPics As System.Windows.Forms.ListView
  Friend WithEvents tvPics As System.Windows.Forms.TreeView
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.pic = New System.Windows.Forms.PictureBox()
    Me.lvPics = New System.Windows.Forms.ListView()
    Me.tvPics = New System.Windows.Forms.TreeView()
    Me.SuspendLayout()
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(38, 32)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(248, 16)
    Me.label2.TabIndex = 9
    Me.label2.Text = "Photo Classifications"
    Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(328, 32)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(328, 16)
    Me.label1.TabIndex = 8
    Me.label1.Text = "All photos"
    Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'pic
    '
    Me.pic.BackColor = System.Drawing.Color.Linen
    Me.pic.Location = New System.Drawing.Point(406, 304)
    Me.pic.Name = "pic"
    Me.pic.Size = New System.Drawing.Size(160, 136)
    Me.pic.TabIndex = 7
    Me.pic.TabStop = False
    '
    'lvPics
    '
    Me.lvPics.Location = New System.Drawing.Point(326, 48)
    Me.lvPics.Name = "lvPics"
    Me.lvPics.Size = New System.Drawing.Size(328, 232)
    Me.lvPics.TabIndex = 6
    '
    'tvPics
    '
    Me.tvPics.ImageIndex = -1
    Me.tvPics.Location = New System.Drawing.Point(38, 48)
    Me.tvPics.Name = "tvPics"
    Me.tvPics.SelectedImageIndex = -1
    Me.tvPics.Size = New System.Drawing.Size(248, 392)
    Me.tvPics.TabIndex = 5
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(692, 473)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label2, Me.label1, Me.pic, Me.lvPics, Me.tvPics})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

#Region "Setup routines"

  Private Sub SetupListView()
    'Set up the photo ListView
    lvPics.View = View.Details
    lvPics.AllowColumnReorder = True
    lvPics.GridLines = True
    lvPics.FullRowSelect = True
    lvPics.AllowDrop = True
    lvPics.MultiSelect = False
    AddHandler lvPics.SelectedIndexChanged, _
                     New EventHandler(AddressOf RowSelect)
    AddHandler lvPics.ItemDrag, _
                     New ItemDragEventHandler(AddressOf PhotoStartDrag)
    AddHandler lvPics.DragEnter, _
                     New DragEventHandler(AddressOf PhotoDragAcross)
    lvPics.Columns.Add("Name", -2, HorizontalAlignment.Center)
    lvPics.Columns.Add("Date", -2, HorizontalAlignment.Center)
    lvPics.Columns.Add("Location", -2, HorizontalAlignment.Center)
    lvPics.Columns.Add("Format", -2, HorizontalAlignment.Center)
    Dim c As ColumnHeader
    For Each c In lvPics.Columns
      c.Width = CType((lvPics.Width / lvPics.Columns.Count), Integer)
    Next

    'Make something that will hold the current sort order for the current column
    Dim order As ArrayList = New ArrayList()
    Dim k As Integer
    For k = 0 To lvPics.Columns.Count - 1
      order.Insert(k, SortOrder.Ascending)
    Next
    order.TrimToSize()
    lvPics.Tag = order
    AddHandler lvPics.ColumnClick, _
                      New ColumnClickEventHandler(AddressOf ColumnSort)

    'Fill the ListView
    lvPics.BeginUpdate()
    lvPics.Items.Clear()
    lvPics.Items.AddRange(Piclist.Items)
    lvPics.EndUpdate()

  End Sub

  Private Sub SetupTree()
    Dim iList As ImageList = New ImageList()
    iList.Images.Add(Image.FromFile("closed.ico"))
    iList.Images.Add(Image.FromFile("open.ico"))
    iList.Images.Add(Image.FromFile("camera.ico"))

    tvPics.AllowDrop = True
    tvPics.ImageList = iList
    tvPics.HideSelection = False
    tvPics.HotTracking = True  'This is limiting
    AddHandler tvPics.AfterSelect, _
                      New TreeViewEventHandler(AddressOf NodeSelect)
    AddHandler tvPics.AfterExpand, _
                      New TreeViewEventHandler(AddressOf TreeExpandCollapse)
    AddHandler tvPics.AfterCollapse, _
                      New TreeViewEventHandler(AddressOf TreeExpandCollapse)
    AddHandler tvPics.DragEnter, _
                      New DragEventHandler(AddressOf TreeDragInto)
    AddHandler tvPics.DragDrop, _
                      New DragEventHandler(AddressOf TreeDragDrop)
    AddHandler tvPics.DragOver, New DragEventHandler(AddressOf TreeDragOver)

    'Add some root nodes
    Dim root As TreeNode = New TreeNode("All Photos")
    root.Nodes.Add("Seascapes")
    root.Nodes.Add("Desert Scenes")
    root.Nodes.Add("Flowers")
    root.Nodes.Add("Spring")
    root.Tag = "Root Node"
    root.Expand()
    tvPics.Nodes.Add(root)

  End Sub

#End Region

#Region "TreeView Delegates"

  Private Sub NodeSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
    Debug.Assert(sender Is tvPics, _
                 "Only the tvPics TreeView control can activate this delegate")

    If (Not e.Node.Tag Is Nothing) AndAlso e.Node.Tag.ToString() = "Photo" Then
      '     If Not e.Node.Tag Is Nothing Then
      Dim p As Photo = DirectCast(e.Node.Tag, Photo)
      pic.Image = p.Picture
    Else
      pic.Image = Nothing
    End If
  End Sub

  Private Sub TreeDragInto(ByVal sender As Object, ByVal e As DragEventArgs)
    e.Effect = DragDropEffects.All
  End Sub

  'Second pass     
  Private Sub TreeDragOver(ByVal sender As Object, ByVal e As DragEventArgs)
    'Stop this from happening when over a node that 
    'is not allowed to be dropped on
    Dim node As TreeNode = tvPics.GetNodeAt(tvPics.PointToClient _
                                     (New Point(e.X, e.Y)))
    If node.Tag Is Nothing Then
      tvPics.Focus()  'Probelem with this is that it fires an event
      tvPics.SelectedNode = node
      e.Effect = DragDropEffects.All
    Else
      e.Effect = DragDropEffects.None
    End If
  End Sub

  Private Sub TreeDragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
    'The x and y values are in form coordinates
    tvPics.SelectedNode = tvPics.GetNodeAt(tvPics.PointToClient _
                                          (New Point(e.X, e.Y)))
    If tvPics.SelectedNode Is Nothing Then
      MessageBox.Show("You need to drop this item on a node.")
      Return
    End If

    'Normally you would detect the source data against the drop node
    'If the source data did not belong there then flag an error
    If tvPics.SelectedNode.Parent Is Nothing Then
      MessageBox.Show("You cannot drop this item on the root node.")
      Return
    End If

    If Not tvPics.SelectedNode.Tag Is Nothing Then
      MessageBox.Show("You cannot drop a photo on a photo.")
      Return
    End If

    'Get the object being passed.
    'I use a ListView object as the carrier since Photo is not serializable
    'A serializable object must be able to serialize all data within
    Dim o As Object = e.Data.GetData(DataFormats.Serializable)
    Dim l As ListViewItem = DirectCast(o, ListViewItem)
    Dim snap As Photo = DirectCast(l.Tag, Photo)

    tvPics.BeginUpdate()
    Dim n As TreeNode = New TreeNode(snap.Name)
    n.Tag = snap
    n.SelectedImageIndex = 2
    n.ImageIndex = 2
    tvPics.SelectedNode.Nodes.Add(n)
    tvPics.SelectedNode.Expand()
    tvPics.EndUpdate()

  End Sub

  Private Sub TreeExpandCollapse(ByVal sender As Object, _
                                 ByVal e As TreeViewEventArgs)
    If e.Action = TreeViewAction.Expand Then
      e.Node.SelectedImageIndex = 1
    End If

    If e.Action = TreeViewAction.Collapse Then
      e.Node.SelectedImageIndex = 0
    End If

  End Sub


#End Region

#Region "ListView Delegates"

  Private Sub RowSelect(ByVal sender As Object, ByVal e As EventArgs)
    Debug.Assert(sender Is lvPics, _
                 "Only the lvPics ListView control can activate this delegate")
    Debug.Assert(lvPics.SelectedIndices.Count <= 1, _
                 "only one item can be selected")

    If lvPics.SelectedIndices.Count = 1 Then
      Dim p As Photo = DirectCast(lvPics.SelectedItems(0).Tag, Photo)
      pic.Image = p.Picture
    End If
  End Sub

  Private Sub ColumnSort(ByVal sender As Object, _
                         ByVal e As ColumnClickEventArgs)
    Dim lvw As ListView = CType(sender, ListView)
    Dim SortList As ArrayList = CType(lvw.Tag, ArrayList)
    SortList(e.Column) = IIf(DirectCast(SortList(e.Column), SortOrder) = _
                                                     SortOrder.Ascending, _
                                                     SortOrder.Descending, _
                                                     SortOrder.Ascending)
    lvw.Sorting = DirectCast(SortList(e.Column), SortOrder)

    lvw.BeginUpdate()
    lvw.ListViewItemSorter = New ListViewSorter(e.Column, lvw.Sorting)
    lvw.Sort()
    lvw.EndUpdate()
  End Sub

  Private Sub PhotoStartDrag(ByVal sender As Object, _
                             ByVal e As ItemDragEventArgs)
    If sender Is lvPics Then
      lvPics.DoDragDrop(e.Item, DragDropEffects.Move)
    End If
  End Sub

  Private Sub PhotoDragAcross(ByVal sender As Object, ByVal e As DragEventArgs)
    If sender Is lvPics Then
      e.Effect = DragDropEffects.Move
    End If
  End Sub

#End Region

End Class
