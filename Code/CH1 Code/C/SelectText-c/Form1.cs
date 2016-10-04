using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SelectText_c
{
  /// <summary>
  /// This project shows how to connect/disconnect dleegates and events.
  /// It also shows how to programatically select text
  /// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button cmdQuit;
    private System.Windows.Forms.TextBox t1;
    private System.Windows.Forms.TextBox t2;
    private System.Windows.Forms.TextBox t3;
    private System.Windows.Forms.CheckBox chkSelect;

    private System.ComponentModel.Container components = null;

    public Form1()
    {
	    InitializeComponent();

      chkSelect.CheckedChanged += new EventHandler(this.FlipSelect);

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
      this.t1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.t2 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.t3 = new System.Windows.Forms.TextBox();
      this.cmdQuit = new System.Windows.Forms.Button();
      this.chkSelect = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // t1
      // 
      this.t1.Location = new System.Drawing.Point(16, 64);
      this.t1.Name = "t1";
      this.t1.Size = new System.Drawing.Size(136, 20);
      this.t1.TabIndex = 0;
      this.t1.Text = "The quick brown fox jumped over the lazy dog";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 48);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(136, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Unlimited Text";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(16, 96);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(136, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "10 characters";
      // 
      // t2
      // 
      this.t2.Location = new System.Drawing.Point(16, 112);
      this.t2.MaxLength = 10;
      this.t2.Name = "t2";
      this.t2.Size = new System.Drawing.Size(136, 20);
      this.t2.TabIndex = 2;
      this.t2.Text = "1-10";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(16, 144);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(136, 16);
      this.label3.TabIndex = 5;
      this.label3.Text = "10 characters";
      // 
      // t3
      // 
      this.t3.Location = new System.Drawing.Point(16, 160);
      this.t3.MaxLength = 10;
      this.t3.Name = "t3";
      this.t3.Size = new System.Drawing.Size(136, 20);
      this.t3.TabIndex = 4;
      this.t3.Text = "1-10";
      // 
      // cmdQuit
      // 
      this.cmdQuit.Location = new System.Drawing.Point(80, 200);
      this.cmdQuit.Name = "cmdQuit";
      this.cmdQuit.Size = new System.Drawing.Size(72, 32);
      this.cmdQuit.TabIndex = 8;
      this.cmdQuit.Text = "Quit";
      this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
      // 
      // chkSelect
      // 
      this.chkSelect.Location = new System.Drawing.Point(16, 16);
      this.chkSelect.Name = "chkSelect";
      this.chkSelect.Size = new System.Drawing.Size(144, 16);
      this.chkSelect.TabIndex = 9;
      this.chkSelect.Text = "Select";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(176, 245);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.chkSelect,
                                                                  this.cmdQuit,
                                                                  this.label3,
                                                                  this.t3,
                                                                  this.label2,
                                                                  this.t2,
                                                                  this.label1,
                                                                  this.t1});
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

    private void cmdQuit_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
    }

    #region events

    private void FlipSelect(object sender, EventArgs e)
    {
      if (chkSelect.Checked)
      {
        t1.GotFocus += new EventHandler(this.SelectMe);
        t2.GotFocus += new EventHandler(this.SelectMe);
        t3.GotFocus += new EventHandler(this.SelectMe);
      }
      else
      {
        t1.GotFocus -= new EventHandler(this.SelectMe);
        t2.GotFocus -= new EventHandler(this.SelectMe);
        t3.GotFocus -= new EventHandler(this.SelectMe);
      }

    }

    private void SelectMe(object sender, EventArgs e)
    {
      t1.Select(0,t1.TextLength);
      t2.Select(0,t2.TextLength);
      t3.Select(0,t3.TextLength);
    }

    #endregion
	}
}
