using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace DB_data_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.ListBox lstParts;
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();

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
      this.lstParts = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // lstParts
      // 
      this.lstParts.Location = new System.Drawing.Point(32, 32);
      this.lstParts.Name = "lstParts";
      this.lstParts.Size = new System.Drawing.Size(208, 173);
      this.lstParts.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(292, 273);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lstParts});
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
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
      string Provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyDB.MDB";
      // create Objects of ADOConnection and ADOCommand
      OleDbConnection myConn = new OleDbConnection(Provider);
      string strSQL = "SELECT * FROM autoparts" ;
      OleDbCommand myCmd = new OleDbCommand( strSQL, myConn );
      OleDbDataReader datareader = null;
      try
      {

        myConn.Open();
        datareader = myCmd.ExecuteReader();
        while (datareader.Read() )
        {
          lstParts.Items.Add(datareader["au_PartName"]);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Database Error: {0}", ex.Message);
      }
      finally
      {
        myConn.Close();
      }
    }
	}
}
