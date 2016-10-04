Option Strict On

Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms

Public Class PhotoList

  Dim mPics As ArrayList

  Public Sub New()
    mPics = New ArrayList()

    'Normally you would detect these pictures and load them.
    mPics.Add(New Photo("desert1.jpg"))
    mPics.Add(New Photo("desert2.jpg"))
    mPics.Add(New Photo("desert3.jpg"))
    mPics.Add(New Photo("fields1.jpg"))
    mPics.Add(New Photo("fields2.jpg"))
    mPics.Add(New Photo("flowers1.jpg"))
    mPics.Add(New Photo("flowers2.jpg"))
    mPics.Add(New Photo("flowers3.jpg"))
    mPics.Add(New Photo("flowers4.jpg"))
    mPics.Add(New Photo("sea1.jpg"))
    mPics.Add(New Photo("sea2.jpg"))
    mPics.Add(New Photo("sea3.jpg"))
    mPics.Add(New Photo("sea4.jpg"))
    mPics.Add(New Photo("spring1.jpg"))
    mPics.Add(New Photo("spring2.jpg"))
    mPics.Add(New Photo("spring3.jpg"))
    mPics.TrimToSize()
  End Sub

  '/// <summary>
  '/// Gets an Image array
  '/// </summary>
  Public ReadOnly Property Items() As ListViewItem()
    Get
      mPics.TrimToSize()
      Dim lst(mPics.Count - 1) As ListViewItem
      Dim aList As ArrayList = New ArrayList()
      Dim p As Photo
      For Each p In mPics
        Dim l As ListViewItem = New ListViewItem(p.Name)
        l.Tag = p
        l.SubItems.Add(p.DateShot)
        l.SubItems.Add(p.Location)
        l.SubItems.Add("JPG")

        aList.Add(l)
      Next
      aList.TrimToSize()
      aList.CopyTo(lst, 0)
      Return lst
    End Get
  End Property

End Class
