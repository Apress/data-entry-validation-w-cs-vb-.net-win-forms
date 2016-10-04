using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace Logging_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>

  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Button cmdLogin;

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
      EventLogger.ProgramEnd();
    }

		#region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.cmdLogin = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cmdLogin
      // 
      this.cmdLogin.Location = new System.Drawing.Point(64, 80);
      this.cmdLogin.Name = "cmdLogin";
      this.cmdLogin.Size = new System.Drawing.Size(136, 32);
      this.cmdLogin.TabIndex = 0;
      this.cmdLogin.Text = "Login";
      this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(272, 190);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdLogin});
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
      EventLogger.ProgramStart();
    }

    private void cmdLogin_Click(object sender, System.EventArgs e)
    {
      Login frm = new Login();
      frm.ShowDialog();
    }


  }
}
