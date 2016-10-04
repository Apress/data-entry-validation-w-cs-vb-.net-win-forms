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
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents lstMovies As System.Windows.Forms.CheckedListBox
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents txtAddr As System.Windows.Forms.TextBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents Err As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lstMovies = New System.Windows.Forms.CheckedListBox()
    Me.label3 = New System.Windows.Forms.Label()
    Me.txtAddr = New System.Windows.Forms.TextBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.txtName = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.cmdSave = New System.Windows.Forms.Button()
    Me.Err = New System.Windows.Forms.ErrorProvider()
    Me.SuspendLayout()
    '
    'lstMovies
    '
    Me.lstMovies.Location = New System.Drawing.Point(19, 153)
    Me.lstMovies.Name = "lstMovies"
    Me.lstMovies.Size = New System.Drawing.Size(264, 109)
    Me.lstMovies.TabIndex = 14
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(19, 137)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(104, 16)
    Me.label3.TabIndex = 13
    Me.label3.Text = "Favorite movie"
    '
    'txtAddr
    '
    Me.txtAddr.Location = New System.Drawing.Point(19, 89)
    Me.txtAddr.Name = "txtAddr"
    Me.txtAddr.Size = New System.Drawing.Size(168, 20)
    Me.txtAddr.TabIndex = 12
    Me.txtAddr.Text = ""
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(19, 73)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(104, 16)
    Me.label2.TabIndex = 11
    Me.label2.Text = "Address"
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(19, 33)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(168, 20)
    Me.txtName.TabIndex = 10
    Me.txtName.Text = ""
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(19, 17)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(104, 16)
    Me.label1.TabIndex = 9
    Me.label1.Text = "Name"
    '
    'cmdSave
    '
    Me.cmdSave.Location = New System.Drawing.Point(339, 265)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(72, 32)
    Me.cmdSave.TabIndex = 8
    Me.cmdSave.Text = "Save"
    '
    'Err
    '
    Me.Err.DataMember = Nothing
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(430, 315)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstMovies, Me.label3, Me.txtAddr, Me.label2, Me.txtName, Me.label1, Me.cmdSave})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdSave_Click(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles cmdSave.Click

    If (txtName.Text = String.Empty) Then
      Err.SetError(txtName, "Cannot save form without a name")
    Else
      Err.SetError(txtName, "")
    End If

    If (txtAddr.Text = String.Empty) Then
      Err.SetError(txtAddr, "Cannot save form without an address")
    Else
      Err.SetError(txtAddr, "")
    End If

    If (lstMovies.SelectedIndices.Count = 0) Then
      Err.SetError(lstMovies, "Cannot save form without a favorite movie")
    Else
      Err.SetError(lstMovies, "")
    End If

  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load

    lstMovies.Items.Add("Dumbo")
    lstMovies.Items.Add("WindTalkers")
    lstMovies.Items.Add("Paper Chase")
    lstMovies.Items.Add("War Of The Worlds")
    lstMovies.Items.Add("LOTR")

  End Sub
End Class
