using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SDIsample_c
{
	/// <summary>
	/// Summary description for Payroll.
	/// </summary>
	public class Payroll : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;

    #region Class Local Variables


    #endregion

		public Payroll()
		{
			InitializeComponent();


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
      // 
      // Payroll
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Name = "Payroll";
      this.Text = "Payroll";
      this.Load += new System.EventHandler(this.Payroll_Load);

    }
		#endregion

    private void Payroll_Load(object sender, System.EventArgs e)
    {
    
    }


	}
}
