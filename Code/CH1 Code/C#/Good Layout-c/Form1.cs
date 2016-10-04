using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Good_Layout_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel2;
    private System.Windows.Forms.StatusBarPanel statusBarPanel3;
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.MenuItem menuItem3;
    private System.Windows.Forms.MenuItem menuItem4;
    private System.Windows.Forms.MenuItem menuItem5;
    private System.Windows.Forms.MenuItem menuItem6;
    private System.Windows.Forms.MenuItem menuItem7;
    private System.Windows.Forms.MenuItem menuItem8;
    private System.Windows.Forms.MenuItem menuItem9;
    private System.Windows.Forms.MenuItem menuItem10;
    private System.Windows.Forms.MenuItem menuItem11;
    private System.Windows.Forms.MenuItem menuItem12;
    private System.Windows.Forms.MenuItem menuItem13;
    private System.Windows.Forms.MenuItem menuItem14;
    private System.Windows.Forms.MenuItem menuItem15;
    private System.Windows.Forms.MenuItem menuItem16;
    private System.Windows.Forms.MenuItem menuItem17;
    private System.Windows.Forms.MenuItem menuItem18;
    private System.Windows.Forms.MenuItem menuItem19;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
      this.statusBar1 = new System.Windows.Forms.StatusBar();
      this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.menuItem3 = new System.Windows.Forms.MenuItem();
      this.menuItem4 = new System.Windows.Forms.MenuItem();
      this.menuItem5 = new System.Windows.Forms.MenuItem();
      this.menuItem6 = new System.Windows.Forms.MenuItem();
      this.menuItem7 = new System.Windows.Forms.MenuItem();
      this.menuItem8 = new System.Windows.Forms.MenuItem();
      this.menuItem9 = new System.Windows.Forms.MenuItem();
      this.menuItem10 = new System.Windows.Forms.MenuItem();
      this.menuItem11 = new System.Windows.Forms.MenuItem();
      this.menuItem12 = new System.Windows.Forms.MenuItem();
      this.menuItem13 = new System.Windows.Forms.MenuItem();
      this.menuItem14 = new System.Windows.Forms.MenuItem();
      this.menuItem15 = new System.Windows.Forms.MenuItem();
      this.menuItem16 = new System.Windows.Forms.MenuItem();
      this.menuItem17 = new System.Windows.Forms.MenuItem();
      this.menuItem18 = new System.Windows.Forms.MenuItem();
      this.menuItem19 = new System.Windows.Forms.MenuItem();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.button2 = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.button1 = new System.Windows.Forms.Button();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusBar1
      // 
      this.statusBar1.Location = new System.Drawing.Point(0, 369);
      this.statusBar1.Name = "statusBar1";
      this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                  this.statusBarPanel1,
                                                                                  this.statusBarPanel2,
                                                                                  this.statusBarPanel3});
      this.statusBar1.ShowPanels = true;
      this.statusBar1.Size = new System.Drawing.Size(600, 32);
      this.statusBar1.TabIndex = 0;
      this.statusBar1.Text = "statusBar1";
      // 
      // statusBarPanel1
      // 
      this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
      this.statusBarPanel1.Text = "c:\\program files\\whatever\\somefile.dat";
      this.statusBarPanel1.Width = 371;
      // 
      // statusBarPanel2
      // 
      this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
      this.statusBarPanel2.Text = "Login User = Admin";
      this.statusBarPanel2.Width = 114;
      // 
      // statusBarPanel3
      // 
      this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
      this.statusBarPanel3.Text = "10/12/02 3:53pm";
      this.statusBarPanel3.Width = 99;
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItem1,
                                                                              this.menuItem8,
                                                                              this.menuItem16,
                                                                              this.menuItem17});
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItem2,
                                                                              this.menuItem3,
                                                                              this.menuItem4,
                                                                              this.menuItem5,
                                                                              this.menuItem6,
                                                                              this.menuItem7});
      this.menuItem1.Text = "&File";
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 0;
      this.menuItem2.Text = "&New";
      // 
      // menuItem3
      // 
      this.menuItem3.Index = 1;
      this.menuItem3.Text = "&Open";
      // 
      // menuItem4
      // 
      this.menuItem4.Index = 2;
      this.menuItem4.Text = "&Save";
      // 
      // menuItem5
      // 
      this.menuItem5.Index = 3;
      this.menuItem5.Text = "Save &As...";
      // 
      // menuItem6
      // 
      this.menuItem6.Index = 4;
      this.menuItem6.Text = "-";
      // 
      // menuItem7
      // 
      this.menuItem7.Index = 5;
      this.menuItem7.Text = "E&xit";
      // 
      // menuItem8
      // 
      this.menuItem8.Index = 1;
      this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItem9,
                                                                              this.menuItem10,
                                                                              this.menuItem11,
                                                                              this.menuItem12,
                                                                              this.menuItem13,
                                                                              this.menuItem14,
                                                                              this.menuItem15});
      this.menuItem8.Text = "&Edit";
      // 
      // menuItem9
      // 
      this.menuItem9.Index = 0;
      this.menuItem9.Text = "&Undo";
      // 
      // menuItem10
      // 
      this.menuItem10.Index = 1;
      this.menuItem10.Text = "-";
      // 
      // menuItem11
      // 
      this.menuItem11.Index = 2;
      this.menuItem11.Text = "Cu&t";
      // 
      // menuItem12
      // 
      this.menuItem12.Index = 3;
      this.menuItem12.Text = "&Copy";
      // 
      // menuItem13
      // 
      this.menuItem13.Index = 4;
      this.menuItem13.Text = "&Paste";
      // 
      // menuItem14
      // 
      this.menuItem14.Index = 5;
      this.menuItem14.Text = "-";
      // 
      // menuItem15
      // 
      this.menuItem15.Index = 6;
      this.menuItem15.Text = "&Search";
      // 
      // menuItem16
      // 
      this.menuItem16.Index = 2;
      this.menuItem16.Text = "&Tools";
      // 
      // menuItem17
      // 
      this.menuItem17.Index = 3;
      this.menuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                               this.menuItem18,
                                                                               this.menuItem19});
      this.menuItem17.Text = "&Help";
      // 
      // menuItem18
      // 
      this.menuItem18.Index = 0;
      this.menuItem18.Text = "&Help";
      // 
      // menuItem19
      // 
      this.menuItem19.Index = 1;
      this.menuItem19.Text = "&About...";
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                              this.tabPage1,
                                                                              this.tabPage2,
                                                                              this.tabPage3,
                                                                              this.tabPage4});
      this.tabControl1.Location = new System.Drawing.Point(16, 16);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(552, 328);
      this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.tabControl1.TabIndex = 1;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.button2,
                                                                           this.groupBox1,
                                                                           this.label1,
                                                                           this.checkedListBox1,
                                                                           this.radioButton2,
                                                                           this.radioButton1});
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new System.Drawing.Size(544, 302);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Body Parts";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(32, 256);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(64, 24);
      this.button2.TabIndex = 7;
      this.button2.Text = "&Delete";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.button1,
                                                                            this.textBox3,
                                                                            this.label5,
                                                                            this.label6,
                                                                            this.textBox2,
                                                                            this.label4,
                                                                            this.label3,
                                                                            this.label2,
                                                                            this.textBox1});
      this.groupBox1.Location = new System.Drawing.Point(256, 64);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(264, 160);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Add New Item";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(176, 120);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(72, 24);
      this.button1.TabIndex = 14;
      this.button1.Text = "&Apply";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(72, 112);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(56, 20);
      this.textBox3.TabIndex = 13;
      this.textBox3.Text = "";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(56, 112);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(16, 16);
      this.label5.TabIndex = 12;
      this.label5.Text = "$";
      this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(16, 112);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(40, 16);
      this.label6.TabIndex = 11;
      this.label6.Text = "Price:";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(72, 80);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(56, 20);
      this.textBox2.TabIndex = 10;
      this.textBox2.Text = "";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(56, 80);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(16, 16);
      this.label4.TabIndex = 9;
      this.label4.Text = "S";
      this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(16, 80);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(40, 16);
      this.label3.TabIndex = 8;
      this.label3.Text = "Code:";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(16, 24);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(192, 16);
      this.label2.TabIndex = 7;
      this.label2.Text = "Description";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(16, 40);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(200, 20);
      this.textBox1.TabIndex = 6;
      this.textBox1.Text = "";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 48);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(208, 16);
      this.label1.TabIndex = 3;
      this.label1.Text = "Parts List";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.Items.AddRange(new object[] {
                                                         "Door, Right Front",
                                                         "Door, Left Rear",
                                                         "Fender, Right Front",
                                                         "Fender, Left Front",
                                                         "Hood",
                                                         "Trunk"});
      this.checkedListBox1.Location = new System.Drawing.Point(24, 64);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(208, 184);
      this.checkedListBox1.TabIndex = 2;
      // 
      // radioButton2
      // 
      this.radioButton2.Location = new System.Drawing.Point(192, 16);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(128, 16);
      this.radioButton2.TabIndex = 1;
      this.radioButton2.Text = "Glass";
      // 
      // radioButton1
      // 
      this.radioButton1.Checked = true;
      this.radioButton1.Location = new System.Drawing.Point(24, 16);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(128, 16);
      this.radioButton1.TabIndex = 0;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "Sheet Metal";
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new System.Drawing.Size(544, 302);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Engine Parts";
      // 
      // tabPage3
      // 
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(544, 302);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Drive Train";
      // 
      // tabPage4
      // 
      this.tabPage4.Location = new System.Drawing.Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new System.Drawing.Size(544, 302);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "Knobs/Lights etc";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(600, 401);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.tabControl1,
                                                                  this.statusBar1});
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this.mainMenu1;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Whatever Super Editor";
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
