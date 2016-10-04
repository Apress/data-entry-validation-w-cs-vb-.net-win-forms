Option Strict On

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region "class local variables"

  Private lvw1 As LvItems
  Private lvw2 As LvItems
  Private SwapList As LvItems

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    'Show details with two columns
    lv.View = View.Details
    lv.Columns.Add("First Item", -2, HorizontalAlignment.Center)
    lv.Columns.Add("Sub Item", -2, HorizontalAlignment.Center)

    'Add individual items to the first stored list
    lvw1 = New LvItems()
    lvw1.Add("1     I belong to LC1")
    lvw1.Add("2     I belong to LC1")
    lvw1.Add("3     I belong to LC1")

    'Add an item to the first list that has a sub item
    Dim k As ListViewItem = New ListViewItem()
    k.Text = "4     Parent Item"
    k.SubItems.Add("Sub Item 1")
    lvw1.Add(k)

    'Add items to the second stored list
    lvw2 = New LvItems()
    lvw2.Add("1   I belong to LC2")
    lvw2.Add("2   I belong to LC2")
    lvw2.Add("3   I belong to LC2")

    lv.Items.AddRange(lvw1.Items)

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
  Friend WithEvents cmdSwap As System.Windows.Forms.Button
  Friend WithEvents lv As System.Windows.Forms.ListView
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdSwap = New System.Windows.Forms.Button()
    Me.lv = New System.Windows.Forms.ListView()
    Me.SuspendLayout()
    '
    'cmdSwap
    '
    Me.cmdSwap.Location = New System.Drawing.Point(136, 242)
    Me.cmdSwap.Name = "cmdSwap"
    Me.cmdSwap.Size = New System.Drawing.Size(80, 32)
    Me.cmdSwap.TabIndex = 3
    Me.cmdSwap.Text = "Swap"
    '
    'lv
    '
    Me.lv.Location = New System.Drawing.Point(56, 34)
    Me.lv.Name = "lv"
    Me.lv.Size = New System.Drawing.Size(232, 192)
    Me.lv.TabIndex = 2
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(344, 309)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdSwap, Me.lv})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

  Private Sub cmdSwap_Click(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles cmdSwap.Click

    If SwapList Is lvw2 Then
      SwapList = lvw1
    Else
      SwapList = lvw2
    End If
    lv.Items.Clear()
    lv.Items.AddRange(SwapList.Items)

  End Sub
End Class
