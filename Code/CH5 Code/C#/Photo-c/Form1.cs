using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace Photo_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

    #region class local variables

    PhotoList Piclist;

    #endregion



    private System.Windows.Forms.TreeView tvPics;
    private System.Windows.Forms.ListView lvPics;
    private System.Windows.Forms.PictureBox pic;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      Piclist = new PhotoList();

      pic.SizeMode = PictureBoxSizeMode.StretchImage;
      SetupListView();
      SetupTree();
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
      this.tvPics = new System.Windows.Forms.TreeView();
      this.lvPics = new System.Windows.Forms.ListView();
      this.pic = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // tvPics
      // 
      this.tvPics.ImageIndex = -1;
      this.tvPics.Location = new System.Drawing.Point(48, 40);
      this.tvPics.Name = "tvPics";
      this.tvPics.SelectedImageIndex = -1;
      this.tvPics.Size = new System.Drawing.Size(248, 392);
      this.tvPics.TabIndex = 0;
      // 
      // lvPics
      // 
      this.lvPics.Location = new System.Drawing.Point(336, 40);
      this.lvPics.Name = "lvPics";
      this.lvPics.Size = new System.Drawing.Size(328, 232);
      this.lvPics.TabIndex = 1;
      // 
      // pic
      // 
      this.pic.BackColor = System.Drawing.Color.Linen;
      this.pic.Location = new System.Drawing.Point(416, 296);
      this.pic.Name = "pic";
      this.pic.Size = new System.Drawing.Size(160, 136);
      this.pic.TabIndex = 2;
      this.pic.TabStop = false;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(336, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(328, 16);
      this.label1.TabIndex = 3;
      this.label1.Text = "All photos";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(48, 24);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(248, 16);
      this.label2.TabIndex = 4;
      this.label2.Text = "Photo Classifications";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(694, 475);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.label2,
                                                                  this.label1,
                                                                  this.pic,
                                                                  this.lvPics,
                                                                  this.tvPics});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
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

    #region Setup routines

    private void SetupListView()
    {
      //Set up the photo ListView
      lvPics.View = View.Details;
      lvPics.AllowColumnReorder = true;
      lvPics.GridLines = true;
      lvPics.FullRowSelect = true;
      lvPics.AllowDrop = true;
      lvPics.MultiSelect = false;
      lvPics.SelectedIndexChanged += new EventHandler(this.RowSelect);
      lvPics.ItemDrag     += new ItemDragEventHandler(this.PhotoStartDrag);
      lvPics.DragEnter    += new DragEventHandler(this.PhotoDragAcross);
      lvPics.Columns.Add("Name",      -2, HorizontalAlignment.Center);
      lvPics.Columns.Add("Date",      -2, HorizontalAlignment.Center);
      lvPics.Columns.Add("Location",  -2, HorizontalAlignment.Center);
      lvPics.Columns.Add("Format",    -2, HorizontalAlignment.Center);
      foreach(ColumnHeader c in lvPics.Columns)
        c.Width = lvPics.Width/lvPics.Columns.Count;

      //Make something that will hold the current sort order for the current column
      ArrayList order = new ArrayList();
      for(int k=0; k<lvPics.Columns.Count; k++)
        order.Insert(k, SortOrder.Ascending);
      order.TrimToSize();
      lvPics.Tag = order;
      lvPics.ColumnClick += new ColumnClickEventHandler(ColumnSort);

      //Fill the ListView
      lvPics.BeginUpdate();
      lvPics.Items.Clear();
      lvPics.Items.AddRange(Piclist.Items);
      lvPics.EndUpdate();

    }

    private void SetupTree()
    {
      ImageList iList = new ImageList();
      iList.Images.Add(Image.FromFile("closed.ico"));
      iList.Images.Add(Image.FromFile("open.ico"));
      iList.Images.Add(Image.FromFile("camera.ico"));

      tvPics.AllowDrop = true;
      tvPics.ImageList = iList;
      tvPics.HideSelection = false;
      tvPics.HotTracking = true;  //This is limiting
      tvPics.AfterSelect   += new TreeViewEventHandler(NodeSelect);
      tvPics.AfterExpand   += new TreeViewEventHandler(TreeExpandCollapse);
      tvPics.AfterCollapse += new TreeViewEventHandler(TreeExpandCollapse);
      tvPics.DragEnter     += new DragEventHandler(TreeDragInto);
      tvPics.DragOver      += new DragEventHandler(TreeDragOver);
      tvPics.DragDrop      += new DragEventHandler(TreeDragDrop);


      //Add some root nodes
      TreeNode root = new TreeNode("All Photos");
      root.Nodes.Add("Seascapes");
      root.Nodes.Add("Desert Scenes");
      root.Nodes.Add("Flowers");
      root.Nodes.Add("Spring");
      root.Tag = "Root Node";
      root.Expand();
      tvPics.Nodes.Add(root);

    }

    #endregion

    #region TreeView Delegates

    private void NodeSelect(object sender, TreeViewEventArgs e)
    {
      Debug.Assert(sender == tvPics, 
                 "Only the tvPics TreeView control can activate this delegate");

      if(e.Node.Tag != null && e.Node.Tag.ToString() == "Photo")
      {
        Photo p = (Photo)e.Node.Tag;
        pic.Image = p.Picture;
      }
      else 
        pic.Image = null;
    }

    private void TreeDragInto(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.All;

    }

    // Second pass     
    private void TreeDragOver(object sender, DragEventArgs e)
    {
      //Stop this from happening when over a node that 
      //is not allowed to be dropped on
      TreeNode node = tvPics.GetNodeAt(tvPics.PointToClient
                                       (new Point(e.X, e.Y)));
      if(node.Tag == null)
      {
        tvPics.Focus();  //Probelem with this is that it fires an event
        tvPics.SelectedNode = node;
        e.Effect = DragDropEffects.All;
      }
      else e.Effect = DragDropEffects.None;
    }

    private void TreeDragDrop(object sender, DragEventArgs e)
    {
      //The x and y values are in form coordinates
      tvPics.SelectedNode = tvPics.GetNodeAt(tvPics.PointToClient
                                             (new Point(e.X, e.Y)));
      if(tvPics.SelectedNode == null)
      {
        MessageBox.Show("You need to drop this item on a node.");
        return;
      }

      //Normally you would detect the source data against the drop node
      //If the source data did not belong there then flag an error
      if(tvPics.SelectedNode.Parent == null)
      {
        MessageBox.Show("You cannot drop this item on the root node.");
        return;
      }

      if(tvPics.SelectedNode.Tag != null)
      {
        MessageBox.Show("You cannot drop a photo on a photo.");
        return;
      }

      //Get the object being passed.
      //I use a ListView object as the carrier since Photo is not serializable
      //A serializable object must be able to serialize all data within
      object o = e.Data.GetData(DataFormats.Serializable);
      ListViewItem l = (ListViewItem)o;
      Photo snap = (Photo)l.Tag;

      tvPics.BeginUpdate();
      TreeNode n = new TreeNode(snap.Name);
      n.Tag = snap;
      n.SelectedImageIndex = 2;
      n.ImageIndex = 2;
      tvPics.SelectedNode.Nodes.Add(n);
      tvPics.SelectedNode.Expand();
      tvPics.EndUpdate();

    }

    private void TreeExpandCollapse(object sender, TreeViewEventArgs e)
    {
      if(e.Action == TreeViewAction.Expand)
        e.Node.SelectedImageIndex = 1;

      if(e.Action == TreeViewAction.Collapse)
        e.Node.SelectedImageIndex = 0;

    }

    #endregion

    #region ListView Delegates

    private void RowSelect(object sender, EventArgs e)
    {
      Debug.Assert(sender == lvPics, 
                 "Only the lvPics ListView control can activate this delegate");
      Debug.Assert(lvPics.SelectedIndices.Count <= 1, 
                 "only one item can be selected");

      if(lvPics.SelectedIndices.Count == 1)
      {
        Photo p = (Photo)lvPics.SelectedItems[0].Tag;
        pic.Image = p.Picture;
      }
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

    private void PhotoStartDrag(object sender, ItemDragEventArgs e)
    {
      if(sender == lvPics)
        lvPics.DoDragDrop(e.Item, DragDropEffects.Move );

    }

    private void PhotoDragAcross(object sender, DragEventArgs e)
    {
      if(sender == lvPics)
        e.Effect = DragDropEffects.Move;
    }

    #endregion
	}
}
