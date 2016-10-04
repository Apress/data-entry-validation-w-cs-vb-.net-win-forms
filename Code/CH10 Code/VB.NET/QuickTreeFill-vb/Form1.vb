Option Strict On

Imports System.Collections

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    toys = New Toys()
    Clothes = New Clothing()
    AddHandler cmdClear.Click, New EventHandler(AddressOf ClearTree)
    AddHandler cmdFill.Click, New EventHandler(AddressOf FillWholeTree)
    AddHandler cmdFillFast.Click, New EventHandler(AddressOf FillTreeFast)

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
  Friend WithEvents cmdFillFast As System.Windows.Forms.Button
  Friend WithEvents cmdFill As System.Windows.Forms.Button
  Friend WithEvents Tree As System.Windows.Forms.TreeView
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdClear = New System.Windows.Forms.Button()
    Me.cmdFillFast = New System.Windows.Forms.Button()
    Me.cmdFill = New System.Windows.Forms.Button()
    Me.Tree = New System.Windows.Forms.TreeView()
    Me.SuspendLayout()
    '
    'cmdClear
    '
    Me.cmdClear.Location = New System.Drawing.Point(348, 322)
    Me.cmdClear.Name = "cmdClear"
    Me.cmdClear.Size = New System.Drawing.Size(88, 24)
    Me.cmdClear.TabIndex = 7
    Me.cmdClear.Text = "Clear"
    '
    'cmdFillFast
    '
    Me.cmdFillFast.Location = New System.Drawing.Point(348, 402)
    Me.cmdFillFast.Name = "cmdFillFast"
    Me.cmdFillFast.Size = New System.Drawing.Size(88, 24)
    Me.cmdFillFast.TabIndex = 6
    Me.cmdFillFast.Text = "Fill Fast"
    '
    'cmdFill
    '
    Me.cmdFill.Location = New System.Drawing.Point(348, 362)
    Me.cmdFill.Name = "cmdFill"
    Me.cmdFill.Size = New System.Drawing.Size(88, 24)
    Me.cmdFill.TabIndex = 5
    Me.cmdFill.Text = "Fill Normal"
    '
    'Tree
    '
    Me.Tree.ImageIndex = -1
    Me.Tree.Location = New System.Drawing.Point(28, 26)
    Me.Tree.Name = "Tree"
    Me.Tree.SelectedImageIndex = -1
    Me.Tree.Size = New System.Drawing.Size(296, 408)
    Me.Tree.TabIndex = 4
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(464, 461)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClear, Me.cmdFillFast, Me.cmdFill, Me.Tree})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "class local variables"

  Private toys As Toys
  Private Clothes As Clothing
  Private Enum NodeLevel
    AllToys
    AllClothes
    ToyBrand
    ClothingBrand
    BatteryToys
    ElectronicToys
    BoardGameToys
    VideoToys
    PlushToys
    ModelToys
    FigureToys
    ClothingFootware
    ClothingTops
    ClothingJackets
    ClothingSweaters
    ClothingPants
    ClothingGloves
  End Enum

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

#Region "fill the tree slow"

  Private Sub FillWholeTree(ByVal sender As Object, ByVal e As EventArgs)
    Dim x As Brand

    RemoveHandler Tree.BeforeExpand, New TreeViewCancelEventHandler(AddressOf FillSubNodes)

    Me.Cursor = Cursors.WaitCursor
    Tree.Nodes.Clear()
    Tree.BeginUpdate()

    '------ Do Toys -------
    Dim ThisNode As TreeNode
    Dim AllToys As TreeNode = Tree.Nodes.Add("All Toys")
    AllToys.Tag = NodeLevel.AllToys
    Dim node As TreeNode = AllToys.Nodes.Add("Action Figures")
    node.Tag = NodeLevel.FigureToys
    For Each x In toys.ActionFigures.Brands
      ThisNode = node.Nodes.Add(x.BrandName)
    Next

    node = AllToys.Nodes.Add("Battery Powered Toys")
    For Each x In toys.BatteryPowered.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllToys.Nodes.Add("Board Games")
    For Each x In toys.BoardGames.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllToys.Nodes.Add("Electronic Games")
    For Each x In toys.Electronic.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllToys.Nodes.Add("Models")
    For Each x In toys.Models.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllToys.Nodes.Add("Plush Toys")
    For Each x In toys.Plush.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllToys.Nodes.Add("Video Games")
    For Each x In toys.Video.Brands
      node.Nodes.Add(x.BrandName)
    Next

    ' --------- Do Clothing ---------
    Dim AllClothes As TreeNode = Tree.Nodes.Add("All Clothes")
    node = AllClothes.Nodes.Add("Footware")
    For Each x In Clothes.Footware.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllClothes.Nodes.Add("Gloves and Hats")
    For Each x In Clothes.GlovesHats.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllClothes.Nodes.Add("Jackets")
    For Each x In Clothes.Jackets.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllClothes.Nodes.Add("Pants")
    For Each x In Clothes.Pants.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllClothes.Nodes.Add("Sweaters")
    For Each x In Clothes.Sweaters.Brands
      node.Nodes.Add(x.BrandName)
    Next

    node = AllClothes.Nodes.Add("Tops")
    For Each x In Clothes.Tops.Brands
      node.Nodes.Add(x.BrandName)
    Next

    Tree.EndUpdate()
    Me.Cursor = Cursors.Arrow

  End Sub

#End Region

#Region "Smoke and Mirrors"

  Private Sub FillTreeFast(ByVal sender As Object, ByVal e As EventArgs)
    cmdFill.Enabled = False
    cmdFillFast.Enabled = False
    AddHandler Tree.BeforeExpand, _
              New TreeViewCancelEventHandler(AddressOf FillSubNodes)
    Tree.Nodes.Clear()
    Tree.BeginUpdate()
    Dim node As TreeNode = Tree.Nodes.Add("All Toys")
    node.Tag = NodeLevel.AllToys
    node.Nodes.Add("VirtualNode")
    node = Tree.Nodes.Add("All Clothes")
    node.Tag = NodeLevel.AllClothes
    node.Nodes.Add("VirtualNode")
    Tree.EndUpdate()

  End Sub

  Private Sub FillSubNodes(ByVal sender As Object, _
                           ByVal e As TreeViewCancelEventArgs)
    Dim ClickedNode As TreeNode = e.Node
    Dim node As TreeNode
    Dim l As NodeLevel = CType(ClickedNode.Tag, NodeLevel)

    ClickedNode.Nodes.Clear()
    Select Case l
      Case NodeLevel.AllToys
        node = ClickedNode.Nodes.Add("Battery Powered Toys")
        node.Tag = NodeLevel.BatteryToys
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Board Games")
        node.Tag = NodeLevel.BoardGameToys
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Electronic Games")
        node.Tag = NodeLevel.ElectronicToys
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Models")
        node.Tag = NodeLevel.ModelToys
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Plush Toys")
        node.Tag = NodeLevel.PlushToys
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Video Games")
        node.Tag = NodeLevel.VideoToys
        node.Nodes.Add("VirtualNode")
      Case NodeLevel.AllClothes
        node = ClickedNode.Nodes.Add("Gloves and Hats")
        node.Tag = NodeLevel.ClothingGloves
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Jackets")
        node.Tag = NodeLevel.ClothingJackets
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Pants")
        node.Tag = NodeLevel.ClothingPants
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Sweaters")
        node.Tag = NodeLevel.ClothingSweaters
        node.Nodes.Add("VirtualNode")
        node = ClickedNode.Nodes.Add("Tops")
        node.Tag = NodeLevel.ClothingTops
        node.Nodes.Add("VirtualNode")
      Case NodeLevel.ModelToys
        UpdateTree(toys.Models.Brands, ClickedNode)
      Case NodeLevel.BatteryToys
        UpdateTree(toys.BatteryPowered.Brands, ClickedNode)
      Case NodeLevel.BoardGameToys
        UpdateTree(toys.BoardGames.Brands, ClickedNode)
      Case NodeLevel.ElectronicToys
        UpdateTree(toys.Electronic.Brands, ClickedNode)
      Case NodeLevel.FigureToys
        UpdateTree(toys.ActionFigures.Brands, ClickedNode)
      Case NodeLevel.PlushToys
        UpdateTree(toys.Plush.Brands, ClickedNode)
      Case NodeLevel.VideoToys
        UpdateTree(toys.Video.Brands, ClickedNode)
      Case NodeLevel.ClothingFootware
        UpdateTree(Clothes.Footware.Brands, ClickedNode)
      Case NodeLevel.ClothingGloves
        UpdateTree(Clothes.GlovesHats.Brands, ClickedNode)
      Case NodeLevel.ClothingJackets
        UpdateTree(Clothes.Jackets.Brands, ClickedNode)
      Case NodeLevel.ClothingPants
        UpdateTree(Clothes.Pants.Brands, ClickedNode)
      Case NodeLevel.ClothingSweaters
        UpdateTree(Clothes.Sweaters.Brands, ClickedNode)
      Case NodeLevel.ClothingTops
        UpdateTree(Clothes.Tops.Brands, ClickedNode)
    End Select
  End Sub

#End Region

#Region "Helper functions"

  Private Sub ClearTree(ByVal sender As Object, ByVal e As EventArgs)
    Tree.Nodes.Clear()
    cmdFill.Enabled = True
    cmdFillFast.Enabled = True
  End Sub

  Private Sub UpdateTree(ByVal Brands As ArrayList, ByVal ClickedNode As TreeNode)
    Dim AllowUpdate As Boolean = True

    Me.Cursor = Cursors.WaitCursor
    Dim x As Brand
    For Each x In Brands
      ClickedNode.Nodes.Add(x.BrandName)
      If AllowUpdate AndAlso ClickedNode.Nodes.Count > Tree.VisibleCount Then
        AllowUpdate = False
        ExpandThisNode(ClickedNode)
        Tree.BeginUpdate()
      End If
    Next
    Tree.EndUpdate()
    Me.Cursor = Cursors.Arrow
  End Sub

  Private Sub ExpandThisNode(ByVal node As TreeNode)
    RemoveHandler Tree.BeforeExpand, New TreeViewCancelEventHandler(AddressOf FillSubNodes)
    node.Expand()
    AddHandler Tree.BeforeExpand, New TreeViewCancelEventHandler(AddressOf FillSubNodes)
    Application.DoEvents()
  End Sub

#End Region

End Class
