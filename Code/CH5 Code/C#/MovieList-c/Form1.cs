using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MovieList_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

    #region class local variables

    MovieList ActionMovies;
    MovieList DramaMovies;
    MovieList ComedyMovies;
    ImageList BigIcons;

    #endregion

    private System.Windows.Forms.ListView lstRentals;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cmbGenre;
    private System.Windows.Forms.ListView lstSold;
    private System.Windows.Forms.PictureBox picRental;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      //Get the movie ListViewItems
      try   { ActionMovies = new MovieList("ActionMovies.txt"); }
      catch { ActionMovies = null; }

      try   { DramaMovies = new MovieList("DramaMovies.txt"); }
      catch { DramaMovies = null; }

      try   { ComedyMovies = new MovieList("ComedyMovies.txt"); }
      catch { ComedyMovies = null; }

      //Set up the rental ListView
      lstRentals.View = View.Details;
      lstRentals.AllowColumnReorder = true;
      lstRentals.GridLines = true;
      lstRentals.FullRowSelect = true;
      lstRentals.AllowDrop = true;
      lstRentals.ItemDrag    += new ItemDragEventHandler(this.MovieRentalStartDrag);
      lstRentals.DragEnter   += new DragEventHandler(this.MovieRentalDragAcross);
      lstRentals.Columns.Add("Title",        -2, HorizontalAlignment.Center);
      lstRentals.Columns.Add("Release Date", -2, HorizontalAlignment.Center);
      lstRentals.Columns.Add("Running Time", -2, HorizontalAlignment.Center);
      lstRentals.Columns.Add("Format",       -2, HorizontalAlignment.Center);
      lstRentals.Columns.Add("In Stock",     -2, HorizontalAlignment.Center);

      //Make something that will hold the current sort order for the current column
      ArrayList order = new ArrayList();
      for(int k=0; k<lstRentals.Columns.Count; k++)
        order.Insert(k, SortOrder.Ascending);
      order.TrimToSize();
      lstRentals.Tag = order;
      lstRentals.ColumnClick += new ColumnClickEventHandler(ColumnSort);

      //Now set up the For-Sale ListView
      BigIcons = new ImageList();
      BigIcons.Images.Add(Image.FromFile("movie.bmp"));
      lstSold.LargeImageList = BigIcons;
      lstSold.View = View.LargeIcon;
      lstSold.AllowDrop = true;
      lstSold.DragEnter += new DragEventHandler(MovieDragInto);
      lstSold.DragDrop  += new DragEventHandler(MovieSoldDrop);

      //Fill the rental box
      picRental.SizeMode = PictureBoxSizeMode.StretchImage;
      picRental.Image = Image.FromFile("cart.bmp");
      picRental.AllowDrop = true;
      picRental.DragEnter += new DragEventHandler(MovieDragInto);
      picRental.DragDrop  += new DragEventHandler(this.RentalCartDrop);

      //Fill the ComboBox.  This MUST be done after setting up the 
      //rental listView control
      if(ActionMovies != null) cmbGenre.Items.Add(ActionMovies);
      if(DramaMovies != null) cmbGenre.Items.Add(DramaMovies);
      if(ComedyMovies != null) cmbGenre.Items.Add(ComedyMovies);
      cmbGenre.SelectedIndexChanged += new EventHandler(this.GenreClick);
      //Setting the index automatically fires the event
      cmbGenre.SelectedIndex = 0;

    }

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.lstRentals = new System.Windows.Forms.ListView();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cmbGenre = new System.Windows.Forms.ComboBox();
      this.lstSold = new System.Windows.Forms.ListView();
      this.picRental = new System.Windows.Forms.PictureBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lstRentals
      // 
      this.lstRentals.Location = new System.Drawing.Point(16, 96);
      this.lstRentals.Name = "lstRentals";
      this.lstRentals.Size = new System.Drawing.Size(424, 208);
      this.lstRentals.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(160, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Movie genre";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(464, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(216, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "For Sale";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // cmbGenre
      // 
      this.cmbGenre.Location = new System.Drawing.Point(16, 40);
      this.cmbGenre.Name = "cmbGenre";
      this.cmbGenre.Size = new System.Drawing.Size(168, 21);
      this.cmbGenre.TabIndex = 4;
      // 
      // lstSold
      // 
      this.lstSold.Location = new System.Drawing.Point(464, 96);
      this.lstSold.Name = "lstSold";
      this.lstSold.Size = new System.Drawing.Size(216, 208);
      this.lstSold.TabIndex = 5;
      // 
      // picRental
      // 
      this.picRental.BackColor = System.Drawing.Color.Snow;
      this.picRental.Location = new System.Drawing.Point(352, 320);
      this.picRental.Name = "picRental";
      this.picRental.Size = new System.Drawing.Size(72, 64);
      this.picRental.TabIndex = 6;
      this.picRental.TabStop = false;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(336, 392);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(104, 16);
      this.label3.TabIndex = 7;
      this.label3.Text = "Rental Check Out";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(16, 80);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(424, 16);
      this.label4.TabIndex = 8;
      this.label4.Text = "Rentals";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(692, 423);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.label4,
                                                                  this.label3,
                                                                  this.picRental,
                                                                  this.lstSold,
                                                                  this.cmbGenre,
                                                                  this.label2,
                                                                  this.label1,
                                                                  this.lstRentals});
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Movie Rental Program";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

    }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

    private void Form1_Load(object sender, System.EventArgs e)
    {
    }

    private void GetList(MovieList list)
    {
      lstRentals.BeginUpdate();
      lstRentals.Items.Clear();
      lstRentals.Items.AddRange(list.Items);
      lstRentals.EndUpdate();
    }

    #region Delegates

    private void GenreClick(object sender, EventArgs e)
    {
      ComboBox cmb = (ComboBox)sender;
      GetList((MovieList)cmb.SelectedItem);
    }

    private void ColumnSort(object sender, ColumnClickEventArgs e)
    {
      ListView lvw = (ListView)sender;
      ArrayList SortList = (ArrayList)lvw.Tag;
      SortList[e.Column] = (SortOrder)SortList[e.Column] == 
                           SortOrder.Ascending ? 
                           SortOrder.Descending : 
                           SortOrder.Ascending;
      lvw.Sorting = (SortOrder)SortList[e.Column];

      lvw.BeginUpdate();
      lvw.ListViewItemSorter = new ListViewSorter(e.Column, lvw.Sorting);
      lvw.Sort();
      lvw.EndUpdate();
    }

    private void MovieRentalStartDrag(object sender, ItemDragEventArgs e)
    {
      lstRentals.DoDragDrop(e.Item, DragDropEffects.Move);
    }

    private void MovieRentalDragAcross(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.Move;
    }

    private void MovieDragInto(object sender, DragEventArgs e)
    {
      //The data must come from the lstRentals ListView
      object o = e.Data.GetData(DataFormats.Serializable);
      if(o is ListViewItem)
      {
        ListViewItem l = (ListViewItem)o;
        if (l.ListView == lstRentals)
          e.Effect = DragDropEffects.All;
        else
          e.Effect = DragDropEffects.None;
      }
    }

    private void RentalCartDrop(object sender, DragEventArgs e)
    {
      object o = e.Data.GetData(DataFormats.Serializable);
      ListViewItem l = (ListViewItem)o;

      DialogResult dr = MessageBox.Show("Confirm Rental of " + l.Text,
                                        "Rent Video",
                                        MessageBoxButtons.YesNo);
      if(dr == DialogResult.No)
        return;

      //Look at the genre combo box to see which movie list to delete this 
      //ListViewItem from.
      MovieList m = (MovieList)cmbGenre.SelectedItem;
      if(!m.CheckOut(l))
        MessageBox.Show("This Movie is already out.");

    }

    private void MovieSoldDrop(object sender, DragEventArgs e)
    {
      object o = e.Data.GetData(DataFormats.Serializable);
      ListViewItem l = (ListViewItem)o;

      DialogResult dr = MessageBox.Show("Are you sure you want to sell " + 
                                        l.Text + "?" ,
                                        "Sell This Video",
                                        MessageBoxButtons.YesNo);
      if(dr == DialogResult.No)
        return;

      //Very important!!  If I did not remove this ListViewItem from the source 
      //list I would need to clone this ListViewItem before I add it to the 
      //lstSold control.
      lstRentals.Items.Remove(l);
      lstSold.Items.Add((ListViewItem)l);
      lstSold.Items[lstSold.Items.Count-1].ImageIndex = 0;

      //Look at the genre combo box to see which movie list to delete this 
      //ListViewItem from.
      MovieList m = (MovieList)cmbGenre.SelectedItem;
      m.Remove(l);

    }

    #endregion

	}
}
