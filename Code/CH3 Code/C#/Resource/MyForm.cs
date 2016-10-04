using System;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Resource
{
  /// <summary>
  /// Multilingual expense form chapter 3
  /// </summary>
	public class Multilingual : System.Windows.Forms.Form
	{
    #region class local variables

    private enum LANG
    {
      LANG_USA,
      LANG_FRA
    };

    float cash  = 0.0f;
    float miles = 0.0f;

    #endregion

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.DateTimePicker dtBirth;
    private System.Windows.Forms.Label lblDOB;
    private System.Windows.Forms.TextBox txtAddr1;
    private System.Windows.Forms.Label lblAddr1;
    private System.Windows.Forms.TextBox txtAddr2;
    private System.Windows.Forms.Label lblAddr2;
    private System.Windows.Forms.TextBox txtAddr3;
    private System.Windows.Forms.Label lblAddr3;
    private System.Windows.Forms.Label lblStart;
    private System.Windows.Forms.DateTimePicker dtStart;
    private System.Windows.Forms.DateTimePicker dtEnd;
    private System.Windows.Forms.TextBox txtMiles;
    private System.Windows.Forms.Label lblMiles;
    private System.Windows.Forms.Label lblOwed;
    private System.Windows.Forms.Label lblCash;
    private System.Windows.Forms.PictureBox picUSA;
    private System.Windows.Forms.PictureBox picFRA;
    private System.Windows.Forms.GroupBox gb1;
    private System.Windows.Forms.Label lblEnd;
    private System.Windows.Forms.Label label1;
		private System.ComponentModel.Container components = null;

		public Multilingual()
		{
			InitializeComponent();

      txtMiles.KeyPress += new KeyPressEventHandler(this.InputValidator);
      txtMiles.KeyUp    += new KeyEventHandler(this.CalculateCash);

      picUSA.BackColor  = Color.Transparent;
      picUSA.SizeMode   = PictureBoxSizeMode.StretchImage;
      picUSA.Image      = Image.FromFile("usa.ico");
      picUSA.Click      += new EventHandler(this.NewLanguage);

      picFRA.BackColor  = Color.Transparent;
      picFRA.SizeMode   = PictureBoxSizeMode.StretchImage;
      picFRA.Image      = Image.FromFile("fra.ico");
      picFRA.Click      += new EventHandler(this.NewLanguage);

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
      this.lblName = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.dtBirth = new System.Windows.Forms.DateTimePicker();
      this.lblDOB = new System.Windows.Forms.Label();
      this.gb1 = new System.Windows.Forms.GroupBox();
      this.txtAddr3 = new System.Windows.Forms.TextBox();
      this.lblAddr3 = new System.Windows.Forms.Label();
      this.txtAddr2 = new System.Windows.Forms.TextBox();
      this.lblAddr2 = new System.Windows.Forms.Label();
      this.txtAddr1 = new System.Windows.Forms.TextBox();
      this.lblAddr1 = new System.Windows.Forms.Label();
      this.lblStart = new System.Windows.Forms.Label();
      this.dtStart = new System.Windows.Forms.DateTimePicker();
      this.lblEnd = new System.Windows.Forms.Label();
      this.dtEnd = new System.Windows.Forms.DateTimePicker();
      this.txtMiles = new System.Windows.Forms.TextBox();
      this.lblMiles = new System.Windows.Forms.Label();
      this.lblOwed = new System.Windows.Forms.Label();
      this.lblCash = new System.Windows.Forms.Label();
      this.picUSA = new System.Windows.Forms.PictureBox();
      this.picFRA = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.gb1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblName
      // 
      this.lblName.Location = new System.Drawing.Point(80, 24);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(168, 16);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Name";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(80, 40);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(176, 20);
      this.txtName.TabIndex = 1;
      this.txtName.Text = "";
      // 
      // dtBirth
      // 
      this.dtBirth.Location = new System.Drawing.Point(320, 40);
      this.dtBirth.Name = "dtBirth";
      this.dtBirth.Size = new System.Drawing.Size(168, 20);
      this.dtBirth.TabIndex = 2;
      // 
      // lblDOB
      // 
      this.lblDOB.Location = new System.Drawing.Point(320, 24);
      this.lblDOB.Name = "lblDOB";
      this.lblDOB.Size = new System.Drawing.Size(160, 16);
      this.lblDOB.TabIndex = 3;
      this.lblDOB.Text = "Date of Birth";
      // 
      // gb1
      // 
      this.gb1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.txtAddr3,
                                                                      this.lblAddr3,
                                                                      this.txtAddr2,
                                                                      this.lblAddr2,
                                                                      this.txtAddr1,
                                                                      this.lblAddr1});
      this.gb1.Location = new System.Drawing.Point(16, 112);
      this.gb1.Name = "gb1";
      this.gb1.Size = new System.Drawing.Size(456, 120);
      this.gb1.TabIndex = 4;
      this.gb1.TabStop = false;
      this.gb1.Text = "Address";
      // 
      // txtAddr3
      // 
      this.txtAddr3.Location = new System.Drawing.Point(112, 72);
      this.txtAddr3.Name = "txtAddr3";
      this.txtAddr3.Size = new System.Drawing.Size(304, 20);
      this.txtAddr3.TabIndex = 7;
      this.txtAddr3.Text = "";
      // 
      // lblAddr3
      // 
      this.lblAddr3.Location = new System.Drawing.Point(16, 72);
      this.lblAddr3.Name = "lblAddr3";
      this.lblAddr3.Size = new System.Drawing.Size(96, 16);
      this.lblAddr3.TabIndex = 6;
      this.lblAddr3.Text = "Address 3";
      this.lblAddr3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // txtAddr2
      // 
      this.txtAddr2.Location = new System.Drawing.Point(112, 48);
      this.txtAddr2.Name = "txtAddr2";
      this.txtAddr2.Size = new System.Drawing.Size(304, 20);
      this.txtAddr2.TabIndex = 5;
      this.txtAddr2.Text = "";
      // 
      // lblAddr2
      // 
      this.lblAddr2.Location = new System.Drawing.Point(16, 48);
      this.lblAddr2.Name = "lblAddr2";
      this.lblAddr2.Size = new System.Drawing.Size(96, 16);
      this.lblAddr2.TabIndex = 4;
      this.lblAddr2.Text = "Address 2";
      this.lblAddr2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // txtAddr1
      // 
      this.txtAddr1.Location = new System.Drawing.Point(112, 24);
      this.txtAddr1.Name = "txtAddr1";
      this.txtAddr1.Size = new System.Drawing.Size(304, 20);
      this.txtAddr1.TabIndex = 3;
      this.txtAddr1.Text = "";
      // 
      // lblAddr1
      // 
      this.lblAddr1.Location = new System.Drawing.Point(16, 24);
      this.lblAddr1.Name = "lblAddr1";
      this.lblAddr1.Size = new System.Drawing.Size(96, 16);
      this.lblAddr1.TabIndex = 2;
      this.lblAddr1.Text = "Address 1";
      this.lblAddr1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // lblStart
      // 
      this.lblStart.Location = new System.Drawing.Point(16, 248);
      this.lblStart.Name = "lblStart";
      this.lblStart.Size = new System.Drawing.Size(160, 16);
      this.lblStart.TabIndex = 6;
      this.lblStart.Text = "Travel start time";
      // 
      // dtStart
      // 
      this.dtStart.Location = new System.Drawing.Point(16, 264);
      this.dtStart.Name = "dtStart";
      this.dtStart.Size = new System.Drawing.Size(168, 20);
      this.dtStart.TabIndex = 5;
      // 
      // lblEnd
      // 
      this.lblEnd.Location = new System.Drawing.Point(240, 248);
      this.lblEnd.Name = "lblEnd";
      this.lblEnd.Size = new System.Drawing.Size(160, 16);
      this.lblEnd.TabIndex = 8;
      this.lblEnd.Text = "Travel end time";
      // 
      // dtEnd
      // 
      this.dtEnd.Location = new System.Drawing.Point(240, 264);
      this.dtEnd.Name = "dtEnd";
      this.dtEnd.Size = new System.Drawing.Size(168, 20);
      this.dtEnd.TabIndex = 7;
      // 
      // txtMiles
      // 
      this.txtMiles.Location = new System.Drawing.Point(16, 320);
      this.txtMiles.Name = "txtMiles";
      this.txtMiles.Size = new System.Drawing.Size(176, 20);
      this.txtMiles.TabIndex = 10;
      this.txtMiles.Text = "";
      // 
      // lblMiles
      // 
      this.lblMiles.Location = new System.Drawing.Point(16, 304);
      this.lblMiles.Name = "lblMiles";
      this.lblMiles.Size = new System.Drawing.Size(168, 16);
      this.lblMiles.TabIndex = 9;
      this.lblMiles.Text = "Miles Traveled";
      // 
      // lblOwed
      // 
      this.lblOwed.Location = new System.Drawing.Point(288, 304);
      this.lblOwed.Name = "lblOwed";
      this.lblOwed.Size = new System.Drawing.Size(168, 16);
      this.lblOwed.TabIndex = 11;
      this.lblOwed.Text = "Amount Owed";
      // 
      // lblCash
      // 
      this.lblCash.BackColor = System.Drawing.Color.Linen;
      this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblCash.Location = new System.Drawing.Point(288, 320);
      this.lblCash.Name = "lblCash";
      this.lblCash.Size = new System.Drawing.Size(56, 24);
      this.lblCash.TabIndex = 12;
      // 
      // picUSA
      // 
      this.picUSA.BackColor = System.Drawing.Color.Linen;
      this.picUSA.Location = new System.Drawing.Point(16, 24);
      this.picUSA.Name = "picUSA";
      this.picUSA.Size = new System.Drawing.Size(32, 32);
      this.picUSA.TabIndex = 13;
      this.picUSA.TabStop = false;
      // 
      // picFRA
      // 
      this.picFRA.BackColor = System.Drawing.Color.Linen;
      this.picFRA.Location = new System.Drawing.Point(16, 64);
      this.picFRA.Name = "picFRA";
      this.picFRA.Size = new System.Drawing.Size(32, 32);
      this.picFRA.TabIndex = 14;
      this.picFRA.TabStop = false;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label1.Location = new System.Drawing.Point(208, 320);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 24);
      this.label1.TabIndex = 15;
      this.label1.Text = "* .35 =";
      // 
      // Multilingual
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(504, 368);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.label1,
                                                                  this.picFRA,
                                                                  this.picUSA,
                                                                  this.lblCash,
                                                                  this.lblOwed,
                                                                  this.txtMiles,
                                                                  this.lblMiles,
                                                                  this.lblEnd,
                                                                  this.dtEnd,
                                                                  this.lblStart,
                                                                  this.dtStart,
                                                                  this.gb1,
                                                                  this.lblDOB,
                                                                  this.dtBirth,
                                                                  this.txtName,
                                                                  this.lblName});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Multilingual";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Car Mileage Expense";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.gb1.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    [STAThread]
    static void Main() 
    {
      Application.Run(new Multilingual());
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
      InitStrings();
    }

    private void InitStrings()
    {
      ResourceSet rs;
      
      if(Thread.CurrentThread.CurrentCulture.Name == "fr-FR")
        rs = new ResourceSet("French.resources");
      else
        rs = new ResourceSet("English.resources");

      this.Text       = rs.GetString("CAPTION");
      lblName.Text    = rs.GetString("NAME");
      lblDOB.Text     = rs.GetString("DOB");
      gb1.Text        = rs.GetString("ADDR");
      lblAddr1.Text   = rs.GetString("ADDR1");
      lblAddr2.Text   = rs.GetString("ADDR2");
      lblAddr3.Text   = rs.GetString("ADDR3");
      lblStart.Text   = rs.GetString("STARTTIME");
      lblEnd.Text     = rs.GetString("ENDTIME");
      lblMiles.Text   = rs.GetString("MILES");
      lblOwed.Text    = rs.GetString("CASHBACK");

      rs.Close();
      rs.Dispose();

      //Adjust the date and time displayed in the pickers
      DateTimeFormatInfo dtf = new DateTimeFormatInfo();
      dtf = Thread.CurrentThread.CurrentCulture.DateTimeFormat;

      dtBirth.CustomFormat = dtf.ShortDatePattern;
      dtBirth.Format = DateTimePickerFormat.Custom;

      dtStart.CustomFormat = dtf.ShortTimePattern;
      dtStart.Format = DateTimePickerFormat.Custom;
      dtStart.ShowUpDown = true;

      dtEnd.CustomFormat = dtf.ShortTimePattern;
      dtEnd.Format = DateTimePickerFormat.Custom;
      dtEnd.ShowUpDown = true;

      lblCash.Text = cash.ToString("N", Thread.CurrentThread.CurrentCulture);
      txtMiles.Text = miles.ToString("N", Thread.CurrentThread.CurrentCulture);

      this.Refresh();
    }

    #region events


    private void NewLanguage(object sender, EventArgs e)
    {
      LANG l = LANG.LANG_USA;
      if (sender is PictureBox)
        if (sender == picFRA)
          l = LANG.LANG_FRA;

      if (l == LANG.LANG_FRA)
      {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
      }
      else
      {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
      }

      InitStrings();
    }


    private void InputValidator(object sender, KeyPressEventArgs e)
    {
      TextBox t;
      NumberFormatInfo nf = Thread.CurrentThread.CurrentCulture.NumberFormat;

      if(sender is TextBox)
      {
        t = (TextBox)sender;
        if (t == txtMiles)
        {
          //Allow only 0-9 and decimal separator
          if(Char.IsNumber(e.KeyChar))
            e.Handled = false;
          else if(e.KeyChar == Convert.ToChar(nf.NumberDecimalSeparator))
          {
            if(t.Text.IndexOf(Convert.ToChar(nf.NumberDecimalSeparator)) >=0)
              e.Handled = true;
            else
              e.Handled = false;
          }
          else
            e.Handled = true;
        }
      }
    }

    private void CalculateCash(object sender, KeyEventArgs e)
    {
      TextBox t;
      if(sender is TextBox)
      {
        t = (TextBox)sender;
        if (t == txtMiles)
        {
          try
          {
            miles = float.Parse(txtMiles.Text);
            cash = miles * 0.35f;
            lblCash.Text=cash.ToString("N",Thread.CurrentThread.CurrentCulture);
          }
          catch 
          {
            lblCash.Text = "";
          }
        }
      }
    }

    #endregion

  }
}
