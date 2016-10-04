Option Strict On

Public Class Towns

  ' static class that get information about towns in a state from 
  ' an Access Database.
  ' 
  ' This is an abstraction of the data from main program.  I can change the
  ' way data is obtained and its source at any time without having to chnage the
  ' interface to the data from the outside.  This is a good thing!
  Private Shared DS As DataSet

  Shared Sub New()
    DS = New DataSet()
    DS.Tables.Add(GetData())
  End Sub


  Public Function Update(ByVal t As Town) As Boolean
    'Code in here updates the database and
    'merges the new and old dataset
    Return True
  End Function

#Region "public static properties"


  Public Shared ReadOnly Property MinAllowedMillRate() As Single
    Get
      Return 12.0F
    End Get
  End Property

  Public Shared ReadOnly Property MaxAllowedMillRate() As Single
    Get
      Return 99.0F
    End Get
  End Property

  Public Shared ReadOnly Property Hartford() As Town
    Get
      Dim t As Town = Nothing
      Dim dt As DataTable = DS.Tables("TownInfo")
      Dim r As DataRow
      For Each r In dt.Rows
        If r("Name").ToString() = "Hartford" Then
          t = FillFromRow(r)
          Exit For
        End If
      Next
      Return t
    End Get
  End Property

  Public Shared ReadOnly Property LosAngeles() As Town
    Get
      Dim t As Town = Nothing
      Dim dt As DataTable = DS.Tables("TownInfo")
      Dim r As DataRow
      For Each r In dt.Rows
        If r("Name").ToString() = "Los Angleles" Then
          t = FillFromRow(r)
          Exit For
        End If
      Next
      Return t
    End Get
  End Property

  Public Shared ReadOnly Property Orlando() As Town
    Get
      Dim t As Town = Nothing
      Dim dt As DataTable = DS.Tables("TownInfo")
      Dim r As DataRow
      For Each r In dt.Rows
        If r("Name").ToString() = "Orlando" Then
          t = FillFromRow(r)
          Exit For
        End If
      Next
      Return t
    End Get
  End Property

#End Region

#Region "local methods"

  Private Shared Function FillFromRow(ByVal r As DataRow) As Town
    Dim t As Town = New Town()
    t.Name = CType(r("Name"), String)
    t.State = CType(r("State"), String)
    t.County = CType(r("County"), String)
    t.Mayor = CType(r("Mayor"), String)
    t.Zip = CType(r("Zip"), String)
    t.MillRate = CType(r("MillRate"), Single)
    Return t
  End Function

  Private Shared Function GetData() As DataTable
    'Lets pretend that we are getting this data from a database table.
    'For now this shows that you can make the table by hand if you want to.
    'You can also get the data from an INI file, CFG file, or XML WEB service.
    'Any way you get the data it can be arranged in a table that has specific
    'demands.


    ' Create a new DataTable.
    Dim dt As DataTable = New DataTable("TownInfo")
    Dim dc As DataColumn
    Dim dr As DataRow

    ' Create town name
    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.String")
    dc.ColumnName = "Name"
    dc.ReadOnly = True
    dc.Unique = True
    dt.Columns.Add(dc)

    ' Create state town is in
    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.String")
    dc.ColumnName = "State"
    dc.ReadOnly = False
    dc.Unique = False
    dt.Columns.Add(dc)

    ' Create county town is in
    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.String")
    dc.ColumnName = "County"
    dc.ReadOnly = False
    dc.Unique = False
    dt.Columns.Add(dc)

    ' Create mayor of town
    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.String")
    dc.ColumnName = "Mayor"
    dc.ReadOnly = False
    dc.Unique = False
    dt.Columns.Add(dc)

    ' Create town zip code
    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.String")
    dc.ColumnName = "Zip"
    dc.ReadOnly = False
    dc.Unique = True
    dt.Columns.Add(dc)

    ' Create town mill rate
    dc = New DataColumn()
    dc.DataType = System.Type.GetType("System.Single")
    dc.ColumnName = "MillRate"
    dc.ReadOnly = False
    dc.Unique = False
    dt.Columns.Add(dc)

    ' Create 4 DataRow objects that represent towns.  Add them to the table
    dt.Rows.Add(New Object() {"Hartford", "CT", "Hartford", _
                              "Mike", "06011", 45.23F})
    dt.Rows.Add(New Object() {"Los Angleles", "CA", "LA", _
                              "Fred", "23456", 64.85F})
    dt.Rows.Add(New Object() {"Orlando", "FL", "Kissime", _
                              "Mikey", "45376", 25.0F})

    Return dt
  End Function

#End Region

End Class
