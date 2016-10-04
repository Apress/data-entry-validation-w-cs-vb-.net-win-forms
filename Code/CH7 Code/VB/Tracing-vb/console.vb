Option Strict On

Public Class console
  Inherits System.Windows.Forms.Form

  Private mAlive As Boolean

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()
    mAlive = True
    Me.Hide()

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
    mAlive = False
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents txtOut As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.txtOut = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'txtOut
    '
    Me.txtOut.AcceptsReturn = True
    Me.txtOut.AcceptsTab = True
    Me.txtOut.BackColor = System.Drawing.Color.Black
    Me.txtOut.Dock = System.Windows.Forms.DockStyle.Fill
    Me.txtOut.ForeColor = System.Drawing.Color.White
    Me.txtOut.Multiline = True
    Me.txtOut.Name = "txtOut"
    Me.txtOut.Size = New System.Drawing.Size(494, 352)
    Me.txtOut.TabIndex = 1
    Me.txtOut.Text = ""
    '
    'console
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(494, 352)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtOut})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.Name = "console"
    Me.Text = "Console Output"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Public ReadOnly Property IsAlive() As Boolean
    Get
      Return mAlive
    End Get
  End Property

  Public Sub Out(ByVal buffer As String)
    Me.Show()
    txtOut.AppendText(buffer)
  End Sub

  Public Sub OutL(ByVal buffer As String)
    Me.Show()
    txtOut.AppendText(buffer + vbCrLf)
  End Sub

  Public Sub Clear()
    txtOut.Text = String.Empty
  End Sub

End Class
