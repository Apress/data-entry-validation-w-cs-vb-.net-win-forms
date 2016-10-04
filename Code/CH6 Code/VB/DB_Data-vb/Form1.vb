Option Strict On

Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb

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
  Friend WithEvents lstParts As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lstParts = New System.Windows.Forms.ListBox()
    Me.SuspendLayout()
    '
    'lstParts
    '
    Me.lstParts.Location = New System.Drawing.Point(42, 47)
    Me.lstParts.Name = "lstParts"
    Me.lstParts.Size = New System.Drawing.Size(208, 173)
    Me.lstParts.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstParts})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
                         ByVal e As System.EventArgs) Handles MyBase.Load
    Dim Provider As String

    Provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyDB.MDB"
    Dim strSQL As String = "SELECT * FROM autoparts"
    ' create Objects of ADOConnection and ADOCommand
    Dim myConn As OleDbConnection = New OleDbConnection(Provider)
    Dim myCmd As OleDbCommand = New OleDbCommand(strSQL, myConn)
    Dim datareader As OleDbDataReader = Nothing

    Try
      myConn.Open()
      datareader = myCmd.ExecuteReader()
      While datareader.Read()
        lstParts.Items.Add(datareader("au_PartName"))
      End While
    Catch ex As Exception
      MessageBox.Show("Database Error: {0}", ex.Message)
    Finally
      myConn.Close()
    End Try

  End Sub
End Class
