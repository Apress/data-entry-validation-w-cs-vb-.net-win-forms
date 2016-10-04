using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Logging_c
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Button cmdOK;
    private System.Windows.Forms.TextBox txtPass;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cmdCancel;
		private System.ComponentModel.Container components = null;

		public Login()
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
      this.cmdOK = new System.Windows.Forms.Button();
      this.txtPass = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cmdOK
      // 
      this.cmdOK.Location = new System.Drawing.Point(40, 136);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.Size = new System.Drawing.Size(72, 32);
      this.cmdOK.TabIndex = 9;
      this.cmdOK.Text = "OK";
      this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
      // 
      // txtPass
      // 
      this.txtPass.Location = new System.Drawing.Point(24, 96);
      this.txtPass.MaxLength = 5;
      this.txtPass.Name = "txtPass";
      this.txtPass.PasswordChar = '*';
      this.txtPass.Size = new System.Drawing.Size(224, 20);
      this.txtPass.TabIndex = 8;
      this.txtPass.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(24, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(128, 16);
      this.label2.TabIndex = 7;
      this.label2.Text = "Password";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(24, 40);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(224, 20);
      this.txtName.TabIndex = 6;
      this.txtName.Text = "";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(128, 16);
      this.label1.TabIndex = 5;
      this.label1.Text = "Login Name";
      // 
      // cmdCancel
      // 
      this.cmdCancel.Location = new System.Drawing.Point(152, 136);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(72, 32);
      this.cmdCancel.TabIndex = 10;
      this.cmdCancel.Text = "Cancel";
      this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
      // 
      // Login
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(272, 206);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdCancel,
                                                                  this.cmdOK,
                                                                  this.txtPass,
                                                                  this.label2,
                                                                  this.txtName,
                                                                  this.label1});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Login";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Login";
      this.Load += new System.EventHandler(this.Login_Load);
      this.ResumeLayout(false);

    }
		#endregion

    private void cmdOK_Click(object sender, System.EventArgs e)
    {
      const bool LoginOK = true; //Causes unreachable code

      //First put in some code to evaluate if login succeeded
      if(LoginOK)
        EventLogger.LoginOK(txtName.Text);
      else
        EventLogger.LoginFailed(txtName.Text);

      this.Close();
    }

    private void cmdCancel_Click(object sender, System.EventArgs e)
    {
      EventLogger.LoginCanceled(txtName.Text);
      this.Close();
    }

    private void Login_Load(object sender, System.EventArgs e)
    {
    
    }
	}
}
