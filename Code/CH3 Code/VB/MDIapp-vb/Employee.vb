Public Class Employee
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
  Friend WithEvents button5 As System.Windows.Forms.Button
  Friend WithEvents button4 As System.Windows.Forms.Button
  Friend WithEvents button3 As System.Windows.Forms.Button
  Friend WithEvents button2 As System.Windows.Forms.Button
  Friend WithEvents button1 As System.Windows.Forms.Button
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents checkedListBox1 As System.Windows.Forms.CheckedListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.button5 = New System.Windows.Forms.Button()
    Me.button4 = New System.Windows.Forms.Button()
    Me.button3 = New System.Windows.Forms.Button()
    Me.button2 = New System.Windows.Forms.Button()
    Me.button1 = New System.Windows.Forms.Button()
    Me.label1 = New System.Windows.Forms.Label()
    Me.checkedListBox1 = New System.Windows.Forms.CheckedListBox()
    Me.SuspendLayout()
    '
    'button5
    '
    Me.button5.Location = New System.Drawing.Point(400, 291)
    Me.button5.Name = "button5"
    Me.button5.Size = New System.Drawing.Size(64, 32)
    Me.button5.TabIndex = 26
    Me.button5.Text = "Cancel"
    '
    'button4
    '
    Me.button4.Location = New System.Drawing.Point(312, 291)
    Me.button4.Name = "button4"
    Me.button4.Size = New System.Drawing.Size(64, 32)
    Me.button4.TabIndex = 25
    Me.button4.Text = "OK"
    '
    'button3
    '
    Me.button3.Location = New System.Drawing.Point(312, 243)
    Me.button3.Name = "button3"
    Me.button3.Size = New System.Drawing.Size(152, 32)
    Me.button3.TabIndex = 24
    Me.button3.Text = "Randomly Demote"
    '
    'button2
    '
    Me.button2.Location = New System.Drawing.Point(312, 195)
    Me.button2.Name = "button2"
    Me.button2.Size = New System.Drawing.Size(152, 32)
    Me.button2.TabIndex = 23
    Me.button2.Text = "Fire Employee"
    '
    'button1
    '
    Me.button1.Location = New System.Drawing.Point(312, 147)
    Me.button1.Name = "button1"
    Me.button1.Size = New System.Drawing.Size(152, 32)
    Me.button1.TabIndex = 22
    Me.button1.Text = "Add Employee"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(16, 19)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(264, 16)
    Me.label1.TabIndex = 21
    Me.label1.Text = "Employees"
    Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'checkedListBox1
    '
    Me.checkedListBox1.Items.AddRange(New Object() {"Jack", "Jim", "Jane", "Leon"})
    Me.checkedListBox1.Location = New System.Drawing.Point(16, 35)
    Me.checkedListBox1.Name = "checkedListBox1"
    Me.checkedListBox1.Size = New System.Drawing.Size(272, 289)
    Me.checkedListBox1.TabIndex = 20
    '
    'Employee
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 342)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button5, Me.button4, Me.button3, Me.button2, Me.button1, Me.label1, Me.checkedListBox1})
    Me.Name = "Employee"
    Me.Text = "Employee"
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
