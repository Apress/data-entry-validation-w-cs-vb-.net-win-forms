using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Resizable_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.listView1 = new System.Windows.Forms.ListView();
      this.label2 = new System.Windows.Forms.Label();
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.label3 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // comboBox1
      // 
      this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.comboBox1.Location = new System.Drawing.Point(24, 40);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(144, 21);
      this.comboBox1.TabIndex = 0;
      this.comboBox1.Text = "comboBox1";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.label1.Location = new System.Drawing.Point(24, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(144, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "ComboBox";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // listView1
      // 
      this.listView1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.listView1.Location = new System.Drawing.Point(24, 88);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(312, 256);
      this.listView1.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.label2.Location = new System.Drawing.Point(24, 72);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(312, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "Some list";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // treeView1
      // 
      this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.treeView1.ImageIndex = -1;
      this.treeView1.Location = new System.Drawing.Point(360, 88);
      this.treeView1.Name = "treeView1";
      this.treeView1.SelectedImageIndex = -1;
      this.treeView1.Size = new System.Drawing.Size(144, 256);
      this.treeView1.TabIndex = 4;
      // 
      // label3
      // 
      this.label3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label3.Location = new System.Drawing.Point(360, 72);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(144, 16);
      this.label3.TabIndex = 5;
      this.label3.Text = "TreeView";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // button1
      // 
      this.button1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.button1.BackColor = System.Drawing.SystemColors.Control;
      this.button1.Location = new System.Drawing.Point(440, 360);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(72, 32);
      this.button1.TabIndex = 6;
      this.button1.Text = "Help";
      // 
      // button2
      // 
      this.button2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.button2.Location = new System.Drawing.Point(352, 360);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(72, 32);
      this.button2.TabIndex = 7;
      this.button2.Text = "Cancel";
      // 
      // button3
      // 
      this.button3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.button3.Location = new System.Drawing.Point(264, 360);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(72, 32);
      this.button3.TabIndex = 8;
      this.button3.Text = "OK";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(528, 405);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.button3,
                                                                  this.button2,
                                                                  this.button1,
                                                                  this.label3,
                                                                  this.treeView1,
                                                                  this.label2,
                                                                  this.listView1,
                                                                  this.label1,
                                                                  this.comboBox1});
      this.MinimumSize = new System.Drawing.Size(536, 432);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Resize Me!";
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
	}
}
