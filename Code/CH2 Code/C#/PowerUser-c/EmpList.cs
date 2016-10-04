using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PowerUser_c
{

  public class EmpList : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Button cmdOK;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cmdCancel;
    private System.Windows.Forms.ListView lstEmps;

    private System.ComponentModel.Container components = null;

    #region class local variables

    string[,] Employees = new string[,] {{"Person A", "500"},
                                         {"Person B", "502"},
                                         {"Person C", "501"},
                                         {"Person D", "503"}};

    #endregion

    public EmpList( bool ByEmployee )
    {
      InitializeComponent();

      cmdOK.Click     += new EventHandler(this.UnloadMe);
      cmdCancel.Click += new EventHandler(this.UnloadMe);

      lstEmps.Items.Clear();
      lstEmps.View = View.Details;
      lstEmps.GridLines = true;
      lstEmps.FullRowSelect = true;
      lstEmps.Sorting = SortOrder.Ascending;
      lstEmps.Scrollable = true;

      //Add column headers
      lstEmps.Columns.Add(ByEmployee ? "Name" : "Clock #", -2, 
                          HorizontalAlignment.Center);
      lstEmps.Columns.Add(ByEmployee ? "Clock #" : "Name", -2, 
                          HorizontalAlignment.Center);

      //Add some people
      for(int k=0; k<Employees.GetLength(0); k++)
      {
        ListViewItem main = new ListViewItem(Employees[k, ByEmployee ? 0 : 1]);
        main.SubItems.Add(Employees[k, ByEmployee ? 1 : 0]);
        lstEmps.Items.Add(main);
      }

      lstEmps.ColumnClick += new ColumnClickEventHandler(this.ChangeSortOrder);
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
      this.cmdOK = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.lstEmps = new System.Windows.Forms.ListView();
      this.SuspendLayout();
      // 
      // cmdOK
      // 
      this.cmdOK.Location = new System.Drawing.Point(16, 232);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.Size = new System.Drawing.Size(96, 32);
      this.cmdOK.TabIndex = 0;
      this.cmdOK.Text = "OK";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(208, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Employees";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // cmdCancel
      // 
      this.cmdCancel.Location = new System.Drawing.Point(128, 232);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(96, 32);
      this.cmdCancel.TabIndex = 3;
      this.cmdCancel.Text = "Cancel";
      // 
      // lstEmps
      // 
      this.lstEmps.Location = new System.Drawing.Point(16, 32);
      this.lstEmps.Name = "lstEmps";
      this.lstEmps.Size = new System.Drawing.Size(200, 184);
      this.lstEmps.TabIndex = 4;
      // 
      // EmpList
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(240, 273);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lstEmps,
                                                                  this.cmdCancel,
                                                                  this.label1,
                                                                  this.cmdOK});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EmpList";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Employees";
      this.Load += new System.EventHandler(this.EmpList_Load);
      this.ResumeLayout(false);

    }
		#endregion

    private void EmpList_Load(object sender, System.EventArgs e)
    {
    }

    private void UnloadMe(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ChangeSortOrder(object sender, ColumnClickEventArgs e)
    {
      if(lstEmps.Sorting == SortOrder.Ascending)
        lstEmps.Sorting = SortOrder.Descending;
      else
        lstEmps.Sorting = SortOrder.Ascending;

    }
	}
}
