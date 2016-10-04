Option Strict On

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Threading
Imports System.Drawing.Drawing2D

Public Class QuickTree
  Inherits System.Windows.Forms.UserControl

#Region "vars"

  Private Delegate Sub NodeAddDelegate(ByVal tnodes() As TreeNode)
  Private NodeDelegate As NodeAddDelegate

  Private on_FillComplete As EventHandler
  Public Event FillComplete As EventHandler

  Private tnodes As ArrayList
  Private BaseNode As TreeNode
  Private FillThread As Thread
  Private filling As Boolean
  Private WaitForFill As Boolean

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    tnodes = New ArrayList()
    NodeDelegate = New NodeAddDelegate(AddressOf AddNodes)
    on_FillComplete = New EventHandler(AddressOf OnFillComplete)
    filling = False

  End Sub

  'UserControl1 overrides dispose to clean up the component list.
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
  Public WithEvents tree As System.Windows.Forms.TreeView
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.tree = New System.Windows.Forms.TreeView()
    Me.SuspendLayout()
    '
    'tree
    '
    Me.tree.Dock = System.Windows.Forms.DockStyle.Fill
    Me.tree.ImageIndex = -1
    Me.tree.Name = "tree"
    Me.tree.SelectedImageIndex = -1
    Me.tree.Size = New System.Drawing.Size(150, 150)
    Me.tree.TabIndex = 1
    '
    'UserControl1
    '
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tree})
    Me.Name = "UserControl1"
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "properties/methods"

  Public ReadOnly Property OK2Fill() As Boolean
    Get
      Return Not filling
    End Get
  End Property

  Public WriteOnly Property Strings() As ArrayList
    Set(ByVal Value As ArrayList)
      If Not filling Then
        tnodes = CType(Value.Clone(), ArrayList)
      End If
    End Set
  End Property

  Public Sub StartFill(ByVal node As TreeNode)
    BaseNode = node

    'Do not interrupt a fill
    If filling Then Return

    'Make sure that someone actually put this control on the form
    'This could have been called without intializing the tree.
    If (tree.IsHandleCreated) Then
      filling = True
      FillThread = New Thread(New ThreadStart(AddressOf tnodeThread))
      FillThread.Start()
    Else
      WaitForFill = True
    End If
  End Sub

  Public Sub StopFill()
    'Obviously if I am not filling then no need to join threads
    If Not filling Then Return

    If FillThread.IsAlive Then
      FillThread.Abort()
      FillThread.Join()
    End If

    FillThread = Nothing
    filling = False
  End Sub

#End Region

#Region "events/Delegates"

  'If the user kills the program before the tree has filled then you will
  'need to stop the fill first.  This is why the Base.OnHandleDestroyed
  'is called after the stop fill.
  Protected Overrides Sub OnHandleDestroyed(ByVal e As EventArgs)
    If Not tree.RecreatingHandle Then
      StopFill()
    End If
    MyBase.OnHandleDestroyed(e)
  End Sub

  'This overidden method sort of delays things a little if the calling program 
  'was too agressive and started a fill before the tree was ready to accept it
  Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
    MyBase.OnHandleCreated(e)
    If WaitForFill Then
      WaitForFill = False
      StartFill(BaseNode)
    End If
  End Sub

  'This method is called via a BeginInvoke by the background
  'thread
  Private Sub AddNodes(ByVal tnodes() As TreeNode)
    tree.BeginUpdate()

    If Not BaseNode Is Nothing Then
      BaseNode.Nodes.AddRange(tnodes)
      BaseNode.Expand()
    Else
      tree.Nodes.AddRange(tnodes)
    End If

    tree.EndUpdate()
  End Sub

  'This method is called by the background thread when it is
  'finished handing over all the nodes it needs to add.
  Private Sub OnFillComplete(ByVal sender As Object, ByVal e As EventArgs)
    'Only call this delegate if someone has hooked up to it
    'otherwise it is null and you will get a major crash.
    RaiseEvent FillComplete(sender, e)
  End Sub

#End Region

#Region "Worker Thread"

  Private Sub tnodeThread()
    Dim NodeList As ArrayList = New ArrayList()
    Dim NodeArray As Array
    Dim k As Int32

    Try
      tnodes.TrimToSize()
      For k = 0 To tnodes.Count - 1
        NodeList.Add(New TreeNode(CType(tnodes(k), String)))
        If Decimal.Remainder(CType(NodeList.Count, Decimal), 20) = 0 Then
          NodeArray = Array.CreateInstance(GetType(TreeNode), NodeList.Count)
          NodeList.CopyTo(NodeArray)
          Dim r As IAsyncResult = Me.BeginInvoke(NodeDelegate, _
                                                New Object() {NodeArray})
          NodeList.Clear()
          'Sleep for 500 milliseconds to pretend we are doing something 
          'really(complicated)
          Thread.Sleep(300)
        End If
      Next
      If NodeList.Count > 0 Then
        NodeArray = Array.CreateInstance(GetType(TreeNode), NodeList.Count)
        NodeList.CopyTo(NodeArray)
        Dim r As IAsyncResult = Me.BeginInvoke(NodeDelegate, _
                                                New Object() {NodeArray})
      End If
    Finally
      filling = False

      'I could raise the event from here but it would be comming from
      'a different thread.  If A client did not know this was a multithreaded
      'control then it could expect the event to be raised from the same 
      'thread that the client is in.
      BeginInvoke(on_FillComplete, New Object() {Me, EventArgs.Empty})
    End Try

  End Sub

#End Region


End Class
