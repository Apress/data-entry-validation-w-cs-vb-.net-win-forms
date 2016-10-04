Option Strict On

Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports System.IO

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Name = "Form1"
    Me.Text = "Form1"

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Try
      Dim file As StreamReader = New StreamReader("MyFile.txt")
      Dim s As String = file.ReadLine()
      If s = String.Empty Or s Is Nothing Then
        Throw New ApplicationException("First line was empty")
      End If
      Dim x As Int32 = Int32.Parse(s)
      s = file.ReadLine()
      If s = String.Empty Or s Is Nothing Then
        Throw New ApplicationException("second line was empty")
      End If

      Dim y As Int32 = Int32.Parse(s)
      If y <> 0 Then
        Dim z As Int32 = CInt(x / y)
        MessageBox.Show("The value of X/Y is " + x.ToString())
      Else
        MessageBox.Show("Unable to divide numbers")
      End If

    Catch ex As IOException
      MessageBox.Show("File I/O Exception: " + ex.Message)
      'Put a trace message here
    Catch ex As ApplicationException
      MessageBox.Show(ex.Message)
      'Put a trace message here
    Catch ex As Exception
      MessageBox.Show(ex.Message)
      'Put a trace message here
    End Try

    Me.Close()
  End Sub

  Private Sub foo()
    Dim file As StreamReader

    Try
      File = New StreamReader("MyFile.txt")
      file.Close()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      If Not file Is Nothing Then
        file.Close()
      End If
    End Try
  End Sub

  Private Sub FooBar()
    Dim file As StreamReader = Nothing
    Dim B As SolidBrush = New SolidBrush(Color.Azure)
    Dim P As Pen = New Pen(B, 3)
    Dim F As Font = New Font("Arial", 12)
    Dim G As Graphics = Nothing

    Try
      G = Graphics.FromHwnd(Me.Handle)
      file = New StreamReader("MyFile.txt")
      Dim s As String = file.ReadLine()
      G.DrawString(s, F, B, 10, 20)
      ' Do some funky stuff with the pen here
      ' Also do some extensive code
      '...
      '...
      If s = "The End" Then
        Return
      End If

      s = file.ReadLine()
      ' Do some more stuff with the pen here
      ' Also do some more extensive code
      '...
      '...
      G.DrawString(s, F, B, 30, 20)

    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      If Not G Is Nothing Then
        G.Dispose()
      End If
      If Not F Is Nothing Then
        F.Dispose()
      End If
      If Not P Is Nothing Then
        P.Dispose()
      End If
      If Not B Is Nothing Then
        B.Dispose()
      End If
      If Not file Is Nothing Then
        file.Close()
      End If
      end try

  End Sub

End Class
