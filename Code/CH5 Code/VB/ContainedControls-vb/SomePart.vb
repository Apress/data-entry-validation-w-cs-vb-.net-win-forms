Option Strict On

Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections
Imports System.Windows.Forms

Public Class SomePart

  Private mnu As ContextMenu = New ContextMenu()
  Private mPrice As Decimal
  Private mIdentifier As String
  Private mToolsNeeded As String
  Private mAr As ArrayList
  Private mImg As Image
  Shared mPartsCount As Int32 = 0

  Private Structure menu_item
    Public m As MenuItem
    Public s As String
    Public Sub DoSomething(ByVal Title As String)
      If Not s Is Nothing Then
        MessageBox.Show(s, Title)
      Else
        MessageBox.Show("No Action", Title)
      End If
    End Sub
  End Structure

  Public Sub New()
    mPartsCount += 1
    GetData()
    InitMenu()
  End Sub

  ' This private function is supposed to get the record for 
  ' this part from the database and set up whatever fields are necessary
  Private Sub GetData()
    'Fake getting this from the database
    mPrice = CType(54.952, Decimal) + mPartsCount
    mToolsNeeded = "Linemans pliers\n Phillips screwdriver\n Half a brain"
    mIdentifier = "Some Part #" + mPartsCount.ToString()

    mImg = Image.FromFile(mPartsCount.ToString() + ".ico")

  End Sub

  Private Sub InitMenu()
    mAr = New ArrayList()
    Dim m As menu_item
    Dim k As Int32

    m = New menu_item()
    m.m = New MenuItem("Customer Price", New EventHandler(AddressOf MenuHandler))
    m.s = "Customer Price = " + mPrice.ToString("C")
    mAr.Add(m)

    m = New menu_item()
    m.m = New MenuItem("Tools Needed", New EventHandler(AddressOf MenuHandler))
    m.s = "Suggested Tools = " + mToolsNeeded
    mAr.Add(m)

    For k = 0 To mPartsCount - 1
      m = New menu_item()
      m.m = New MenuItem("Item #" + k.ToString(), New EventHandler(AddressOf MenuHandler))
      mAr.Add(m)
    Next

    mAr.TrimToSize()

  End Sub

  Private Sub MenuHandler(ByVal sender As Object, ByVal e As EventArgs)
    Dim m As MenuItem = DirectCast(sender, MenuItem)
    Dim menu As menu_item

    For Each menu In mAr
      If Object.Equals(menu.m, m) Then
        menu.DoSomething(mIdentifier)
      End If
    Next
  End Sub

  Public Sub ShowMenu(ByVal c As Control, ByVal p As Point)
    Dim m As menu_item

    For Each m In mAr
      mnu.MenuItems.Add(m.m)
    Next

    mnu.Show(c, p)
    mnu.MenuItems.Clear()
  End Sub

  Public ReadOnly Property Price() As Decimal
    Get
      Return mPrice
    End Get
  End Property

  Public ReadOnly Property ID() As String
    Get
      Return mIdentifier
    End Get
  End Property

  Public ReadOnly Property img() As Image
    Get
      Return mImg
    End Get
  End Property

End Class
