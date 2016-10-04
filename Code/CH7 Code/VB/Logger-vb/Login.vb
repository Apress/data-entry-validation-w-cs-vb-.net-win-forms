Public Class Login
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
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdOK As System.Windows.Forms.Button
  Friend WithEvents txtPass As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdOK = New System.Windows.Forms.Button()
    Me.txtPass = New System.Windows.Forms.TextBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.txtName = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'cmdCancel
    '
    Me.cmdCancel.Location = New System.Drawing.Point(152, 136)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(72, 32)
    Me.cmdCancel.TabIndex = 16
    Me.cmdCancel.Text = "Cancel"
    '
    'cmdOK
    '
    Me.cmdOK.Location = New System.Drawing.Point(40, 136)
    Me.cmdOK.Name = "cmdOK"
    Me.cmdOK.Size = New System.Drawing.Size(72, 32)
    Me.cmdOK.TabIndex = 15
    Me.cmdOK.Text = "OK"
    '
    'txtPass
    '
    Me.txtPass.Location = New System.Drawing.Point(24, 96)
    Me.txtPass.MaxLength = 5
    Me.txtPass.Name = "txtPass"
    Me.txtPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
    Me.txtPass.Size = New System.Drawing.Size(224, 20)
    Me.txtPass.TabIndex = 14
    Me.txtPass.Text = ""
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(24, 80)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(128, 16)
    Me.label2.TabIndex = 13
    Me.label2.Text = "Password"
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(24, 40)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(224, 20)
    Me.txtName.TabIndex = 12
    Me.txtName.Text = ""
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(24, 24)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(128, 16)
    Me.label1.TabIndex = 11
    Me.label1.Text = "Login Name"
    '
    'Login
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(272, 206)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.cmdOK, Me.txtPass, Me.label2, Me.txtName, Me.label1})
    Me.Name = "Login"
    Me.Text = "Login"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdOK_Click(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) Handles cmdOK.Click
    Const LoginOK As Boolean = True   'Causes unreachable code

    'First put in some code to evaluate if login succeeded
    If LoginOK Then
      EventLogger.LoginOK(txtName.Text)
    Else
      EventLogger.LoginFailed(txtName.Text)
    End If

    Me.Close()

  End Sub

  Private Sub cmdCancel_Click(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) Handles cmdCancel.Click
    EventLogger.LoginCanceled(txtName.Text)
    Me.Close()

  End Sub

  Private Sub Login_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
    EventLogger.ProgramStart()
  End Sub
End Class
