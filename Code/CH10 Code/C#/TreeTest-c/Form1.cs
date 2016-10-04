using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TreeTest_c
{
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.TreeView Tree;
    private System.Windows.Forms.Label lblFill;
    private System.Windows.Forms.TextBox txtMax;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cmdFill;
    private System.Windows.Forms.Button cmdClear;
    private System.Windows.Forms.Label lblClear;

    private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
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
      this.lblFill = new System.Windows.Forms.Label();
      this.txtMax = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cmdFill = new System.Windows.Forms.Button();
      this.cmdClear = new System.Windows.Forms.Button();
      this.lblClear = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // Tree
      // 
      this.Tree.ImageIndex = -1;
      this.Tree.Location = new System.Drawing.Point(16, 16);
      this.Tree.Name = "Tree";
      this.Tree.SelectedImageIndex = -1;
      this.Tree.Size = new System.Drawing.Size(224, 248);
      this.Tree.TabIndex = 0;
      // 
      // lblFill
      // 
      this.lblFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblFill.Location = new System.Drawing.Point(16, 360);
      this.lblFill.Name = "lblFill";
      this.lblFill.Size = new System.Drawing.Size(224, 24);
      this.lblFill.TabIndex = 1;
      // 
      // txtMax
      // 
      this.txtMax.Location = new System.Drawing.Point(16, 296);
      this.txtMax.Name = "txtMax";
      this.txtMax.Size = new System.Drawing.Size(88, 20);
      this.txtMax.TabIndex = 2;
      this.txtMax.Text = "1000";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 280);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(160, 16);
      this.label1.TabIndex = 3;
      this.label1.Text = "Max nodes to fill in at one time";
      // 
      // cmdFill
      // 
      this.cmdFill.Location = new System.Drawing.Point(16, 328);
      this.cmdFill.Name = "cmdFill";
      this.cmdFill.Size = new System.Drawing.Size(224, 24);
      this.cmdFill.TabIndex = 4;
      this.cmdFill.Text = "Fill";
      this.cmdFill.Click += new System.EventHandler(this.cmdFill_Click);
      // 
      // cmdClear
      // 
      this.cmdClear.Location = new System.Drawing.Point(16, 400);
      this.cmdClear.Name = "cmdClear";
      this.cmdClear.Size = new System.Drawing.Size(224, 24);
      this.cmdClear.TabIndex = 6;
      this.cmdClear.Text = "Clear";
      this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
      // 
      // lblClear
      // 
      this.lblClear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblClear.Location = new System.Drawing.Point(16, 432);
      this.lblClear.Name = "lblClear";
      this.lblClear.Size = new System.Drawing.Size(224, 24);
      this.lblClear.TabIndex = 5;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(256, 477);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdClear,
                                                                  this.lblClear,
                                                                  this.cmdFill,
                                                                  this.label1,
                                                                  this.txtMax,
                                                                  this.lblFill,
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

    private void cmdFill_Click(object sender, System.EventArgs e)
    {
      DateTime  tmr;
      TimeSpan  ts;
      int       NumNodes = int.Parse(txtMax.Text);
      
      lblFill.Text  = "";
      lblClear.Text = "";
      Application.DoEvents();
      this.Cursor = Cursors.WaitCursor;
      tmr = DateTime.Now;
//      Tree.BeginUpdate();
      //--------------------------------------------------------------------
      //Add only root nodes
      //      for(int k=0; k< NumNodes; k++)
      //        Tree.Nodes.Add("Node " + k.ToString());
      //--------------------------------------------------------------------

      //---------------------------------------------------------------------
      //Add a single root node and many child nodes.
//      TreeNode HeaderNode = Tree.Nodes.Add("User Header Node");
//      for(int k=0; k< NumNodes; k++)
//        HeaderNode.Nodes.Add("Node " + k.ToString());
//      HeaderNode.Expand();
      //---------------------------------------------------------------------

      //Add nodes and show them before shutting down the tree pane update
      bool AllowUpdate = true;
      TreeNode HeaderNode = Tree.Nodes.Add("User Header Node");
      for(int k=0; k< NumNodes; k++)
      {
        if(AllowUpdate && HeaderNode.Nodes.Count > Tree.VisibleCount)
        {
          HeaderNode.Expand();
          Application.DoEvents();
          Tree.BeginUpdate();
          AllowUpdate = false;
        }
        HeaderNode.Nodes.Add("Node " + k.ToString());
      }
      Tree.EndUpdate();
      ts = DateTime.Now - tmr;
      lblFill.Text = ts.TotalSeconds.ToString() + " seconds to add " + 
        NumNodes.ToString() + " Nodes ";
      this.Cursor = Cursors.Arrow;
    }

    private void cmdClear_Click(object sender, System.EventArgs e)
    {
      DateTime tmr = DateTime.Now;
      TimeSpan ts;
      string   NodeCount = Tree.Nodes.Count.ToString();

      this.Cursor = Cursors.WaitCursor;
      Tree.BeginUpdate();
      Tree.Nodes.Clear();
      Tree.EndUpdate();
      this.Cursor = Cursors.Arrow;

      ts = DateTime.Now - tmr;
      lblClear.Text = ts.TotalSeconds.ToString() + " seconds to clear " + NodeCount + " Nodes ";
    }
	}
}
