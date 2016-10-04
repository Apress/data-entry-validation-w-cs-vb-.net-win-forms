Option Strict On

Imports System.Data
Imports System.Diagnostics
Imports System.IO

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region "class local variables"
  Dim Tsw As TraceSwitch
#End Region


  Public Class NewListener
    Inherits TraceListener

    Dim con As console = New console()

    Public Sub New()
      con = Nothing
    End Sub

    Public Overloads Overrides Sub Write(ByVal s As String)
      If con Is Nothing OrElse Not con.IsAlive Then
        con = New console()
      End If

      con.Out(s)
    End Sub

    Public Overloads Overrides Sub WriteLine(ByVal s As String)
      If con Is Nothing OrElse Not con.IsAlive Then
        con = New console()
      End If

      con.OutL(s)
    End Sub

    Public Overloads Overrides Sub Close()
      If Not con Is Nothing Then
        con.Close()
        con = Nothing
      End If
    End Sub

    Public Sub clear()
      If Not con Is Nothing Then
        con.Clear()
      End If
    End Sub
  End Class

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    Tsw = New TraceSwitch("VerboseTrace", "Trace data read/write")

    Dim myFile As Stream = File.Create("TestFile.txt")
    Trace.Listeners.Add(New TextWriterTraceListener(myFile))
    Trace.Listeners.Add(New NewListener())
    Trace.AutoFlush = True

    AddHandler txtInput.KeyPress, New KeyPressEventHandler(AddressOf KeyPress)
    AddHandler cmdEnable.Click, New EventHandler(AddressOf EnableTrace)
    AddHandler cmdDisable.Click, New EventHandler(AddressOf DisableTrace)
    AddHandler cmdQuit.Click, New EventHandler(AddressOf Quit)

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
  Friend WithEvents cmdQuit As System.Windows.Forms.Button
  Friend WithEvents txtInput As System.Windows.Forms.TextBox
  Friend WithEvents cmdDisable As System.Windows.Forms.Button
  Friend WithEvents cmdEnable As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdQuit = New System.Windows.Forms.Button()
    Me.txtInput = New System.Windows.Forms.TextBox()
    Me.cmdDisable = New System.Windows.Forms.Button()
    Me.cmdEnable = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'cmdQuit
    '
    Me.cmdQuit.Location = New System.Drawing.Point(264, 223)
    Me.cmdQuit.Name = "cmdQuit"
    Me.cmdQuit.Size = New System.Drawing.Size(72, 32)
    Me.cmdQuit.TabIndex = 7
    Me.cmdQuit.Text = "Quit"
    '
    'txtInput
    '
    Me.txtInput.Location = New System.Drawing.Point(24, 23)
    Me.txtInput.Multiline = True
    Me.txtInput.Name = "txtInput"
    Me.txtInput.Size = New System.Drawing.Size(312, 160)
    Me.txtInput.TabIndex = 6
    Me.txtInput.Text = ""
    '
    'cmdDisable
    '
    Me.cmdDisable.Location = New System.Drawing.Point(24, 231)
    Me.cmdDisable.Name = "cmdDisable"
    Me.cmdDisable.Size = New System.Drawing.Size(120, 24)
    Me.cmdDisable.TabIndex = 5
    Me.cmdDisable.Text = "Disable Trace"
    '
    'cmdEnable
    '
    Me.cmdEnable.Location = New System.Drawing.Point(24, 199)
    Me.cmdEnable.Name = "cmdEnable"
    Me.cmdEnable.Size = New System.Drawing.Size(120, 24)
    Me.cmdEnable.TabIndex = 4
    Me.cmdEnable.Text = "Enable Trace"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(360, 278)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdQuit, Me.txtInput, Me.cmdDisable, Me.cmdEnable})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
    'You should not see this anywhere in any trace logs
    Trace.WriteLineIf(Tsw.TraceVerbose, "Program Started")

  End Sub

#Region "events"

  Private Sub EnableTrace(ByVal sender As Object, ByVal e As EventArgs)
    Tsw.Level = TraceLevel.Verbose
    Trace.WriteLineIf(Tsw.TraceVerbose, DateTime.Now.ToString() + _
                                        "  Tracing enabled")
  End Sub

  Private Sub DisableTrace(ByVal sender As Object, ByVal e As EventArgs)
    Trace.WriteLineIf(Tsw.TraceVerbose, DateTime.Now.ToString() + _
      "  Tracing Disabled")
    Tsw.Level = TraceLevel.Off
  End Sub

  Private Sub Quit(ByVal sender As Object, ByVal e As EventArgs)
    Trace.WriteLineIf(Tsw.TraceVerbose, DateTime.Now.ToString() + _
      "  Program Closed")
    Trace.Close()
    Me.Close()
  End Sub

  Private Shadows Sub KeyPress(ByVal sender As Object, _
                               ByVal e As KeyPressEventArgs)
    Trace.WriteIf(Tsw.TraceVerbose, e.KeyChar.ToString())
  End Sub
#End Region



End Class
