using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MSComm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private AxMSCommLib.AxMSComm COM1;
		private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      COM1.CommPort    = 1;
      COM1.Handshaking = MSCommLib.HandshakeConstants.comRTSXOnXOff;
      COM1.Settings    = "9600, O, 7, 1";
      COM1.InputMode   = MSCommLib.InputModeConstants.comInputModeText;
      COM1.InputLen    = 0;
      COM1.NullDiscard = false;
      COM1.OnComm      += new EventHandler(this.CommEvent);

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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
      this.COM1 = new AxMSCommLib.AxMSComm();
      ((System.ComponentModel.ISupportInitialize)(this.COM1)).BeginInit();
      this.SuspendLayout();
      // 
      // COM1
      // 
      this.COM1.Enabled = true;
      this.COM1.Location = new System.Drawing.Point(24, 192);
      this.COM1.Name = "COM1";
      this.COM1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("COM1.OcxState")));
      this.COM1.Size = new System.Drawing.Size(38, 38);
      this.COM1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.COM1});
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.COM1)).EndInit();
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

    private void CommEvent(object sender, EventArgs e)
    {
      if (COM1.InBufferCount <= 0) 
        return;

      //Do some processing and validation here.
    }

	}
}
