using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MDIapp_c
{
	/// <summary>
	/// Summary description for Payroll.
	/// </summary>
	public class Payroll : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label lblCash;
		private System.ComponentModel.Container components = null;


  public Payroll()
  {
    InitializeComponent();

    ContextMenu m = new ContextMenu();
    m.MenuItems.Add("Add money to employee");
    m.MenuItems.Add("Remove money from employee");
    m.MenuItems.Add("Give raises to everyone");
    MenuItem mnu = m.MenuItems[m.MenuItems.Count-1];
    mnu.Enabled = false;
    m.MenuItems.Add("Cut in pay");

    lblCash.ContextMenu = m;

  }

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
      this.lblCash = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblCash
      // 
      this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblCash.Location = new System.Drawing.Point(56, 40);
      this.lblCash.Name = "lblCash";
      this.lblCash.Size = new System.Drawing.Size(160, 160);
      this.lblCash.TabIndex = 0;
      this.lblCash.Text = "$";
      this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Payroll
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(292, 273);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lblCash});
      this.Name = "Payroll";
      this.Text = "Payroll";
      this.Load += new System.EventHandler(this.Payroll_Load);
      this.ResumeLayout(false);

    }
		#endregion

    private void Payroll_Load(object sender, System.EventArgs e)
    {
    }



	}
}
