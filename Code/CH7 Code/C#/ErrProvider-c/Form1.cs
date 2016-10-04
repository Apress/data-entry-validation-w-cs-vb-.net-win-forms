using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ErrProvider_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Button cmdSave;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckedListBox lstMovies;
    private System.Windows.Forms.TextBox txtAddr;
    private System.Windows.Forms.ErrorProvider Err;

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
      this.cmdSave = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.txtAddr = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lstMovies = new System.Windows.Forms.CheckedListBox();
      this.Err = new System.Windows.Forms.ErrorProvider();
      this.SuspendLayout();
      // 
      // cmdSave
      // 
      this.cmdSave.Location = new System.Drawing.Point(344, 272);
      this.cmdSave.Name = "cmdSave";
      this.cmdSave.Size = new System.Drawing.Size(72, 32);
      this.cmdSave.TabIndex = 0;
      this.cmdSave.Text = "Save";
      this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(104, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Name";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(24, 40);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(168, 20);
      this.txtName.TabIndex = 2;
      this.txtName.Text = "";
      // 
      // txtAddr
      // 
      this.txtAddr.Location = new System.Drawing.Point(24, 96);
      this.txtAddr.Name = "txtAddr";
      this.txtAddr.Size = new System.Drawing.Size(168, 20);
      this.txtAddr.TabIndex = 4;
      this.txtAddr.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(24, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(104, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "Address";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(24, 144);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(104, 16);
      this.label3.TabIndex = 6;
      this.label3.Text = "Favorite movie";
      // 
      // lstMovies
      // 
      this.lstMovies.Location = new System.Drawing.Point(24, 160);
      this.lstMovies.Name = "lstMovies";
      this.lstMovies.Size = new System.Drawing.Size(264, 109);
      this.lstMovies.TabIndex = 7;
      // 
      // Err
      // 
      this.Err.DataMember = null;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(432, 317);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lstMovies,
                                                                  this.label3,
                                                                  this.txtAddr,
                                                                  this.label2,
                                                                  this.txtName,
                                                                  this.label1,
                                                                  this.cmdSave});
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
      lstMovies.Items.Add("Dumbo");
      lstMovies.Items.Add("WindTalkers");
      lstMovies.Items.Add("Paper Chase");
      lstMovies.Items.Add("War Of The Worlds");
      lstMovies.Items.Add("LOTR");

    }

    private void cmdSave_Click(object sender, System.EventArgs e)
    {
      if(txtName.Text == string.Empty)
        Err.SetError(txtName, "Cannot save form without a name");
      else
        Err.SetError(txtName, "");

      if(txtAddr.Text == string.Empty)
        Err.SetError(txtAddr, "Cannot save form without an address");
      else
        Err.SetError(txtAddr, "");

      if(lstMovies.SelectedIndices.Count == 0)
        Err.SetError(lstMovies, "Cannot save form without a favorite movie");
      else
        Err.SetError(lstMovies, "");
    }
	}
}
