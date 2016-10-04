using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SDIsample_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel2;
    private System.Windows.Forms.StatusBarPanel statusBarPanel3;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.MenuItem menuItem3;
    private System.Windows.Forms.MenuItem menuItem4;
    private System.Windows.Forms.MenuItem menuItem5;
    private System.Windows.Forms.MenuItem menuItem6;
    private System.Windows.Forms.MenuItem menuItem7;
    private System.Windows.Forms.MenuItem menuItem8;
    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
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
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.statusBar1 = new System.Windows.Forms.StatusBar();
      this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.menuItem3 = new System.Windows.Forms.MenuItem();
      this.menuItem4 = new System.Windows.Forms.MenuItem();
      this.menuItem5 = new System.Windows.Forms.MenuItem();
      this.menuItem6 = new System.Windows.Forms.MenuItem();
      this.menuItem7 = new System.Windows.Forms.MenuItem();
      this.menuItem8 = new System.Windows.Forms.MenuItem();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItem1,
                                                                              this.menuItem3,
                                                                              this.menuItem8});
      // 
      // statusBar1
      // 
      this.statusBar1.Location = new System.Drawing.Point(0, 289);
      this.statusBar1.Name = "statusBar1";
      this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                  this.statusBarPanel1,
                                                                                  this.statusBarPanel2,
                                                                                  this.statusBarPanel3});
      this.statusBar1.ShowPanels = true;
      this.statusBar1.Size = new System.Drawing.Size(464, 24);
      this.statusBar1.TabIndex = 0;
      this.statusBar1.Text = "statusBar1";
      // 
      // statusBarPanel1
      // 
      this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
      this.statusBarPanel1.Text = "Employee Screen";
      this.statusBarPanel1.Width = 271;
      // 
      // statusBarPanel2
      // 
      this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
      this.statusBarPanel2.Text = "Operator:";
      this.statusBarPanel2.Width = 62;
      // 
      // statusBarPanel3
      // 
      this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
      this.statusBarPanel3.Text = "Sunday May 3 1999";
      this.statusBarPanel3.Width = 115;
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItem2});
      this.menuItem1.Text = "File";
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 0;
      this.menuItem2.Text = "Close";
      // 
      // menuItem3
      // 
      this.menuItem3.Index = 1;
      this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItem4,
                                                                              this.menuItem5,
                                                                              this.menuItem6,
                                                                              this.menuItem7});
      this.menuItem3.Text = "Edit";
      // 
      // menuItem4
      // 
      this.menuItem4.Index = 0;
      this.menuItem4.Text = "Employee";
      // 
      // menuItem5
      // 
      this.menuItem5.Index = 1;
      this.menuItem5.Text = "Training";
      // 
      // menuItem6
      // 
      this.menuItem6.Index = 2;
      this.menuItem6.Text = "Payroll";
      // 
      // menuItem7
      // 
      this.menuItem7.Index = 3;
      this.menuItem7.Text = "Scheduling";
      // 
      // menuItem8
      // 
      this.menuItem8.Index = 2;
      this.menuItem8.Text = "Help";
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.Items.AddRange(new object[] {
                                                         "Jack",
                                                         "Jim",
                                                         "Jane",
                                                         "Leon"});
      this.checkedListBox1.Location = new System.Drawing.Point(16, 32);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(272, 244);
      this.checkedListBox1.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(264, 16);
      this.label1.TabIndex = 2;
      this.label1.Text = "Employees";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(312, 144);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(120, 32);
      this.button1.TabIndex = 3;
      this.button1.Text = "Add Employee";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(312, 192);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(120, 32);
      this.button2.TabIndex = 4;
      this.button2.Text = "Fire Employee";
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(312, 240);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(120, 32);
      this.button3.TabIndex = 5;
      this.button3.Text = "Randomly Demote";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(464, 313);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.button3,
                                                                  this.button2,
                                                                  this.button1,
                                                                  this.label1,
                                                                  this.checkedListBox1,
                                                                  this.statusBar1});
      this.Menu = this.mainMenu1;
      this.Name = "Form1";
      this.Text = "HR Program";
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
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
