
using System;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Keys_c
{
  /// <summary>
  /// Shows interaction of key events
  /// </summary>
	public class frmKeys : System.Windows.Forms.Form
	{
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblDownTime;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label lblUpTime;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label lblPress;
    private System.Windows.Forms.Label lblPressTime;
    private System.Windows.Forms.Label lblUpMod;
    private System.Windows.Forms.Label lblUpValue;
    private System.Windows.Forms.Label lblUpData;
    private System.Windows.Forms.Label lblUpCode;
    private System.Windows.Forms.Label lblDownMod;
    private System.Windows.Forms.Label lblDownValue;
    private System.Windows.Forms.Label lblDownData;
    private System.Windows.Forms.Label lblDownCode;

    private System.ComponentModel.Container components = null;

    public frmKeys()
    {
      InitializeComponent();

      //This is only valid if the form has focus
      //The form only has focus if there are no visible controls on it.
      this.KeyDown  += new KeyEventHandler(this.MyKeyDown);
      this.KeyPress += new KeyPressEventHandler(this.MyKeyPress);
      this.KeyUp    += new KeyEventHandler(this.MyKeyUp);

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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
      this.lblDownMod = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lblDownValue = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblDownData = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblDownCode = new System.Windows.Forms.Label();
      this.lblDownTime = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.lblUpTime = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.lblUpMod = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.lblUpValue = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.lblUpData = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.lblUpCode = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.lblPress = new System.Windows.Forms.Label();
      this.lblPressTime = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.lblDownTime,
                                                                            this.label7,
                                                                            this.lblDownMod,
                                                                            this.label5,
                                                                            this.lblDownValue,
                                                                            this.label3,
                                                                            this.lblDownData,
                                                                            this.label2,
                                                                            this.lblDownCode});
      this.groupBox1.Location = new System.Drawing.Point(8, 8);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(336, 160);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "KeyDown event";
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(12, 96);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(104, 16);
      this.label7.TabIndex = 15;
      this.label7.Text = "Key Modifiers";
      // 
      // lblDownMod
      // 
      this.lblDownMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDownMod.Location = new System.Drawing.Point(124, 96);
      this.lblDownMod.Name = "lblDownMod";
      this.lblDownMod.Size = new System.Drawing.Size(180, 16);
      this.lblDownMod.TabIndex = 14;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(12, 72);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(104, 16);
      this.label5.TabIndex = 13;
      this.label5.Text = "Key Value";
      // 
      // lblDownValue
      // 
      this.lblDownValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDownValue.Location = new System.Drawing.Point(124, 72);
      this.lblDownValue.Name = "lblDownValue";
      this.lblDownValue.Size = new System.Drawing.Size(180, 16);
      this.lblDownValue.TabIndex = 12;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(12, 48);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(104, 16);
      this.label3.TabIndex = 11;
      this.label3.Text = "Key Data";
      // 
      // lblDownData
      // 
      this.lblDownData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDownData.Location = new System.Drawing.Point(124, 48);
      this.lblDownData.Name = "lblDownData";
      this.lblDownData.Size = new System.Drawing.Size(180, 16);
      this.lblDownData.TabIndex = 10;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(12, 24);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(104, 16);
      this.label2.TabIndex = 9;
      this.label2.Text = "Key Code";
      // 
      // lblDownCode
      // 
      this.lblDownCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDownCode.Location = new System.Drawing.Point(124, 24);
      this.lblDownCode.Name = "lblDownCode";
      this.lblDownCode.Size = new System.Drawing.Size(180, 16);
      this.lblDownCode.TabIndex = 8;
      // 
      // lblDownTime
      // 
      this.lblDownTime.BackColor = System.Drawing.Color.Linen;
      this.lblDownTime.Location = new System.Drawing.Point(40, 136);
      this.lblDownTime.Name = "lblDownTime";
      this.lblDownTime.Size = new System.Drawing.Size(248, 16);
      this.lblDownTime.TabIndex = 16;
      this.lblDownTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.lblUpTime,
                                                                            this.label10,
                                                                            this.lblUpMod,
                                                                            this.label12,
                                                                            this.lblUpValue,
                                                                            this.label14,
                                                                            this.lblUpData,
                                                                            this.label16,
                                                                            this.lblUpCode});
      this.groupBox2.Location = new System.Drawing.Point(8, 248);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(336, 160);
      this.groupBox2.TabIndex = 9;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "KeyUp event";
      // 
      // lblUpTime
      // 
      this.lblUpTime.BackColor = System.Drawing.Color.Linen;
      this.lblUpTime.Location = new System.Drawing.Point(40, 136);
      this.lblUpTime.Name = "lblUpTime";
      this.lblUpTime.Size = new System.Drawing.Size(248, 16);
      this.lblUpTime.TabIndex = 16;
      this.lblUpTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(12, 96);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(104, 16);
      this.label10.TabIndex = 15;
      this.label10.Text = "Key Modifiers";
      // 
      // lblUpMod
      // 
      this.lblUpMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblUpMod.Location = new System.Drawing.Point(124, 96);
      this.lblUpMod.Name = "lblUpMod";
      this.lblUpMod.Size = new System.Drawing.Size(180, 16);
      this.lblUpMod.TabIndex = 14;
      // 
      // label12
      // 
      this.label12.Location = new System.Drawing.Point(12, 72);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(104, 16);
      this.label12.TabIndex = 13;
      this.label12.Text = "Key Value";
      // 
      // lblUpValue
      // 
      this.lblUpValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblUpValue.Location = new System.Drawing.Point(124, 72);
      this.lblUpValue.Name = "lblUpValue";
      this.lblUpValue.Size = new System.Drawing.Size(180, 16);
      this.lblUpValue.TabIndex = 12;
      // 
      // label14
      // 
      this.label14.Location = new System.Drawing.Point(12, 48);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(104, 16);
      this.label14.TabIndex = 11;
      this.label14.Text = "Key Data";
      // 
      // lblUpData
      // 
      this.lblUpData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblUpData.Location = new System.Drawing.Point(124, 48);
      this.lblUpData.Name = "lblUpData";
      this.lblUpData.Size = new System.Drawing.Size(180, 16);
      this.lblUpData.TabIndex = 10;
      // 
      // label16
      // 
      this.label16.Location = new System.Drawing.Point(12, 24);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(104, 16);
      this.label16.TabIndex = 9;
      this.label16.Text = "Key Code";
      // 
      // lblUpCode
      // 
      this.lblUpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblUpCode.Location = new System.Drawing.Point(124, 24);
      this.lblUpCode.Name = "lblUpCode";
      this.lblUpCode.Size = new System.Drawing.Size(180, 16);
      this.lblUpCode.TabIndex = 8;
      // 
      // label9
      // 
      this.label9.Location = new System.Drawing.Point(24, 184);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(104, 16);
      this.label9.TabIndex = 17;
      this.label9.Text = "Key Press";
      // 
      // lblPress
      // 
      this.lblPress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblPress.Location = new System.Drawing.Point(136, 184);
      this.lblPress.Name = "lblPress";
      this.lblPress.Size = new System.Drawing.Size(180, 16);
      this.lblPress.TabIndex = 16;
      // 
      // lblPressTime
      // 
      this.lblPressTime.BackColor = System.Drawing.Color.Linen;
      this.lblPressTime.Location = new System.Drawing.Point(48, 208);
      this.lblPressTime.Name = "lblPressTime";
      this.lblPressTime.Size = new System.Drawing.Size(248, 16);
      this.lblPressTime.TabIndex = 18;
      this.lblPressTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // frmKeys
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(386, 439);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lblPressTime,
                                                                  this.label9,
                                                                  this.lblPress,
                                                                  this.groupBox2,
                                                                  this.groupBox1});
      this.Enabled = false;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmKeys";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "KeyPresses";
      this.Load += new System.EventHandler(this.frmKeys_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion


    [STAThread]
    static void Main() 
    {
      Application.Run(new frmKeys());
    }

    private void frmKeys_Load(object sender, System.EventArgs e)
    {
      this.OnKeyDown(null);
    }

    #region events


    private void MyKeyDown(object sender, KeyEventArgs e)
    {

      Debug.Assert(e != null, "BoneHead call");

      lblDownCode.Text = e.KeyCode.ToString();
      lblDownData.Text = e.KeyData.ToString();
      lblDownValue.Text = e.KeyValue.ToString();
      lblDownMod.Text = e.Modifiers.ToString();

      lblDownTime.Text = DateTime.Now.Ticks.ToString();
      Thread.Sleep(2);
    }

    private void MyKeyPress(object sender, KeyPressEventArgs e)
    {

      lblPress.Text = e.KeyChar.ToString();
      lblPressTime.Text = DateTime.Now.Ticks.ToString();
      Thread.Sleep(2);

    }

    private void MyKeyUp(object sender, KeyEventArgs e)
    {
      lblUpCode.Text = e.KeyCode.ToString();
      lblUpData.Text = e.KeyData.ToString();
      lblUpValue.Text = e.KeyValue.ToString();
      lblUpMod.Text = e.Modifiers.ToString();

      lblUpTime.Text = DateTime.Now.Ticks.ToString();
      Thread.Sleep(2);

    }

    #endregion

  }
}
