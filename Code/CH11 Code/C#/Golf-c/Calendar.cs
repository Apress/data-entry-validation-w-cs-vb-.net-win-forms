using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Golf_c
{
	/// <summary>
	/// Summary description for Calendar.
	/// </summary>
	public class Calendar : System.Windows.Forms.Form
	{
    private System.Windows.Forms.MonthCalendar cal;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Calendar()
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
      this.cal = new System.Windows.Forms.MonthCalendar();
      this.SuspendLayout();
      // 
      // cal
      // 
      this.cal.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.cal.Name = "cal";
      this.cal.TabIndex = 0;
      // 
      // Calendar
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(200, 152);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cal});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Calendar";
      this.Text = "Calendar";
      this.ResumeLayout(false);

    }
		#endregion
	}
}
