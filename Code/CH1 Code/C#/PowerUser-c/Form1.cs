using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PowerUser_c
{
  /// <summary>
  /// This project details a number of design elements that go into 
  /// making a form both usable and easy to use.  Can be used by both 
  /// sophisticated and unsophisticated users.
  /// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.TabControl tc1;
    private System.Windows.Forms.Button cmdHelp;
    private System.Windows.Forms.Button cmdCancel;
    private System.Windows.Forms.Button cmdOK;
    private System.Windows.Forms.TabPage tp1;
    private System.Windows.Forms.TabPage tp2;
    private System.Windows.Forms.TabPage tp3;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.ComboBox cmbParking;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.PictureBox pic;
    private System.Windows.Forms.DateTimePicker dtBirthday;
    private System.Windows.Forms.TextBox txtCar1;
    private System.Windows.Forms.TextBox txtCar2;
    private System.Windows.Forms.TextBox txtLic1;
    private System.Windows.Forms.TextBox txtLic2;
    private System.Windows.Forms.ListView lstEmps;
    private System.Windows.Forms.ComboBox cmbPay;
    private System.Windows.Forms.CheckBox chkManager;
    private System.Windows.Forms.RadioButton optHourly;
    private System.Windows.Forms.RadioButton optSalary;
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.ImageList imgToolBar;
    private System.Windows.Forms.Button cmdListByNum;
    private System.Windows.Forms.Button cmdListByEmp;
    private System.Windows.Forms.TextBox txtNum;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtEmp;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cmdEdit;
    private System.Windows.Forms.Label lblYears;
    private System.Windows.Forms.TextBox txtDept;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DateTimePicker dtHire;
    private System.Windows.Forms.TextBox txtMI;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtFirst;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtLast;
    private System.Windows.Forms.Label label3;

    #region Class Local Variables

    ToolBar   tb1;
    private System.Windows.Forms.StatusBar sb1;
    MainMenu  mnu;

    #endregion

    public Form1()
    {
      InitializeComponent();

      //Close the program when OK/Cancel/Help buttons are pressed
      cmdOK.Text       = "&OK";
      cmdOK.Enabled    = false;
      cmdOK.Click     += new EventHandler(this.ApplyChanges);
      cmdCancel.Text   = "&Cancel";
      cmdCancel.Enabled = false;
      cmdCancel.Click += new EventHandler(this.ApplyChanges);
      cmdHelp.Text     = "&Help";
      cmdEdit.Text     = "&Edit";
      cmdEdit.Click   += new EventHandler(this.EditFields);

      //Do the menu
      mnu = new MainMenu();
      this.Menu = mnu;
      MenuItem Top = new MenuItem("&File");
      mnu.MenuItems.Add(Top);
      MenuItem Next = new MenuItem("&New", new EventHandler(this.MenuHandler));
      Next.Shortcut = Shortcut.F5;
      Top.MenuItems.Add(Next);
      Next = new MenuItem("&Save", new EventHandler(this.MenuHandler));
      Next.Shortcut = Shortcut.F6;
      Top.MenuItems.Add(Next);
      Next = new MenuItem("-");
      Top.MenuItems.Add(Next);
      Next = new MenuItem("E&xit", new EventHandler(this.MenuHandler));
      Next.Shortcut = Shortcut.F12;
      Top.MenuItems.Add(Next);

      Top = new MenuItem("&Record");
      mnu.MenuItems.Add(Top);
      Next = new MenuItem("&Previous", new EventHandler(this.MenuHandler));
      Next.Shortcut = Shortcut.F7;
      Top.MenuItems.Add(Next);
      Next = new MenuItem("N&ext", new EventHandler(this.MenuHandler));
      Next.Shortcut = Shortcut.F8;
      Top.MenuItems.Add(Next);

      Top = new MenuItem("&Help");
      mnu.MenuItems.Add(Top);
      Next = new MenuItem("&Help", new EventHandler(this.MenuHandler));
      Next.Shortcut = Shortcut.F1;
      Top.MenuItems.Add(Next);
      Next = new MenuItem("&About", new EventHandler(this.MenuHandler));
      Top.MenuItems.Add(Next);

      //Do the images for the toolbar and buttons
      imgToolBar.Images.Clear();
      imgToolBar.Images.Add(Image.FromFile("new.ico"));
      imgToolBar.Images.Add(Image.FromFile("save.ico"));
      imgToolBar.Images.Add(Image.FromFile("delete.ico"));
      imgToolBar.Images.Add(Image.FromFile("prev.ico"));
      imgToolBar.Images.Add(Image.FromFile("next.ico"));
      imgToolBar.Images.Add(Image.FromFile("help.ico"));
      imgToolBar.Images.Add(Image.FromFile("search.ico"));

      //Do the toolbar
      tb1 = new ToolBar();
      this.Controls.Add(tb1);
      tb1.ImageList = imgToolBar;
      tb1.Appearance = ToolBarAppearance.Flat;
      tb1.ButtonClick += new ToolBarButtonClickEventHandler(this.ToolBarHandler);

      //Make a space that we can add when we want to
      ToolBarButton btnSpacer = new ToolBarButton();
      btnSpacer.Style = ToolBarButtonStyle.Separator;

      ToolBarButton btn  = new ToolBarButton();
      btn.ImageIndex = 0;
      btn.ToolTipText = "New Employee";
      btn.Tag = 'N';
      tb1.Buttons.Add(btn);
      
      btn = new ToolBarButton();
      btn.ImageIndex = 1;
      btn.ToolTipText = "Save Record";
      btn.Tag = 'S';
      tb1.Buttons.Add(btn);
      
      btn  = new ToolBarButton();
      btn.ImageIndex = 2;
      btn.ToolTipText = "Delete Employee";
      btn.Tag = 'D';
      tb1.Buttons.Add(btn);
      tb1.Buttons.Add(btnSpacer);
      
      btn = new ToolBarButton();
      btn.ImageIndex = 3;
      btn.ToolTipText = "Previous Record";
      btn.Tag = 'P';
      tb1.Buttons.Add(btn);
      
      btn = new ToolBarButton();
      btn.ImageIndex = 4;
      btn.ToolTipText = "Next Record";
      btn.Tag = 'E';
      tb1.Buttons.Add(btn);
      tb1.Buttons.Add(btnSpacer);
      
      btn = new ToolBarButton();
      btn.ImageIndex = 5;
      btn.ToolTipText = "Help";
      btn.Tag = 'H';
      tb1.Buttons.Add(btn);

      //Set up the list view of employees
      lstEmps.SmallImageList = imgToolBar;
      lstEmps.View = View.List;

      //Do the buttons
      cmdListByEmp.FlatStyle = FlatStyle.Popup;
      cmdListByEmp.Height = txtEmp.Height;
      cmdListByEmp.Top = txtEmp.Top;
      cmdListByEmp.ImageList = imgToolBar;
      cmdListByEmp.ImageIndex = 6;
      cmdListByEmp.ImageAlign = ContentAlignment.MiddleCenter;
      cmdListByEmp.Tag = true;
      cmdListByEmp.Click += new EventHandler(this.CallEmployees);

      cmdListByNum.FlatStyle = FlatStyle.Popup;
      cmdListByNum.Height = txtNum.Height;
      cmdListByNum.Top = txtNum.Top;
      cmdListByNum.ImageList = imgToolBar;
      cmdListByNum.ImageIndex = 6;
      cmdListByNum.ImageAlign = ContentAlignment.MiddleCenter;
      cmdListByNum.Tag = false;
      cmdListByNum.Click += new EventHandler(this.CallEmployees);

      //Do the status bar
      StatusBarPanel sb = new StatusBarPanel();
      sb.AutoSize = StatusBarPanelAutoSize.Spring;
      sb.BorderStyle = StatusBarPanelBorderStyle.Sunken;
      sb.Text = "Employee:";
      sb1.Panels.Add(sb);

      sb = new StatusBarPanel();
      sb.AutoSize = StatusBarPanelAutoSize.Contents;
      sb.Text = DateTime.Today.ToLongDateString();
      sb1.Panels.Add(sb);
      sb1.ShowPanels = true;

      txtEmp.ReadOnly = true;
      txtNum.ReadOnly = true;

      dtHire.Format = DateTimePickerFormat.Short;
      dtHire.MaxDate = DateTime.Today;
      dtHire.ValueChanged += new EventHandler(this.CalcTime);

    //Do the tabindexes on the form itself
    txtEmp.TabIndex = 0;
    cmdListByEmp.TabIndex = 1;
    txtNum.TabIndex = 2;
    cmdListByNum.TabIndex = 3;
    cmdEdit.TabIndex = 4;
    tc1.TabIndex = 5;    //Doing this starts the tabbing on the tab page
    cmdOK.TabIndex = 6;
    cmdCancel.TabIndex = 7;
    cmdHelp.TabIndex = 8;
    //Do the tabindexes on the first tab page
    txtLast.TabIndex = 0;
    txtFirst.TabIndex = 1;
    txtMI.TabIndex = 2;
    dtHire.TabIndex = 3;
    txtDept.TabIndex = 4;
    //Do the tabindexes on the second tab page
    cmbPay.TabIndex = 0;
    chkManager.TabIndex = 1;
    optHourly.TabIndex = 2;
    optSalary.TabIndex = 3;
    lstEmps.TabIndex = 4;
    //Do the tabindexes on the third tab page
    dtBirthday.TabIndex = 0;
    txtCar1.TabIndex = 1;
    txtLic1.TabIndex = 2;
    txtCar2.TabIndex = 3;
    txtLic2.TabIndex = 4;
    cmbParking.TabIndex = 5;

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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
                                                                                                                                                        new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "Nom Text", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, -1);
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
                                                                                                                                                        new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "No Text", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))))}, -1);
      this.tc1 = new System.Windows.Forms.TabControl();
      this.tp1 = new System.Windows.Forms.TabPage();
      this.lblYears = new System.Windows.Forms.Label();
      this.txtDept = new System.Windows.Forms.TextBox();
      this.label17 = new System.Windows.Forms.Label();
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.dtHire = new System.Windows.Forms.DateTimePicker();
      this.txtMI = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtFirst = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtLast = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.tp2 = new System.Windows.Forms.TabPage();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.optSalary = new System.Windows.Forms.RadioButton();
      this.optHourly = new System.Windows.Forms.RadioButton();
      this.chkManager = new System.Windows.Forms.CheckBox();
      this.label15 = new System.Windows.Forms.Label();
      this.cmbPay = new System.Windows.Forms.ComboBox();
      this.label16 = new System.Windows.Forms.Label();
      this.lstEmps = new System.Windows.Forms.ListView();
      this.tp3 = new System.Windows.Forms.TabPage();
      this.pic = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtLic2 = new System.Windows.Forms.TextBox();
      this.label14 = new System.Windows.Forms.Label();
      this.txtLic1 = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.txtCar2 = new System.Windows.Forms.TextBox();
      this.txtCar1 = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.cmbParking = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.dtBirthday = new System.Windows.Forms.DateTimePicker();
      this.cmdHelp = new System.Windows.Forms.Button();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.cmdOK = new System.Windows.Forms.Button();
      this.imgToolBar = new System.Windows.Forms.ImageList(this.components);
      this.cmdListByNum = new System.Windows.Forms.Button();
      this.cmdListByEmp = new System.Windows.Forms.Button();
      this.txtNum = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtEmp = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cmdEdit = new System.Windows.Forms.Button();
      this.sb1 = new System.Windows.Forms.StatusBar();
      this.tc1.SuspendLayout();
      this.tp1.SuspendLayout();
      this.tp2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.tp3.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tc1
      // 
      this.tc1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.tp1,
                                                                      this.tp2,
                                                                      this.tp3});
      this.tc1.Location = new System.Drawing.Point(16, 88);
      this.tc1.Name = "tc1";
      this.tc1.SelectedIndex = 0;
      this.tc1.Size = new System.Drawing.Size(520, 240);
      this.tc1.TabIndex = 6;
      // 
      // tp1
      // 
      this.tp1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.lblYears,
                                                                      this.txtDept,
                                                                      this.label17,
                                                                      this.txtTitle,
                                                                      this.label8,
                                                                      this.label7,
                                                                      this.label6,
                                                                      this.dtHire,
                                                                      this.txtMI,
                                                                      this.label5,
                                                                      this.txtFirst,
                                                                      this.label4,
                                                                      this.txtLast,
                                                                      this.label3});
      this.tp1.Location = new System.Drawing.Point(4, 22);
      this.tp1.Name = "tp1";
      this.tp1.Size = new System.Drawing.Size(512, 214);
      this.tp1.TabIndex = 0;
      this.tp1.Text = "Basic Data";
      // 
      // lblYears
      // 
      this.lblYears.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblYears.Location = new System.Drawing.Point(292, 97);
      this.lblYears.Name = "lblYears";
      this.lblYears.Size = new System.Drawing.Size(40, 16);
      this.lblYears.TabIndex = 46;
      // 
      // txtDept
      // 
      this.txtDept.Location = new System.Drawing.Point(292, 161);
      this.txtDept.Name = "txtDept";
      this.txtDept.Size = new System.Drawing.Size(136, 20);
      this.txtDept.TabIndex = 45;
      this.txtDept.Text = "";
      // 
      // label17
      // 
      this.label17.Location = new System.Drawing.Point(292, 145);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(144, 16);
      this.label17.TabIndex = 44;
      this.label17.Text = "Department";
      // 
      // txtTitle
      // 
      this.txtTitle.Location = new System.Drawing.Point(20, 161);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.Size = new System.Drawing.Size(144, 20);
      this.txtTitle.TabIndex = 43;
      this.txtTitle.Text = "";
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(20, 145);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(144, 16);
      this.label8.TabIndex = 42;
      this.label8.Text = "Title";
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(292, 81);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(120, 16);
      this.label7.TabIndex = 41;
      this.label7.Text = "Years with Company";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(292, 33);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(200, 16);
      this.label6.TabIndex = 40;
      this.label6.Text = "Date of Hire";
      // 
      // dtHire
      // 
      this.dtHire.Location = new System.Drawing.Point(292, 49);
      this.dtHire.Name = "dtHire";
      this.dtHire.Size = new System.Drawing.Size(136, 20);
      this.dtHire.TabIndex = 39;
      // 
      // txtMI
      // 
      this.txtMI.Location = new System.Drawing.Point(180, 97);
      this.txtMI.Name = "txtMI";
      this.txtMI.Size = new System.Drawing.Size(40, 20);
      this.txtMI.TabIndex = 38;
      this.txtMI.Text = "";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(180, 81);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(24, 16);
      this.label5.TabIndex = 37;
      this.label5.Text = "M.I.";
      // 
      // txtFirst
      // 
      this.txtFirst.Location = new System.Drawing.Point(20, 97);
      this.txtFirst.Name = "txtFirst";
      this.txtFirst.Size = new System.Drawing.Size(144, 20);
      this.txtFirst.TabIndex = 36;
      this.txtFirst.Text = "";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(20, 81);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(144, 16);
      this.label4.TabIndex = 35;
      this.label4.Text = "First Name";
      // 
      // txtLast
      // 
      this.txtLast.Location = new System.Drawing.Point(20, 49);
      this.txtLast.Name = "txtLast";
      this.txtLast.Size = new System.Drawing.Size(200, 20);
      this.txtLast.TabIndex = 34;
      this.txtLast.Text = "";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(20, 33);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(200, 16);
      this.label3.TabIndex = 33;
      this.label3.Text = "Last Name";
      // 
      // tp2
      // 
      this.tp2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.groupBox2,
                                                                      this.label16,
                                                                      this.lstEmps});
      this.tp2.Location = new System.Drawing.Point(4, 22);
      this.tp2.Name = "tp2";
      this.tp2.Size = new System.Drawing.Size(512, 214);
      this.tp2.TabIndex = 1;
      this.tp2.Text = "Position";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.optSalary,
                                                                            this.optHourly,
                                                                            this.chkManager,
                                                                            this.label15,
                                                                            this.cmbPay});
      this.groupBox2.Location = new System.Drawing.Point(16, 24);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(192, 168);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Employee Type";
      // 
      // optSalary
      // 
      this.optSalary.Location = new System.Drawing.Point(24, 112);
      this.optSalary.Name = "optSalary";
      this.optSalary.Size = new System.Drawing.Size(96, 16);
      this.optSalary.TabIndex = 6;
      this.optSalary.Text = "Salary";
      // 
      // optHourly
      // 
      this.optHourly.Location = new System.Drawing.Point(24, 96);
      this.optHourly.Name = "optHourly";
      this.optHourly.Size = new System.Drawing.Size(96, 16);
      this.optHourly.TabIndex = 5;
      this.optHourly.Text = "Hourly";
      // 
      // chkManager
      // 
      this.chkManager.Location = new System.Drawing.Point(24, 64);
      this.chkManager.Name = "chkManager";
      this.chkManager.Size = new System.Drawing.Size(120, 16);
      this.chkManager.TabIndex = 4;
      this.chkManager.Text = "Manager";
      // 
      // label15
      // 
      this.label15.Location = new System.Drawing.Point(16, 24);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(40, 16);
      this.label15.TabIndex = 3;
      this.label15.Text = "Code";
      this.label15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // cmbPay
      // 
      this.cmbPay.Location = new System.Drawing.Point(56, 24);
      this.cmbPay.Name = "cmbPay";
      this.cmbPay.Size = new System.Drawing.Size(64, 21);
      this.cmbPay.TabIndex = 2;
      // 
      // label16
      // 
      this.label16.Location = new System.Drawing.Point(224, 16);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(272, 16);
      this.label16.TabIndex = 3;
      this.label16.Text = "Reporting Staff";
      this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lstEmps
      // 
      this.lstEmps.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
                                                                            listViewItem1,
                                                                            listViewItem2});
      this.lstEmps.Location = new System.Drawing.Point(224, 32);
      this.lstEmps.Name = "lstEmps";
      this.lstEmps.Size = new System.Drawing.Size(272, 160);
      this.lstEmps.TabIndex = 2;
      this.lstEmps.View = System.Windows.Forms.View.List;
      // 
      // tp3
      // 
      this.tp3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.pic,
                                                                      this.groupBox1,
                                                                      this.label9,
                                                                      this.dtBirthday});
      this.tp3.Location = new System.Drawing.Point(4, 22);
      this.tp3.Name = "tp3";
      this.tp3.Size = new System.Drawing.Size(512, 214);
      this.tp3.TabIndex = 2;
      this.tp3.Text = "Personal";
      // 
      // pic
      // 
      this.pic.Location = new System.Drawing.Point(48, 64);
      this.pic.Name = "pic";
      this.pic.Size = new System.Drawing.Size(100, 130);
      this.pic.TabIndex = 16;
      this.pic.TabStop = false;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.txtLic2,
                                                                            this.label14,
                                                                            this.txtLic1,
                                                                            this.label13,
                                                                            this.txtCar2,
                                                                            this.txtCar1,
                                                                            this.label12,
                                                                            this.label11,
                                                                            this.cmbParking,
                                                                            this.label10});
      this.groupBox1.Location = new System.Drawing.Point(216, 16);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(288, 176);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Automobile";
      // 
      // txtLic2
      // 
      this.txtLic2.Location = new System.Drawing.Point(152, 88);
      this.txtLic2.Name = "txtLic2";
      this.txtLic2.Size = new System.Drawing.Size(120, 20);
      this.txtLic2.TabIndex = 9;
      this.txtLic2.Text = "";
      // 
      // label14
      // 
      this.label14.Location = new System.Drawing.Point(152, 72);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(112, 16);
      this.label14.TabIndex = 8;
      this.label14.Text = "License";
      // 
      // txtLic1
      // 
      this.txtLic1.Location = new System.Drawing.Point(16, 88);
      this.txtLic1.Name = "txtLic1";
      this.txtLic1.Size = new System.Drawing.Size(120, 20);
      this.txtLic1.TabIndex = 7;
      this.txtLic1.Text = "";
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point(16, 72);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(112, 16);
      this.label13.TabIndex = 6;
      this.label13.Text = "License";
      // 
      // txtCar2
      // 
      this.txtCar2.Location = new System.Drawing.Point(152, 40);
      this.txtCar2.Name = "txtCar2";
      this.txtCar2.Size = new System.Drawing.Size(120, 20);
      this.txtCar2.TabIndex = 5;
      this.txtCar2.Text = "";
      // 
      // txtCar1
      // 
      this.txtCar1.Location = new System.Drawing.Point(16, 40);
      this.txtCar1.Name = "txtCar1";
      this.txtCar1.Size = new System.Drawing.Size(120, 20);
      this.txtCar1.TabIndex = 4;
      this.txtCar1.Text = "";
      // 
      // label12
      // 
      this.label12.Location = new System.Drawing.Point(152, 24);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(56, 16);
      this.label12.TabIndex = 3;
      this.label12.Text = "Car 2";
      // 
      // label11
      // 
      this.label11.Location = new System.Drawing.Point(16, 24);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(56, 16);
      this.label11.TabIndex = 2;
      this.label11.Text = "Car 1";
      // 
      // cmbParking
      // 
      this.cmbParking.Location = new System.Drawing.Point(16, 144);
      this.cmbParking.Name = "cmbParking";
      this.cmbParking.Size = new System.Drawing.Size(104, 21);
      this.cmbParking.TabIndex = 1;
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(16, 128);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(104, 16);
      this.label10.TabIndex = 0;
      this.label10.Text = "Parking Space";
      // 
      // label9
      // 
      this.label9.Location = new System.Drawing.Point(16, 16);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(168, 16);
      this.label9.TabIndex = 13;
      this.label9.Text = "Birthday";
      // 
      // dtBirthday
      // 
      this.dtBirthday.Location = new System.Drawing.Point(16, 32);
      this.dtBirthday.Name = "dtBirthday";
      this.dtBirthday.Size = new System.Drawing.Size(192, 20);
      this.dtBirthday.TabIndex = 12;
      // 
      // cmdHelp
      // 
      this.cmdHelp.Location = new System.Drawing.Point(472, 344);
      this.cmdHelp.Name = "cmdHelp";
      this.cmdHelp.Size = new System.Drawing.Size(64, 24);
      this.cmdHelp.TabIndex = 7;
      this.cmdHelp.Text = "Help";
      // 
      // cmdCancel
      // 
      this.cmdCancel.Location = new System.Drawing.Point(392, 344);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(64, 24);
      this.cmdCancel.TabIndex = 8;
      this.cmdCancel.Text = "Cancel";
      // 
      // cmdOK
      // 
      this.cmdOK.Location = new System.Drawing.Point(312, 344);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.Size = new System.Drawing.Size(64, 24);
      this.cmdOK.TabIndex = 9;
      this.cmdOK.Text = "OK";
      // 
      // imgToolBar
      // 
      this.imgToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imgToolBar.ImageSize = new System.Drawing.Size(16, 16);
      this.imgToolBar.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // cmdListByNum
      // 
      this.cmdListByNum.Location = new System.Drawing.Point(368, 56);
      this.cmdListByNum.Name = "cmdListByNum";
      this.cmdListByNum.Size = new System.Drawing.Size(32, 24);
      this.cmdListByNum.TabIndex = 26;
      // 
      // cmdListByEmp
      // 
      this.cmdListByEmp.Location = new System.Drawing.Point(224, 56);
      this.cmdListByEmp.Name = "cmdListByEmp";
      this.cmdListByEmp.Size = new System.Drawing.Size(32, 24);
      this.cmdListByEmp.TabIndex = 25;
      // 
      // txtNum
      // 
      this.txtNum.Location = new System.Drawing.Point(296, 56);
      this.txtNum.Name = "txtNum";
      this.txtNum.Size = new System.Drawing.Size(72, 20);
      this.txtNum.TabIndex = 24;
      this.txtNum.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(296, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 16);
      this.label2.TabIndex = 23;
      this.label2.Text = "Clock Number";
      // 
      // txtEmp
      // 
      this.txtEmp.Location = new System.Drawing.Point(24, 56);
      this.txtEmp.Name = "txtEmp";
      this.txtEmp.Size = new System.Drawing.Size(200, 20);
      this.txtEmp.TabIndex = 22;
      this.txtEmp.Text = "";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 40);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(144, 16);
      this.label1.TabIndex = 21;
      this.label1.Text = "Employee Name";
      // 
      // cmdEdit
      // 
      this.cmdEdit.Location = new System.Drawing.Point(440, 56);
      this.cmdEdit.Name = "cmdEdit";
      this.cmdEdit.Size = new System.Drawing.Size(64, 24);
      this.cmdEdit.TabIndex = 27;
      this.cmdEdit.Text = "Edit";
      // 
      // sb1
      // 
      this.sb1.Location = new System.Drawing.Point(0, 379);
      this.sb1.Name = "sb1";
      this.sb1.Size = new System.Drawing.Size(554, 16);
      this.sb1.TabIndex = 28;
      this.sb1.Text = "statusBar1";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(554, 395);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.sb1,
                                                                  this.cmdEdit,
                                                                  this.cmdListByNum,
                                                                  this.cmdListByEmp,
                                                                  this.txtNum,
                                                                  this.label2,
                                                                  this.txtEmp,
                                                                  this.label1,
                                                                  this.cmdOK,
                                                                  this.cmdCancel,
                                                                  this.cmdHelp,
                                                                  this.tc1});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "PowerUser";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tc1.ResumeLayout(false);
      this.tp1.ResumeLayout(false);
      this.tp2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.tp3.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
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
      FillList();

      foreach (TabPage p in tc1.TabPages)
      {
        foreach (Control c in p.Controls)
        {
          c.Enabled = false;
        }
      }

    }

    private void FillList()
    {
      txtEmp.Text = "John Smith";
      txtNum.Text = "504";
      txtLast.Text = "Smith";
      txtFirst.Text = "John";
      txtMI.Text = "Q";
      txtTitle.Text = "Marketing Manager";
      txtDept.Text = "Marketing";
      dtHire.Value = DateTime.Parse("6/23/97");

      cmbPay.Items.Clear();
      cmbPay.Items.Add("W01");
      cmbPay.Items.Add("W02");
      cmbPay.Items.Add("W03");
      cmbPay.Items.Add("W04");
      cmbPay.Items.Add("B01");
      cmbPay.SelectedIndex = 0;

      lstEmps.Items.Clear();
      lstEmps.Items.Add("Grunt 1", 0);
      lstEmps.Items.Add("Grunt 2", 0);
      lstEmps.Items.Add("Grunt 3", 0);

      txtCar1.Text = "Pickup Truck";
      txtLic1.Text = "NOBUGS";

      cmbParking.Items.Clear();
      cmbParking.Items.Add("A1");
      cmbParking.Items.Add("A2");
      cmbParking.Items.Add("A3");
      cmbParking.Items.Add("A4");
      cmbParking.Items.Add("B1");
      cmbParking.Items.Add("B2");
      cmbParking.Items.Add("B3");
      cmbParking.Items.Add("B4");
      cmbParking.Items.Add("-NA-");
      cmbParking.SelectedIndex = 0;

      chkManager.Checked = true;
      optSalary.Checked = true;

      pic.SizeMode = PictureBoxSizeMode.StretchImage;
      pic.Image = Image.FromFile("nick symmonds.jpg");

    }

    #region Events

    private void CalcTime(object sender, EventArgs e)
    {
      lblYears.Text = (DateTime.Today.Year - dtHire.Value.Year).ToString();
    }

    private void CallEmployees(object sender, EventArgs e)
    {
      Button b = (Button)sender;

      EmpList frm = new EmpList((bool)b.Tag);
      frm.ShowDialog();
    }

    private void ApplyChanges(object sender, EventArgs e)
    {
      foreach (TabPage p in tc1.TabPages)
      {
        foreach (Control c in p.Controls)
        {
          c.Enabled = false;
        }
      }
      cmdEdit.Enabled   = true;
      cmdOK.Enabled     = false;
      cmdCancel.Enabled = false;
    }

    private void EditFields(object sender, EventArgs e)
    {
      foreach (TabPage p in tc1.TabPages)
      {
        foreach (Control c in p.Controls)
        {
          c.Enabled = true;
        }
      }
      cmdEdit.Enabled   = false;
      cmdOK.Enabled     = true;
      cmdCancel.Enabled = true;
    }

    private void ToolBarHandler(object sender, ToolBarButtonClickEventArgs e)
    {
      switch ((char)e.Button.Tag)
      {
        case 'N':   //New
          //Your code here.
          break;
        case 'S':   //Save
          //Your code here.
          break;
        case 'D':   //Delete
          //Your code here.
          break;
        case 'X':   //Exit
          this.Close();
          break;
        case 'P':   //Previous
          //Your code here.
          break;
        case 'E':   //Next
          //Your code here.
          break;
        case 'H':   //Help
          //Your code here.
          break;
        case 'A':   //About
          //Your code here.
          break;
      }

    }

    private void MenuHandler(object sender, EventArgs e)
    {
      MenuItem m;
      if(sender is MenuItem)
        m = (MenuItem)sender;
      else
        return;

      switch (m.Mnemonic)
      {
        case 'N':   //New
          //Your code here.
          break;
        case 'S':   //Save
          //Your code here.
          break;
        case 'D':   //Delete
          //Your code here.
          break;
        case 'X':   //Exit
          this.Close();
          break;
        case 'P':   //Previous
          //Your code here.
          break;
        case 'E':   //Next
          //Your code here.
          break;
        case 'H':   //Help
          //Your code here.
          break;
        case 'A':   //About
          //Your code here.
          break;
      }

    }
    #endregion

	}
}
