Option Strict On

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    'Create a new data set with a table
    Dim DS As DataSet = New DataSet()
    Dim DT As DataTable = MakeTable()

    Dim t As Town = Towns.Hartford
    DT.Rows.Add(New Object() {t.Name, t.State, t.County, t.MillRate})
    t = Towns.LosAngeles
    DT.Rows.Add(New Object() {t.Name, t.State, t.County, t.MillRate})
    t = Towns.Orlando
    DT.Rows.Add(New Object() {t.Name, t.State, t.County, t.MillRate})
    DT.AcceptChanges() 'A base comparison to reject changes if necessary

    'Add table to data set
    'Only one table so assign source directly to it.
    DS.Tables.Add(DT)
    dg1.DataSource = DS
    dg1.DataMember = "SomeTowns"

    AddHandler DT.ColumnChanged, _
               New DataColumnChangeEventHandler(AddressOf DataChanged)
    AddHandler dg1.MouseDown, _
               New MouseEventHandler(AddressOf Grid_MouseDown)

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
  Friend WithEvents dg1 As System.Windows.Forms.DataGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.dg1 = New System.Windows.Forms.DataGrid()
    CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dg1
    '
    Me.dg1.DataMember = ""
    Me.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dg1.Location = New System.Drawing.Point(23, 42)
    Me.dg1.Name = "dg1"
    Me.dg1.Size = New System.Drawing.Size(520, 296)
    Me.dg1.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(566, 380)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dg1})
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

#Region "event code"

  Private Sub DataChanged(ByVal sender As Object, _
                          ByVal e As DataColumnChangeEventArgs)
    Dim dt As DataTable = CType(sender, DataTable)

    If e.Column.ColumnName.Equals("MillRate") Then
      If CType(e.ProposedValue, Single) < Towns.MinAllowedMillRate Or _
          CType(e.ProposedValue, Single) > Towns.MaxAllowedMillRate Then
        e.Row.RowError = _
              "You tried to enter a value outside accepted parameters!"
        Dim s As String = "Mill Rate cannot be < " + _
                     Towns.MinAllowedMillRate.ToString() + _
                     "\n Mill Rate cannot be > " + _
                     Towns.MaxAllowedMillRate.ToString()
        e.Row.SetColumnError(e.Column, s)

        'An error object is put up next to the row and cell
        dt.RejectChanges()
        Beep()
      Else
        dt.AcceptChanges()
      End If
    End If
  End Sub

  Private Sub Grid_MouseDown(ByVal sender As Object, _
                             ByVal e As MouseEventArgs)
    ' Use the DataGrid control's HitTest method with the x and y properties.
    'I use this event to clear erros in the current row.
    Dim GridHit As DataGrid.HitTestInfo = dg1.HitTest(e.X, e.Y)

    If GridHit.Type = DataGrid.HitTestType.Cell Then
      Dim DS As DataSet = CType(dg1.DataSource, DataSet)
      If DS.HasErrors Then
        Dim DT As DataTable = DS.Tables(dg1.DataMember)
        DT.Rows(GridHit.Row).ClearErrors()
      End If
    End If
  End Sub

#End Region

#Region "internal methods"

  Private Function MakeTable() As DataTable
    ' Create a new DataTable.
    Dim dt As DataTable = New DataTable("SomeTowns")
    Dim dc As DataColumn
    Dim dr As DataRow

    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.String")
    dc.ColumnName = "Town Name"
    dc.Caption = "Town Name"
    dc.ReadOnly = True
    dc.Unique = True
    dt.Columns.Add(dc)

    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.String")
    dc.ColumnName = "State"
    dc.Caption = "State"
    dc.ReadOnly = True
    dc.Unique = False
    dt.Columns.Add(dc)

    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.String")
    dc.ColumnName = "County Name"
    dc.Caption = "County Name"
    dc.ReadOnly = True
    dc.Unique = False
    dt.Columns.Add(dc)

    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.Single")
    dc.ColumnName = "MillRate"
    dc.Caption = "MillRate"
    dc.ReadOnly = False
    dc.Unique = False
    dt.Columns.Add(dc)

    Return dt
  End Function

#End Region

End Class
