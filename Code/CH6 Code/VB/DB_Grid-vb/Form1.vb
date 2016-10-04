Option Strict On

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region "class local variables"

  Dim Provider As String = _
                  "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyDB.MDB"
  Dim MyDB_Conn As OleDbConnection
  Dim SQL_parts As OleDbDataAdapter
  Dim SQL_inv As OleDbDataAdapter
  Dim OLE_Parts As OleDbCommandBuilder
  Dim OLE_Inv As OleDbCommandBuilder

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    AddHandler cmdParts.Click, New EventHandler(AddressOf ViewParts)
    AddHandler cmdInventory.Click, New EventHandler(AddressOf ViewInventory)
    AddHandler cmdBoth.Click, New EventHandler(AddressOf ViewBoth)
    AddHandler cmdCommit.Click, New EventHandler(AddressOf CommitChanges)
    'cmdCommit.Enabled = False

    'First thing to do is establish the connection
    MyDB_Conn = New OleDbConnection(Provider)

    'Now create some SQL statements that get data from different tables
    SQL_parts = New OleDbDataAdapter("SELECT * FROM AutoParts", MyDB_Conn)
    SQL_parts.SelectCommand = _
                New OleDbCommand("SELECT * FROM AutoParts", MyDB_Conn)
    OLE_Parts = New OleDbCommandBuilder(SQL_parts)

    SQL_inv = New OleDbDataAdapter("SELECT * FROM Inventory", MyDB_Conn)
    SQL_inv.SelectCommand = _
              New OleDbCommand("SELECT * FROM Inventory", MyDB_Conn)
    OLE_Inv = New OleDbCommandBuilder(SQL_inv)

    'You now have your SQL statements that get all data from both 
    'tables in the database.  Create a data set and add 2 tables
    Dim DS As DataSet = New DataSet()
    Dim Parts As DataTable = New DataTable("AutoParts")
    Dim Inv As DataTable = New DataTable("Inventory")
    DS.Tables.Add(Parts)
    DS.Tables.Add(Inv)

    MyDB_Conn.Open()

    'Use the SQL data adapters to fill the tables via the SQL statements
    SQL_parts.Fill(DS, "AutoParts")
    SQL_inv.Fill(DS, "Inventory")

    ''Normally I would put this at the end.  I put it here
    ''to prove a point... The data set is disconnected and you
    ''can still work with it after the connection is gone.
    ''If you need to update the database you will need to keep 
    ''this connection.
    'MyDB_Conn.Close()
    'MyDB_Conn.Dispose()

    'Once I have the data tables filled in the data set I can manipulate the
    'existing columns.
    Parts.Columns(0).Caption = "ID"
    Parts.Columns(0).ColumnName = "ID"
    Parts.Columns(1).Caption = "Name"
    Parts.Columns(1).ColumnName = "Name"
    Parts.Columns(2).Caption = "Vehicle ID"
    Parts.Columns(2).ColumnName = "Vehicle ID"
    Parts.Columns(3).Caption = "Notes"
    Parts.Columns(3).ColumnName = "Notes"
    'Make the last 2 columns invisible
    Parts.Columns(4).ColumnMapping = MappingType.Hidden
    Parts.Columns(5).ColumnMapping = MappingType.Hidden

    'Inv.Columns(0).Caption = "Part Num"
    'Inv.Columns(0).ColumnName = "Part Num"
    'Inv.Columns(1).Caption = "Current Count"
    'Inv.Columns(1).ColumnName = "Current Count"
    'Inv.Columns(2).Caption = "Reorder Count"
    'Inv.Columns(2).ColumnName = "Reorder Count"

    'Bind the table in the data source to the grid display
    dg1.SetDataBinding(DS, "AutoParts")

    'This object takes up space.  Get rid of them.
    DS.Dispose()
  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
      If Not MyDB_Conn Is Nothing Then
        MyDB_Conn.Close()
        MyDB_Conn.Dispose()
      End If
      If Not SQL_inv Is Nothing Then
        SQL_inv.Dispose()
      End If
      If Not SQL_parts Is Nothing Then
        SQL_parts.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents cmdCommit As System.Windows.Forms.Button
  Friend WithEvents cmdBoth As System.Windows.Forms.Button
  Friend WithEvents cmdInventory As System.Windows.Forms.Button
  Friend WithEvents cmdParts As System.Windows.Forms.Button
  Friend WithEvents dg1 As System.Windows.Forms.DataGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdCommit = New System.Windows.Forms.Button()
    Me.cmdBoth = New System.Windows.Forms.Button()
    Me.cmdInventory = New System.Windows.Forms.Button()
    Me.cmdParts = New System.Windows.Forms.Button()
    Me.dg1 = New System.Windows.Forms.DataGrid()
    CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cmdCommit
    '
    Me.cmdCommit.Location = New System.Drawing.Point(423, 321)
    Me.cmdCommit.Name = "cmdCommit"
    Me.cmdCommit.Size = New System.Drawing.Size(88, 32)
    Me.cmdCommit.TabIndex = 9
    Me.cmdCommit.Text = "Commit"
    '
    'cmdBoth
    '
    Me.cmdBoth.Location = New System.Drawing.Point(263, 321)
    Me.cmdBoth.Name = "cmdBoth"
    Me.cmdBoth.Size = New System.Drawing.Size(88, 32)
    Me.cmdBoth.TabIndex = 8
    Me.cmdBoth.Text = "Both"
    '
    'cmdInventory
    '
    Me.cmdInventory.Location = New System.Drawing.Point(151, 321)
    Me.cmdInventory.Name = "cmdInventory"
    Me.cmdInventory.Size = New System.Drawing.Size(88, 32)
    Me.cmdInventory.TabIndex = 7
    Me.cmdInventory.Text = "Inventory"
    '
    'cmdParts
    '
    Me.cmdParts.Location = New System.Drawing.Point(39, 321)
    Me.cmdParts.Name = "cmdParts"
    Me.cmdParts.Size = New System.Drawing.Size(88, 32)
    Me.cmdParts.TabIndex = 6
    Me.cmdParts.Text = "Parts"
    '
    'dg1
    '
    Me.dg1.DataMember = ""
    Me.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dg1.Location = New System.Drawing.Point(23, 25)
    Me.dg1.Name = "dg1"
    Me.dg1.Size = New System.Drawing.Size(584, 272)
    Me.dg1.TabIndex = 5
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(630, 379)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCommit, Me.cmdBoth, Me.cmdInventory, Me.cmdParts, Me.dg1})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

#Region "events"

  Private Sub ViewParts(ByVal sender As Object, ByVal e As EventArgs)
    dg1.SetDataBinding(dg1.DataSource, "AutoParts")
  End Sub

  Private Sub ViewInventory(ByVal sender As Object, ByVal e As EventArgs)
    dg1.SetDataBinding(dg1.DataSource, "Inventory")
  End Sub

  Private Sub ViewBoth(ByVal sender As Object, ByVal e As EventArgs)
    'Setting this to a null string forces the top
    'level view.
    dg1.SetDataBinding(dg1.DataSource, "")
    dg1.Expand(-1)
  End Sub

  Private Sub CommitChanges(ByVal sender As Object, ByVal e As EventArgs)
    Dim DS As DataSet = CType(dg1.DataSource, DataSet)
    Dim DS_Change As DataSet = DS.GetChanges(DataRowState.Modified)
    If Not DS_Change Is Nothing Then
      If Not DS_Change.HasErrors Then
        'get the data adapter and call update
        Try
          SQL_inv.Update(DS_Change, "Inventory")
          MessageBox.Show("Saving Iventory data successful!")
        Catch ex As Exception
          MessageBox.Show("Error Saving Iventory data\n{0}", ex.Message)
        End Try
      End If
    End If
  End Sub

#End Region



End Class
