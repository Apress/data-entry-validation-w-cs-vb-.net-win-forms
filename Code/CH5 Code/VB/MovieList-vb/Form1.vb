Public Class Form1
    Inherits System.Windows.Forms.Form

#Region "class local variables"

  Private ActionMovies As MovieList
  Private DramaMovies As MovieList
  Private ComedyMovies As MovieList
  Private BigIcons As ImageList

#End Region

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Get the movie ListViewItems
    Try
      ActionMovies = New MovieList("ActionMovies.txt")
    Catch
      ActionMovies = Nothing
    End Try

    Try
      DramaMovies = New MovieList("DramaMovies.txt")
    Catch
      DramaMovies = Nothing
    End Try

    Try
      ComedyMovies = New MovieList("ComedyMovies.txt")
    Catch
      ComedyMovies = Nothing
    End Try


    'Set up the rental ListView
    lstRentals.View = View.Details
    lstRentals.AllowColumnReorder = True
    lstRentals.GridLines = True
    lstRentals.FullRowSelect = True
    lstRentals.AllowDrop = True
    AddHandler lstRentals.ItemDrag, New ItemDragEventHandler _
                                        (AddressOf MovieRentalStartDrag)
    AddHandler lstRentals.DragEnter, New DragEventHandler _
                                        (AddressOf MovieRentalDragAcross)

    lstRentals.Columns.Add("Title", -2, HorizontalAlignment.Center)
    lstRentals.Columns.Add("Release Date", -2, HorizontalAlignment.Center)
    lstRentals.Columns.Add("Running Time", -2, HorizontalAlignment.Center)
    lstRentals.Columns.Add("Format", -2, HorizontalAlignment.Center)
    lstRentals.Columns.Add("In Stock", -2, HorizontalAlignment.Center)

    'Make something that will hold the current sort order for the current column
    Dim order As ArrayList = New ArrayList()
    Dim k As Integer
    For k = 0 To lstRentals.Columns.Count - 1
      order.Insert(k, SortOrder.Ascending)
    Next
    order.TrimToSize()
    lstRentals.Tag = order
    AddHandler lstRentals.ColumnClick, New ColumnClickEventHandler _
                                            (AddressOf ColumnSort)

    'Now set up the For-Sale ListView
    BigIcons = New ImageList()
    BigIcons.Images.Add(Image.FromFile("movie.bmp"))
    lstSold.LargeImageList = BigIcons
    lstSold.View = View.LargeIcon
    lstSold.AllowDrop = True
    AddHandler lstSold.DragEnter, New DragEventHandler(AddressOf MovieDragInto)
    AddHandler lstSold.DragDrop, New DragEventHandler(AddressOf MovieSoldDrop)

    'Fill the rental box
    picRental.SizeMode = PictureBoxSizeMode.StretchImage
    picRental.Image = Image.FromFile("cart.bmp")
    picRental.AllowDrop = True
    AddHandler picRental.DragEnter, New DragEventHandler(AddressOf MovieDragInto)
    AddHandler picRental.DragDrop, New DragEventHandler(AddressOf RentalCartDrop)

    'Fill the ComboBox.  This MUST be done after setting up the 
    'rental listView control
    If Not ActionMovies Is Nothing Then cmbGenre.Items.Add(ActionMovies)
    If Not DramaMovies Is Nothing Then cmbGenre.Items.Add(DramaMovies)
    If Not ComedyMovies Is Nothing Then cmbGenre.Items.Add(ComedyMovies)
    AddHandler cmbGenre.SelectedIndexChanged, New EventHandler _
                                                  (AddressOf GenreClick)
    'Setting the index automatically fires the event
    cmbGenre.SelectedIndex = 0

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
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents picRental As System.Windows.Forms.PictureBox
  Friend WithEvents lstSold As System.Windows.Forms.ListView
  Friend WithEvents cmbGenre As System.Windows.Forms.ComboBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents lstRentals As System.Windows.Forms.ListView
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.label4 = New System.Windows.Forms.Label()
    Me.label3 = New System.Windows.Forms.Label()
    Me.picRental = New System.Windows.Forms.PictureBox()
    Me.lstSold = New System.Windows.Forms.ListView()
    Me.cmbGenre = New System.Windows.Forms.ComboBox()
    Me.label2 = New System.Windows.Forms.Label()
    Me.label1 = New System.Windows.Forms.Label()
    Me.lstRentals = New System.Windows.Forms.ListView()
    Me.SuspendLayout()
    '
    'label4
    '
    Me.label4.Location = New System.Drawing.Point(14, 75)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(424, 16)
    Me.label4.TabIndex = 16
    Me.label4.Text = "Rentals"
    Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'label3
    '
    Me.label3.Location = New System.Drawing.Point(334, 387)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(104, 16)
    Me.label3.TabIndex = 15
    Me.label3.Text = "Rental Check Out"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'picRental
    '
    Me.picRental.BackColor = System.Drawing.Color.Snow
    Me.picRental.Location = New System.Drawing.Point(350, 315)
    Me.picRental.Name = "picRental"
    Me.picRental.Size = New System.Drawing.Size(72, 64)
    Me.picRental.TabIndex = 14
    Me.picRental.TabStop = False
    '
    'lstSold
    '
    Me.lstSold.Location = New System.Drawing.Point(462, 91)
    Me.lstSold.Name = "lstSold"
    Me.lstSold.Size = New System.Drawing.Size(216, 208)
    Me.lstSold.TabIndex = 13
    '
    'cmbGenre
    '
    Me.cmbGenre.Location = New System.Drawing.Point(14, 35)
    Me.cmbGenre.Name = "cmbGenre"
    Me.cmbGenre.Size = New System.Drawing.Size(168, 21)
    Me.cmbGenre.TabIndex = 12
    '
    'label2
    '
    Me.label2.Location = New System.Drawing.Point(462, 75)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(216, 16)
    Me.label2.TabIndex = 11
    Me.label2.Text = "For Sale"
    Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'label1
    '
    Me.label1.Location = New System.Drawing.Point(14, 19)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(160, 16)
    Me.label1.TabIndex = 10
    Me.label1.Text = "Movie genre"
    '
    'lstRentals
    '
    Me.lstRentals.Location = New System.Drawing.Point(14, 91)
    Me.lstRentals.Name = "lstRentals"
    Me.lstRentals.Size = New System.Drawing.Size(424, 208)
    Me.lstRentals.TabIndex = 9
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(692, 423)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label4, Me.label3, Me.picRental, Me.lstSold, Me.cmbGenre, Me.label2, Me.label1, Me.lstRentals})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  End Sub

  Private Sub GetList(ByVal list As MovieList)
    lstRentals.BeginUpdate()
    lstRentals.Items.Clear()
    lstRentals.Items.AddRange(list.Items)
    lstRentals.EndUpdate()
  End Sub

#Region "Delegates"

  Private Sub GenreClick(ByVal sender As Object, ByVal e As EventArgs)
    Dim cmb As ComboBox = CType(sender, ComboBox)
    GetList(CType(cmb.SelectedItem, MovieList))
  End Sub

  Private Sub ColumnSort(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
    Dim lvw As ListView = CType(sender, ListView)
    Dim SortList As ArrayList = CType(lvw.Tag, ArrayList)
    SortList(e.Column) = IIf(DirectCast(SortList(e.Column), SortOrder) = _
                                                     SortOrder.Ascending, _
                                                     SortOrder.Descending, _
                                                     SortOrder.Ascending)
    lvw.Sorting = DirectCast(SortList(e.Column), SortOrder)

    lvw.BeginUpdate()
    lvw.ListViewItemSorter = New ListViewSorter(e.Column, lvw.Sorting)
    lvw.Sort()
    lvw.EndUpdate()
  End Sub

  Private Sub MovieRentalStartDrag(ByVal sender As Object, _
                                   ByVal e As ItemDragEventArgs)
    lstRentals.DoDragDrop(e.Item, DragDropEffects.Move)
  End Sub

  Private Sub MovieRentalDragAcross(ByVal sender As Object, _
                                    ByVal e As DragEventArgs)
    e.Effect = DragDropEffects.Move
  End Sub

  Private Sub MovieDragInto(ByVal sender As Object, ByVal e As DragEventArgs)
    'The data must come from the lstRentals ListView
    Dim o As Object = e.Data.GetData(DataFormats.Serializable)
    If o.GetType() Is GetType(ListViewItem) Then
      Dim l As ListViewItem = DirectCast(o, ListViewItem)
      If (l.ListView Is lstRentals) Then
        e.Effect = DragDropEffects.All
      Else
        e.Effect = DragDropEffects.None
      End If
    End If
  End Sub

  Private Sub RentalCartDrop(ByVal sender As Object, ByVal e As DragEventArgs)
    Dim o As Object = e.Data.GetData(DataFormats.Serializable)
    Dim l As ListViewItem = DirectCast(o, ListViewItem)

    Dim dr As DialogResult = MessageBox.Show("Confirm Rental of " + l.Text, _
                                      "Rent Video", _
                                      MessageBoxButtons.YesNo)
    If dr = DialogResult.No Then
      Return
    End If


    'Look at the genre combo box to see which movie list to delete this 
    'ListViewItem from.
    Dim m As MovieList = CType(cmbGenre.SelectedItem, MovieList)
    If Not m.CheckOut(l) Then
      MessageBox.Show("This Movie is already out.")
    End If

  End Sub

  Private Sub MovieSoldDrop(ByVal sender As Object, ByVal e As DragEventArgs)
    Dim o As Object = e.Data.GetData(DataFormats.Serializable)
    Dim l As ListViewItem = DirectCast(o, ListViewItem)

    Dim dr As DialogResult = MessageBox.Show("Are you sure you want to sell " + _
                                      l.Text + "?", _
                                      "Sell This Video", _
                                      MessageBoxButtons.YesNo)
    If dr = DialogResult.No Then
      Return
    End If

    'Very important!!  If I did not remove this ListViewItem from the source 
    'list I would need to clone this ListViewItem before I add it to the 
    'lstSold control.
    lstRentals.Items.Remove(l)
    lstSold.Items.Add(DirectCast(l, ListViewItem))
    lstSold.Items(lstSold.Items.Count - 1).ImageIndex = 0

    'Look at the genre combo box to see which movie list to delete this 
    'ListViewItem from.
    Dim m As MovieList = CType(cmbGenre.SelectedItem, MovieList)
    m.Remove(l)

  End Sub

#End Region




End Class
