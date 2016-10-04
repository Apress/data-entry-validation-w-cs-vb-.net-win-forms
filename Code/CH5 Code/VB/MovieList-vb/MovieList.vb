Option Strict On

Imports System
Imports System.IO
Imports System.Collections
Imports System.Windows.Forms

Public Class MovieList

  Private Const OUT As String = "Out"
  Private Const INHOUSE As String = "In"

  Private mCol As ArrayList
  Private mDelimiter As Char = "^"c
  Private mGenre As String

  Public Sub New()
    mCol = New ArrayList()
  End Sub

  Public Sub New(ByVal fname As String)
    Dim buffer As String

    mCol = New ArrayList()
    Dim fIn As FileInfo = New FileInfo(fname)
    Try
      Dim sr As StreamReader = New StreamReader(fIn.OpenRead())
      While (sr.Peek() <> -1)
        buffer = sr.ReadLine()
        Dim List() As String = buffer.Split(mDelimiter)
        If List.GetLength(0) = 1 Then
          If (buffer <> String.Empty) Then
            mGenre = buffer
          End If
        ElseIf List.GetLength(0) > 1 Then
          Dim l As ListViewItem = New ListViewItem(List)
          l.Tag = New Movie(l.Text)
          mCol.Add(l)
        End If
      End While
      sr.Close()
    Catch e As Exception
      MessageBox.Show("Unable to read file " + fname)
      Throw e
    End Try

  End Sub

  Public Overrides Function ToString() As String
    Return mGenre
  End Function

  Public ReadOnly Property Genre() As String
    Get
      Return mGenre
    End Get
  End Property

  Public Sub Add(ByVal val As String)
    mCol.Add(New ListViewItem(val))
  End Sub

  Public Sub Add(ByVal val As ListViewItem)
    mCol.Add(val)
  End Sub

  Public Sub Remove(ByVal val As ListViewItem)
    mCol.Remove(val)
  End Sub

  Public Function CheckOut(ByVal val As ListViewItem) As Boolean
    Dim stock As String = val.SubItems(val.SubItems.Count - 1).Text

    If stock = OUT Then
      Return False
    End If

    mCol.Remove(val)
    val.SubItems(val.SubItems.Count - 1).Text = OUT
    mCol.Add(val)
    Return True
  End Function

  Public ReadOnly Property Items() As ListViewItem()
    Get
      mCol.TrimToSize()
      Dim lvw(mCol.Count - 1) As ListViewItem
      mCol.CopyTo(lvw, 0)
      Return lvw
    End Get
  End Property

End Class
