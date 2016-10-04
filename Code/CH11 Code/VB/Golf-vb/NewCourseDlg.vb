Option Strict On

Public Class NewCourseDlg
  Inherits System.Windows.Forms.Form

  Private mName As String = String.Empty

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    txtName.MaxLength = 50

    'Setting the dialogresult of the button makes the form 
    'take the same dialog result.  The form is then hidden.
    TopMost = True
    Text = "New Course"
    cmdSave.DialogResult = DialogResult.OK
    AddHandler cmdSave.Click, New EventHandler(AddressOf OK)
    cmdCancel.DialogResult = DialogResult.Cancel
    AddHandler cmdCancel.Click, New EventHandler(AddressOf Cancel)

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
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents lblName As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdSave = New System.Windows.Forms.Button()
    Me.txtName = New System.Windows.Forms.TextBox()
    Me.lblName = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'cmdCancel
    '
    Me.cmdCancel.Location = New System.Drawing.Point(161, 67)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(104, 32)
    Me.cmdCancel.TabIndex = 7
    Me.cmdCancel.Text = "Cancel"
    '
    'cmdSave
    '
    Me.cmdSave.Location = New System.Drawing.Point(17, 67)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(104, 32)
    Me.cmdSave.TabIndex = 6
    Me.cmdSave.Text = "OK"
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(17, 27)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(248, 20)
    Me.txtName.TabIndex = 5
    Me.txtName.Text = ""
    '
    'lblName
    '
    Me.lblName.Location = New System.Drawing.Point(17, 11)
    Me.lblName.Name = "lblName"
    Me.lblName.Size = New System.Drawing.Size(248, 16)
    Me.lblName.TabIndex = 4
    Me.lblName.Text = "Enter Name for new golf course"
    '
    'NewCourseDlg
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(282, 111)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.cmdSave, Me.txtName, Me.lblName})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "NewCourseDlg"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "NewCourseDlg"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Public ReadOnly Property NewName() As String
    Get
      Return mName
    End Get
  End Property

#Region "Events"

  Private Sub OK(ByVal sender As Object, ByVal e As EventArgs)
    mName = txtName.Text

    'Since dialogresult was assigned to this button the form will
    'hide itself rather than close.
  End Sub

  Private Sub Cancel(ByVal sender As Object, ByVal e As EventArgs)
    mName = String.Empty

    'Since dialogresult was assigned to this button the form will
    'hide itself rather than close.
  End Sub

#End Region

End Class
