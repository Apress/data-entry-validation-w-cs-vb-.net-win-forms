using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MDIapp_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class UberForm : System.Windows.Forms.Form
	{
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.MenuItem mnuFile;
    private System.Windows.Forms.MenuItem mnuClose;
    private System.Windows.Forms.MenuItem mnuEdit;
    private System.Windows.Forms.MenuItem mnuEmp;
    private System.Windows.Forms.MenuItem mnuTrain;
    private System.Windows.Forms.MenuItem mnuPayroll;
    private System.Windows.Forms.MenuItem mnuSked;
    private System.Windows.Forms.MenuItem mnuWindow;
    private System.Windows.Forms.MenuItem mnuHelp;
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel1;
    private System.Windows.Forms.StatusBarPanel statusBarPanel2;
    private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.ComponentModel.Container components = null;
    private System.Windows.Forms.MenuItem mnuHoriz;
    private System.Windows.Forms.MenuItem mnuVert;
    private System.Windows.Forms.MenuItem mnuCascade;
    private System.Windows.Forms.MenuItem mnuCloseAll;

    #region Class Local Variables

    Payroll     PayForm;
    Employee    EmpForm;
    Scheduling  SkedForm;
    Training    TrainForm;

    #endregion

		public UberForm()
		{
			InitializeComponent();

      this.Menu = mainMenu1;
      mnuClose.Click    += new EventHandler(this.CloseMe);
      mnuEmp.Click      += new EventHandler(this.OpenWindow);
      mnuSked.Click     += new EventHandler(this.OpenWindow);
      mnuPayroll.Click  += new EventHandler(this.OpenWindow);
      mnuTrain.Click    += new EventHandler(this.OpenWindow);
      mnuCloseAll.Click += new EventHandler(this.CloseAllWindows);

      mnuHoriz.Click    += new EventHandler(this.ArrangeWindow);
      mnuVert.Click     += new EventHandler(this.ArrangeWindow);
      mnuCascade.Click  += new EventHandler(this.ArrangeWindow);

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
      this.mnuCloseAll = new System.Windows.Forms.MenuItem();
      this.mnuHelp = new System.Windows.Forms.MenuItem();
      this.statusBar1 = new System.Windows.Forms.StatusBar();
      this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
      this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
      this.mnuHoriz = new System.Windows.Forms.MenuItem();
      this.mnuVert = new System.Windows.Forms.MenuItem();
      this.mnuCascade = new System.Windows.Forms.MenuItem();
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
      this.mnuWindow.MdiList = true;
      this.mnuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.mnuCloseAll,
                                                                              this.mnuHoriz,
                                                                              this.mnuVert,
                                                                              this.mnuCascade});
      this.mnuWindow.Text = "Window";
      // 
      // mnuCloseAll
      // 
      this.mnuCloseAll.Index = 0;
      this.mnuCloseAll.Text = "Close All";
      // 
      // mnuHelp
      // 
      this.mnuHelp.Index = 3;
      this.mnuHelp.Text = "Help";
      // 
      // statusBar1
      // 
      this.statusBar1.Location = new System.Drawing.Point(0, 549);
      this.statusBar1.Name = "statusBar1";
      this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                  this.statusBarPanel1,
                                                                                  this.statusBarPanel2,
                                                                                  this.statusBarPanel3});
      this.statusBar1.ShowPanels = true;
      this.statusBar1.Size = new System.Drawing.Size(792, 24);
      this.statusBar1.TabIndex = 1;
      this.statusBar1.Text = "statusBar1";
      // 
      // statusBarPanel1
      // 
      this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
      this.statusBarPanel1.Text = "Employee Screen";
      this.statusBarPanel1.Width = 599;
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
      // mnuHoriz
      // 
      this.mnuHoriz.Index = 1;
      this.mnuHoriz.Text = "Tile Horizontally";
      // 
      // mnuVert
      // 
      this.mnuVert.Index = 2;
      this.mnuVert.Text = "Time Vertically";
      // 
      // mnuCascade
      // 
      this.mnuCascade.Index = 3;
      this.mnuCascade.Text = "Cascade";
      // 
      // UberForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(792, 573);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.statusBar1});
      this.IsMdiContainer = true;
      this.Name = "UberForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "HR Program";
      this.Load += new System.EventHandler(this.UberForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new UberForm());
		}

    private void UberForm_Load(object sender, System.EventArgs e)
    {
    }

    #region events

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
          EmpForm.MdiParent = this;
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
          TrainForm.MdiParent = this;
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
          PayForm.MdiParent = this;
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
          SkedForm.MdiParent = this;
          SkedForm.Disposed  += new EventHandler(this.ByByWindow);
          SkedForm.Show();
        }
        else
          SkedForm.Focus();
      }

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

    }

    private void ArrangeWindow(object sender, EventArgs e)
    {
      MenuItem m;

      if(sender is MenuItem)
        m = (MenuItem)sender;
      else
        return;

      if(m == mnuHoriz)
        this.LayoutMdi(MdiLayout.TileHorizontal);
      if(m == mnuVert)
        this.LayoutMdi(MdiLayout.TileVertical);
      if(m == mnuCascade)
        this.LayoutMdi(MdiLayout.Cascade);

    }

    #endregion
	}
}
