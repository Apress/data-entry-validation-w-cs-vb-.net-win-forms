Public Class GolfStat
  Inherits System.Windows.Forms.Form

#Region "locals"

  Public db As Database

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    InitScreen()
    db = New Database()

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
  Friend WithEvents mnu As System.Windows.Forms.MainMenu
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.mnu = New System.Windows.Forms.MainMenu()
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(792, 573)
    Me.IsMdiContainer = True
    Me.Menu = Me.mnu
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "GolfStat"

  End Sub

#End Region




  Private Sub InitScreen()
    Dim mi As MenuItem = mnu.MenuItems.Add("&File")
    mi.MenuItems.Add("&Edit Course", New EventHandler(AddressOf EditCourse))
    mi.MenuItems.Add("-")
    mi.MenuItems.Add("&Save", New EventHandler(AddressOf SaveCourse))
    mi.MenuItems.Add("Save &As...", New EventHandler(AddressOf SaveCourseAs))
    mi.MenuItems.Add("-")
    mi.MenuItems.Add("&Print")
    mi.MenuItems.Add("-")
    mi.MenuItems.Add("E&xit", New EventHandler(AddressOf ProgramExit))

    mi = mnu.MenuItems.Add("&Statistics", New EventHandler(AddressOf Stats))

  End Sub

#Region "Menu events"

  Private Sub EditCourse(ByVal sender As Object, ByVal e As EventArgs)
    Dim frm As Course = New Course()
    frm.MdiParent = Me
    frm.Show()
  End Sub

  Private Sub Stats(ByVal sender As Object, ByVal e As EventArgs)
    Dim frm As Statistics = New Statistics()
    frm.MdiParent = Me
    frm.Show()
  End Sub

  Private Sub SaveCourse(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

  Private Sub SaveCourseAs(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

  Private Sub ProgramExit(ByVal sender As Object, ByVal e As EventArgs)
  End Sub

#End Region

End Class
