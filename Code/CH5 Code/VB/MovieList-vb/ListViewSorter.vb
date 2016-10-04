Option Strict On
Imports System.Windows.Forms
Imports System.Collections

Public Class ListViewSorter
  Implements IComparer

  Dim mCol As Integer
  Dim mOrder As SortOrder

  Public Sub New(ByVal column As Integer, ByVal order As SortOrder)
    mCol = column
    mOrder = order
  End Sub

  Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
                          Implements System.Collections.IComparer.Compare
    Dim returnVal As Integer = String.Compare( _
                                (CType(x, ListViewItem)).SubItems(mCol).Text, _
                                (CType(y, ListViewItem).SubItems(mCol).Text))
    If mOrder = SortOrder.Descending Then
      returnVal *= -1
      Return returnVal
    Else
      Return returnVal
    End If
  End Function

End Class
