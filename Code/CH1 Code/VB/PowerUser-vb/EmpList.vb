Public Class EmpList
    Inherits System.Windows.Forms.Form

#Region "class local variables"

   dim Employees(,) as string = new string(,) {{"Person A", "500"}, _
                                         {"Person B", "502"}, _
                                         {"Person C", "501"}, _
                                         {"Person D", "503"}}

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New(ByVal ByEmployee As Boolean)
    MyBase.New()

    InitializeComponent()

    AddHandler cmdOK.Click, AddressOf UnloadMe
    AddHandler cmdCancel.Click, AddressOf UnloadMe

    lstEmps.Items.Clear()
    lstEmps.View = View.Details
    lstEmps.GridLines = True
    lstEmps.FullRowSelect = True
    lstEmps.Sorting = SortOrder.Ascending
    lstEmps.Scrollable = True

    'Add column headers
    lstEmps.Columns.Add(IIf(ByEmployee, "Name", "Clock #"), -2, _
                            HorizontalAlignment.Center)
    lstEmps.Columns.Add(IIf(ByEmployee, "Clock #", "Name"), -2, _
                            HorizontalAlignment.Center)

    'Add some people
    Dim k As Int32
    For k = 0 To Employees.GetLength(0) - 1
      Dim main As ListViewItem = _
               New ListViewItem(Employees(k, IIf(ByEmployee, 0, 1)))
      main.SubItems.Add(Employees(k, IIf(ByEmployee, 1, 0)))
      lstEmps.Items.Add(main)
    Next

    AddHandler lstEmps.ColumnClick, AddressOf ChangeSortOrder

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
  Friend WithEvents lstEmps As System.Windows.Forms.ListView
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents cmdOK As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lstEmps = New System.Windows.Forms.ListView()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.label1 = New System.Windows.Forms.Label()
    Me.cmdOK = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'lstEmps
    '
    Me.lstEmps.Location = New System.Drawing.Point(15, 27)
    Me.lstEmps.Name = "lstEmps"
    Me.lstEmps.Size = New System.Drawing.Size(200, 184)
    Me.lstEmps.TabIndex = 8
    '
    'cmdCancel
    '
    Me.cmdCancel.Location = New System.Drawing.Point(127, 227)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(96, 32)
    Me.cmdCancel.TabIndex = 7
    Me.cmdCancel.Text = "Cancel"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(15, 11)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(208, 16)
    Me.label1.TabIndex = 6
    Me.label1.Text = "Employees"
    Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'cmdOK
    '
    Me.cmdOK.Location = New System.Drawing.Point(15, 227)
    Me.cmdOK.Name = "cmdOK"
    Me.cmdOK.Size = New System.Drawing.Size(96, 32)
    Me.cmdOK.TabIndex = 5
    Me.cmdOK.Text = "OK"
    '
    'EmpList
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(238, 271)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstEmps, Me.cmdCancel, Me.label1, Me.cmdOK})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "EmpList"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "EmpList"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub EmpList_Load(ByVal sender As System.Object, _
                           ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub


  Private Sub UnloadMe(ByVal sender As Object, ByVal e As EventArgs)
    Me.Close()
  End Sub

  Private Sub ChangeSortOrder(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
    If (lstEmps.Sorting = SortOrder.Ascending) Then
      lstEmps.Sorting = SortOrder.Descending
    Else
      lstEmps.Sorting = SortOrder.Ascending
    End If
  End Sub

End Class
