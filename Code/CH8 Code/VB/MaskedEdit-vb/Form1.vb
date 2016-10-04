Option Strict On

Imports AxMSMask

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()


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
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents meDate As AxMSMask.AxMaskEdBox
  Friend WithEvents meTime As AxMSMask.AxMaskEdBox
  Friend WithEvents L As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.meDate = New AxMSMask.AxMaskEdBox()
    Me.meTime = New AxMSMask.AxMaskEdBox()
    Me.L = New System.Windows.Forms.ListBox()
    CType(Me.meDate, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.meTime, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(24, 80)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(152, 16)
    Me.label2.TabIndex = 11
    Me.label2.Text = "Enter Military Time"
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(24, 16)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(152, 16)
    Me.label1.TabIndex = 10
    Me.label1.Text = "Enter Date"
    '
    'meDate
    '
    Me.meDate.Location = New System.Drawing.Point(24, 32)
    Me.meDate.Name = "meDate"
    Me.meDate.OcxState = CType(resources.GetObject("meDate.OcxState"), System.Windows.Forms.AxHost.State)
    Me.meDate.Size = New System.Drawing.Size(168, 24)
    Me.meDate.TabIndex = 1
    '
    'meTime
    '
    Me.meTime.Location = New System.Drawing.Point(24, 96)
    Me.meTime.Name = "meTime"
    Me.meTime.OcxState = CType(resources.GetObject("meTime.OcxState"), System.Windows.Forms.AxHost.State)
    Me.meTime.Size = New System.Drawing.Size(168, 24)
    Me.meTime.TabIndex = 2
    '
    'L
    '
    Me.L.Location = New System.Drawing.Point(16, 160)
    Me.L.Name = "L"
    Me.L.Size = New System.Drawing.Size(192, 160)
    Me.L.TabIndex = 0
    Me.L.TabStop = False
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(240, 357)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.L, Me.meTime, Me.meDate, Me.label2, Me.label1})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    CType(Me.meDate, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.meTime, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load

    AddHandler meDate.ValidationError, _
              New MaskEdBoxEvents_ValidationErrorEventHandler(AddressOf DateErr)
    AddHandler meDate.Enter, New EventHandler(AddressOf DateEnter)
    AddHandler meDate.Leave, New EventHandler(AddressOf DateLeave)

    AddHandler meTime.ValidationError, _
              New MaskEdBoxEvents_ValidationErrorEventHandler(AddressOf TimeErr)
    AddHandler meTime.Enter, New EventHandler(AddressOf TimeEnter)
    AddHandler meTime.Leave, New EventHandler(AddressOf TimeLeave)

  End Sub

#Region "Masked Edit events"

  Private Sub DateEnter(ByVal sender As Object, ByVal e As EventArgs)
    L.Items.Add("Date got focus")
  End Sub

  Private Sub DateLeave(ByVal sender As Object, ByVal e As EventArgs)
    L.Items.Add("Date left")
    L.Items.Add("Date Text = " + meDate.Text)
  End Sub

  Private Sub DateErr(ByVal sender As Object, _
                      ByVal e As MaskEdBoxEvents_ValidationErrorEvent)
    L.Items.Add("Date validation error")
  End Sub

  Private Sub TimeEnter(ByVal sender As Object, ByVal e As EventArgs)
    L.Items.Add("Time got focus")
  End Sub

  Private Sub TimeLeave(ByVal sender As Object, ByVal e As EventArgs)
    L.Items.Add("Time left")
    L.Items.Add("Time Text = " + meTime.Text)
  End Sub

  Private Sub TimeErr(ByVal sender As Object, _
                      ByVal e As MaskEdBoxEvents_ValidationErrorEvent)
    L.Items.Add("Time validation error")
  End Sub

#End Region


End Class
