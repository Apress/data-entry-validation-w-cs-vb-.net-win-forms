Option Strict On

Public Class frmMouse
  Inherits System.Windows.Forms.Form

#Region "Class Local Variables"


  'Structs get created on the stack
  Private Structure Symbols
    Private mflag As Image
    Private mDispName As String
    Public Sub New(ByVal DispName As String, ByVal flag As Image)
      mflag = flag
      mDispName = DispName
    End Sub
    Public ReadOnly Property Flag() As Image
      Get
        Return mflag
      End Get
    End Property
    Public ReadOnly Property Name() As String
      Get
        Return mDispName
      End Get
    End Property
  End Structure

  'This is added for marquis selection of flags in the Panel
  Dim Marquis As Rectangle = Rectangle.Empty

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    'Need to use arraylist here.
    Dim Pics As ArrayList = New ArrayList()
    Pics.Add(New Symbols("Italy", Image.FromFile("Italy.ico")))
    Pics.Add(New Symbols("Japan", Image.FromFile("japan.ico")))
    Pics.Add(New Symbols("Canada", Image.FromFile("canada.ico")))
    Pics.Add(New Symbols("Germany", Image.FromFile("germany.ico")))
    Pics.Add(New Symbols("Mexico", Image.FromFile("mexico.ico")))
    Pics.Add(New Symbols("Norway", Image.FromFile("norway.ico")))
    Pics.Add(New Symbols("New Zealand", Image.FromFile("nz.ico")))
    Pics.Add(New Symbols("England", Image.FromFile("england.ico")))
    Pics.Add(New Symbols("USA", Image.FromFile("usa.ico")))

    lstPics.SelectionMode = SelectionMode.MultiExtended
    lstPics.DataSource = Pics
    lstPics.DisplayMember = "Name"
    lstPics.ValueMember = "Flag"

    'Set up the status bar
    sb.Panels.Add("Flag = ")
    sb.Panels(0).AutoSize = StatusBarPanelAutoSize.Spring
    sb.ShowPanels = True


    'Transfer the data over.
    AddHandler cmdAdd.Click, New EventHandler(AddressOf MoveFlags)

    'Make sure the user can see all flags
    P1.AutoScroll = True
    'These delegates are added to facilitate marquis selection
    AddHandler P1.MouseMove, New MouseEventHandler(AddressOf PanelMouseMove)
    AddHandler P1.MouseDown, New MouseEventHandler(AddressOf PanelMouseDown)
    AddHandler P1.MouseUp, New MouseEventHandler(AddressOf PanelMouseUp)
    AddHandler P1.MouseMove, New MouseEventHandler(AddressOf PanelMouseMove)
    AddHandler P1.Paint, New PaintEventHandler(AddressOf PanelPaint)

    'Intercept all keyboard strokes before they get to the controls
    Me.KeyPreview = True
    AddHandler Me.KeyDown, New KeyEventHandler(AddressOf DeleteFlags)

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
  Friend WithEvents sb As System.Windows.Forms.StatusBar
  Friend WithEvents cmdAdd As System.Windows.Forms.Button
  Friend WithEvents lstPics As System.Windows.Forms.ListBox
  Friend WithEvents P1 As System.Windows.Forms.Panel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.sb = New System.Windows.Forms.StatusBar()
    Me.cmdAdd = New System.Windows.Forms.Button()
    Me.lstPics = New System.Windows.Forms.ListBox()
    Me.P1 = New System.Windows.Forms.Panel()
    Me.SuspendLayout()
    '
    'sb
    '
    Me.sb.Location = New System.Drawing.Point(0, 366)
    Me.sb.Name = "sb"
    Me.sb.Size = New System.Drawing.Size(480, 24)
    Me.sb.TabIndex = 7
    '
    'cmdAdd
    '
    Me.cmdAdd.Location = New System.Drawing.Point(8, 308)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.Size = New System.Drawing.Size(136, 32)
    Me.cmdAdd.TabIndex = 6
    Me.cmdAdd.Text = "Add to Panel"
    '
    'lstPics
    '
    Me.lstPics.Location = New System.Drawing.Point(8, 20)
    Me.lstPics.Name = "lstPics"
    Me.lstPics.Size = New System.Drawing.Size(136, 264)
    Me.lstPics.TabIndex = 5
    '
    'P1
    '
    Me.P1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.P1.Location = New System.Drawing.Point(160, 12)
    Me.P1.Name = "P1"
    Me.P1.Size = New System.Drawing.Size(312, 328)
    Me.P1.TabIndex = 4
    '
    'frmMouse
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 390)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sb, Me.cmdAdd, Me.lstPics, Me.P1})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmMouse"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Mouse Event Handlers"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub frmMouse_Load(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub


#Region "Helper functions"

  Private Sub ArrangeImages()
    Dim x As Int32 = 0
    Dim y As Int32 = 0
    Dim k As Int32
    Dim PICSPACE As Int32 = 10
    Dim PICSIZE As Int32 = 64

    'Number of pictures in a row.
    'Do not show a picture if it means we get a horizontal
    'scroll bar
    Dim NumPicsInWidth As Int32 = CType(((P1.Size.Width - PICSPACE) / _
                                          (PICSIZE + PICSPACE)) - 1, Int32)
    'Control collections are zero based.
    'VB type collections are 1 based.
    For k = 0 To P1.Controls.Count - 1
      'determine if we are in a new row
      If k Mod (NumPicsInWidth) = 0 Then
        x = PICSPACE
      Else
        x = P1.Controls(k - 1).Location.X + PICSIZE + PICSPACE
      End If

      If k < NumPicsInWidth Then
        y = PICSPACE
      ElseIf k Mod (NumPicsInWidth) = 0 Then
        y = P1.Controls(k - 1).Location.Y + PICSIZE + PICSPACE
      End If

      P1.Controls(k).Location = New Point(x, y)
    Next

  End Sub

#End Region

#Region "events"

  Private Sub MoveFlags(ByVal sender As Object, ByVal e As EventArgs)
    Dim flg As Symbols

    For Each flg In lstPics.SelectedItems
      Dim p As PictureBox = New PictureBox()
      p.Size = New Size(40, 40)
      p.SizeMode = PictureBoxSizeMode.StretchImage
      AddHandler p.MouseDown, New MouseEventHandler(AddressOf PicMouseDown)
      AddHandler p.MouseEnter, New EventHandler(AddressOf PicMouseEnter)
      AddHandler p.MouseLeave, New EventHandler(AddressOf PicMouseLeave)
      p.Cursor = Cursors.Hand
      p.Image = flg.Flag
      p.Tag = flg.Name
      P1.Controls.Add(p)
    Next

    ArrangeImages()

  End Sub

  Private Sub DeleteFlags(ByVal sender As Object, ByVal e As KeyEventArgs)

    If e.KeyCode = Keys.Delete Then

      'Try this shortcut. It will not work.  Do you know why?
      'Dim p As PictureBox
      'For Each p In P1.Controls
      '  If p.BorderStyle = BorderStyle.FixedSingle Then
      '    P1.Controls.Remove(p)
      '  End If
      'Next

      Dim p As PictureBox
      Dim deleted As Boolean = True
      Dim k As Int32
      While (deleted)
        deleted = False
        For k = 0 To P1.Controls.Count - 1
          If P1.Controls(k).GetType() Is GetType(PictureBox) Then
            p = DirectCast(P1.Controls(k), PictureBox)
            If p.BorderStyle = BorderStyle.FixedSingle Then
              P1.Controls.RemoveAt(k)
              deleted = True
              'Controls.count has changed. Reinitialize the "for" loop
              Exit For
            End If
          End If
        Next
      End While

      ArrangeImages()
    End If

  End Sub

  Private Sub PicMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
    Dim P As PictureBox

    If sender.GetType() Is GetType(PictureBox) Then
      P = DirectCast(sender, PictureBox)
    Else
      Return
    End If

    If e.Button = MouseButtons.Left Then
      If P.BorderStyle = BorderStyle.FixedSingle Then
        P.BorderStyle = BorderStyle.None
      Else
        P.BorderStyle = BorderStyle.FixedSingle
      End If
    End If

  End Sub

  Private Sub PicMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
    Dim P As PictureBox

    If sender.GetType() Is GetType(PictureBox) Then
      P = CType(sender, PictureBox)
    Else
      Return
    End If

    sb.Panels(0).Text = P.Tag.ToString()

  End Sub

  Private Sub PicMouseLeave(ByVal sender As Object, ByVal e As EventArgs)

    sb.Panels(0).Text = ""
  End Sub

#End Region

#Region "Marquis selection events"

  Private Sub PanelPaint(ByVal sender As Object, ByVal e As PaintEventArgs)
    Dim P As PictureBox
    Dim r As Rectangle = RectangleC.Convert(Marquis)

    If Not Marquis.Equals(Rectangle.Empty) Then
      e.Graphics.DrawRectangle(Pens.Red, r)
      For Each P In P1.Controls
        If r.Contains(P.Bounds) Then
          P.BorderStyle = BorderStyle.FixedSingle
        Else
          P.BorderStyle = BorderStyle.None
        End If
      Next
    End If
  End Sub

  Private Sub PanelMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)

    If e.Button <> MouseButtons.Left Then Return
    Marquis = New Rectangle(New Point(e.X, e.Y), Size.Empty)
  End Sub

  Private Sub PanelMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)

    If e.Button <> MouseButtons.Left Then Return

    Marquis.Size = New Size(e.X - Marquis.X, e.Y - Marquis.Y)
    P1.Invalidate()
  End Sub

  Private Sub PanelMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)

    Marquis = Rectangle.Empty
    P1.Invalidate()
  End Sub

#End Region
End Class
