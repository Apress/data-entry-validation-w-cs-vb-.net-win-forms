using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ErrDialog_c
{
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label lblTicks;
    private System.Windows.Forms.Button cmdOK;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtStart;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtEnd;
    private System.ComponentModel.IContainer components;

    public Form1()
    {
      InitializeComponent();

      timer1.Interval = 1000;
      timer1.Start();
      cmdOK.Click += new EventHandler(this.OK_Click);

      txtStart.Text = DateTime.Now.ToShortTimeString();
      txtEnd.Text   = DateTime.Now.AddMinutes(-1).ToShortTimeString();

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
      this.components = new System.ComponentModel.Container();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.lblTicks = new System.Windows.Forms.Label();
      this.cmdOK = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtStart = new System.Windows.Forms.TextBox();
      this.txtEnd = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // lblTicks
      // 
      this.lblTicks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblTicks.Location = new System.Drawing.Point(56, 168);
      this.lblTicks.Name = "lblTicks";
      this.lblTicks.Size = new System.Drawing.Size(64, 16);
      this.lblTicks.TabIndex = 0;
      this.lblTicks.Text = "0";
      this.lblTicks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // cmdOK
      // 
      this.cmdOK.Location = new System.Drawing.Point(40, 120);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.Size = new System.Drawing.Size(96, 24);
      this.cmdOK.TabIndex = 1;
      this.cmdOK.Text = "OK";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(32, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(112, 16);
      this.label1.TabIndex = 2;
      this.label1.Text = "Start Time";
      // 
      // txtStart
      // 
      this.txtStart.Location = new System.Drawing.Point(32, 32);
      this.txtStart.Name = "txtStart";
      this.txtStart.Size = new System.Drawing.Size(120, 20);
      this.txtStart.TabIndex = 3;
      this.txtStart.Text = "";
      // 
      // txtEnd
      // 
      this.txtEnd.Location = new System.Drawing.Point(32, 80);
      this.txtEnd.Name = "txtEnd";
      this.txtEnd.Size = new System.Drawing.Size(120, 20);
      this.txtEnd.TabIndex = 5;
      this.txtEnd.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(32, 64);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(112, 16);
      this.label2.TabIndex = 4;
      this.label2.Text = "End Time";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(184, 213);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.txtEnd,
                                                                  this.label2,
                                                                  this.txtStart,
                                                                  this.label1,
                                                                  this.cmdOK,
                                                                  this.lblTicks});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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

    private void timer1_Tick(object sender, System.EventArgs e)
    {
      lblTicks.Text = (int.Parse(lblTicks.Text)+1).ToString();
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
    }

    private void OK_Click(object sender, EventArgs e)
    {
      DialogResult Retval;
      string msg;

      msg =  "The end time field has an incorrect value.\n";
      msg += "The end time must be later than the start time\n\n";
      msg += "Press 'Yes' to automatically adjust the end time";

      Retval = MessageBox.Show( msg,
                                "Incorrect End Time",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error);
      if(Retval == DialogResult.Yes)
        txtEnd.Text = 
               DateTime.Parse(txtStart.Text).AddMinutes(1).ToShortTimeString();
      txtEnd.SelectAll();
      txtEnd.Focus();
    }
	}
}
