using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SerialPort
{
  /// <summary>
  /// For example purposes this is the list of possibilities.
  /// 9600,7,o,1
  /// 9600,7,e,2
  /// 9600,8,n,1
  /// 4800,6,m,1
  /// 4800,7,s,1
  /// 4800,7,s,2
  /// 2400,5,o,1
  /// 2400,5,e,1
  /// 2400,5,e,1.5
  /// 2400,6,o,1
  /// Any type of flow control
  /// </summary>


  public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbSpeed;
    private System.Windows.Forms.ComboBox cmbLen;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cmbParity;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cmbStop;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cmbFlow;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button cmdClose;

    private System.ComponentModel.Container components = null;

		public Form1()
		{

      InitializeComponent();

      this.StartPosition = FormStartPosition.CenterScreen;

      //Handle the click events for each combo box
      cmbSpeed.SelectedIndexChanged  += new EventHandler(this.Speed);
      cmbLen.SelectedIndexChanged    += new EventHandler(this.DataLen);
      cmbParity.SelectedIndexChanged += new EventHandler(this.Parity);
      cmdClose.Click                 += new EventHandler(this.CloseMe);

      cmbSpeed.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbSpeed.Items.Add("9,600");
      cmbSpeed.Items.Add("4,800");
      cmbSpeed.Items.Add("2,400");
      cmbSpeed.SelectedIndex=0;

      cmbFlow.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbFlow.Items.Add("NONE");
      cmbFlow.Items.Add("XON/XOFF");
      cmbFlow.Items.Add("HARDWARE");
      cmbFlow.SelectedIndex = 0;

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
      this.label1 = new System.Windows.Forms.Label();
      this.cmbSpeed = new System.Windows.Forms.ComboBox();
      this.cmbLen = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cmbParity = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cmbStop = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.cmbFlow = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cmdClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(144, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Speed";
      // 
      // cmbSpeed
      // 
      this.cmbSpeed.Location = new System.Drawing.Point(24, 40);
      this.cmbSpeed.Name = "cmbSpeed";
      this.cmbSpeed.Size = new System.Drawing.Size(144, 21);
      this.cmbSpeed.TabIndex = 1;
      // 
      // cmbLen
      // 
      this.cmbLen.Location = new System.Drawing.Point(24, 88);
      this.cmbLen.Name = "cmbLen";
      this.cmbLen.Size = new System.Drawing.Size(144, 21);
      this.cmbLen.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(24, 72);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(144, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Data Length";
      // 
      // cmbParity
      // 
      this.cmbParity.Location = new System.Drawing.Point(24, 144);
      this.cmbParity.Name = "cmbParity";
      this.cmbParity.Size = new System.Drawing.Size(144, 21);
      this.cmbParity.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(24, 128);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(144, 16);
      this.label3.TabIndex = 4;
      this.label3.Text = "Parity";
      // 
      // cmbStop
      // 
      this.cmbStop.Location = new System.Drawing.Point(24, 200);
      this.cmbStop.Name = "cmbStop";
      this.cmbStop.Size = new System.Drawing.Size(144, 21);
      this.cmbStop.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(24, 184);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(144, 16);
      this.label4.TabIndex = 6;
      this.label4.Text = "Stop Bits";
      // 
      // cmbFlow
      // 
      this.cmbFlow.Location = new System.Drawing.Point(24, 256);
      this.cmbFlow.Name = "cmbFlow";
      this.cmbFlow.Size = new System.Drawing.Size(144, 21);
      this.cmbFlow.TabIndex = 9;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(24, 240);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(144, 16);
      this.label5.TabIndex = 8;
      this.label5.Text = "Flow Control";
      // 
      // cmdClose
      // 
      this.cmdClose.Location = new System.Drawing.Point(104, 312);
      this.cmdClose.Name = "cmdClose";
      this.cmdClose.Size = new System.Drawing.Size(64, 24);
      this.cmdClose.TabIndex = 10;
      this.cmdClose.Text = "Close";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(192, 350);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdClose,
                                                                  this.cmbFlow,
                                                                  this.label5,
                                                                  this.cmbStop,
                                                                  this.label4,
                                                                  this.cmbParity,
                                                                  this.label3,
                                                                  this.cmbLen,
                                                                  this.label2,
                                                                  this.cmbSpeed,
                                                                  this.label1});
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Terminal Setup";
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

    #region Click events

    private void Speed(object sender, EventArgs e)
    {
      switch (cmbSpeed.Text)
      {
        case "9,600":
          cmbLen.Items.Clear();
          cmbLen.Items.Add("7 Bits");
          cmbLen.Items.Add("8 Bits");
          break;
        case "4,800":
          cmbLen.Items.Clear();
          cmbLen.Items.Add("6 Bits");
          cmbLen.Items.Add("7 Bits");
          break;
        case "2,400":
          cmbLen.Items.Clear();
          cmbLen.Items.Add("5 Bits");
          cmbLen.Items.Add("6 Bits");
          break;
        case "1,200":
          cmbLen.Items.Clear();
          cmbLen.Items.Add("8 Bits");
          break;
      }
      cmbLen.SelectedIndex = 0;
    }

    private void DataLen(object sender, EventArgs e)
    {
      switch (cmbLen.Text)
      {
        case "5 Bits":
          if (cmbSpeed.Text == "2,400")
          {
            cmbParity.Items.Clear();
            cmbParity.Items.Add("ODD");
            cmbParity.Items.Add("EVEN");
          }
          break;
        case "6 Bits":
          if (cmbSpeed.Text == "4,800")
          {
            cmbParity.Items.Clear();
            cmbParity.Items.Add("MARK");
          }
          if (cmbSpeed.Text == "2,400")
          {
            cmbParity.Items.Clear();
            cmbParity.Items.Add("ODD");
          }
          break;
        case "7 Bits":
          if (cmbSpeed.Text == "9,600")
          {
            cmbParity.Items.Clear();
            cmbParity.Items.Add("ODD");
            cmbParity.Items.Add("EVEN");
          }
          if (cmbSpeed.Text == "4,800")
          {
            cmbParity.Items.Clear();
            cmbParity.Items.Add("SPACE");
          }
          break;
        case "8 Bits":
          if (cmbSpeed.Text == "9,600")
          {
            cmbParity.Items.Clear();
            cmbParity.Items.Add("NONE");
          }
          break;
      }
      cmbParity.SelectedIndex = 0;
    }

    private void Parity(object sender, EventArgs e)
    {
      switch (cmbParity.Text)
      {
        case "NONE":
          if (cmbLen.Text == "8 Bits")
          {
            cmbStop.Items.Clear();
            cmbStop.Items.Add("1");
          }
          break;
        case "ODD":
          if (cmbLen.Text == "5 Bits")
          {
            cmbStop.Items.Clear();
            cmbStop.Items.Add("1");
          }
          if (cmbLen.Text == "6 Bits")
          {
            cmbStop.Items.Clear();
            cmbStop.Items.Add("1");
          }
          if (cmbLen.Text == "7 Bits")
          {
            cmbStop.Items.Clear();
            cmbStop.Items.Add("1");
          }
          break;
        case "EVEN":
          if (cmbLen.Text == "5 Bits")
          {
            cmbStop.Items.Clear();
            cmbStop.Items.Add("1");
            cmbStop.Items.Add("1.5");
          }
          if (cmbLen.Text == "7 Bits")
          {
            cmbStop.Items.Clear();
            cmbStop.Items.Add("2");
          }
          break;
        case "SPACE":
          if (cmbLen.Text == "7 Bits")
          {
            cmbStop.Items.Clear();
            cmbStop.Items.Add("1");
            cmbStop.Items.Add("2");
          }
          break;
        case "MARK":
          if (cmbLen.Text == "6 Bits")
          {
            cmbStop.Items.Clear();
            cmbStop.Items.Add("1");
          }
          break;
      }
      cmbStop.SelectedIndex = 0;
    }

    private void CloseMe(object sender, EventArgs e)
    {
      this.Close();
    }

    #endregion

	}
}
