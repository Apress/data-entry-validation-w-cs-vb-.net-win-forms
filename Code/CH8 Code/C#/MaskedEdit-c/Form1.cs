using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AxMSMask;

namespace MaskedEdit_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private AxMSMask.AxMaskEdBox meDate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private AxMSMask.AxMaskEdBox meTime;
    private System.Windows.Forms.ErrorProvider ep1;
    private System.Windows.Forms.ListBox L;
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
    }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
      this.meDate = new AxMSMask.AxMaskEdBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.meTime = new AxMSMask.AxMaskEdBox();
      this.ep1 = new System.Windows.Forms.ErrorProvider();
      this.L = new System.Windows.Forms.ListBox();
      ((System.ComponentModel.ISupportInitialize)(this.meDate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.meTime)).BeginInit();
      this.SuspendLayout();
      // 
      // meDate
      // 
      this.meDate.Location = new System.Drawing.Point(24, 32);
      this.meDate.Name = "meDate";
      this.meDate.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("meDate.OcxState")));
      this.meDate.Size = new System.Drawing.Size(192, 24);
      this.meDate.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(152, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Enter Date";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(24, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(152, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "Enter Military Time";
      // 
      // meTime
      // 
      this.meTime.Location = new System.Drawing.Point(24, 96);
      this.meTime.Name = "meTime";
      this.meTime.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("meTime.OcxState")));
      this.meTime.Size = new System.Drawing.Size(192, 24);
      this.meTime.TabIndex = 1;
      // 
      // L
      // 
      this.L.Location = new System.Drawing.Point(40, 160);
      this.L.Name = "L";
      this.L.Size = new System.Drawing.Size(168, 121);
      this.L.TabIndex = 4;
      this.L.TabStop = false;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(248, 309);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.L,
                                                                  this.label2,
                                                                  this.meTime,
                                                                  this.label1,
                                                                  this.meDate});
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.meDate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.meTime)).EndInit();
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
      meDate.ValidationError += 
                  new MaskEdBoxEvents_ValidationErrorEventHandler(DateErr);
      meDate.Enter += new EventHandler(DateEnter);
      meDate.Leave += new EventHandler(DateLeave);

      meTime.ValidationError += 
                  new MaskEdBoxEvents_ValidationErrorEventHandler(TimeErr);
      meTime.Enter += new EventHandler(TimeEnter);
      meTime.Leave += new EventHandler(TimeLeave);

    }

    #region Masked Edit events

    private void DateEnter(object sender, EventArgs e)
    {
      L.Items.Add("Date got focus");
    }

    private void DateLeave(object sender, EventArgs e)
    {
      L.Items.Add("Date left");
      L.Items.Add("Date Text = " + meDate.Text);
    }

    private void DateErr(object sender, MaskEdBoxEvents_ValidationErrorEvent e)
    {
      L.Items.Add("Date validation error");
    }

    private void TimeEnter(object sender, EventArgs e)
    {
      L.Items.Add("Time got focus");
    }

    private void TimeLeave(object sender, EventArgs e)
    {
      L.Items.Add("Time left");
      L.Items.Add("Time Text = " + meTime.Text);
   }

    private void TimeErr(object sender, MaskEdBoxEvents_ValidationErrorEvent e)
    {
      L.Items.Add("Time validation error");
    }

    #endregion

  }
}
