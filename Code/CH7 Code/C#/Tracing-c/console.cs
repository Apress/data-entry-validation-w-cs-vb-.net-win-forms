using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Tracing_c
{

  public class console : System.Windows.Forms.Form
	{

    private bool mAlive;

    private System.Windows.Forms.TextBox txtOut;
		private System.ComponentModel.Container components = null;

    public console()
    {
      InitializeComponent();
      this.Text        = "Console Output";
      txtOut.BackColor = Color.Black;
      txtOut.ForeColor = Color.White;
      mAlive           = true;
      this.Hide();
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
      mAlive = false;
    }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.txtOut = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtOut
      // 
      this.txtOut.AcceptsReturn = true;
      this.txtOut.AcceptsTab = true;
      this.txtOut.BackColor = System.Drawing.Color.Black;
      this.txtOut.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtOut.ForeColor = System.Drawing.Color.White;
      this.txtOut.Multiline = true;
      this.txtOut.Name = "txtOut";
      this.txtOut.Size = new System.Drawing.Size(496, 357);
      this.txtOut.TabIndex = 0;
      this.txtOut.Text = "";
      // 
      // console
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(496, 357);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.txtOut});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "console";
      this.Text = "Console Output";
      this.Load += new System.EventHandler(this.console_Load);
      this.ResumeLayout(false);

    }
		#endregion

    private void console_Load(object sender, System.EventArgs e)
    {
    }

    public bool IsAlive { get{return mAlive;} }
    public void Out(string buffer)
    {
      this.Show();
      txtOut.AppendText(buffer);
    }

    public void OutL(string buffer)
    {
      this.Show();
      txtOut.AppendText(buffer + "\r\n");
    }

    public void Clear()
    {
      txtOut.Text = string.Empty;
    }

	}
}
