using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Accessibility_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class dataentry : System.Windows.Forms.Form
	{
    #region class local variables

    Spy SpyForm;

    #endregion
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;


    private System.ComponentModel.Container components = null;

		public dataentry()
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
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.AccessibleDescription = "Program Exit Button";
      this.button1.AccessibleName = "Exit Button";
      this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.button1.Location = new System.Drawing.Point(112, 120);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(88, 32);
      this.button1.TabIndex = 0;
      this.button1.Text = "Exit";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(56, 40);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(120, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Name";
      // 
      // textBox1
      // 
      this.textBox1.AccessibleDescription = "Name of Employee";
      this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
      this.textBox1.Location = new System.Drawing.Point(56, 56);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(128, 20);
      this.textBox1.TabIndex = 2;
      this.textBox1.Text = "";
      // 
      // dataentry
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(320, 230);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.textBox1,
                                                                  this.label1,
                                                                  this.button1});
      this.Name = "dataentry";
      this.Text = "DataEntry";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

    }
		#endregion

    [STAThread]
    static void Main() 
    {
      Application.Run(new dataentry());
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
      SpyForm = new Spy();
      SpyForm.Owner = this;

      SpyForm.Show();
    }

	}
}
