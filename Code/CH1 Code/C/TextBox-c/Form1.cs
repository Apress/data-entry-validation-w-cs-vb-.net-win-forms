using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TextBox_c
{
  /// <summary>
  /// This project shows how to set up the TextBox to perform some elementary
  /// text entry validation
  /// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbMaxLen;
    private System.Windows.Forms.Button cmdClose;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtUpper;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.TextBox txtCentered;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtMultiLine;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtAlpha;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtNumber;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtMixed;

    private System.ComponentModel.Container components = null;


		public Form1()
		{
			InitializeComponent();

      cmbMaxLen.TabIndex = 0;
      txtUpper.TabIndex = 1;
      txtPassword.TabIndex = 2;
      txtMultiLine.TabStop = false;
      txtCentered.TabIndex = 3;
      cmdClose.TabIndex = 4;

      cmbMaxLen.Items.Clear();
      cmbMaxLen.Items.Add("5");
      cmbMaxLen.Items.Add("10");
      cmbMaxLen.Items.Add("15");
      cmbMaxLen.Items.Add("20");
      cmbMaxLen.SelectedIndexChanged += new EventHandler(this.ChangeLen);
      cmbMaxLen.SelectedIndex = 0;

      txtUpper.CharacterCasing = CharacterCasing.Upper;
      txtPassword.PasswordChar = '*';
      txtCentered.TextAlign = HorizontalAlignment.Center;
      txtMultiLine.Multiline = true;
      txtMultiLine.ScrollBars = ScrollBars.Vertical;
      txtMultiLine.WordWrap = true;
      txtMultiLine.AcceptsReturn = true;
      txtMultiLine.AcceptsTab = true;

      this.AcceptButton = cmdClose;
      cmdClose.Click += new EventHandler(this.CloseMe);

      //Event based input resricted controls
      txtAlpha.CharacterCasing = CharacterCasing.Lower;
      txtMixed.CharacterCasing = CharacterCasing.Upper;
      txtAlpha.KeyPress  += new KeyPressEventHandler(this.InputValidator);
      txtNumber.KeyPress += new KeyPressEventHandler(this.InputValidator);
      txtMixed.KeyPress  += new KeyPressEventHandler(this.InputValidator);

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
      this.cmbMaxLen = new System.Windows.Forms.ComboBox();
      this.cmdClose = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.txtUpper = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txtCentered = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtMultiLine = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtAlpha = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtNumber = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtMixed = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(32, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(96, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Max Text Length";
      // 
      // cmbMaxLen
      // 
      this.cmbMaxLen.Location = new System.Drawing.Point(32, 40);
      this.cmbMaxLen.Name = "cmbMaxLen";
      this.cmbMaxLen.Size = new System.Drawing.Size(56, 21);
      this.cmbMaxLen.TabIndex = 1;
      this.cmbMaxLen.Text = "comboBox1";
      // 
      // cmdClose
      // 
      this.cmdClose.Location = new System.Drawing.Point(232, 344);
      this.cmdClose.Name = "cmdClose";
      this.cmdClose.Size = new System.Drawing.Size(64, 32);
      this.cmdClose.TabIndex = 8;
      this.cmdClose.Text = "Close";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(32, 80);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(120, 16);
      this.label5.TabIndex = 10;
      this.label5.Text = "Upper Case";
      // 
      // txtUpper
      // 
      this.txtUpper.Location = new System.Drawing.Point(32, 96);
      this.txtUpper.Name = "txtUpper";
      this.txtUpper.Size = new System.Drawing.Size(120, 20);
      this.txtUpper.TabIndex = 9;
      this.txtUpper.Text = "";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(168, 80);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(120, 16);
      this.label6.TabIndex = 12;
      this.label6.Text = "Password";
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(168, 96);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(120, 20);
      this.txtPassword.TabIndex = 11;
      this.txtPassword.Text = "";
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(168, 136);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(120, 16);
      this.label7.TabIndex = 14;
      this.label7.Text = "Centered";
      // 
      // txtCentered
      // 
      this.txtCentered.Location = new System.Drawing.Point(168, 152);
      this.txtCentered.Name = "txtCentered";
      this.txtCentered.Size = new System.Drawing.Size(120, 20);
      this.txtCentered.TabIndex = 13;
      this.txtCentered.Text = "";
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(32, 136);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(120, 16);
      this.label8.TabIndex = 16;
      this.label8.Text = "Multi Line";
      // 
      // txtMultiLine
      // 
      this.txtMultiLine.AcceptsReturn = true;
      this.txtMultiLine.Location = new System.Drawing.Point(32, 152);
      this.txtMultiLine.Multiline = true;
      this.txtMultiLine.Name = "txtMultiLine";
      this.txtMultiLine.Size = new System.Drawing.Size(120, 112);
      this.txtMultiLine.TabIndex = 15;
      this.txtMultiLine.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(32, 280);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(120, 16);
      this.label2.TabIndex = 18;
      this.label2.Text = "Alpha";
      // 
      // txtAlpha
      // 
      this.txtAlpha.Location = new System.Drawing.Point(32, 296);
      this.txtAlpha.Name = "txtAlpha";
      this.txtAlpha.Size = new System.Drawing.Size(120, 20);
      this.txtAlpha.TabIndex = 17;
      this.txtAlpha.Text = "";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(176, 280);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(120, 16);
      this.label3.TabIndex = 20;
      this.label3.Text = "Number";
      // 
      // txtNumber
      // 
      this.txtNumber.Location = new System.Drawing.Point(176, 296);
      this.txtNumber.Name = "txtNumber";
      this.txtNumber.Size = new System.Drawing.Size(120, 20);
      this.txtNumber.TabIndex = 19;
      this.txtNumber.Text = "";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(32, 336);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(120, 16);
      this.label4.TabIndex = 22;
      this.label4.Text = "Mixed";
      // 
      // txtMixed
      // 
      this.txtMixed.Location = new System.Drawing.Point(32, 352);
      this.txtMixed.Name = "txtMixed";
      this.txtMixed.Size = new System.Drawing.Size(120, 20);
      this.txtMixed.TabIndex = 21;
      this.txtMixed.Text = "";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(320, 398);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.label4,
                                                                  this.txtMixed,
                                                                  this.label3,
                                                                  this.txtNumber,
                                                                  this.label2,
                                                                  this.txtAlpha,
                                                                  this.label8,
                                                                  this.txtMultiLine,
                                                                  this.label7,
                                                                  this.txtCentered,
                                                                  this.label6,
                                                                  this.txtPassword,
                                                                  this.label5,
                                                                  this.txtUpper,
                                                                  this.cmdClose,
                                                                  this.cmbMaxLen,
                                                                  this.label1});
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "TextBox Setup";
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

    #region control events

    private void ChangeLen(object sender, EventArgs e)
    {
      txtUpper.MaxLength = Convert.ToInt32(cmbMaxLen.Text);
      txtPassword.MaxLength = txtUpper.MaxLength;
      txtCentered.MaxLength = txtUpper.MaxLength;
      txtAlpha.MaxLength = txtUpper.MaxLength;
      txtNumber.MaxLength = txtUpper.MaxLength;
      txtMixed.MaxLength = txtUpper.MaxLength;
    }

    private void CloseMe(object sender, EventArgs e)
    {
      this.Close();
    }

    private void InputValidator(object sender, KeyPressEventArgs e)
    {
      TextBox t;
      if(sender is TextBox)
      {
        t = (TextBox)sender;
        if (t.Name == txtAlpha.Name)
        {
          //If it is not a letter then disallow the character
          if(!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)8 )
            e.Handled = true;
        }
        if (t.Name == txtNumber.Name)
        {
          //If it is not a letter then disallow the character
          if(!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8 )
            e.Handled = true;
        }
        if (t.Name == txtMixed.Name)
        {
          //Allow only 0-9,A-F,<>?=
          if(Char.IsNumber(e.KeyChar))
            e.Handled = false;
          else if(Char.ToUpper(e.KeyChar)>='A' && Char.ToUpper(e.KeyChar)<='F' )
            e.Handled = false;
          else if(e.KeyChar=='<' || e.KeyChar=='>' || e.KeyChar=='?' || e.KeyChar=='=')
            e.Handled = false;
          else
            e.Handled = true;
        }
      }
    }




    #endregion

	}
}
