using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Golf_c
{
	/// <summary>
	/// HoleDetail.
	/// You will need to add some data validation code here.
	/// </summary>
	public class HoleDetail : System.Windows.Forms.Form
	{
    #region locals

    private IHoleDetailInfo mHole;
    private Tees            distance;
    private YardMarker      TeeBox;

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblHole;
    private System.Windows.Forms.Label lblCourse;
    private System.Windows.Forms.Label lblPar;
    private System.Windows.Forms.Label txtYards;
    private System.Windows.Forms.RadioButton optWhite;
    private System.Windows.Forms.RadioButton optRed;
    private System.Windows.Forms.RadioButton optBlue;
    private System.Windows.Forms.CheckBox chkGoodHit;
    private System.Windows.Forms.TextBox txtTotal;
    private System.Windows.Forms.TextBox txtPutts;
    private System.Windows.Forms.TextBox txtShots2Green;
    private System.Windows.Forms.CheckBox chkFairway;
    private System.Windows.Forms.ComboBox cmbSecondClub;
    private System.Windows.Forms.ComboBox cmbFirstClub;
    private System.Windows.Forms.Button cmdSave;
    private System.Windows.Forms.Button cmdCancel;

    private System.ComponentModel.Container components = null;

    public HoleDetail(ref ICourseInfo ThisCourse, ref IHoleDetailInfo hole)
    {
			InitializeComponent();

      //Dont forget to initailize tab order and speedkeys, etc
      this.BackColor = Color.LightGreen;
      cmdSave.BackColor = Color.SandyBrown;
      cmdCancel.BackColor = Color.SandyBrown;

      mHole = hole;
      lblCourse.Text = ThisCourse.Name;
      foreach(Tees tee in ThisCourse.Hole)
      {
        if(tee.HoleNumber == mHole.Hole)
        {
          distance = tee;
          break;
        }
      }

      lblHole.Text = "Hole: " + mHole.Hole.ToString();
      lblPar.Text  = "Par: "  + mHole.Par.ToString();

      optBlue.CheckedChanged += new EventHandler(this.YardClick);
      optWhite.CheckedChanged += new EventHandler(this.YardClick);
      optRed.CheckedChanged += new EventHandler(this.YardClick);
      switch(hole.TeeBox)
      {
        case YardMarker.Blue:
          optBlue.Checked = true;
          TeeBox = YardMarker.Blue;
          break;
        case YardMarker.Red:
          optRed.Checked = true;
          TeeBox = YardMarker.Red;
          break;
        case YardMarker.White:
        default:
          optWhite.Checked = true;
          TeeBox = YardMarker.White;
          break;
      }

      //This is how you enumerate an enumeration
      //Bet you didn't know you could do this.
      GolfClubs G = GolfClubs.One_iron;
      while(G <= GolfClubs.Putter)
      {
        cmbFirstClub.Items.Add(G);
        if(mHole.TeeClub == G)
          cmbFirstClub.SelectedIndex = cmbFirstClub.Items.Count-1;

        cmbSecondClub.Items.Add(G);
        if(mHole.ScondClub == G)
          cmbSecondClub.SelectedIndex = cmbSecondClub.Items.Count-1;

        G++;
      }

      cmdSave.DialogResult    = DialogResult.OK;
      cmdCancel.DialogResult  = DialogResult.Cancel;
      cmdSave.Click           += new EventHandler(SaveHole);

      chkFairway.Checked  = hole.HitFairway;
      chkGoodHit.Checked  = hole.GoodSecondShot;
      txtShots2Green.MaxLength = 3;
      txtShots2Green.Text = hole.ShotsToGreen.ToString();
      txtShots2Green.KeyPress += new KeyPressEventHandler(OnlyNumbers);
      txtPutts.MaxLength = 3;
      txtPutts.Text       = hole.Putts.ToString();
      txtPutts.KeyPress   += new KeyPressEventHandler(OnlyNumbers);
      txtTotal.MaxLength = 3;
      txtTotal.Text       = hole.TotalShots.ToString();
      txtTotal.KeyPress   += new KeyPressEventHandler(OnlyNumbers);

      //Consider adding a databinding or validation to the totals 
      //text box so it automatically totals the shots2green and putts TextBoxes.
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.lblPar = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtYards = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.optWhite = new System.Windows.Forms.RadioButton();
      this.optRed = new System.Windows.Forms.RadioButton();
      this.optBlue = new System.Windows.Forms.RadioButton();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.chkGoodHit = new System.Windows.Forms.CheckBox();
      this.txtTotal = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txtPutts = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtShots2Green = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cmbSecondClub = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.chkFairway = new System.Windows.Forms.CheckBox();
      this.cmbFirstClub = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cmdSave = new System.Windows.Forms.Button();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.lblHole = new System.Windows.Forms.Label();
      this.lblCourse = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblPar
      // 
      this.lblPar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblPar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblPar.Location = new System.Drawing.Point(376, 96);
      this.lblPar.Name = "lblPar";
      this.lblPar.Size = new System.Drawing.Size(96, 24);
      this.lblPar.TabIndex = 13;
      this.lblPar.Text = "Par:";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.txtYards,
                                                                            this.label9,
                                                                            this.optWhite,
                                                                            this.optRed,
                                                                            this.optBlue});
      this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(24, 56);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(320, 112);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Distance";
      // 
      // txtYards
      // 
      this.txtYards.BackColor = System.Drawing.Color.Linen;
      this.txtYards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.txtYards.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.txtYards.Location = new System.Drawing.Point(144, 56);
      this.txtYards.Name = "txtYards";
      this.txtYards.Size = new System.Drawing.Size(96, 16);
      this.txtYards.TabIndex = 4;
      // 
      // label9
      // 
      this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label9.Location = new System.Drawing.Point(144, 40);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(88, 16);
      this.label9.TabIndex = 3;
      this.label9.Text = "Yardage";
      // 
      // optWhite
      // 
      this.optWhite.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.optWhite.Location = new System.Drawing.Point(24, 56);
      this.optWhite.Name = "optWhite";
      this.optWhite.Size = new System.Drawing.Size(96, 16);
      this.optWhite.TabIndex = 2;
      this.optWhite.Text = "White Tees";
      // 
      // optRed
      // 
      this.optRed.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.optRed.Location = new System.Drawing.Point(24, 80);
      this.optRed.Name = "optRed";
      this.optRed.Size = new System.Drawing.Size(96, 16);
      this.optRed.TabIndex = 1;
      this.optRed.Text = "Red Tees";
      // 
      // optBlue
      // 
      this.optBlue.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.optBlue.Location = new System.Drawing.Point(24, 32);
      this.optBlue.Name = "optBlue";
      this.optBlue.Size = new System.Drawing.Size(96, 16);
      this.optBlue.TabIndex = 0;
      this.optBlue.Text = "Blue Tees";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.chkGoodHit,
                                                                            this.txtTotal,
                                                                            this.label7,
                                                                            this.txtPutts,
                                                                            this.label6,
                                                                            this.txtShots2Green,
                                                                            this.label5,
                                                                            this.cmbSecondClub,
                                                                            this.label3,
                                                                            this.label4,
                                                                            this.chkFairway,
                                                                            this.cmbFirstClub,
                                                                            this.label2,
                                                                            this.label1});
      this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.groupBox2.Location = new System.Drawing.Point(24, 184);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(496, 216);
      this.groupBox2.TabIndex = 15;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Shots";
      // 
      // chkGoodHit
      // 
      this.chkGoodHit.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.chkGoodHit.Location = new System.Drawing.Point(344, 88);
      this.chkGoodHit.Name = "chkGoodHit";
      this.chkGoodHit.Size = new System.Drawing.Size(112, 16);
      this.chkGoodHit.TabIndex = 26;
      this.chkGoodHit.Text = "Good Hit";
      // 
      // txtTotal
      // 
      this.txtTotal.BackColor = System.Drawing.Color.Linen;
      this.txtTotal.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.txtTotal.Location = new System.Drawing.Point(384, 160);
      this.txtTotal.Name = "txtTotal";
      this.txtTotal.Size = new System.Drawing.Size(40, 26);
      this.txtTotal.TabIndex = 25;
      this.txtTotal.Text = "";
      // 
      // label7
      // 
      this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label7.Location = new System.Drawing.Point(232, 168);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(128, 16);
      this.label7.TabIndex = 24;
      this.label7.Text = "Total Shots";
      // 
      // txtPutts
      // 
      this.txtPutts.BackColor = System.Drawing.Color.Linen;
      this.txtPutts.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.txtPutts.Location = new System.Drawing.Point(176, 160);
      this.txtPutts.Name = "txtPutts";
      this.txtPutts.Size = new System.Drawing.Size(40, 26);
      this.txtPutts.TabIndex = 23;
      this.txtPutts.Text = "";
      // 
      // label6
      // 
      this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label6.Location = new System.Drawing.Point(24, 168);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(128, 16);
      this.label6.TabIndex = 22;
      this.label6.Text = "Putts";
      // 
      // txtShots2Green
      // 
      this.txtShots2Green.BackColor = System.Drawing.Color.Linen;
      this.txtShots2Green.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.txtShots2Green.Location = new System.Drawing.Point(176, 120);
      this.txtShots2Green.Name = "txtShots2Green";
      this.txtShots2Green.Size = new System.Drawing.Size(40, 26);
      this.txtShots2Green.TabIndex = 21;
      this.txtShots2Green.Text = "";
      // 
      // label5
      // 
      this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label5.Location = new System.Drawing.Point(24, 128);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(136, 16);
      this.label5.TabIndex = 20;
      this.label5.Text = "Shots To Green";
      // 
      // cmbSecondClub
      // 
      this.cmbSecondClub.BackColor = System.Drawing.Color.Linen;
      this.cmbSecondClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbSecondClub.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.cmbSecondClub.Location = new System.Drawing.Point(176, 80);
      this.cmbSecondClub.Name = "cmbSecondClub";
      this.cmbSecondClub.Size = new System.Drawing.Size(128, 26);
      this.cmbSecondClub.TabIndex = 19;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label3.Location = new System.Drawing.Point(120, 88);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 16);
      this.label3.TabIndex = 18;
      this.label3.Text = "Club";
      // 
      // label4
      // 
      this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label4.Location = new System.Drawing.Point(24, 88);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(72, 16);
      this.label4.TabIndex = 17;
      this.label4.Text = "2nd Shot:";
      // 
      // chkFairway
      // 
      this.chkFairway.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.chkFairway.Location = new System.Drawing.Point(344, 40);
      this.chkFairway.Name = "chkFairway";
      this.chkFairway.Size = new System.Drawing.Size(112, 16);
      this.chkFairway.TabIndex = 16;
      this.chkFairway.Text = "Hit Fairway";
      // 
      // cmbFirstClub
      // 
      this.cmbFirstClub.BackColor = System.Drawing.Color.Linen;
      this.cmbFirstClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbFirstClub.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.cmbFirstClub.Location = new System.Drawing.Point(176, 32);
      this.cmbFirstClub.Name = "cmbFirstClub";
      this.cmbFirstClub.Size = new System.Drawing.Size(128, 26);
      this.cmbFirstClub.TabIndex = 15;
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label2.Location = new System.Drawing.Point(120, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 16);
      this.label2.TabIndex = 14;
      this.label2.Text = "Club";
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label1.Location = new System.Drawing.Point(24, 40);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 16);
      this.label1.TabIndex = 13;
      this.label1.Text = "Tee Shot:";
      // 
      // cmdSave
      // 
      this.cmdSave.BackColor = System.Drawing.Color.SandyBrown;
      this.cmdSave.Location = new System.Drawing.Point(320, 416);
      this.cmdSave.Name = "cmdSave";
      this.cmdSave.Size = new System.Drawing.Size(88, 32);
      this.cmdSave.TabIndex = 16;
      this.cmdSave.Text = "&Save Hole";
      // 
      // cmdCancel
      // 
      this.cmdCancel.BackColor = System.Drawing.Color.SandyBrown;
      this.cmdCancel.Location = new System.Drawing.Point(432, 416);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(88, 32);
      this.cmdCancel.TabIndex = 0;
      this.cmdCancel.Text = "&Cancel";
      // 
      // lblHole
      // 
      this.lblHole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblHole.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblHole.Location = new System.Drawing.Point(376, 64);
      this.lblHole.Name = "lblHole";
      this.lblHole.Size = new System.Drawing.Size(96, 24);
      this.lblHole.TabIndex = 19;
      this.lblHole.Text = "Hole:";
      // 
      // lblCourse
      // 
      this.lblCourse.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblCourse.Location = new System.Drawing.Point(32, 24);
      this.lblCourse.Name = "lblCourse";
      this.lblCourse.Size = new System.Drawing.Size(472, 16);
      this.lblCourse.TabIndex = 20;
      this.lblCourse.Text = "Tunxis Red Course";
      this.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // HoleDetail
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
      this.ClientSize = new System.Drawing.Size(536, 462);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lblCourse,
                                                                  this.lblHole,
                                                                  this.cmdCancel,
                                                                  this.cmdSave,
                                                                  this.groupBox2,
                                                                  this.groupBox1,
                                                                  this.lblPar});
      this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "HoleDetail";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "HoleDetail";
      this.Load += new System.EventHandler(this.HoleDetail_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    private void HoleDetail_Load(object sender, System.EventArgs e)
    {
    }


    #region events

    private void OnlyNumbers(object sender, KeyPressEventArgs e)
    {
      //Allow only positive numbers
      if(!char.IsDigit(e.KeyChar))
        e.Handled = true;
    }

     private void YardClick(object sender, EventArgs e)
    {
      if(optBlue.Checked)
      {
        txtYards.Text = distance.BlueDistance.ToString();
        TeeBox = YardMarker.Blue;
      }
      else if(optWhite.Checked)
      {
        txtYards.Text = distance.WhiteDistance.ToString();
        TeeBox = YardMarker.White;
      }
      else if(optRed.Checked)
      {
        txtYards.Text = distance.RedDistance.ToString();
        TeeBox = YardMarker.Blue;
      }
      
    }

    private void SaveHole(object sender, EventArgs e)
    {
      mHole.GoodSecondShot = chkFairway.Checked;
      mHole.GoodSecondShot = chkGoodHit.Checked;
      mHole.Putts = int.Parse(txtPutts.Text);
      mHole.ScondClub = (GolfClubs)cmbSecondClub.SelectedItem;
      mHole.ShotsToGreen = int.Parse(txtShots2Green.Text);
      mHole.TeeBox = TeeBox;
      mHole.TeeClub = (GolfClubs)cmbFirstClub.SelectedItem;
      mHole.TotalShots = int.Parse(txtTotal.Text);
    }

    #endregion


	}
}
