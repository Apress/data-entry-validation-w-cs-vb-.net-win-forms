using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DB_grid_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

    #region class local variables
    
    string Provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyDB.MDB";
    OleDbConnection MyDB_Conn;
    OleDbDataAdapter SQL_parts;
    OleDbDataAdapter SQL_inv;
    OleDbCommandBuilder OLE_Parts;
    OleDbCommandBuilder OLE_Inv;

    #endregion

    private System.Windows.Forms.DataGrid dg1;
    private System.Windows.Forms.Button cmdParts;
    private System.Windows.Forms.Button cmdInventory;
    private System.Windows.Forms.Button cmdBoth;
    private System.Windows.Forms.Button cmdCommit;
		private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      cmdParts.Click      += new EventHandler(this.ViewParts);
      cmdInventory.Click  += new EventHandler(this.ViewInventory);
      cmdBoth.Click       += new EventHandler(this.ViewBoth);
      cmdCommit.Click     += new EventHandler(this.CommitChanges);
//      cmdCommit.Enabled = false;

      //First thing to do is establish the connection
      DataSet DS      = null;
      DataTable Parts = null;
      DataTable Inv   = null;

      MyDB_Conn = new OleDbConnection(Provider);

      //Now create some SQL statements that get data from different tables
      SQL_parts = new OleDbDataAdapter( "SELECT * FROM AutoParts", MyDB_Conn );
      SQL_parts.SelectCommand = 
                  new OleDbCommand("SELECT * FROM AutoParts", MyDB_Conn );
      OLE_Parts = new OleDbCommandBuilder(SQL_parts);

      SQL_inv   = new OleDbDataAdapter( "SELECT * FROM Inventory", MyDB_Conn );
      SQL_inv.SelectCommand = 
                  new OleDbCommand("SELECT * FROM Inventory", MyDB_Conn );
      OLE_Inv   = new OleDbCommandBuilder(SQL_inv);

      //You now have your SQL statements that get all data from both 
      //tables in the database.  Create a data set and add 2 tables
      DS      = new DataSet();
      Parts   = new DataTable("AutoParts");
      Inv     = new DataTable("Inventory");
      DS.Tables.Add(Parts);
      DS.Tables.Add(Inv);

      MyDB_Conn.Open();

      //Use the SQL data adapters to fill the tables via the SQL statements
      SQL_parts.Fill(DS, "AutoParts");
      SQL_inv.Fill(DS, "Inventory");


//      //Normally I would put this at the end.  I put it here
//      //to prove a point... The data set is disconnected and you
//      //can still work with it after the connection is gone.
//      //If you need to update the database you will need to keep 
//      //this connection.
//     MyDB_Conn.Close();
//     MyDB_Conn.Dispose();

      //Once I have the data tables filled in the data set I can manipulate the
      //existing columns.
      if(Parts != null)
      {
        Parts.Columns[0].Caption    = "ID";
        Parts.Columns[0].ColumnName = "ID";
        Parts.Columns[1].Caption    = "Name";
        Parts.Columns[1].ColumnName = "Name";
        Parts.Columns[2].Caption    = "Vehicle ID";
        Parts.Columns[2].ColumnName = "Vehicle ID";
        Parts.Columns[3].Caption    = "Notes";
        Parts.Columns[3].ColumnName = "Notes";
        //Make the last 2 columns invisible
        Parts.Columns[4].ColumnMapping = MappingType.Hidden;
        Parts.Columns[5].ColumnMapping = MappingType.Hidden;
      }
      
//      if(Inv != null)
//      {
//        Inv.Columns[0].Caption      = "Part Num";
//        Inv.Columns[0].ColumnName   = "Part Num";
//        Inv.Columns[1].Caption      = "Current Count";
//        Inv.Columns[1].ColumnName   = "Current Count";
//        Inv.Columns[2].Caption      = "Reorder Count";
//        Inv.Columns[2].ColumnName   = "Reorder Count";
//      }
      //Bind the table in the data source to the grid display
      dg1.SetDataBinding(DS, "AutoParts");

      //This object takes up space.  Get rid of them.
      if(DS != null)
        DS.Dispose();

    }

    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
        if(MyDB_Conn != null)
        {
          MyDB_Conn.Close();
          MyDB_Conn.Dispose();
        }
        if(SQL_inv != null)
          SQL_inv.Dispose();
        if(SQL_parts != null)
          SQL_parts.Dispose();
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
      this.cmdParts = new System.Windows.Forms.Button();
      this.cmdInventory = new System.Windows.Forms.Button();
      this.cmdBoth = new System.Windows.Forms.Button();
      this.cmdCommit = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
      this.SuspendLayout();
      // 
      // dg1
      // 
      this.dg1.DataMember = "";
      this.dg1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dg1.Location = new System.Drawing.Point(24, 40);
      this.dg1.Name = "dg1";
      this.dg1.Size = new System.Drawing.Size(584, 272);
      this.dg1.TabIndex = 0;
      // 
      // cmdParts
      // 
      this.cmdParts.Location = new System.Drawing.Point(40, 336);
      this.cmdParts.Name = "cmdParts";
      this.cmdParts.Size = new System.Drawing.Size(88, 32);
      this.cmdParts.TabIndex = 1;
      this.cmdParts.Text = "Parts";
      // 
      // cmdInventory
      // 
      this.cmdInventory.Location = new System.Drawing.Point(152, 336);
      this.cmdInventory.Name = "cmdInventory";
      this.cmdInventory.Size = new System.Drawing.Size(88, 32);
      this.cmdInventory.TabIndex = 2;
      this.cmdInventory.Text = "Inventory";
      // 
      // cmdBoth
      // 
      this.cmdBoth.Location = new System.Drawing.Point(264, 336);
      this.cmdBoth.Name = "cmdBoth";
      this.cmdBoth.Size = new System.Drawing.Size(88, 32);
      this.cmdBoth.TabIndex = 3;
      this.cmdBoth.Text = "Both";
      // 
      // cmdCommit
      // 
      this.cmdCommit.Location = new System.Drawing.Point(424, 336);
      this.cmdCommit.Name = "cmdCommit";
      this.cmdCommit.Size = new System.Drawing.Size(88, 32);
      this.cmdCommit.TabIndex = 4;
      this.cmdCommit.Text = "Commit";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(632, 381);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdCommit,
                                                                  this.cmdBoth,
                                                                  this.cmdInventory,
                                                                  this.cmdParts,
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

    #region events
    
    private void ViewParts(object sender, EventArgs e)
    {
      dg1.SetDataBinding(dg1.DataSource, "AutoParts");
    }

    private void ViewInventory(object sender, EventArgs e)
    {
      dg1.SetDataBinding(dg1.DataSource, "Inventory");
    }

    private void ViewBoth(object sender, EventArgs e)
    {
      //Setting this to a null string forces the top
      //level view.
      dg1.SetDataBinding(dg1.DataSource, "");
      dg1.Expand(-1);
    }

    private void CommitChanges(object sender, EventArgs e)
    {
      DataSet DS = (DataSet)dg1.DataSource;
      DataSet DS_Change = DS.GetChanges(DataRowState.Modified);
      //If no changes then obviously no new data set is formed
      if(DS_Change != null)
      {
        if(!DS_Change.HasErrors)
        {
          //get the data adapter and call update
          try
          {
            SQL_inv.Update(DS_Change, "Inventory");
            MessageBox.Show("Saving Iventory data successful!");
          }
          catch (Exception ex)
          {
            MessageBox.Show("Error Saving Iventory data\n{0}", ex.Message);
          }
        }
      }
    }

    #endregion

	}
}




