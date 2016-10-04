Public Class UberForm
  Inherits System.Windows.Forms.Form

#Region "Class Local Variables"

  Dim PayForm As Payroll
  Dim EmpForm As Employee
  Dim SkedForm As Scheduling
  Dim TrainForm As Training

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    Me.Menu = mainMenu1
    AddHandler mnuClose.Click, New EventHandler(AddressOf Me.CloseMe)
    AddHandler mnuEmp.Click, New EventHandler(AddressOf Me.OpenWindow)
    AddHandler mnuSked.Click, New EventHandler(AddressOf Me.OpenWindow)
    AddHandler mnuPayroll.Click, New EventHandler(AddressOf Me.OpenWindow)
    AddHandler mnuTrain.Click, New EventHandler(AddressOf Me.OpenWindow)
    AddHandler mnuCloseAll.Click, New EventHandler(AddressOf Me.CloseAllWindows)

    AddHandler mnuHoriz.Click, New EventHandler(AddressOf Me.ArrangeWindow)
    AddHandler mnuVert.Click, New EventHandler(AddressOf Me.ArrangeWindow)
    AddHandler mnuCascade.Click, New EventHandler(AddressOf Me.ArrangeWindow)

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
  Friend WithEvents statusBar1 As System.Windows.Forms.StatusBar
  Friend WithEvents statusBarPanel1 As System.Windows.Forms.StatusBarPanel
  Friend WithEvents statusBarPanel2 As System.Windows.Forms.StatusBarPanel
  Friend WithEvents statusBarPanel3 As System.Windows.Forms.StatusBarPanel
  Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
  Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
  Friend WithEvents mnuEmp As System.Windows.Forms.MenuItem
  Friend WithEvents mnuTrain As System.Windows.Forms.MenuItem
  Friend WithEvents mnuPayroll As System.Windows.Forms.MenuItem
  Friend WithEvents mnuSked As System.Windows.Forms.MenuItem
  Friend WithEvents mnuWindow As System.Windows.Forms.MenuItem
  Friend WithEvents mnuHoriz As System.Windows.Forms.MenuItem
  Friend WithEvents mnuVert As System.Windows.Forms.MenuItem
  Friend WithEvents mnuCascade As System.Windows.Forms.MenuItem
  Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
  Friend WithEvents mnuCloseAll As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.statusBar1 = New System.Windows.Forms.StatusBar()
    Me.statusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
    Me.statusBarPanel2 = New System.Windows.Forms.StatusBarPanel()
    Me.statusBarPanel3 = New System.Windows.Forms.StatusBarPanel()
    Me.mainMenu1 = New System.Windows.Forms.MainMenu()
    Me.mnuFile = New System.Windows.Forms.MenuItem()
    Me.mnuClose = New System.Windows.Forms.MenuItem()
    Me.mnuEdit = New System.Windows.Forms.MenuItem()
    Me.mnuEmp = New System.Windows.Forms.MenuItem()
    Me.mnuTrain = New System.Windows.Forms.MenuItem()
    Me.mnuPayroll = New System.Windows.Forms.MenuItem()
    Me.mnuSked = New System.Windows.Forms.MenuItem()
    Me.mnuWindow = New System.Windows.Forms.MenuItem()
    Me.mnuCloseAll = New System.Windows.Forms.MenuItem()
    Me.mnuHoriz = New System.Windows.Forms.MenuItem()
    Me.mnuVert = New System.Windows.Forms.MenuItem()
    Me.mnuCascade = New System.Windows.Forms.MenuItem()
    Me.mnuHelp = New System.Windows.Forms.MenuItem()
    CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.statusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.statusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'statusBar1
    '
    Me.statusBar1.Location = New System.Drawing.Point(0, 549)
    Me.statusBar1.Name = "statusBar1"
    Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusBarPanel1, Me.statusBarPanel2, Me.statusBarPanel3})
    Me.statusBar1.ShowPanels = True
    Me.statusBar1.Size = New System.Drawing.Size(792, 24)
    Me.statusBar1.TabIndex = 2
    Me.statusBar1.Text = "statusBar1"
    '
    'statusBarPanel1
    '
    Me.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
    Me.statusBarPanel1.Text = "Employee Screen"
    Me.statusBarPanel1.Width = 599
    '
    'statusBarPanel2
    '
    Me.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
    Me.statusBarPanel2.Text = "Operator:"
    Me.statusBarPanel2.Width = 62
    '
    'statusBarPanel3
    '
    Me.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
    Me.statusBarPanel3.Text = "Sunday May 3 1999"
    Me.statusBarPanel3.Width = 115
    '
    'mainMenu1
    '
    Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.mnuWindow, Me.mnuHelp})
    '
    'mnuFile
    '
    Me.mnuFile.Index = 0
    Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuClose})
    Me.mnuFile.Text = "File"
    '
    'mnuClose
    '
    Me.mnuClose.Index = 0
    Me.mnuClose.Text = "Close"
    '
    'mnuEdit
    '
    Me.mnuEdit.Index = 1
    Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEmp, Me.mnuTrain, Me.mnuPayroll, Me.mnuSked})
    Me.mnuEdit.Text = "Edit"
    '
    'mnuEmp
    '
    Me.mnuEmp.Index = 0
    Me.mnuEmp.Text = "Employee"
    '
    'mnuTrain
    '
    Me.mnuTrain.Index = 1
    Me.mnuTrain.Text = "Training"
    '
    'mnuPayroll
    '
    Me.mnuPayroll.Index = 2
    Me.mnuPayroll.Text = "Payroll"
    '
    'mnuSked
    '
    Me.mnuSked.Index = 3
    Me.mnuSked.Text = "Scheduling"
    '
    'mnuWindow
    '
    Me.mnuWindow.Index = 2
    Me.mnuWindow.MdiList = True
    Me.mnuWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCloseAll, Me.mnuHoriz, Me.mnuVert, Me.mnuCascade})
    Me.mnuWindow.Text = "Window"
    '
    'mnuCloseAll
    '
    Me.mnuCloseAll.Index = 0
    Me.mnuCloseAll.Text = "Close All"
    '
    'mnuHoriz
    '
    Me.mnuHoriz.Index = 1
    Me.mnuHoriz.Text = "Tile Horizontally"
    '
    'mnuVert
    '
    Me.mnuVert.Index = 2
    Me.mnuVert.Text = "Time Vertically"
    '
    'mnuCascade
    '
    Me.mnuCascade.Index = 3
    Me.mnuCascade.Text = "Cascade"
    '
    'mnuHelp
    '
    Me.mnuHelp.Index = 3
    Me.mnuHelp.Text = "Help"
    '
    'UberForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(792, 573)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.statusBar1})
    Me.IsMdiContainer = True
    Me.Menu = Me.mainMenu1
    Me.Name = "UberForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "HR Program"
    CType(Me.statusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.statusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.statusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub UberForm_Load(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

#Region "Events"

  Private Sub CloseMe(ByVal sender As Object, ByVal e As EventArgs)
    Me.Close()
  End Sub

  Private Sub OpenWindow(ByVal sender As Object, ByVal e As EventArgs)
    Dim m As MenuItem

    If sender.GetType() Is GetType(MenuItem) Then
      m = CType(sender, MenuItem)
    Else
      Return
    End If

    If m Is mnuEmp Then
      If EmpForm Is Nothing Then
        EmpForm = New Employee()
        AddHandler EmpForm.Disposed, AddressOf Me.ByByWindow
        EmpForm.MdiParent = Me
        EmpForm.Show()
      Else
        EmpForm.Focus()
      End If
    End If

    If m Is mnuTrain Then
      If TrainForm Is Nothing Then
        TrainForm = New Training()
        AddHandler TrainForm.Disposed, AddressOf Me.ByByWindow
        TrainForm.MdiParent = Me
        TrainForm.Show()
      Else
        TrainForm.Focus()
      End If
    End If

    If m Is mnuPayroll Then
      If PayForm Is Nothing Then
        PayForm = New Payroll()
        AddHandler PayForm.Disposed, AddressOf Me.ByByWindow
        PayForm.MdiParent = Me
        PayForm.Show()
      Else
        PayForm.Focus()
      End If
    End If

    If m Is mnuSked Then
      If SkedForm Is Nothing Then
        SkedForm = New Scheduling()
        AddHandler SkedForm.Disposed, AddressOf Me.ByByWindow
        SkedForm.MdiParent = Me
        SkedForm.Show()
      Else
        SkedForm.Focus()
      End If
    End If

  End Sub

  Private Sub ArrangeWindow(ByVal sender As Object, ByVal e As EventArgs)
    Dim m As MenuItem

    If sender.GetType() Is GetType(MenuItem) Then
      m = CType(sender, MenuItem)
    Else
      Return
    End If

    If m Is mnuHoriz Then
      Me.LayoutMdi(MdiLayout.TileHorizontal)
    End If

    If m Is mnuVert Then
      Me.LayoutMdi(MdiLayout.TileVertical)
    End If

    If m Is mnuCascade Then
      Me.LayoutMdi(MdiLayout.Cascade)
    End If

  End Sub

  Private Sub CloseAllWindows(ByVal sender As Object, ByVal e As EventArgs)

    If Not EmpForm Is Nothing Then
      EmpForm.Dispose()
    End If
    If Not PayForm Is Nothing Then
      PayForm.Dispose()
    End If
    If Not TrainForm Is Nothing Then
      TrainForm.Dispose()
    End If
    If Not SkedForm Is Nothing Then
      SkedForm.Dispose()
    End If
  End Sub

  Private Sub ByByWindow(ByVal sender As Object, ByVal e As EventArgs)

    If sender Is EmpForm Then
      EmpForm = Nothing
    End If
    If sender Is PayForm Then
      PayForm = Nothing
    End If
    If sender Is TrainForm Then
      TrainForm = Nothing
    End If
    If sender Is SkedForm Then
      SkedForm = Nothing
    End If

  End Sub


#End Region

End Class
