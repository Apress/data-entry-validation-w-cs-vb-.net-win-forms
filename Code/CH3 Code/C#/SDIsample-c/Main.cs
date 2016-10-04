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
	/// 

	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel2;
    private System.Windows.Forms.StatusBarPanel statusBarPanel3;
    private System.Windows.Forms.MenuItem mnuFile;
    private System.Windows.Forms.MenuItem mnuClose;
    private System.Windows.Forms.MenuItem mnuEdit;
    private System.Windows.Forms.MenuItem mnuTrain;
    private System.Windows.Forms.MenuItem mnuPayroll;
    private System.Windows.Forms.MenuItem mnuSked;
    private System.Windows.Forms.MenuItem mnuWindow;
    private System.Windows.Forms.MenuItem mnuHelp;
    private System.Windows.Forms.MenuItem mnuEmp;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuItem2;

    private System.ComponentModel.Container components = null;

    #region Class Local Variables

    Payroll     PayForm;
    Employee    EmpForm;
    Scheduling  SkedForm;
    Training    TrainForm;

    #endregion

    public Form1()
    {
	    InitializeComponent();

      mnuClose.Click    += new EventHandler(this.CloseMe);
      mnuEmp.Click      += new EventHandler(this.OpenWindow);
      mnuSked.Click     += new EventHandler(this.OpenWindow);
      mnuPayroll.Click  += new EventHandler(this.OpenWindow);
      mnuTrain.Click    += new EventHandler(this.OpenWindow);

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
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.mnuFile = new System.Windows.Forms.MenuItem();
      this.mnuClose = new System.Windows.Forms.MenuItem();
      this.mnuEdit = new System.Windows.Forms.MenuItem();
      this.mnuEmp = new System.Windows.Forms.MenuItem();
      this.mnuTrain = new System.Windows.Forms.MenuItem();
      this.mnuPayroll = new System.Windows.Forms.MenuItem();
      this.mnuSked = new System.Windows.Forms.MenuItem();
      this.mnuWindow = new System.Windows.Forms.MenuItem();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.mnuHelp = new System.Windows.Forms.MenuItem();
      this.statusBar1 = new System.Windows.Forms.StatusBar();
      this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.mnuFile,
                                                                              this.mnuEdit,
                                                                              this.mnuWindow,
                                                                              this.mnuHelp});
      // 
      // mnuFile
      // 
      this.mnuFile.Index = 0;
      this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                            this.mnuClose});
      this.mnuFile.Text = "File";
      // 
      // mnuClose
      // 
      this.mnuClose.Index = 0;
      this.mnuClose.Text = "Close";
      // 
      // mnuEdit
      // 
      this.mnuEdit.Index = 1;
      this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                            this.mnuEmp,
                                                                            this.mnuTrain,
                                                                            this.mnuPayroll,
                                                                            this.mnuSked});
      this.mnuEdit.Text = "Edit";
      // 
      // mnuEmp
      // 
      this.mnuEmp.Index = 0;
      this.mnuEmp.Text = "Employee";
      // 
      // mnuTrain
      // 
      this.mnuTrain.Index = 1;
      this.mnuTrain.Text = "Training";
      // 
      // mnuPayroll
      // 
      this.mnuPayroll.Index = 2;
      this.mnuPayroll.Text = "Payroll";
      // 
      // mnuSked
      // 
      this.mnuSked.Index = 3;
      this.mnuSked.Text = "Scheduling";
      // 
      // mnuWindow
      // 
      this.mnuWindow.Index = 2;
      this.mnuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItem1,
                                                                              this.menuItem2});
      this.mnuWindow.Text = "Window";
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.Text = "Close All";
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 1;
      this.menuItem2.Text = "-";
      // 
      // mnuHelp
      // 
      this.mnuHelp.Index = 3;
      this.mnuHelp.Text = "Help";
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
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(464, 313);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.statusBar1});
      this.Menu = this.mainMenu1;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "HR Program";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
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

    #region Menu delegates

    private void CloseMe(object sender, EventArgs e)
    {
      this.Close();
    }

    private void OpenWindow(object sender, EventArgs e)
    {
      MenuItem m;

      if(sender is MenuItem)
        m = (MenuItem)sender;
      else
        return;

      if(m == mnuEmp)
      {
        if(EmpForm == null)
        {
          EmpForm = new Employee();
          EmpForm.Load      += new EventHandler(this.ListWindows);
 //         EmpForm.GotFocus  += new EventHandler(this.ListWindows);
          EmpForm.Click     += new EventHandler(this.ListWindows);
          EmpForm.Disposed  += new EventHandler(this.ByByWindow);
          EmpForm.Show();
        }
        else
          EmpForm.Focus();
      }

      if(m == mnuTrain)
      {
        if(TrainForm == null)
        {
          TrainForm = new Training();
          TrainForm.Load      += new EventHandler(this.ListWindows);
//          TrainForm.GotFocus  += new EventHandler(this.ListWindows);
          TrainForm.Click     += new EventHandler(this.ListWindows);
          TrainForm.Disposed  += new EventHandler(this.ByByWindow);
          TrainForm.Show();
        }
        else
          TrainForm.Focus();
      }

      if(m == mnuPayroll)
      {
        if(PayForm == null)
        {
          PayForm = new Payroll();
          PayForm.Load      += new EventHandler(this.ListWindows);
//          PayForm.GotFocus  += new EventHandler(this.ListWindows);
          PayForm.Click     += new EventHandler(this.ListWindows);
          PayForm.Disposed  += new EventHandler(this.ByByWindow);
          PayForm.Show();
        }
        else
          PayForm.Focus();
      }

      if(m == mnuSked)
      {
        if(SkedForm == null)
        {
          SkedForm = new Scheduling();
          SkedForm.Load      += new EventHandler(this.ListWindows);
//          SkedForm.GotFocus  += new EventHandler(this.ListWindows);
          SkedForm.Click     += new EventHandler(this.ListWindows);
          SkedForm.Disposed  += new EventHandler(this.ByByWindow);
          SkedForm.Show();
        }
        else
          SkedForm.Focus();
      }
    }

    private void ListWindows(object sender, EventArgs e)
    {
      mnuWindow.MenuItems.Clear();

      mnuWindow.MenuItems.Add("Close All", 
                               new EventHandler(this.CloseAllWindows));
      mnuWindow.MenuItems.Add("-");
      if(EmpForm != null)
        mnuWindow.MenuItems.Add(EmpForm.Text, 
                                new EventHandler(this.FocusForm));
      if(PayForm != null)
        mnuWindow.MenuItems.Add(PayForm.Text, 
                                new EventHandler(this.FocusForm));
      if(TrainForm != null)
        mnuWindow.MenuItems.Add(TrainForm.Text, 
                                new EventHandler(this.FocusForm));
      if(SkedForm != null)
        mnuWindow.MenuItems.Add(SkedForm.Text, 
                                new EventHandler(this.FocusForm));

      foreach(MenuItem mnu in mnuWindow.MenuItems)
      {
        if(EmpForm != null && sender == EmpForm && 
           mnu.Text == EmpForm.Text)
        {
          mnu.Checked = true;
          break;
        }
        if(PayForm != null && sender == PayForm && 
           mnu.Text == PayForm.Text)
        {
          mnu.Checked = true;
          break;
        }
        if(TrainForm != null && sender == TrainForm && 
           mnu.Text == TrainForm.Text)
        {
          mnu.Checked = true;
          break;
        }
        if(SkedForm != null && sender == SkedForm && 
           mnu.Text == SkedForm.Text)
        {
          mnu.Checked = true;
          break;
        }
      }
    }

    private void FocusForm(object sender, EventArgs e)
    {
      MenuItem m;

      if(sender is MenuItem)
        m = (MenuItem)sender;
      else
        return;

      foreach(MenuItem mnu in mnuWindow.MenuItems)
        mnu.Checked = false;

      if(EmpForm != null && m.Text == EmpForm.Text)
        EmpForm.Focus();

      if(PayForm != null && m.Text == PayForm.Text)
        PayForm.Focus();

      if(TrainForm != null && m.Text == TrainForm.Text)
        TrainForm.Focus();

      if(SkedForm != null && m.Text == SkedForm.Text)
        SkedForm.Focus();

      m.Checked = true;
    }

    private void CloseAllWindows(object sender, EventArgs e)
    {
      if(EmpForm != null)
        EmpForm.Dispose();
      if(PayForm != null)
        PayForm.Dispose();
      if(TrainForm != null)
        TrainForm.Dispose();
      if(SkedForm != null)
        SkedForm.Dispose();

    }

    private void ByByWindow(object sender, EventArgs e)
    {

      if(sender == EmpForm)
        EmpForm = null;
      if(sender == PayForm)
        PayForm = null;
      if(sender == TrainForm)
        TrainForm = null;
      if(sender == SkedForm)
        SkedForm = null;

      ListWindows(null, null);
    }

    #endregion

  }
}
