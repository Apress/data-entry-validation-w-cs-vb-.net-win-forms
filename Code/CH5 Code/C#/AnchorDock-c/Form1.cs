using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AnchorDock_c
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.TreeView T1;
    private System.Windows.Forms.RichTextBox rcT;
    private System.Windows.Forms.Splitter splitter2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.PictureBox Pic;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      //Fill the tree view
      TreeNode node = new TreeNode("Base Inventory");
      node.Nodes.Add("Laptop 234");
      node.Nodes.Add("Desktop 831");
      node.Nodes.Add("68030 Emulator");
      node.Expand();
      T1.Nodes.Add(node);


      // uncomment this next line to make the aspect ratio of bitmap real
      //Pic.SizeMode = PictureBoxSizeMode.AutoSize;
      Pic.Size = panel1.Size;
      //Comment this next line of code out for correct aspect ratio
      Pic.SizeMode = PictureBoxSizeMode.StretchImage;
      Pic.Image = Image.FromFile("floorplan.bmp");

      this.Resize += new EventHandler(this.DisplaySize);
      foreach(Control c in this.Controls)
        c.Resize += new EventHandler(this.DisplaySize);
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
      this.rcT = new System.Windows.Forms.RichTextBox();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.T1 = new System.Windows.Forms.TreeView();
      this.splitter2 = new System.Windows.Forms.Splitter();
      this.panel1 = new System.Windows.Forms.Panel();
      this.Pic = new System.Windows.Forms.PictureBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // rcT
      // 
      this.rcT.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.rcT.Location = new System.Drawing.Point(0, 374);
      this.rcT.Name = "rcT";
      this.rcT.Size = new System.Drawing.Size(600, 104);
      this.rcT.TabIndex = 0;
      this.rcT.Text = "richTextBox1";
      // 
      // splitter1
      // 
      this.splitter1.BackColor = System.Drawing.Color.Fuchsia;
      this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter1.Location = new System.Drawing.Point(0, 366);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(600, 8);
      this.splitter1.TabIndex = 1;
      this.splitter1.TabStop = false;
      // 
      // T1
      // 
      this.T1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.T1.Dock = System.Windows.Forms.DockStyle.Left;
      this.T1.ImageIndex = -1;
      this.T1.Name = "T1";
      this.T1.SelectedImageIndex = -1;
      this.T1.Size = new System.Drawing.Size(136, 366);
      this.T1.TabIndex = 2;
      // 
      // splitter2
      // 
      this.splitter2.BackColor = System.Drawing.Color.Fuchsia;
      this.splitter2.Location = new System.Drawing.Point(136, 0);
      this.splitter2.Name = "splitter2";
      this.splitter2.Size = new System.Drawing.Size(8, 366);
      this.splitter2.TabIndex = 3;
      this.splitter2.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                         this.Pic});
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(144, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(456, 366);
      this.panel1.TabIndex = 4;
      // 
      // Pic
      // 
      this.Pic.BackColor = System.Drawing.Color.LightCyan;
      this.Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Pic.Location = new System.Drawing.Point(16, 24);
      this.Pic.Name = "Pic";
      this.Pic.Size = new System.Drawing.Size(224, 200);
      this.Pic.TabIndex = 0;
      this.Pic.TabStop = false;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(600, 478);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.panel1,
                                                                  this.splitter2,
                                                                  this.T1,
                                                                  this.splitter1,
                                                                  this.rcT});
      this.MinimumSize = new System.Drawing.Size(200, 200);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() 
    {
      Application.Run(new Form1());
    }

    private void DisplaySize(object sender, EventArgs e)
    {
      rcT.AppendText("Picture Size = " + Pic.Size.ToString() + "\n");
      rcT.AppendText("Panel size = " + panel1.Size.ToString() + "\n\n");
    }


  }


}
