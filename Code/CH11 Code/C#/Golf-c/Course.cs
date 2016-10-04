using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Golf_c
{
	/// <summary>
	/// Use a database to store all records
	/// </summary>
	public class Course : System.Windows.Forms.Form
	{
    #region Class Local Variables

    private GolfStat        mParent;
    private ICourseInfo     ThisCourse;
    private IScoreCardInfo  ThisCard;
    private IHoleDetailInfo ThisHole;

    #endregion

    private System.Windows.Forms.Button cmdQuit;
    private System.Windows.Forms.TabControl TC;
    private System.Windows.Forms.TabPage tp1;
    private System.Windows.Forms.TabPage tp2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtSlope;
    private System.Windows.Forms.ComboBox cmbHoles;
    private System.Windows.Forms.ComboBox cmbPar;
    private System.Windows.Forms.Button cmdSave;
    private System.Windows.Forms.DataGrid dg1;
    private System.Windows.Forms.ComboBox cmbCourseName;
    private System.Windows.Forms.Button cmdNew;
    private System.Windows.Forms.ListView lstTees;
    private System.Windows.Forms.Button cmdEdit;
    private System.Windows.Forms.Label lblLength;
    private System.Windows.Forms.Button cmdNewCard;
    private System.Windows.Forms.ErrorProvider err;

    private System.ComponentModel.Container components = null;

    public Course()
    {
      InitializeComponent();

      //Dont forget to initailize tab order and speedkeys, etc
      this.Anchor = AnchorStyles.Left & AnchorStyles.Top;

      //Automatic disposal of "f"
      using (Font f = (Font)this.Font.Clone())
      {
        this.Font = new Font("Comic Sans MS", 10);
        this.Text = "Golf Course Score Tracker";
        //Figure out why I have to clone this font.
        //It is important that you understand the reason
        this.Font = (Font)f.Clone();
      }

      cmdQuit.Click += new EventHandler(this.CloseProgram);

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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Course));
      this.TC = new System.Windows.Forms.TabControl();
      this.tp1 = new System.Windows.Forms.TabPage();
      this.lblLength = new System.Windows.Forms.Label();
      this.cmdEdit = new System.Windows.Forms.Button();
      this.lstTees = new System.Windows.Forms.ListView();
      this.cmdNew = new System.Windows.Forms.Button();
      this.cmbCourseName = new System.Windows.Forms.ComboBox();
      this.cmdSave = new System.Windows.Forms.Button();
      this.cmbPar = new System.Windows.Forms.ComboBox();
      this.cmbHoles = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtSlope = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tp2 = new System.Windows.Forms.TabPage();
      this.cmdNewCard = new System.Windows.Forms.Button();
      this.dg1 = new System.Windows.Forms.DataGrid();
      this.cmdQuit = new System.Windows.Forms.Button();
      this.err = new System.Windows.Forms.ErrorProvider();
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
      this.TC.Size = new System.Drawing.Size(736, 360);
      this.TC.TabIndex = 0;
      // 
      // tp1
      // 
      this.tp1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.lblLength,
                                                                      this.cmdEdit,
                                                                      this.lstTees,
                                                                      this.cmdNew,
                                                                      this.cmbCourseName,
                                                                      this.cmdSave,
                                                                      this.cmbPar,
                                                                      this.cmbHoles,
                                                                      this.label6,
                                                                      this.label5,
                                                                      this.label4,
                                                                      this.txtSlope,
                                                                      this.label3,
                                                                      this.label2,
                                                                      this.label1});
      this.tp1.Location = new System.Drawing.Point(4, 22);
      this.tp1.Name = "tp1";
      this.tp1.Size = new System.Drawing.Size(728, 334);
      this.tp1.TabIndex = 0;
      this.tp1.Text = "Course Setup";
      // 
      // lblLength
      // 
      this.lblLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblLength.Location = new System.Drawing.Point(72, 64);
      this.lblLength.Name = "lblLength";
      this.lblLength.Size = new System.Drawing.Size(48, 20);
      this.lblLength.TabIndex = 16;
      // 
      // cmdEdit
      // 
      this.cmdEdit.Location = new System.Drawing.Point(560, 288);
      this.cmdEdit.Name = "cmdEdit";
      this.cmdEdit.Size = new System.Drawing.Size(64, 32);
      this.cmdEdit.TabIndex = 15;
      this.cmdEdit.Text = "Edit";
      // 
      // lstTees
      // 
      this.lstTees.Location = new System.Drawing.Point(16, 144);
      this.lstTees.Name = "lstTees";
      this.lstTees.Size = new System.Drawing.Size(696, 120);
      this.lstTees.TabIndex = 14;
      // 
      // cmdNew
      // 
      this.cmdNew.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdNew.Image")));
      this.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.cmdNew.Location = new System.Drawing.Point(424, 24);
      this.cmdNew.Name = "cmdNew";
      this.cmdNew.Size = new System.Drawing.Size(64, 24);
      this.cmdNew.TabIndex = 13;
      this.cmdNew.Text = "New";
      // 
      // cmbCourseName
      // 
      this.cmbCourseName.Location = new System.Drawing.Point(72, 24);
      this.cmbCourseName.Name = "cmbCourseName";
      this.cmbCourseName.Size = new System.Drawing.Size(344, 21);
      this.cmbCourseName.TabIndex = 12;
      // 
      // cmdSave
      // 
      this.cmdSave.Location = new System.Drawing.Point(648, 288);
      this.cmdSave.Name = "cmdSave";
      this.cmdSave.Size = new System.Drawing.Size(64, 32);
      this.cmdSave.TabIndex = 11;
      this.cmdSave.Text = "Save";
      // 
      // cmbPar
      // 
      this.cmbPar.Location = new System.Drawing.Point(280, 104);
      this.cmbPar.Name = "cmbPar";
      this.cmbPar.Size = new System.Drawing.Size(64, 21);
      this.cmbPar.TabIndex = 10;
      // 
      // cmbHoles
      // 
      this.cmbHoles.Location = new System.Drawing.Point(280, 64);
      this.cmbHoles.Name = "cmbHoles";
      this.cmbHoles.Size = new System.Drawing.Size(64, 21);
      this.cmbHoles.TabIndex = 9;
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(224, 104);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(56, 16);
      this.label6.TabIndex = 8;
      this.label6.Text = "Par";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(224, 64);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(56, 16);
      this.label5.TabIndex = 7;
      this.label5.Text = "Holes";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(128, 64);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(56, 16);
      this.label4.TabIndex = 6;
      this.label4.Text = "Yards";
      // 
      // txtSlope
      // 
      this.txtSlope.Location = new System.Drawing.Point(72, 104);
      this.txtSlope.Name = "txtSlope";
      this.txtSlope.Size = new System.Drawing.Size(32, 20);
      this.txtSlope.TabIndex = 5;
      this.txtSlope.Text = "";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(16, 104);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 16);
      this.label3.TabIndex = 3;
      this.label3.Text = "Slope";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(16, 64);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Length";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      // 
      // tp2
      // 
      this.tp2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.cmdNewCard,
                                                                      this.dg1});
      this.tp2.Location = new System.Drawing.Point(4, 22);
      this.tp2.Name = "tp2";
      this.tp2.Size = new System.Drawing.Size(728, 334);
      this.tp2.TabIndex = 1;
      this.tp2.Text = "Course scores";
      // 
      // cmdNewCard
      // 
      this.cmdNewCard.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdNewCard.Image")));
      this.cmdNewCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.cmdNewCard.Location = new System.Drawing.Point(608, 288);
      this.cmdNewCard.Name = "cmdNewCard";
      this.cmdNewCard.Size = new System.Drawing.Size(104, 32);
      this.cmdNewCard.TabIndex = 14;
      this.cmdNewCard.Text = "New Card";
      // 
      // dg1
      // 
      this.dg1.DataMember = "";
      this.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dg1.Location = new System.Drawing.Point(16, 16);
      this.dg1.Name = "dg1";
      this.dg1.Size = new System.Drawing.Size(696, 248);
      this.dg1.TabIndex = 0;
      // 
      // cmdQuit
      // 
      this.cmdQuit.Location = new System.Drawing.Point(696, 392);
      this.cmdQuit.Name = "cmdQuit";
      this.cmdQuit.Size = new System.Drawing.Size(60, 30);
      this.cmdQuit.TabIndex = 1;
      this.cmdQuit.Text = "Quit";
      // 
      // err
      // 
      this.err.DataMember = null;
      // 
      // Course
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(770, 440);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdQuit,
                                                                  this.TC});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Course";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.TC.ResumeLayout(false);
      this.tp1.ResumeLayout(false);
      this.tp2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion

    private void Form1_Load(object sender, System.EventArgs e)
    {
      mParent = (GolfStat)this.MdiParent;
      TabSetup();
      GolfCourseTabSetup();

    }

    #region Setup routines

    private void AddScoreCardStyle()
    {
      //First clear the existing one out
      dg1.TableStyles.Clear();

      DataGridTableStyle ts1 = new DataGridTableStyle();
      ts1.MappingName = "Course Score";
      // Set other properties.
      ts1.AlternatingBackColor = Color.LightGray;
      //
      // Add textbox column style so we can catch textbox mouse clicks
      DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
      TextCol.MappingName         = "Date";
      TextCol.HeaderText          = "Date";
      TextCol.Width               = 100;
      TextCol.TextBox.Validating  += new CancelEventHandler(DateCellValidating);
      TextCol.TextBox.DoubleClick += new EventHandler(CellDateClick);
      TextCol.TextBox.KeyPress    += new KeyPressEventHandler(CellDateKeyPress);
      ts1.GridColumnStyles.Add(TextCol);

      TextCol = new DataGridTextBoxColumn();
      TextCol.MappingName         = "Score";
      TextCol.HeaderText          = "Score";
      TextCol.Width               = 50;
      TextCol.TextBox.Enabled     = false;
      ts1.GridColumnStyles.Add(TextCol);

      for(int k=1; k<ThisCourse.NumberOfHoles+1; k++)
      {
        TextCol = new DataGridTextBoxColumn();
        TextCol.MappingName         = k.ToString();
        TextCol.HeaderText          = k.ToString();
        TextCol.Width               = 50;
        TextCol.TextBox.MaxLength   = 2;
        TextCol.TextBox.DoubleClick += new EventHandler(HoleScoreDblClick);
        TextCol.TextBox.KeyPress    += new KeyPressEventHandler(HoleScoreEntry);
        TextCol.TextBox.Validating  += new CancelEventHandler(HoleScoreValidate);
        ts1.GridColumnStyles.Add(TextCol);
      }
      dg1.TableStyles.Add(ts1);
    }

    private void SetupScoreCardDatagrid()
    {
      //This must be set up based upon the scorecard collection within 
      //the thiscourse object. as each cell is clicked it brings up a hole 
      //detail. If the user chooses not to click a cell he can in-place edit 
      //just the total score. Either way any time a cell is edited I will need 
      //to change something in the iholedetail object that belongs to this hole.

      Debug.Assert(ThisCourse != null, "Must have a valid course");

      //Generate a column style collection that makes each cell a text box.
      AddScoreCardStyle();

      DataColumn dc;
      //Set the datasource to null at start.
      dg1.DataSource = null;
      DataSet DS = new DataSet();

      //Top level table
      DataTable DT  = new DataTable("Course Score");
      dc = new DataColumn("Date", System.Type.GetType("System.DateTime"));
      DT.Columns.Add(dc);
      dc = new DataColumn("Score", System.Type.GetType("System.Int32"));
      DT.Columns.Add(dc);
      for(int k=1; k<ThisCourse.NumberOfHoles+1; k++)
      {
        dc = new DataColumn(k.ToString(), System.Type.GetType("System.Int32"));
        DT.Columns.Add(dc);
      }

      //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      //Add something here to catch if the number of holedetail objects exceeds 
      //the number of holes in the course If so then write to an error file.
      //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

      ArrayList scores = new ArrayList();
      foreach(IScoreCardInfo s in ThisCourse.ScoreCards)
      {
        scores.Clear();
        scores.Add(s.PlayDate.ToShortDateString());
        scores.Add(s.RoundScore);
        foreach(IHoleDetailInfo h in s.holes)
        {
          //Remember that the basis for this collection is a SortedList so it 
          //should come out in order.
          scores.Add(h.TotalShots);
        }
        DT.Rows.Add(scores.ToArray());
      }

      DS.Tables.Add(DT);

      dg1.CaptionText = cmbCourseName.Text + " / Date of play and Hole score ";
      dg1.CaptionFont = new Font("Comic Sans MS", 10);
      dg1.Font = new Font("Arial", 8);
      dg1.DataSource = DS;
      dg1.DataMember = "Course Score";
      dg1.CurrentCellChanged += new EventHandler(this.CellChanged);

      //Remember binding the property of one control to the property of another.
      //This was managed by a PropertyManager object.  When you have an 
      //object that derives from the IList interface such as a collection, 
      //then each of these objects has a CurrencyManager. I am changing the 
      //data view object that belongs to this data source's datamember 
      //(The table name in this case).  I am making sure that the user cannot 
      //add a new row using this dataview.  See the online help 
      //"Consumers of Data on Windows Forms" for more explanation.
      CurrencyManager cm = (CurrencyManager)this.BindingContext[dg1.DataSource, 
                                                                dg1.DataMember];
      ((DataView)cm.List).AllowNew = false;
 
      cmdNewCard.BackColor = Color.SandyBrown;
      cmdNewCard.Click += new EventHandler(NewCard);

    }

    private void GolfCourseTabSetup()
    {

      lblLength.BackColor = Color.LightGray;

      //Slope must be between 55 and 155
      txtSlope.MaxLength  = Globals.SlopeLen;
      txtSlope.KeyPress   += new KeyPressEventHandler(this.SlopeKeyPress);
      txtSlope.Validating += new CancelEventHandler(this.SlopeValidate);

      cmdNew.BackColor  = Color.SandyBrown;
      cmdNew.Font       = cmdQuit.Font;
      cmdNew.Image      = Image.FromFile("new.ico");
      cmdNew.Click      += new EventHandler(this.NewCourse);

      cmdSave.BackColor = Color.SandyBrown;
      cmdSave.Font      = cmdQuit.Font;
      cmdSave.Click     += new EventHandler(this.SaveCourse);
      cmdSave.Enabled   =  false;

      cmdEdit.BackColor = Color.SandyBrown;
      cmdEdit.Font      = cmdQuit.Font;
      cmdEdit.Click     += new EventHandler(this.EditCourse);

      cmbPar.DropDownStyle = ComboBoxStyle.DropDownList;

      cmbHoles.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbHoles.Items.Add(Globals.NineHoles);
      cmbHoles.Items.Add(Globals.EighteenHoles);
      cmbHoles.SelectedIndexChanged += new EventHandler(this.SelectPar);
      cmbHoles.SelectedIndex = 1;

      cmbCourseName.MaxLength = 60;
      cmbCourseName.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbCourseName.SelectedIndexChanged += new EventHandler(ChangeCourse);
      foreach(ICourseInfo c in mParent.db.GolfCourses)
      {
        cmbCourseName.Items.Add(c);
      }
      if(cmbCourseName.Items.Count>0)
        cmbCourseName.SelectedIndex = 0;

      lstTees.MouseUp += new MouseEventHandler(EditTeeBox);
    }

    private void TabSetup()
    {
      tp1.BorderStyle   = BorderStyle.FixedSingle;
      tp1.BackColor     = Color.LightGreen;

      tp2.BorderStyle   = BorderStyle.FixedSingle;
      tp2.BackColor     = Color.LightGreen;

      TC.Font           = new Font("Comic Sans MS", 10);
      TC.Alignment      = TabAlignment.Bottom;
      TC.Appearance     = TabAppearance.Normal;
      TC.SelectedIndexChanged += new EventHandler(ChangeTabPage);
    }

    private void SetupTeeList()
    {
      lstTees.View = View.Details;
      lstTees.GridLines = true;
      lstTees.BeginUpdate();
      lstTees.Clear();
      lstTees.Columns.Add("Stats", 100, HorizontalAlignment.Left);
      for(int k=0; k<(int)cmbHoles.SelectedItem; k++)
        lstTees.Columns.Add((k+1).ToString(), 50, HorizontalAlignment.Center);

      ListViewItem Blue   = lstTees.Items.Add("Blue Tee");
      Blue.ForeColor      = Color.Blue;
      ListViewItem White  = lstTees.Items.Add("White Tee");
      ListViewItem Red    = lstTees.Items.Add("Red Tee");
      Red.ForeColor       = Color.Red;
      ListViewItem Par    = lstTees.Items.Add("Par");

      if(cmbCourseName.SelectedItem != null)
      {
        ThisCourse = (ICourseInfo)cmbCourseName.SelectedItem;
        foreach(Tees tee in ThisCourse.Hole)
        {
          Blue.SubItems.Add(tee.BlueDistance.ToString(),  Color.Blue, Color.Linen,  lstTees.Font);
          White.SubItems.Add(tee.WhiteDistance.ToString(),Color.Black, Color.Linen, lstTees.Font);
          Red.SubItems.Add(tee.RedDistance.ToString(),    Color.Red, Color.Linen,   lstTees.Font);
          Par.SubItems.Add(tee.Par.ToString());
        }
      }
      lstTees.EndUpdate();
    }

    #endregion

    #region DataGrid associated events


    private void CellDateClick(object sender, EventArgs e)
    {
      //Handle double clicking on the date field
      //If you want you can bring up a calendar dialog here to make it 
      //easy for the user to pick a date
    }

    private void CellDateKeyPress(object sender, KeyPressEventArgs e)
    {
      //Handle entering data in the date field
      if(!Regex.IsMatch(e.KeyChar.ToString(), "[0-9/-]"))
        e.Handled = true;
    }

    private void DateCellValidating(object sender, CancelEventArgs e)
    {
      Debug.Assert(sender is TextBox, 
        "Sender must be a datagrid cell that is a textbox");

      string DateMatch = "[0-1]?[0-9]/[0-3]?[0-9]/[0-9]{4}$";
      if(Regex.IsMatch(((TextBox)sender).Text, DateMatch))
        if(ThisCard != null)
          ThisCard.PlayDate = DateTime.Parse(((TextBox)sender).Text);
      else
        e.Cancel = true;
    }

    private void HoleScoreEntry(object sender, KeyPressEventArgs e)
    {
      if(!Char.IsDigit(e.KeyChar))
        e.Handled = true;
    }

    private void HoleScoreValidate(object sender, CancelEventArgs e)
    {
      Debug.Assert(sender is TextBox, 
                   "Sender must be a datagrid cell that is a textbox");

      if(ThisCard != null && ThisHole != null)
      {
        ThisHole.TotalShots = int.Parse(((TextBox)sender).Text);
        dg1[dg1.CurrentCell.RowNumber, 1] = ThisCard.RoundScore;
      }
    }

     private void CellChanged(object sender, EventArgs e)
    {
      try
      {
        ThisCard = ThisCourse.ScoreCards.Item(dg1.CurrentCell.RowNumber);
        ThisHole = ThisCard.holes.Item(dg1.CurrentCell.ColumnNumber-2);
      }
      catch
      {
        ThisCard = null;
        ThisHole = null;
      }
    }

    private void HoleScoreDblClick(object sender, EventArgs e)
    {
      Debug.Assert(sender is TextBox, 
                  "Sender must be a datagrid cell that is a textbox");

      //Get the scorecard and then get the holedetail for the scorecard
      if(ThisCourse != null && ThisHole != null)
      {
        HoleDetail detail = new HoleDetail(ref ThisCourse, ref ThisHole);
        detail.ShowDialog();
        if(detail.DialogResult == DialogResult.OK)
        {
          //change the underlying dataset here
          ((TextBox)sender).Text = ThisHole.TotalShots.ToString();
        }
        detail.Close();
        dg1.Update();
      }
    }

    private void NewCard(object sender, EventArgs e)
    {
      IScoreCardInfo card = new IScoreCardInfo(ThisCourse.NumberOfHoles);
      ThisCourse.ScoreCards.Add(card);

      ArrayList scores = new ArrayList();
      scores.Add(card.PlayDate.ToShortDateString());
      scores.Add(card.RoundScore);
      foreach(IHoleDetailInfo h in card.holes)
      {
        h.Par = ((Tees)ThisCourse.Hole[h.Hole-1]).Par;
        scores.Add(h.TotalShots);
      }

      DataSet ds = (DataSet)dg1.DataSource;
      DataTable DT = ds.Tables[dg1.DataMember];
      DT.Rows.Add(scores.ToArray());
    }

    #endregion

    #region Tab Control Events

    private void ChangeTabPage(object sender, EventArgs e)
    {
      if(TC.SelectedIndex == 1)
      {
        if(cmbCourseName.Text == string.Empty)
        {
          MessageBox.Show("You must choose a valid golf course.", 
                          "No Course Chosen", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Error);
          TC.SelectedIndex = 0;
        }
        else
        {
          //If we were editing at the time we changed tabs
          //then too bad.  We lost the edit.
          AllowEdit(false);
          SetupScoreCardDatagrid();
        }
      }
    }

    #endregion

    #region First Tab event handlers

    private void NewCourse(object sender, EventArgs e)
    {
      NewCourseDlg frm = new NewCourseDlg();
      try
      {
        frm.ShowDialog();
        if(frm.DialogResult == DialogResult.OK)
        {
          cmbCourseName.Items.Add(new ICourseInfo(frm.NewName));
          cmbCourseName.SelectedIndex = cmbCourseName.Items.Count-1;
        }
      }
      finally
      {
        //Unload and dispose of dialog
        if(frm != null)
          frm.Close();
      }
    }

    private void ChangeCourse(object sender, EventArgs e)
    {
      ThisCourse = (ICourseInfo)cmbCourseName.SelectedItem;
      //Do the holes
      for(int x=0; x<cmbHoles.Items.Count; x++)
      {
        if((int)cmbHoles.Items[x] == ThisCourse.NumberOfHoles)
        {
          cmbHoles.SelectedIndex = x;
          break;
        }
      }
      lblLength.Text = ThisCourse.Length.ToString();
      //Do the par
      for(int x=0; x<cmbPar.Items.Count; x++)
      {
        if((int)cmbPar.Items[x] == (int)ThisCourse.Par)
        {
          cmbPar.SelectedIndex = x;
          break;
        }
      }
      //Do the Slope/length
      SetupTeeList();
      txtSlope.Text  = ThisCourse.Slope.ToString();
      AllowEdit(false);
    }

    private void EditTeeBox(object sender, MouseEventArgs e)
    {
      ListViewItem l = lstTees.GetItemAt(e.X, e.Y);
      if(l != null)
      {
        MessageBox.Show("====== " + l.Text + " ======\n\n" +
          "Add code or another dialog box here to edit \n" +
          "the values for the subitems of this item");
      }
    }

    private void SlopeKeyPress(object sender, KeyPressEventArgs e)
    {
      Debug.Assert(sender == txtSlope, 
                  "SlopeKeyPress method called by wrong control");

      if(e.KeyChar < '0' || e.KeyChar > '9')
        e.Handled = true;

      //0 cannot be leading digit
      if(txtSlope.Text == "" && e.KeyChar == '0')
        e.Handled = true;
    }

    private void SlopeValidate(object sender, CancelEventArgs e)
    {
      Debug.Assert(sender == txtSlope, 
                  "SlopeValidate method called by wrong control");

      try
      {
        int slope = int.Parse(txtSlope.Text);
        if(slope < Globals.MinSlope || slope > Globals.MaxSlope)
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
      Debug.Assert(sender == cmdQuit, 
                  "CloseProgram method called by wrong control");

      this.Close(); //Close causes disposal
    }

    private void SaveCourse(object sender, EventArgs e)
    {
      AllowEdit(false);

      ThisCourse.Par    = (CoursePar)cmbPar.SelectedItem;
      ThisCourse.Slope  = int.Parse(txtSlope.Text);

      //Since I did not add code to change the tee distances I am not going to
      //add code to save them either.
      //If you want to do this then you will need to add code here
      //to enumerate through the ThisCourse.Hole arraylist.
    
      mParent.db.SaveCourse(ThisCourse);    
    }

    private void EditCourse(object sender, EventArgs e)
    {
      AllowEdit(true);
    }

    private void AllowEdit(bool state)
    {
      cmdEdit.Enabled       = !state;
      cmdSave.Enabled       = state;

      lstTees.Enabled       = state;
      txtSlope.Enabled      = state;
      cmbPar.Enabled        = state;
      cmbHoles.Enabled      = state;
      cmbCourseName.Enabled = !state;
      cmdNew.Enabled        = !state;
    }

    private void SelectPar(object sender, EventArgs e)
    {
      Debug.Assert(sender == cmbHoles, 
                  "SelectPar method called by wrong control");

      cmbPar.BeginUpdate();
      cmbPar.Items.Clear();
      if((int)cmbHoles.SelectedItem == Globals.NineHoles)
      {
        cmbPar.Items.Add((int)CoursePar._36);
        cmbPar.Items.Add((int)CoursePar._35);
        cmbPar.Items.Add((int)CoursePar._27);
      }
      else
      {
        cmbPar.Items.Add((int)CoursePar._72);
        cmbPar.Items.Add((int)CoursePar._71);
        cmbPar.Items.Add((int)CoursePar._70);
        cmbPar.Items.Add((int)CoursePar._54);
      }
      cmbPar.SelectedIndex = 0;
      cmbPar.EndUpdate();

      //While I am in here I need to create the listview on the fly
      //The listview depends upon the number of holes
      if(ThisCourse != null)
        Debug.WriteLine(ThisCourse.Name);

      if(ThisCourse != null && !cmdEdit.Enabled)
        ThisCourse.NumberOfHoles = (int)cmbHoles.SelectedItem;

      SetupTeeList();
    }

    #endregion


	}
}
