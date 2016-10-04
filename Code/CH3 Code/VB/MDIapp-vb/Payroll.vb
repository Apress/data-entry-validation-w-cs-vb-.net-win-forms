Public Class Payroll
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    Dim m As ContextMenu
    m = New ContextMenu()
    m.MenuItems.Add("Add money to employee")
    m.MenuItems.Add("Remove money from employee")
    m.MenuItems.Add("Give raises to everyone")
    Dim mnu As MenuItem = m.MenuItems(m.MenuItems.Count - 1)
    mnu.Enabled = False
    m.MenuItems.Add("Cut in pay")

    lblCash.ContextMenu = m

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
  Friend WithEvents lblCash As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lblCash = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'lblCash
    '
    Me.lblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 100.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCash.Location = New System.Drawing.Point(66, 56)
    Me.lblCash.Name = "lblCash"
    Me.lblCash.Size = New System.Drawing.Size(160, 160)
    Me.lblCash.TabIndex = 1
    Me.lblCash.Text = "$"
    Me.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Payroll
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCash})
    Me.Name = "Payroll"
    Me.Text = "Payroll"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Payroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class
