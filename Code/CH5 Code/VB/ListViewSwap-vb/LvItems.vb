Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Collections

Public Class LvItems

  Private mCol As ArrayList

  Public Sub New()
    mCol = New ArrayList()
  End Sub

  ' <summary>
  ' Add a string to an array of ListViewItems
  ' </summary>
  ' <param name="val"></param>
  Public Sub Add(ByVal val As String)
    mCol.Add(New ListViewItem(val))
  End Sub

  ' <summary>
  ' Add a ListViewItem to an array of ListViewItems
  ' </summary>
  ' <param name="val"></param>
  Public Sub Add(ByVal val As ListViewItem)
    mCol.Add(val)
  End Sub

  ' <summary>
  ' Gets a ListViewItem array
  ' </summary>
  Public ReadOnly Property Items() As ListViewItem()
    Get
      mCol.TrimToSize()
      Dim lvw(mCol.Count - 1) As ListViewItem
      mCol.CopyTo(lvw, 0)
      Return lvw
    End Get
  End Property

End Class
