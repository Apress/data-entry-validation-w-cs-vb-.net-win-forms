using System;
using System.Threading;
using System.Globalization;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowSwitch_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button cmdChange;

    private System.ComponentModel.Container components = null;

		public Form1()
		{
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
      Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.cmdChange = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AccessibleDescription = ((string)(resources.GetObject("label1.AccessibleDescription")));
      this.label1.AccessibleName = ((string)(resources.GetObject("label1.AccessibleName")));
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
      this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
      this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
      this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
      this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
      this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
      this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
      this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
      this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
      this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
      this.label1.Name = "label1";
      this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
      this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
      this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
      this.label1.Text = resources.GetString("label1.Text");
      this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
      this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
      // 
      // textBox1
      // 
      this.textBox1.AccessibleDescription = ((string)(resources.GetObject("textBox1.AccessibleDescription")));
      this.textBox1.AccessibleName = ((string)(resources.GetObject("textBox1.AccessibleName")));
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("textBox1.Anchor")));
      this.textBox1.AutoSize = ((bool)(resources.GetObject("textBox1.AutoSize")));
      this.textBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("textBox1.BackgroundImage")));
      this.textBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("textBox1.Dock")));
      this.textBox1.Enabled = ((bool)(resources.GetObject("textBox1.Enabled")));
      this.textBox1.Font = ((System.Drawing.Font)(resources.GetObject("textBox1.Font")));
      this.textBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("textBox1.ImeMode")));
      this.textBox1.Location = ((System.Drawing.Point)(resources.GetObject("textBox1.Location")));
      this.textBox1.MaxLength = ((int)(resources.GetObject("textBox1.MaxLength")));
      this.textBox1.Multiline = ((bool)(resources.GetObject("textBox1.Multiline")));
      this.textBox1.Name = "textBox1";
      this.textBox1.PasswordChar = ((char)(resources.GetObject("textBox1.PasswordChar")));
      this.textBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("textBox1.RightToLeft")));
      this.textBox1.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("textBox1.ScrollBars")));
      this.textBox1.Size = ((System.Drawing.Size)(resources.GetObject("textBox1.Size")));
      this.textBox1.TabIndex = ((int)(resources.GetObject("textBox1.TabIndex")));
      this.textBox1.Text = resources.GetString("textBox1.Text");
      this.textBox1.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("textBox1.TextAlign")));
      this.textBox1.Visible = ((bool)(resources.GetObject("textBox1.Visible")));
      this.textBox1.WordWrap = ((bool)(resources.GetObject("textBox1.WordWrap")));
      // 
      // cmdChange
      // 
      this.cmdChange.AccessibleDescription = ((string)(resources.GetObject("cmdChange.AccessibleDescription")));
      this.cmdChange.AccessibleName = ((string)(resources.GetObject("cmdChange.AccessibleName")));
      this.cmdChange.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdChange.Anchor")));
      this.cmdChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdChange.BackgroundImage")));
      this.cmdChange.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdChange.Dock")));
      this.cmdChange.Enabled = ((bool)(resources.GetObject("cmdChange.Enabled")));
      this.cmdChange.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdChange.FlatStyle")));
      this.cmdChange.Font = ((System.Drawing.Font)(resources.GetObject("cmdChange.Font")));
      this.cmdChange.Image = ((System.Drawing.Image)(resources.GetObject("cmdChange.Image")));
      this.cmdChange.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdChange.ImageAlign")));
      this.cmdChange.ImageIndex = ((int)(resources.GetObject("cmdChange.ImageIndex")));
      this.cmdChange.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdChange.ImeMode")));
      this.cmdChange.Location = ((System.Drawing.Point)(resources.GetObject("cmdChange.Location")));
      this.cmdChange.Name = "cmdChange";
      this.cmdChange.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdChange.RightToLeft")));
      this.cmdChange.Size = ((System.Drawing.Size)(resources.GetObject("cmdChange.Size")));
      this.cmdChange.TabIndex = ((int)(resources.GetObject("cmdChange.TabIndex")));
      this.cmdChange.Text = resources.GetString("cmdChange.Text");
      this.cmdChange.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdChange.TextAlign")));
      this.cmdChange.Visible = ((bool)(resources.GetObject("cmdChange.Visible")));
      this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
      // 
      // Form1
      // 
      this.AccessibleDescription = ((string)(resources.GetObject("$this.AccessibleDescription")));
      this.AccessibleName = ((string)(resources.GetObject("$this.AccessibleName")));
      this.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("$this.Anchor")));
      this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
      this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
      this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
      this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdChange,
                                                                  this.textBox1,
                                                                  this.label1});
      this.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("$this.Dock")));
      this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
      this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
      this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
      this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
      this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
      this.Name = "Form1";
      this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
      this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
      this.Text = resources.GetString("$this.Text");
      this.Visible = ((bool)(resources.GetObject("$this.Visible")));
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
    
    }

    private void cmdChange_Click(object sender, System.EventArgs e)
    {
      MessageBox.Show(CultureInfo.CurrentCulture.ToString());
      
    }
	}
}
