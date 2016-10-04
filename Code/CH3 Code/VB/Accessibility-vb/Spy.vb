Option Strict On

Public Class Spy
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
  Friend WithEvents lblText As System.Windows.Forms.Label
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents lblDesc As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lblText = New System.Windows.Forms.Label()
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.lblDesc = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'lblText
    '
    Me.lblText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblText.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblText.Location = New System.Drawing.Point(32, 210)
    Me.lblText.Name = "lblText"
    Me.lblText.Size = New System.Drawing.Size(424, 48)
    Me.lblText.TabIndex = 7
    Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(32, 186)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(416, 24)
    Me.label2.TabIndex = 6
    Me.label2.Text = "Text"
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(24, 42)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(424, 24)
    Me.label1.TabIndex = 5
    Me.label1.Text = "Accessible Description"
    '
    'lblDesc
    '
    Me.lblDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblDesc.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblDesc.Location = New System.Drawing.Point(24, 66)
    Me.lblDesc.Name = "lblDesc"
    Me.lblDesc.Size = New System.Drawing.Size(424, 48)
    Me.lblDesc.TabIndex = 4
    Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Spy
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 300)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblText, Me.label2, Me.label1, Me.lblDesc})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Name = "Spy"
    Me.Text = "Spy"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Spy_Load(ByVal sender As System.Object, _
                       ByVal e As System.EventArgs) Handles MyBase.Load

    'This precludes menus becaus a menu is a component
    Dim c As Control
    For Each c In Me.Owner.Controls
      AddHandler c.MouseEnter, AddressOf AccessibleEnter
      AddHandler c.MouseLeave, AddressOf AccessibleLeave
    Next

  End Sub

  Private Sub AccessibleEnter(ByVal sender As Object, ByVal e As EventArgs)
    Dim c As Control

    'This precludes menus.  You can include menus if you like
    'by testing for a component.

    'I cannot test for lineage like in C#
    c = CType(sender, Control)

    'Dont bother with incidental controls
    If c.AccessibleRole = AccessibleRole.Default Then
      Return
    End If

    Beep()

    lblDesc.Text = c.AccessibleDescription
    lblText.Text = c.Text
  End Sub

  Private Sub AccessibleLeave(ByVal sender As Object, ByVal e As EventArgs)

    lblDesc.Text = ""
    lblText.Text = ""
  End Sub

End Class
