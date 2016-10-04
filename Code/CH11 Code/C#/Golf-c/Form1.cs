using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace Golf_c
{
	/// <summary>
	/// Use a database to store all records
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    #region Class Local Variables

    private const int MinSlope      = 55;
    private const int MaxSlope      = 155;


    #endregion

    private System.Windows.Forms.Button cmdQuit;
    private System.Windows.Forms.TabControl TC;
    private System.Windows.Forms.ErrorProvider err;
    private System.Windows.Forms.TabPage tp1;
    private System.Windows.Forms.TabPage tp2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtLength;
    private System.Windows.Forms.TextBox txtSlope;
    private System.Windows.Forms.ComboBox cmbHoles;
    private System.Windows.Forms.ComboBox cmbPar;
    private System.Windows.Forms.Button cmdSave;
    private System.Windows.Forms.ComboBox cmbCourse;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.DataGrid dg1;
    private System.Windows.Forms.ComboBox cmbCourseName;

    private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      cmdQuit.Click += new EventHandler(this.CloseProgram);

      //Automatic disposal of "f"
      using (Font f = (Font)this.Font.Clone())
      {
        this.Font = new Font("Comic Sans MS", 10);
        this.Text = "Golf Course Score Tracker";
        //Figure out why I have to clone this font.
        //It is important that you understand the reason
        this.Font = (Font)f.Clone();
      }

      TabSetup();
      GolfCourseTabSetup();
      GolfScoreTabSetup();

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
      this.TC = new System.Windows.Forms.TabControl();
      this.tp1 = new System.Windows.Forms.TabPage();
      this.cmdSave = new System.Windows.Forms.Button();
      this.cmbPar = new System.Windows.Forms.ComboBox();
      this.cmbHoles = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtSlope = new System.Windows.Forms.TextBox();
      this.txtLength = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tp2 = new System.Windows.Forms.TabPage();
      this.cmdQuit = new System.Windows.Forms.Button();
      this.err = new System.Windows.Forms.ErrorProvider();
      this.dg1 = new System.Windows.Forms.DataGrid();
      this.cmbCourse = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cmbCourseName = new System.Windows.Forms.ComboBox();
      this.TC.SuspendLayout();
      this.tp1.SuspendLayout();
      this.tp2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
      this.SuspendLayout();
      // 
      // TC
      // 
      this.TC.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                     this.tp1,
                                                                     this.tp2});
      this.TC.Location = new System.Drawing.Point(16, 16);
      this.TC.Name = "TC";
      this.TC.SelectedIndex = 0;
      this.TC.Size = new System.Drawing.Size(512, 280);
      this.TC.TabIndex = 0;
      // 
      // tp1
      // 
      this.tp1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.cmbCourseName,
                                                                      this.cmdSave,
                                                                      this.cmbPar,
                                                                      this.cmbHoles,
                                                                      this.label6,
                                                                      this.label5,
                                                                      this.label4,
                                                                      this.txtSlope,
                                                                      this.txtLength,
                                                                      this.label3,
                                                                      this.label2,
                                                                      this.label1});
      this.tp1.Location = new System.Drawing.Point(4, 22);
      this.tp1.Name = "tp1";
      this.tp1.Size = new System.Drawing.Size(504, 254);
      this.tp1.TabIndex = 0;
      this.tp1.Text = "Course Setup";
      // 
      // cmdSave
      // 
      this.cmdSave.Location = new System.Drawing.Point(408, 200);
      this.cmdSave.Name = "cmdSave";
      this.cmdSave.Size = new System.Drawing.Size(56, 32);
      this.cmdSave.TabIndex = 11;
      this.cmdSave.Text = "Save";
      // 
      // cmbPar
      // 
      this.cmbPar.Location = new System.Drawing.Point(296, 136);
      this.cmbPar.Name = "cmbPar";
      this.cmbPar.Size = new System.Drawing.Size(64, 21);
      this.cmbPar.TabIndex = 10;
      // 
      // cmbHoles
      // 
      this.cmbHoles.Location = new System.Drawing.Point(296, 80);
      this.cmbHoles.Name = "cmbHoles";
      this.cmbHoles.Size = new System.Drawing.Size(64, 21);
      this.cmbHoles.TabIndex = 9;
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(240, 136);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(56, 16);
      this.label6.TabIndex = 8;
      this.label6.Text = "Par";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(240, 80);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(56, 16);
      this.label5.TabIndex = 7;
      this.label5.Text = "Holes";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(144, 80);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(56, 16);
      this.label4.TabIndex = 6;
      this.label4.Text = "Yards";
      // 
      // txtSlope
      // 
      this.txtSlope.Location = new System.Drawing.Point(88, 136);
      this.txtSlope.Name = "txtSlope";
      this.txtSlope.Size = new System.Drawing.Size(32, 20);
      this.txtSlope.TabIndex = 5;
      this.txtSlope.Text = "";
      // 
      // txtLength
      // 
      this.txtLength.Location = new System.Drawing.Point(88, 80);
      this.txtLength.Name = "txtLength";
      this.txtLength.Size = new System.Drawing.Size(48, 20);
      this.txtLength.TabIndex = 4;
      this.txtLength.Text = "";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(32, 136);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 16);
      this.label3.TabIndex = 3;
      this.label3.Text = "Slope";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(32, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Length";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(32, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      // 
      // tp2
      // 
      this.tp2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.label7,
                                                                      this.cmbCourse,
                                                                      this.dg1});
      this.tp2.Location = new System.Drawing.Point(4, 22);
      this.tp2.Name = "tp2";
      this.tp2.Size = new System.Drawing.Size(504, 254);
      this.tp2.TabIndex = 1;
      this.tp2.Text = "Course scores";
      // 
      // cmdQuit
      // 
      this.cmdQuit.Location = new System.Drawing.Point(472, 312);
      this.cmdQuit.Name = "cmdQuit";
      this.cmdQuit.Size = new System.Drawing.Size(60, 30);
      this.cmdQuit.TabIndex = 1;
      this.cmdQuit.Text = "Quit";
      // 
      // err
      // 
      this.err.DataMember = null;
      // 
      // dg1
      // 
      this.dg1.DataMember = "";
      this.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dg1.Location = new System.Drawing.Point(16, 64);
      this.dg1.Name = "dg1";
      this.dg1.Size = new System.Drawing.Size(472, 176);
      this.dg1.TabIndex = 0;
      // 
      // cmbCourse
      // 
      this.cmbCourse.Location = new System.Drawing.Point(16, 32);
      this.cmbCourse.Name = "cmbCourse";
      this.cmbCourse.Size = new System.Drawing.Size(184, 21);
      this.cmbCourse.TabIndex = 1;
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(16, 16);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(168, 16);
      this.label7.TabIndex = 2;
      this.label7.Text = "Choose Course";
      // 
      // cmbCourseName
      // 
      this.cmbCourseName.Location = new System.Drawing.Point(88, 24);
      this.cmbCourseName.Name = "cmbCourseName";
      this.cmbCourseName.Size = new System.Drawing.Size(360, 21);
      this.cmbCourseName.TabIndex = 12;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(544, 358);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdQuit,
                                                                  this.TC});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.TC.ResumeLayout(false);
      this.tp1.ResumeLayout(false);
      this.tp2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
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

    #region Setup routines

    private void GolfScoreTabSetup()
    {
      DataColumn dc;
      DataSet DS = new DataSet();

      //Top level table
      DataTable DT  = new DataTable("Course Score");
      dc = new DataColumn("Date", System.Type.GetType("System.DateTime"));
      DT.Columns.Add(dc);
      dc = new DataColumn("Score", System.Type.GetType("System.Int32"));
      DT.Columns.Add(dc);
      for(int k=1; k<19; k++)
      {
        dc = new DataColumn(k.ToString(), System.Type.GetType("System.Int32"));
        DT.Columns.Add(dc);
      }
      DT.Rows.Add(new Object[] {DateTime.Today, 81, 3, 4, 5, 6, 3, 4, 5, 6, 3, 4, 5, 6, 5, 6, 3, 4, 5, 6});
      DS.Tables.Add(DT);

      dg1.CaptionText = "Date of play: Hole score";
      dg1.CaptionFont = new Font("Comic Sans MS", 10);
      dg1.Font = new Font("Arial", 8);
      dg1.DataSource = DS;
      dg1.DataMember = "Course Score";

      //Add code to right click on cell and bring up a details screen
      //Add code to get a stats screen

    }

    private void GolfCourseTabSetup()
    {
      cmbCourseName.MaxLength = 60;
      cmbCourseName.DropDownStyle = ComboBoxStyle.DropDown;

      //Max length of 9999 yards
      txtLength.MaxLength = 4;
      txtLength.KeyPress  += new KeyPressEventHandler(this.YardKeyPress);

      //Slope must be between 55 and 155
      txtSlope.MaxLength  = 3;
      txtSlope.KeyPress   += new KeyPressEventHandler(this.SlopeKeyPress);
      txtSlope.Validating += new CancelEventHandler(this.SlopeValidate);

      cmbHoles.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbHoles.Items.Add(9);
      cmbHoles.Items.Add(18);
      cmbHoles.SelectedIndexChanged += new EventHandler(this.SelectPar);
      cmbHoles.SelectedIndex = 1;

      cmbPar.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbPar.Items.Add(27);
      cmbPar.Items.Add(54);
      cmbPar.Items.Add(70);
      cmbPar.Items.Add(71);
      cmbPar.Items.Add(72);
    }

    private void TabSetup()
    {
      tp1.BorderStyle   = BorderStyle.FixedSingle;
      tp1.BackColor     = Color.LightGreen;

      cmdSave.BackColor = Color.SandyBrown;
      cmdSave.Font      = cmdQuit.Font;
      cmdSave.Click     += new EventHandler(this.SaveCourse);

      tp2.BorderStyle   = BorderStyle.FixedSingle;
      tp2.BackColor     = Color.LightGreen;

      TC.Font           = new Font("Comic Sans MS", 10);
      TC.Alignment      = TabAlignment.Bottom;
      TC.Appearance     = TabAppearance.Normal;
    }

    #endregion

    #region events

    private void YardKeyPress(object sender, KeyPressEventArgs e)
    {
      Debug.Assert(sender == txtLength, "YardKeyPress method called by wrong control");

      if(e.KeyChar < '0' || e.KeyChar > '9')
        e.Handled = true;

      //0 cannot be leading digit
      if(txtLength.Text == "" && e.KeyChar == '0')
        e.Handled = true;
    }

    private void SlopeKeyPress(object sender, KeyPressEventArgs e)
    {
      Debug.Assert(sender == txtSlope, "SlopeKeyPress method called by wrong control");

      if(e.KeyChar < '0' || e.KeyChar > '9')
        e.Handled = true;

      //0 cannot be leading digit
      if(txtSlope.Text == "" && e.KeyChar == '0')
        e.Handled = true;
    }

    private void SlopeValidate(object sender, CancelEventArgs e)
    {
      Debug.Assert(sender == txtSlope, "SlopeValidate method called by wrong control");

      try
      {
        int slope = int.Parse(txtSlope.Text);
        if(slope < MinSlope || slope > MaxSlope)
        {
          err.SetError(txtSlope, "Slope must be between 55 and 155");
          e.Cancel = true;
        }
      }
      catch
      {
        err.SetError(txtSlope, "BUG: Slope must be an integer");
        e.Cancel = true;
      }
      
      if(e.Cancel)
        txtSlope.SelectAll();
      else
        err.SetError(txtSlope, "");
    }

    private void CloseProgram(object sender, EventArgs e)
    {
      Debug.Assert(sender == cmdQuit, "CloseProgram method called by wrong control");
      this.Close();
    }

    private void SaveCourse(object sender, EventArgs e)
    {
    }

    private void SelectPar(object sender, EventArgs e)
    {
      Debug.Assert(sender == cmbHoles, "SelectPar method called by wrong control");

      cmbPar.BeginUpdate();
      cmbPar.Items.Clear();
      if((int)cmbHoles.SelectedItem == 9)
      {
        cmbPar.Items.Add(36);
        cmbPar.Items.Add(35);
        cmbPar.Items.Add(27);
      }
      else
      {
        cmbPar.Items.Add(72);
        cmbPar.Items.Add(71);
        cmbPar.Items.Add(70);
        cmbPar.Items.Add(54);
      }
      cmbPar.SelectedIndex = 0;
      cmbPar.EndUpdate();

    }

    #endregion

	}
}
