using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Drawing.Drawing2D;

namespace QuickTreeTester
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

    #region Class local storage

    private Point         mStartPoint;
    private Point         mLastPoint;
    private GraphicsPath  mPath;
    private Rectangle     mInvalidRect;

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtNodes;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cmdFill;
    private QuickTree_c.QuickTree qt;
    private System.Windows.Forms.Panel P1;

    private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();

      //Set Drawing Panel Properties
      P1.BackColor      = Color.Bisque;
      P1.Paint          += new PaintEventHandler(this.PanelPaint);
      P1.MouseDown      += new MouseEventHandler(this.M_Down);
      P1.MouseUp        += new MouseEventHandler(this.M_Up);
      P1.MouseMove      += new MouseEventHandler(this.M_Move);
      mPath = new GraphicsPath();

      //Set double buffer to ameliorate screen flicker
      this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
      this.SetStyle(ControlStyles.DoubleBuffer,true);

      cmdFill.Click     += new EventHandler(FillTree);
      txtNodes.KeyPress += new KeyPressEventHandler(AllowNumbers);
      qt.FillComplete   += new EventHandler(TreeComplete);
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
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtNodes = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cmdFill = new System.Windows.Forms.Button();
      this.qt = new QuickTree_c.QuickTree();
      this.P1 = new System.Windows.Forms.Panel();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // richTextBox1
      // 
      this.richTextBox1.AcceptsTab = true;
      this.richTextBox1.Location = new System.Drawing.Point(296, 16);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(248, 184);
      this.richTextBox1.TabIndex = 5;
      this.richTextBox1.Text = "Type Some Text Here:";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.label2,
                                                                            this.txtNodes,
                                                                            this.label1,
                                                                            this.cmdFill,
                                                                            this.qt});
      this.groupBox1.Location = new System.Drawing.Point(16, 8);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(256, 400);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Node Tester";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(32, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(192, 16);
      this.label2.TabIndex = 9;
      this.label2.Text = "Multithreaded Nodes";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txtNodes
      // 
      this.txtNodes.Location = new System.Drawing.Point(88, 320);
      this.txtNodes.Name = "txtNodes";
      this.txtNodes.Size = new System.Drawing.Size(64, 20);
      this.txtNodes.TabIndex = 8;
      this.txtNodes.Text = "1000";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(40, 320);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(40, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Nodes";
      // 
      // cmdFill
      // 
      this.cmdFill.Location = new System.Drawing.Point(32, 352);
      this.cmdFill.Name = "cmdFill";
      this.cmdFill.Size = new System.Drawing.Size(192, 32);
      this.cmdFill.TabIndex = 6;
      this.cmdFill.Text = "Fill";
      // 
      // qt
      // 
      this.qt.Location = new System.Drawing.Point(32, 32);
      this.qt.Name = "qt";
      this.qt.Size = new System.Drawing.Size(192, 280);
      this.qt.TabIndex = 5;
      // 
      // P1
      // 
      this.P1.Location = new System.Drawing.Point(296, 224);
      this.P1.Name = "P1";
      this.P1.Size = new System.Drawing.Size(248, 184);
      this.P1.TabIndex = 7;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(568, 437);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.P1,
                                                                  this.groupBox1,
                                                                  this.richTextBox1});
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

    private void AllowNumbers(object sender, KeyPressEventArgs e)
    {
      if(!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 )
        e.Handled = true;
    }

    private void TreeComplete(object sender, EventArgs e)
    {
      MessageBox.Show("Tree is done filling");
    }

    private void FillTree(object sender, EventArgs e)
    {
      ArrayList s = new ArrayList();
      int x = int.Parse(txtNodes.Text);

      for(int k=0; k<x; k++)
        s.Add(k.ToString());
      s.TrimToSize();

      //Do not try to bypass the fill without knowing that it is ok
      if(qt.OK2Fill)
      {
        qt.tree.Nodes.Clear();
        TreeNode n = qt.tree.Nodes.Add("BaseNode");    
        qt.Strings = s;
        qt.StartFill(n);
      }
    }

    #region Panel Painting code

    private void PanelPaint(object sender, PaintEventArgs e)
    {
      Graphics G = e.Graphics;

      G.SmoothingMode = SmoothingMode.HighSpeed;

      if (mPath.PointCount > 0)
        G.DrawPath(Pens.Black, mPath);

      G.DrawRectangle(Pens.Red, 0, 0, P1.Width-1, P1.Height-1);
    }

    private void M_Down(object sender, MouseEventArgs m)
    {
      if (m.Button == MouseButtons.Left)
      {
        mStartPoint  = new Point(m.X, m.Y);
        mLastPoint   = mStartPoint;
        mPath  = new GraphicsPath();
        P1.Invalidate();
      }
    }

    private void M_Up(object sender, MouseEventArgs m)
    {
      mPath.CloseFigure();
      P1.Cursor = Cursors.Default;
      P1.Invalidate();
    }

    private void M_Move(object sender, MouseEventArgs m)
    {
      if(m.Button == MouseButtons.Left)
      {
        mPath.AddLine(mLastPoint.X, mLastPoint.Y, m.X, m.Y);
        mLastPoint.X = m.X;
        mLastPoint.Y = m.Y;

        mInvalidRect = Rectangle.Truncate(mPath.GetBounds());
        mInvalidRect.Inflate( new Size(2, 2) );
        P1.Invalidate(mInvalidRect);
      }
    }

    #endregion
	}
}
