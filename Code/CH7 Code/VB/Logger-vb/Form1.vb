Public Class Form1
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
    EventLogger.ProgramEnd()

    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents cmdLogin As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdLogin = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'cmdLogin
    '
    Me.cmdLogin.Location = New System.Drawing.Point(78, 117)
    Me.cmdLogin.Name = "cmdLogin"
    Me.cmdLogin.Size = New System.Drawing.Size(136, 32)
    Me.cmdLogin.TabIndex = 1
    Me.cmdLogin.Text = "Login"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdLogin})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdLogin_Click(ByVal sender As System.Object, _
                             ByVal e As System.EventArgs) Handles cmdLogin.Click
    Dim frm As Login = New Login()
    frm.ShowDialog()

  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    EventLogger.ProgramStart()
  End Sub
End Class
