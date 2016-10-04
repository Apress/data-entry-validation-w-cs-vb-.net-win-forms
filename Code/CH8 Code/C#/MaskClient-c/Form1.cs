using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using CustomMask_c;

namespace MaskClient_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.TextBox textBox1;
    private CustomMask_c.MaskedTextBox_C me1;
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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.me1 = new CustomMask_c.MaskedTextBox_C();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(40, 72);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(160, 20);
      this.textBox1.TabIndex = 1;
      this.textBox1.Text = "textBox1";
      // 
      // me1
      // 
      this.me1.Format = CustomMask_c.MaskedTextBox_C.FormatType.None;
      this.me1.Location = new System.Drawing.Point(40, 24);
      this.me1.Mask = "##?/#?/##";
      this.me1.Name = "me1";
      this.me1.Size = new System.Drawing.Size(160, 20);
      this.me1.TabIndex = 2;
      this.me1.Text = "___/__/__";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(240, 149);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.me1,
                                                                  this.textBox1});
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
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

    private void Form1_Load(object sender, System.EventArgs e)
    {
      me1.ValidationError += new ValidationErrorEventHandler(MaskValid);
    }

    private void MaskValid(object sender, ValidationErrorEventArgs e)
    {
      MessageBox.Show(e.Mask + "  " + e.Text);
    }
	}
}
