using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GridRestrict_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.DataGrid dg1;

		private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      //Create a new data set with a table
      DataSet   DS  = new DataSet();
      DataTable DT  = MakeTable();
      
      Town t = Towns.Hartford;
      DT.Rows.Add(new object[] {t.Name, t.State, t.County, t.MillRate});
      t = Towns.LosAngeles;
      DT.Rows.Add(new object[] {t.Name, t.State, t.County, t.MillRate});
      t = Towns.Orlando;
      DT.Rows.Add(new object[] {t.Name, t.State, t.County, t.MillRate});
      DT.AcceptChanges();  //A base comparison to reject changes if necessary

      //Add table to data set
      //Only one table so assign source directly to it.
      DS.Tables.Add(DT);
      dg1.DataSource = DS;
      dg1.DataMember = "SomeTowns";

      DT.ColumnChanged += new DataColumnChangeEventHandler(this.DataChanged);
      dg1.MouseDown    += new MouseEventHandler(this.Grid_MouseDown);

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
      this.dg1 = new System.Windows.Forms.DataGrid();
      ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
      this.SuspendLayout();
      // 
      // dg1
      // 
      this.dg1.DataMember = "";
      this.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dg1.Location = new System.Drawing.Point(24, 24);
      this.dg1.Name = "dg1";
      this.dg1.Size = new System.Drawing.Size(520, 296);
      this.dg1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(568, 382);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dg1});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
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


    #region event code

    private void DataChanged(object sender, DataColumnChangeEventArgs e)
    {
      DataTable dt = (DataTable)sender;
      if (e.Column.ColumnName.Equals("MillRate"))
      {
        if ((float)e.ProposedValue < Towns.MinAllowedMillRate || 
            (float)e.ProposedValue > Towns.MaxAllowedMillRate)
        {
          e.Row.RowError = 
                "You tried to enter a value outside accepted parameters!";
          string s = "Mill Rate cannot be < " + 
                     Towns.MinAllowedMillRate.ToString() + 
                     "\n Mill Rate cannot be > " + 
                     Towns.MaxAllowedMillRate.ToString();
          e.Row.SetColumnError(e.Column, s);

          //An error object is put up next to the row and cell
          dt.RejectChanges();
          //Yes folks, you can use VB commands in C#.
          Microsoft.VisualBasic.Interaction.Beep();
        }
        else
          dt.AcceptChanges();
      }
    }

    private void Grid_MouseDown(object sender, MouseEventArgs e)
    {
      // Use the DataGrid control's HitTest method with the x and y properties.
      //I use this event to clear erros in the current row.
      DataGrid.HitTestInfo GridHit = dg1.HitTest(e.X,e.Y);

      if(GridHit.Type == DataGrid.HitTestType.Cell)
      {
        DataSet DS = (DataSet)dg1.DataSource;
        if(DS.HasErrors)
        {
          DataTable DT = DS.Tables[dg1.DataMember];
          DT.Rows[GridHit.Row].ClearErrors();
        }
      }
    }
 
    #endregion

    #region internal methods

    private DataTable MakeTable()
    {
      // Create a new DataTable.
      DataTable dt = new DataTable("SomeTowns");
      DataColumn dc;
      DataRow dr;
 
      dc = new DataColumn();
      dc.DataType= System.Type.GetType("System.String");
      dc.ColumnName = "Town Name";
      dc.Caption = "Town Name";
      dc.ReadOnly = true;
      dc.Unique = true;
      dt.Columns.Add(dc);
 
      dc = new DataColumn();
      dc.DataType= System.Type.GetType("System.String");
      dc.ColumnName = "State";
      dc.Caption = "State";
      dc.ReadOnly = true;
      dc.Unique = false;
      dt.Columns.Add(dc);
 
      dc = new DataColumn();
      dc.DataType= System.Type.GetType("System.String");
      dc.ColumnName = "County Name";
      dc.Caption = "County Name";
      dc.ReadOnly = true;
      dc.Unique = false;
      dt.Columns.Add(dc);
 
      dc = new DataColumn();
      dc.DataType= System.Type.GetType("System.Single");
      dc.ColumnName = "MillRate";
      dc.Caption = "MillRate";
      dc.ReadOnly = false;
      dc.Unique = false;
      dt.Columns.Add(dc);
 
      return dt;
    }

    #endregion


	}
}
