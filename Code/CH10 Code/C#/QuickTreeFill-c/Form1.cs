using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace QuickTreeFill_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.TreeView Tree;
    private System.Windows.Forms.Button cmdFill;
    private System.ComponentModel.Container components = null;
    private System.Windows.Forms.Button cmdFillFast;
    private System.Windows.Forms.Button cmdClear;

    #region class local variables

    private Toys toys;
    private Clothing Clothes;
    private enum NodeLevel
    {
      AllToys,
      AllClothes,
      ToyBrand,
      ClothingBrand,
      BatteryToys,
      ElectronicToys,
      BoardGameToys,
      VideoToys,
      PlushToys,
      ModelToys,
      FigureToys,
      ClothingFootware,
      ClothingTops,
      ClothingJackets,
      ClothingSweaters,
      ClothingPants,
      ClothingGloves
    }

    #endregion

    public Form1()
    {
      InitializeComponent();

      toys              = new Toys();
      Clothes           = new Clothing();
      cmdClear.Click    += new EventHandler(ClearTree);
      cmdFill.Click     += new EventHandler(FillWholeTree);
      cmdFillFast.Click += new EventHandler(FillTreeFast);
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
      this.Tree = new System.Windows.Forms.TreeView();
      this.cmdFill = new System.Windows.Forms.Button();
      this.cmdFillFast = new System.Windows.Forms.Button();
      this.cmdClear = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // Tree
      // 
      this.Tree.ImageIndex = -1;
      this.Tree.Location = new System.Drawing.Point(24, 24);
      this.Tree.Name = "Tree";
      this.Tree.SelectedImageIndex = -1;
      this.Tree.Size = new System.Drawing.Size(296, 408);
      this.Tree.TabIndex = 0;
      // 
      // cmdFill
      // 
      this.cmdFill.Location = new System.Drawing.Point(344, 360);
      this.cmdFill.Name = "cmdFill";
      this.cmdFill.Size = new System.Drawing.Size(88, 24);
      this.cmdFill.TabIndex = 1;
      this.cmdFill.Text = "Fill Normal";
      // 
      // cmdFillFast
      // 
      this.cmdFillFast.Location = new System.Drawing.Point(344, 400);
      this.cmdFillFast.Name = "cmdFillFast";
      this.cmdFillFast.Size = new System.Drawing.Size(88, 24);
      this.cmdFillFast.TabIndex = 2;
      this.cmdFillFast.Text = "Fill Fast";
      // 
      // cmdClear
      // 
      this.cmdClear.Location = new System.Drawing.Point(344, 320);
      this.cmdClear.Name = "cmdClear";
      this.cmdClear.Size = new System.Drawing.Size(88, 24);
      this.cmdClear.TabIndex = 3;
      this.cmdClear.Text = "Clear";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(464, 461);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdClear,
                                                                  this.cmdFillFast,
                                                                  this.cmdFill,
                                                                  this.Tree});
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


    #region fill the tree slow

    private void FillWholeTree(object sender, EventArgs e)
    {
      Tree.BeforeExpand   -= new TreeViewCancelEventHandler(FillSubNodes);

      cmdFill.Enabled = false;
      cmdFillFast.Enabled = false;
      this.Cursor = Cursors.WaitCursor;
      Tree.Nodes.Clear();
      Tree.BeginUpdate();

      //------ Do Toys -------
      TreeNode ThisNode;
      TreeNode AllToys = Tree.Nodes.Add("All Toys");
      AllToys.Tag = NodeLevel.AllToys;
      TreeNode node = AllToys.Nodes.Add("Action Figures");
      node.Tag = NodeLevel.FigureToys;
      foreach(Brand x in toys.ActionFigures.Brands)
        ThisNode = node.Nodes.Add(x.BrandName);

      node = AllToys.Nodes.Add("Battery Powered Toys");
      foreach(Brand x in toys.BatteryPowered.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllToys.Nodes.Add("Board Games");
      foreach(Brand x in toys.BoardGames.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllToys.Nodes.Add("Electronic Games");
      foreach(Brand x in toys.Electronic.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllToys.Nodes.Add("Models");
      foreach(Brand x in toys.Models.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllToys.Nodes.Add("Plush Toys");
      foreach(Brand x in toys.Plush.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllToys.Nodes.Add("Video Games");
      foreach(Brand x in toys.Video.Brands)
        node.Nodes.Add(x.BrandName);

      // --------- Do Clothing ---------
      TreeNode AllClothes = Tree.Nodes.Add("All Clothes");
      node = AllClothes.Nodes.Add("Footware");
      foreach(Brand x in Clothes.Footware.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllClothes.Nodes.Add("Gloves and Hats");
      foreach(Brand x in Clothes.GlovesHats.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllClothes.Nodes.Add("Jackets");
      foreach(Brand x in Clothes.Jackets.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllClothes.Nodes.Add("Pants");
      foreach(Brand x in Clothes.Pants.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllClothes.Nodes.Add("Sweaters");
      foreach(Brand x in Clothes.Sweaters.Brands)
        node.Nodes.Add(x.BrandName);

      node = AllClothes.Nodes.Add("Tops");
      foreach(Brand x in Clothes.Tops.Brands)
        node.Nodes.Add(x.BrandName);

      Tree.EndUpdate();
      this.Cursor = Cursors.Arrow;

    }

    #endregion

    #region Smoke and Mirrors

    private void FillTreeFast(object sender, EventArgs e)
    {
      cmdFill.Enabled     = false;
      cmdFillFast.Enabled = false;
      Tree.BeforeExpand   += new TreeViewCancelEventHandler(FillSubNodes);

      Tree.Nodes.Clear();
      Tree.BeginUpdate();
      TreeNode node = Tree.Nodes.Add("All Toys");
      node.Tag = NodeLevel.AllToys;
      node.Nodes.Add("VirtualNode");
      node = Tree.Nodes.Add("All Clothes");
      node.Tag = NodeLevel.AllClothes;
      node.Nodes.Add("VirtualNode");
      Tree.EndUpdate();

    }

    private void FillSubNodes(object sender, TreeViewCancelEventArgs e)
    {
      TreeNode  ClickedNode = e.Node;
      TreeNode  node;
      NodeLevel l = (NodeLevel)ClickedNode.Tag;

      ClickedNode.Nodes.Clear();
      switch(l)
      {
        case NodeLevel.AllToys:
          node = ClickedNode.Nodes.Add("Battery Powered Toys");
          node.Tag = NodeLevel.BatteryToys;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Board Games");
          node.Tag = NodeLevel.BoardGameToys;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Electronic Games");
          node.Tag = NodeLevel.ElectronicToys;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Models");
          node.Tag = NodeLevel.ModelToys;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Plush Toys");
          node.Tag = NodeLevel.PlushToys;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Video Games");
          node.Tag = NodeLevel.VideoToys;
          node.Nodes.Add("VirtualNode");
          break;
        case NodeLevel.AllClothes:
          node = ClickedNode.Nodes.Add("Gloves and Hats");
          node.Tag = NodeLevel.ClothingGloves;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Jackets");
          node.Tag = NodeLevel.ClothingJackets;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Pants");
          node.Tag = NodeLevel.ClothingPants;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Sweaters");
          node.Tag = NodeLevel.ClothingSweaters;
          node.Nodes.Add("VirtualNode");
          node = ClickedNode.Nodes.Add("Tops");
          node.Tag = NodeLevel.ClothingTops;
          node.Nodes.Add("VirtualNode");
          break;
        case NodeLevel.ModelToys:
          UpdateTree(toys.Models.Brands, ClickedNode);
          break;
        case NodeLevel.BatteryToys:
          UpdateTree(toys.BatteryPowered.Brands, ClickedNode);
          break;
        case NodeLevel.BoardGameToys:
          UpdateTree(toys.BoardGames.Brands, ClickedNode);
          break;
        case NodeLevel.ElectronicToys:
          UpdateTree(toys.Electronic.Brands, ClickedNode);
          break;
        case NodeLevel.FigureToys:
          UpdateTree(toys.ActionFigures.Brands, ClickedNode);
          break;
        case NodeLevel.PlushToys:
          UpdateTree(toys.Plush.Brands, ClickedNode);
          break;
        case NodeLevel.VideoToys:
          UpdateTree(toys.Video.Brands, ClickedNode);
          break;
        case NodeLevel.ClothingFootware:
          UpdateTree(Clothes.Footware.Brands, ClickedNode);
          break;
        case NodeLevel.ClothingGloves:
          UpdateTree(Clothes.GlovesHats.Brands, ClickedNode);
          break;
        case NodeLevel.ClothingJackets:
          UpdateTree(Clothes.Jackets.Brands, ClickedNode);
          break;
        case NodeLevel.ClothingPants:
          UpdateTree(Clothes.Pants.Brands, ClickedNode);
          break;
        case NodeLevel.ClothingSweaters:
          UpdateTree(Clothes.Sweaters.Brands, ClickedNode);
          break;
        case NodeLevel.ClothingTops:
          UpdateTree(Clothes.Tops.Brands, ClickedNode);
          break;
      }
    }

    #endregion

    #region Helper functions

    private void ClearTree(object sender, EventArgs e)
    {
      Tree.Nodes.Clear();
      cmdFill.Enabled     = true;
      cmdFillFast.Enabled = true;
    }

    private void UpdateTree(ArrayList Brands, TreeNode ClickedNode)
    {
      bool AllowUpdate = true;

      this.Cursor = Cursors.WaitCursor;
      foreach(Brand x in Brands)
      {
        ClickedNode.Nodes.Add(x.BrandName);
        if(AllowUpdate && ClickedNode.Nodes.Count > Tree.VisibleCount)
        {
          AllowUpdate = false;
          ExpandThisNode(ClickedNode);
          Tree.BeginUpdate();
        }
      }
      Tree.EndUpdate();
      this.Cursor = Cursors.Arrow;
    }

    private void ExpandThisNode(TreeNode node)
    {
      Tree.BeforeExpand -= new TreeViewCancelEventHandler(FillSubNodes);
      node.Expand();
      Tree.BeforeExpand += new TreeViewCancelEventHandler(FillSubNodes);
      Application.DoEvents();
    }

    #endregion

	}
}
