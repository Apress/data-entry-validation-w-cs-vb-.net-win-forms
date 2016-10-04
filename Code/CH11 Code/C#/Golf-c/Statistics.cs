using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Golf_c
{
	/// <summary>
	/// Summary description for Statistics.
	/// </summary>
	public class Statistics : System.Windows.Forms.Form
	{

    #region locals

    private GolfStat        mParent;
    private ICourseInfo     ThisCourse;
    private IScoreCardInfo  ThisCard;
    private IHoleDetailInfo ThisHole;

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label label28;
    private System.Windows.Forms.Label label30;
    private System.Windows.Forms.TreeView tvwCourse;
    private System.Windows.Forms.Label lblOther;
    private System.Windows.Forms.Label lblDoubles;
    private System.Windows.Forms.Label lblBogies;
    private System.Windows.Forms.Label lblEagles;
    private System.Windows.Forms.Label lblBirdies;
    private System.Windows.Forms.Label lblPars;
    private System.Windows.Forms.Label lblHandicap;
    private System.Windows.Forms.Label lblMinPutts;
    private System.Windows.Forms.Label lblAvgPutts;
    private System.Windows.Forms.Label lblMaxPutts;
    private System.Windows.Forms.Label lblPutting;
    private System.Windows.Forms.Label lblGreens;
    private System.Windows.Forms.Label lblFairwaysHit;
    private System.Windows.Forms.Button cmdClose;
    private System.Windows.Forms.ImageList imgIcons;
    private System.ComponentModel.IContainer components;

    public Statistics()
    {
      InitializeComponent();
      Init();
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
      this.components = new System.ComponentModel.Container();
      this.tvwCourse = new System.Windows.Forms.TreeView();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.lblOther = new System.Windows.Forms.Label();
      this.label26 = new System.Windows.Forms.Label();
      this.lblDoubles = new System.Windows.Forms.Label();
      this.label28 = new System.Windows.Forms.Label();
      this.lblBogies = new System.Windows.Forms.Label();
      this.label30 = new System.Windows.Forms.Label();
      this.lblEagles = new System.Windows.Forms.Label();
      this.label24 = new System.Windows.Forms.Label();
      this.lblBirdies = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.lblPars = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.lblHandicap = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.lblMinPutts = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.lblAvgPutts = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.lblMaxPutts = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lblPutting = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lblGreens = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lblFairwaysHit = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cmdClose = new System.Windows.Forms.Button();
      this.imgIcons = new System.Windows.Forms.ImageList(this.components);
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tvwCourse
      // 
      this.tvwCourse.ImageIndex = -1;
      this.tvwCourse.Location = new System.Drawing.Point(24, 40);
      this.tvwCourse.Name = "tvwCourse";
      this.tvwCourse.SelectedImageIndex = -1;
      this.tvwCourse.Size = new System.Drawing.Size(200, 408);
      this.tvwCourse.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.groupBox3,
                                                                            this.lblHandicap,
                                                                            this.label18,
                                                                            this.groupBox2,
                                                                            this.label8,
                                                                            this.lblPutting,
                                                                            this.label10,
                                                                            this.label5,
                                                                            this.lblGreens,
                                                                            this.label7,
                                                                            this.label4,
                                                                            this.lblFairwaysHit,
                                                                            this.label2});
      this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(240, 24);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(408, 424);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Statistics";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.lblOther,
                                                                            this.label26,
                                                                            this.lblDoubles,
                                                                            this.label28,
                                                                            this.lblBogies,
                                                                            this.label30,
                                                                            this.lblEagles,
                                                                            this.label24,
                                                                            this.lblBirdies,
                                                                            this.label20,
                                                                            this.lblPars,
                                                                            this.label22});
      this.groupBox3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.groupBox3.Location = new System.Drawing.Point(24, 272);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(344, 104);
      this.groupBox3.TabIndex = 16;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Totals";
      // 
      // lblOther
      // 
      this.lblOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblOther.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblOther.Location = new System.Drawing.Point(296, 64);
      this.lblOther.Name = "lblOther";
      this.lblOther.Size = new System.Drawing.Size(32, 16);
      this.lblOther.TabIndex = 27;
      // 
      // label26
      // 
      this.label26.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label26.Location = new System.Drawing.Point(232, 64);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(64, 16);
      this.label26.TabIndex = 26;
      this.label26.Text = "Other";
      // 
      // lblDoubles
      // 
      this.lblDoubles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDoubles.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblDoubles.Location = new System.Drawing.Point(176, 64);
      this.lblDoubles.Name = "lblDoubles";
      this.lblDoubles.Size = new System.Drawing.Size(32, 16);
      this.lblDoubles.TabIndex = 25;
      // 
      // label28
      // 
      this.label28.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label28.Location = new System.Drawing.Point(112, 64);
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size(64, 16);
      this.label28.TabIndex = 24;
      this.label28.Text = "Dbl Bogies";
      // 
      // lblBogies
      // 
      this.lblBogies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblBogies.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblBogies.Location = new System.Drawing.Point(64, 64);
      this.lblBogies.Name = "lblBogies";
      this.lblBogies.Size = new System.Drawing.Size(32, 16);
      this.lblBogies.TabIndex = 23;
      // 
      // label30
      // 
      this.label30.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label30.Location = new System.Drawing.Point(8, 64);
      this.label30.Name = "label30";
      this.label30.Size = new System.Drawing.Size(64, 16);
      this.label30.TabIndex = 22;
      this.label30.Text = "Bogies";
      // 
      // lblEagles
      // 
      this.lblEagles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblEagles.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblEagles.Location = new System.Drawing.Point(296, 32);
      this.lblEagles.Name = "lblEagles";
      this.lblEagles.Size = new System.Drawing.Size(32, 16);
      this.lblEagles.TabIndex = 21;
      // 
      // label24
      // 
      this.label24.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label24.Location = new System.Drawing.Point(232, 32);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(64, 16);
      this.label24.TabIndex = 20;
      this.label24.Text = "Eagles";
      // 
      // lblBirdies
      // 
      this.lblBirdies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblBirdies.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblBirdies.Location = new System.Drawing.Point(176, 32);
      this.lblBirdies.Name = "lblBirdies";
      this.lblBirdies.Size = new System.Drawing.Size(32, 16);
      this.lblBirdies.TabIndex = 19;
      // 
      // label20
      // 
      this.label20.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label20.Location = new System.Drawing.Point(112, 32);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(64, 16);
      this.label20.TabIndex = 18;
      this.label20.Text = "Birdies";
      // 
      // lblPars
      // 
      this.lblPars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblPars.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblPars.Location = new System.Drawing.Point(64, 32);
      this.lblPars.Name = "lblPars";
      this.lblPars.Size = new System.Drawing.Size(32, 16);
      this.lblPars.TabIndex = 17;
      // 
      // label22
      // 
      this.label22.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label22.Location = new System.Drawing.Point(8, 32);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(64, 16);
      this.label22.TabIndex = 16;
      this.label22.Text = "Pars";
      // 
      // lblHandicap
      // 
      this.lblHandicap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblHandicap.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblHandicap.Location = new System.Drawing.Point(168, 392);
      this.lblHandicap.Name = "lblHandicap";
      this.lblHandicap.Size = new System.Drawing.Size(48, 16);
      this.lblHandicap.TabIndex = 13;
      // 
      // label18
      // 
      this.label18.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label18.Location = new System.Drawing.Point(24, 392);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(136, 16);
      this.label18.TabIndex = 12;
      this.label18.Text = "Raw Handicap";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.lblMinPutts,
                                                                            this.label16,
                                                                            this.lblAvgPutts,
                                                                            this.label14,
                                                                            this.lblMaxPutts,
                                                                            this.label12});
      this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.groupBox2.Location = new System.Drawing.Point(16, 144);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(192, 112);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Putts per hole";
      // 
      // lblMinPutts
      // 
      this.lblMinPutts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMinPutts.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblMinPutts.Location = new System.Drawing.Point(120, 80);
      this.lblMinPutts.Name = "lblMinPutts";
      this.lblMinPutts.Size = new System.Drawing.Size(48, 16);
      this.lblMinPutts.TabIndex = 16;
      // 
      // label16
      // 
      this.label16.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label16.Location = new System.Drawing.Point(16, 80);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(96, 16);
      this.label16.TabIndex = 15;
      this.label16.Text = "Min.";
      // 
      // lblAvgPutts
      // 
      this.lblAvgPutts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblAvgPutts.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblAvgPutts.Location = new System.Drawing.Point(120, 56);
      this.lblAvgPutts.Name = "lblAvgPutts";
      this.lblAvgPutts.Size = new System.Drawing.Size(48, 16);
      this.lblAvgPutts.TabIndex = 14;
      // 
      // label14
      // 
      this.label14.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label14.Location = new System.Drawing.Point(16, 56);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(96, 16);
      this.label14.TabIndex = 13;
      this.label14.Text = "Avg.";
      // 
      // lblMaxPutts
      // 
      this.lblMaxPutts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMaxPutts.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblMaxPutts.Location = new System.Drawing.Point(120, 32);
      this.lblMaxPutts.Name = "lblMaxPutts";
      this.lblMaxPutts.Size = new System.Drawing.Size(48, 16);
      this.lblMaxPutts.TabIndex = 12;
      // 
      // label12
      // 
      this.label12.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label12.Location = new System.Drawing.Point(16, 32);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(96, 16);
      this.label12.TabIndex = 11;
      this.label12.Text = "Max.";
      // 
      // label8
      // 
      this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label8.Location = new System.Drawing.Point(216, 96);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(24, 16);
      this.label8.TabIndex = 8;
      this.label8.Text = "%";
      // 
      // lblPutting
      // 
      this.lblPutting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblPutting.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblPutting.Location = new System.Drawing.Point(160, 96);
      this.lblPutting.Name = "lblPutting";
      this.lblPutting.Size = new System.Drawing.Size(48, 16);
      this.lblPutting.TabIndex = 7;
      // 
      // label10
      // 
      this.label10.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label10.Location = new System.Drawing.Point(16, 96);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(136, 16);
      this.label10.TabIndex = 6;
      this.label10.Text = "Putting";
      // 
      // label5
      // 
      this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label5.Location = new System.Drawing.Point(216, 64);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(24, 16);
      this.label5.TabIndex = 5;
      this.label5.Text = "%";
      // 
      // lblGreens
      // 
      this.lblGreens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblGreens.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblGreens.Location = new System.Drawing.Point(160, 64);
      this.lblGreens.Name = "lblGreens";
      this.lblGreens.Size = new System.Drawing.Size(48, 16);
      this.lblGreens.TabIndex = 4;
      // 
      // label7
      // 
      this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label7.Location = new System.Drawing.Point(16, 64);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(136, 16);
      this.label7.TabIndex = 3;
      this.label7.Text = "Greens in regulation";
      // 
      // label4
      // 
      this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label4.Location = new System.Drawing.Point(216, 32);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(24, 16);
      this.label4.TabIndex = 2;
      this.label4.Text = "%";
      // 
      // lblFairwaysHit
      // 
      this.lblFairwaysHit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblFairwaysHit.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblFairwaysHit.Location = new System.Drawing.Point(160, 32);
      this.lblFairwaysHit.Name = "lblFairwaysHit";
      this.lblFairwaysHit.Size = new System.Drawing.Size(48, 16);
      this.lblFairwaysHit.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label2.Location = new System.Drawing.Point(16, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(136, 16);
      this.label2.TabIndex = 0;
      this.label2.Text = "Fairways Hit";
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label1.Location = new System.Drawing.Point(24, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(200, 16);
      this.label1.TabIndex = 2;
      this.label1.Text = "Golf Games";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // cmdClose
      // 
      this.cmdClose.Location = new System.Drawing.Point(568, 464);
      this.cmdClose.Name = "cmdClose";
      this.cmdClose.Size = new System.Drawing.Size(80, 32);
      this.cmdClose.TabIndex = 3;
      this.cmdClose.Text = "Close";
      // 
      // imgIcons
      // 
      this.imgIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imgIcons.ImageSize = new System.Drawing.Size(16, 16);
      this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // Statistics
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
      this.ClientSize = new System.Drawing.Size(664, 503);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdClose,
                                                                  this.label1,
                                                                  this.groupBox1,
                                                                  this.tvwCourse});
      this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "Statistics";
      this.Text = "Statistics";
      this.Load += new System.EventHandler(this.Statistics_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    private void Statistics_Load(object sender, System.EventArgs e)
    {
      mParent = (GolfStat)this.MdiParent;
      SetupTree();
    }

    #region Setup

    private void Init()
    {
      this.BackColor = Color.LightGreen;
      cmdClose.BackColor = Color.SandyBrown;
      cmdClose.Text = "&Close";
      cmdClose.TabIndex = 0;
      cmdClose.Click += new EventHandler(CloseMe);
      imgIcons.Images.Add(Image.FromFile("flag.ico"));
    }

    private void SetupTree()
    {
      TreeNode CourseNode;
      TreeNode CardNode;

      tvwCourse.Nodes.Clear();
      tvwCourse.BeginUpdate();

      tvwCourse.ImageList = imgIcons;
      tvwCourse.ImageIndex = 0;
      tvwCourse.SelectedImageIndex = 0;
      foreach(ICourseInfo c in mParent.db.GolfCourses)
      {
        CourseNode = tvwCourse.Nodes.Add(c.Name);
        CourseNode.Tag = c;
        foreach(IScoreCardInfo card in c.ScoreCards)
        {
          CardNode = CourseNode.Nodes.Add(card.PlayDate.ToShortDateString());
          CardNode.Tag = card;
        }
      }

      tvwCourse.AfterSelect += new TreeViewEventHandler(CourseStats);
      tvwCourse.EndUpdate();
    }

    #endregion

    #region events

    public void CloseMe(object sender, EventArgs e)
    {
      this.Close();
    }

    private void CourseStats(object s, TreeViewEventArgs e)
    {
      float FairwaysHit = 0;
      float GreensInReg = 0;
      float Putting     = 0;
      float MaxPutts    = 0;
      float MinPutts    = 99;
      float AvgPutts    = 0;

      if(e.Node.Tag is IScoreCardInfo)
      {
        ThisCard = (IScoreCardInfo)e.Node.Tag;
        foreach(IHoleDetailInfo h in ThisCard.holes)
        {
          FairwaysHit += h.HitFairway ? 1 : 0;
          GreensInReg += h.GreenInReg ? 1 : 0;
          Putting     += h.Putts;
          if(h.Putts > MaxPutts) MaxPutts = h.Putts;
          if(h.Putts < MinPutts) MinPutts = h.Putts;
          AvgPutts    += h.Putts;
        }
        FairwaysHit /= ThisCard.holes.Count;
        Putting /= (ThisCard.holes.Count * 2);
        GreensInReg /= ThisCard.holes.Count;
        AvgPutts    /= ThisCard.holes.Count;

        lblFairwaysHit.Text = (FairwaysHit*100).ToString();
        lblGreens.Text = (GreensInReg*100).ToString();
        lblPutting.Text = (Putting*100).ToString();
        lblMaxPutts.Text = MaxPutts.ToString();
        lblAvgPutts.Text = AvgPutts.ToString();
        lblMinPutts.Text = MinPutts.ToString();

        //I will let you figure out the rest of the stats. :)

      }
    }


    #endregion

	}
}
