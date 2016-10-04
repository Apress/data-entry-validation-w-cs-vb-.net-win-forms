using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataBound_c
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.TabControl tc;
    private System.Windows.Forms.TabPage t1;
    private System.Windows.Forms.TabPage t2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtCab;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button cmdQuit;
    private System.Windows.Forms.TextBox txtRed;
    private System.Windows.Forms.TextBox txtTotRed;
    private System.Windows.Forms.TextBox txtWhite;
    private System.Windows.Forms.TextBox txtChablis;
    private System.Windows.Forms.TextBox txtPino;
    private System.Windows.Forms.TextBox txtChardonay;
    private System.Windows.Forms.TextBox txtTotWhite;
    private System.Windows.Forms.TextBox txtShiraz;
    private System.Windows.Forms.TextBox txtMerlot;

    private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      cmdQuit.Click += new EventHandler(this.CloseMe);

      //This is the tab for the red wines
      txtCab.CausesValidation = true;
      txtCab.Validating += new CancelEventHandler(this.ValidateRed);
      txtCab.KeyPress   += new KeyPressEventHandler(this.InputValidator);
      txtCab.TextChanged += new EventHandler(this.Pastings);

      txtMerlot.CausesValidation = true;
      txtMerlot.Validating += new CancelEventHandler(this.ValidateRed);
      txtMerlot.KeyPress   += new KeyPressEventHandler(this.InputValidator);

      txtShiraz.CausesValidation = true;
      txtShiraz.Validating += new CancelEventHandler(this.ValidateRed);
      txtShiraz.KeyPress   += new KeyPressEventHandler(this.InputValidator);

      txtCab.Text = "0";
      txtMerlot.Text = "0";
      txtShiraz.Text = "0";

      //This is the tab for the white wines
      txtChardonay.CausesValidation = true;
      txtChardonay.Validating += new CancelEventHandler(this.ValidateWhite);
      txtChardonay.KeyPress   += new KeyPressEventHandler(this.InputValidator);

      txtPino.CausesValidation = true;
      txtPino.Validating    += new CancelEventHandler(this.ValidateWhite);
      txtPino.KeyPress += new KeyPressEventHandler(this.InputValidator);

      txtChablis.CausesValidation = true;
      txtChablis.Validating += new CancelEventHandler(this.ValidateWhite);
      txtChablis.KeyPress += new KeyPressEventHandler(this.InputValidator);

      txtChardonay.Text = "0";
      txtPino.Text = "0";
      txtChablis.Text = "0";

      //Do the data binding summaries
      txtTotRed.DataBindings.Add("Text",txtRed,"Text");
      txtTotWhite.DataBindings.Add("Text",txtWhite,"Text");

      //Call the delegate to start totals
      ValidateRed(new object(), new CancelEventArgs());
      ValidateWhite(new object(), new CancelEventArgs());

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
      this.tc = new System.Windows.Forms.TabControl();
      this.t1 = new System.Windows.Forms.TabPage();
      this.txtRed = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txtShiraz = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtMerlot = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtCab = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.t2 = new System.Windows.Forms.TabPage();
      this.txtWhite = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtChablis = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtPino = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtChardonay = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtTotRed = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.txtTotWhite = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.cmdQuit = new System.Windows.Forms.Button();
      this.tc.SuspendLayout();
      this.t1.SuspendLayout();
      this.t2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tc
      // 
      this.tc.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                     this.t1,
                                                                     this.t2});
      this.tc.Location = new System.Drawing.Point(16, 16);
      this.tc.Name = "tc";
      this.tc.SelectedIndex = 0;
      this.tc.Size = new System.Drawing.Size(232, 224);
      this.tc.TabIndex = 0;
      // 
      // t1
      // 
      this.t1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                     this.txtRed,
                                                                     this.label7,
                                                                     this.txtShiraz,
                                                                     this.label3,
                                                                     this.txtMerlot,
                                                                     this.label2,
                                                                     this.txtCab,
                                                                     this.label1});
      this.t1.Location = new System.Drawing.Point(4, 22);
      this.t1.Name = "t1";
      this.t1.Size = new System.Drawing.Size(224, 198);
      this.t1.TabIndex = 0;
      this.t1.Text = "Red Wine";
      // 
      // txtRed
      // 
      this.txtRed.Location = new System.Drawing.Point(128, 152);
      this.txtRed.Name = "txtRed";
      this.txtRed.Size = new System.Drawing.Size(64, 20);
      this.txtRed.TabIndex = 7;
      this.txtRed.Text = "";
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(128, 136);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(88, 16);
      this.label7.TabIndex = 6;
      this.label7.Text = "Total Red";
      // 
      // txtShiraz
      // 
      this.txtShiraz.Location = new System.Drawing.Point(24, 152);
      this.txtShiraz.Name = "txtShiraz";
      this.txtShiraz.Size = new System.Drawing.Size(64, 20);
      this.txtShiraz.TabIndex = 5;
      this.txtShiraz.Text = "";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(24, 136);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(88, 16);
      this.label3.TabIndex = 4;
      this.label3.Text = "Shiraz count";
      // 
      // txtMerlot
      // 
      this.txtMerlot.Location = new System.Drawing.Point(24, 96);
      this.txtMerlot.Name = "txtMerlot";
      this.txtMerlot.Size = new System.Drawing.Size(64, 20);
      this.txtMerlot.TabIndex = 3;
      this.txtMerlot.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(24, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Merlot count";
      // 
      // txtCab
      // 
      this.txtCab.Location = new System.Drawing.Point(24, 40);
      this.txtCab.Name = "txtCab";
      this.txtCab.Size = new System.Drawing.Size(64, 20);
      this.txtCab.TabIndex = 1;
      this.txtCab.Text = "";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(88, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Cabernet count";
      // 
      // t2
      // 
      this.t2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                     this.txtWhite,
                                                                     this.label8,
                                                                     this.txtChablis,
                                                                     this.label4,
                                                                     this.txtPino,
                                                                     this.label5,
                                                                     this.txtChardonay,
                                                                     this.label6});
      this.t2.Location = new System.Drawing.Point(4, 22);
      this.t2.Name = "t2";
      this.t2.Size = new System.Drawing.Size(224, 198);
      this.t2.TabIndex = 1;
      this.t2.Text = "White wine";
      // 
      // txtWhite
      // 
      this.txtWhite.Location = new System.Drawing.Point(128, 152);
      this.txtWhite.Name = "txtWhite";
      this.txtWhite.Size = new System.Drawing.Size(64, 20);
      this.txtWhite.TabIndex = 13;
      this.txtWhite.Text = "";
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(128, 136);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(88, 16);
      this.label8.TabIndex = 12;
      this.label8.Text = "Total white";
      // 
      // txtChablis
      // 
      this.txtChablis.Location = new System.Drawing.Point(24, 152);
      this.txtChablis.Name = "txtChablis";
      this.txtChablis.Size = new System.Drawing.Size(64, 20);
      this.txtChablis.TabIndex = 11;
      this.txtChablis.Text = "";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(24, 136);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(88, 16);
      this.label4.TabIndex = 10;
      this.label4.Text = "Chablis count";
      // 
      // txtPino
      // 
      this.txtPino.Location = new System.Drawing.Point(24, 96);
      this.txtPino.Name = "txtPino";
      this.txtPino.Size = new System.Drawing.Size(64, 20);
      this.txtPino.TabIndex = 9;
      this.txtPino.Text = "";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(24, 80);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(104, 16);
      this.label5.TabIndex = 8;
      this.label5.Text = "Pinot Grigio count";
      // 
      // txtChardonay
      // 
      this.txtChardonay.Location = new System.Drawing.Point(24, 40);
      this.txtChardonay.Name = "txtChardonay";
      this.txtChardonay.Size = new System.Drawing.Size(64, 20);
      this.txtChardonay.TabIndex = 7;
      this.txtChardonay.Text = "";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(24, 24);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(104, 16);
      this.label6.TabIndex = 6;
      this.label6.Text = "Chardonay count";
      // 
      // txtTotRed
      // 
      this.txtTotRed.Location = new System.Drawing.Point(272, 56);
      this.txtTotRed.Name = "txtTotRed";
      this.txtTotRed.Size = new System.Drawing.Size(64, 20);
      this.txtTotRed.TabIndex = 9;
      this.txtTotRed.Text = "";
      // 
      // label9
      // 
      this.label9.Location = new System.Drawing.Point(272, 40);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(88, 16);
      this.label9.TabIndex = 8;
      this.label9.Text = "Total Red";
      // 
      // txtTotWhite
      // 
      this.txtTotWhite.Location = new System.Drawing.Point(272, 120);
      this.txtTotWhite.Name = "txtTotWhite";
      this.txtTotWhite.Size = new System.Drawing.Size(64, 20);
      this.txtTotWhite.TabIndex = 15;
      this.txtTotWhite.Text = "";
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(272, 104);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(88, 16);
      this.label10.TabIndex = 14;
      this.label10.Text = "Total white";
      // 
      // cmdQuit
      // 
      this.cmdQuit.Location = new System.Drawing.Point(272, 200);
      this.cmdQuit.Name = "cmdQuit";
      this.cmdQuit.Size = new System.Drawing.Size(64, 32);
      this.cmdQuit.TabIndex = 16;
      this.cmdQuit.Text = "Quit";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(368, 270);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdQuit,
                                                                  this.txtTotWhite,
                                                                  this.label10,
                                                                  this.txtTotRed,
                                                                  this.label9,
                                                                  this.tc});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Property Binding";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tc.ResumeLayout(false);
      this.t1.ResumeLayout(false);
      this.t2.ResumeLayout(false);
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

    #region events

    private void CloseMe(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ValidateRed(object sender, CancelEventArgs e)
    {
      int     reds = 0;
      TextBox t;
      string  msg;
      
      //Remeber we call this once with a generic object
      if(sender is TextBox)
      {
        t = (TextBox)sender;
        msg = t.Name + " Needs a number.";
      }
      else
        msg = "Wine count cannot be blank";

      if(txtCab.Text == "" || 
        txtMerlot.Text == "" || 
        txtShiraz.Text == "")
      {
        MessageBox.Show(msg);
        e.Cancel = true;
        return;
      }

      reds =  Convert.ToInt32(txtCab.Text);
      reds += Convert.ToInt32(txtMerlot.Text);
      reds += Convert.ToInt32(txtShiraz.Text);

      txtRed.Text = reds.ToString();
    }

    private void ValidateWhite(object sender, CancelEventArgs e)
    {
      int whites = 0;

      if(txtChardonay.Text == "" || 
        txtPino.Text == "" || 
        txtChablis.Text == "")
      {
        e.Cancel = true;
        return;
      }

      whites =  Convert.ToInt32(txtChardonay.Text);
      whites += Convert.ToInt32(txtPino.Text);
      whites += Convert.ToInt32(txtChablis.Text);

      txtWhite.Text = whites.ToString();
    }

    private void InputValidator(object sender, KeyPressEventArgs e)
    {
      if(!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 )
        e.Handled = true;
    }

    private void Pastings(object sender, EventArgs e)
    {
      TextBox t;
      if(sender is TextBox)
      {
        t = (TextBox)sender;
        if (t.Name == txtCab.Name)
        {
          for (int x =0; x<txtCab.TextLength; x++)
          {
            if (!char.IsNumber(txtCab.Text,x))
            {
              txtCab.Text = "";
              break;
            }
          }
        }
      }
    }

    #endregion

  }
}
