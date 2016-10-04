using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ContainedControls_c
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    #region class local variables

    SomePart Engine;

    #endregion

    private System.Windows.Forms.TreeView Tree;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox chkP3;
    private System.Windows.Forms.CheckBox chkP2;
    private System.Windows.Forms.CheckBox chkP1;
    private System.Windows.Forms.Button cmdQuit;
    private System.Windows.Forms.PictureBox picA;
    private System.Windows.Forms.PictureBox picB;
    private System.Windows.Forms.PictureBox picC;
		private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      Tree.MouseDown  += new MouseEventHandler(this.RightClick);
      chkP1.MouseDown += new MouseEventHandler(this.RightClick);
      chkP2.MouseDown += new MouseEventHandler(this.RightClick);
      chkP3.MouseDown += new MouseEventHandler(this.RightClick);
      picA.MouseDown  += new MouseEventHandler(this.RightClick);
      picB.MouseDown  += new MouseEventHandler(this.RightClick);
      picC.MouseDown  += new MouseEventHandler(this.RightClick);

      SomePart part;

      //Put the first part in the tree and the checkbox and the image
      part = new SomePart();
      TreeNode Node = new TreeNode();
      Node.Text = part.ID;
      Node.Tag = part;
      Tree.Nodes.Add(Node);
      chkP1.Text=part.ID;
      chkP1.Tag = part;
      picA.Image = part.img;
      picA.Tag = part;

      part = new SomePart();
      Node = new TreeNode();
      Node.Text = part.ID;
      Node.Tag = part;
      Tree.Nodes.Add(Node);
      chkP2.Text=part.ID;
      chkP2.Tag = part;
      picB.Image = part.img;
      picB.Tag = part;

      part = new SomePart();
      Node = new TreeNode();
      Node.Text = part.ID;
      Node.Tag = part;
      Tree.Nodes.Add(Node);
      chkP3.Text=part.ID;
      chkP3.Tag = part;
      picC.Image = part.img;
      picC.Tag = part;

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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.chkP3 = new System.Windows.Forms.CheckBox();
      this.chkP2 = new System.Windows.Forms.CheckBox();
      this.chkP1 = new System.Windows.Forms.CheckBox();
      this.cmdQuit = new System.Windows.Forms.Button();
      this.picA = new System.Windows.Forms.PictureBox();
      this.picB = new System.Windows.Forms.PictureBox();
      this.picC = new System.Windows.Forms.PictureBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // Tree
      // 
      this.Tree.BackColor = System.Drawing.Color.Linen;
      this.Tree.ImageIndex = -1;
      this.Tree.Location = new System.Drawing.Point(40, 32);
      this.Tree.Name = "Tree";
      this.Tree.SelectedImageIndex = -1;
      this.Tree.Size = new System.Drawing.Size(184, 224);
      this.Tree.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.chkP3,
                                                                            this.chkP2,
                                                                            this.chkP1});
      this.groupBox1.Location = new System.Drawing.Point(240, 32);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(168, 144);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Parts";
      // 
      // chkP3
      // 
      this.chkP3.BackColor = System.Drawing.Color.SeaShell;
      this.chkP3.Location = new System.Drawing.Point(16, 96);
      this.chkP3.Name = "chkP3";
      this.chkP3.Size = new System.Drawing.Size(136, 16);
      this.chkP3.TabIndex = 6;
      // 
      // chkP2
      // 
      this.chkP2.BackColor = System.Drawing.Color.SeaShell;
      this.chkP2.Location = new System.Drawing.Point(16, 64);
      this.chkP2.Name = "chkP2";
      this.chkP2.Size = new System.Drawing.Size(136, 16);
      this.chkP2.TabIndex = 5;
      // 
      // chkP1
      // 
      this.chkP1.BackColor = System.Drawing.Color.SeaShell;
      this.chkP1.Location = new System.Drawing.Point(16, 32);
      this.chkP1.Name = "chkP1";
      this.chkP1.Size = new System.Drawing.Size(136, 16);
      this.chkP1.TabIndex = 4;
      // 
      // cmdQuit
      // 
      this.cmdQuit.Location = new System.Drawing.Point(336, 240);
      this.cmdQuit.Name = "cmdQuit";
      this.cmdQuit.Size = new System.Drawing.Size(72, 32);
      this.cmdQuit.TabIndex = 2;
      this.cmdQuit.Text = "Quit";
      this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
      // 
      // picA
      // 
      this.picA.BackColor = System.Drawing.Color.Linen;
      this.picA.Location = new System.Drawing.Point(240, 192);
      this.picA.Name = "picA";
      this.picA.Size = new System.Drawing.Size(32, 32);
      this.picA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picA.TabIndex = 3;
      this.picA.TabStop = false;
      // 
      // picB
      // 
      this.picB.BackColor = System.Drawing.Color.Linen;
      this.picB.Location = new System.Drawing.Point(304, 192);
      this.picB.Name = "picB";
      this.picB.Size = new System.Drawing.Size(32, 32);
      this.picB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picB.TabIndex = 4;
      this.picB.TabStop = false;
      // 
      // picC
      // 
      this.picC.BackColor = System.Drawing.Color.Linen;
      this.picC.Location = new System.Drawing.Point(368, 192);
      this.picC.Name = "picC";
      this.picC.Size = new System.Drawing.Size(32, 32);
      this.picC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picC.TabIndex = 5;
      this.picC.TabStop = false;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(440, 278);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.picC,
                                                                  this.picB,
                                                                  this.picA,
                                                                  this.cmdQuit,
                                                                  this.groupBox1,
                                                                  this.Tree});
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
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

    #region Mouse Events

    private void RightClick(object sender, MouseEventArgs e)
    {
      if(e.Button != MouseButtons.Right)
        return;

      if(sender is TreeView)
        Engine = (SomePart)Tree.SelectedNode.Tag;
      else if(sender is PictureBox)
      {
        PictureBox p = (PictureBox)sender;
        Engine = (SomePart)p.Tag;
      }
      else if(sender is CheckBox)
      {
        CheckBox c = (CheckBox)sender;
        Engine = (SomePart)c.Tag;
      }

      Engine.ShowMenu((Control)sender, new Point(e.X, e.Y) );

    }

    #endregion

    private void cmdQuit_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }

	}
}
