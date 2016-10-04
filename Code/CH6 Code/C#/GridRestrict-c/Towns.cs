using System;
using System.Data;

namespace GridRestrict_c
{
  /// <summary>
  /// static class that get information about towns in a state from 
  /// an Access Database.
  /// 
  /// This is an abstraction of the data from main program.  I can change the
  /// way data is obtained and its source at any time without having to change 
  /// the interface to the data from the outside.  This is a good thing!
  /// </summary>
	public class Towns
	{
    private static DataSet DS;

		static Towns()
		{
      DS = new DataSet();
      DS.Tables.Add(GetData());
    }


    public bool Update(Town t)
    {
      //Code in here updates the database and
      //merges the new and old dataset
      return true;
    }


    #region public static properties

    public static float MinAllowedMillRate { get { return 12f; } }
    public static float MaxAllowedMillRate { get { return 99f; } }


      public static Town Hartford
    {
      get
      {
        Town t = null;
        DataTable dt = DS.Tables["TownInfo"];
        foreach(DataRow r in dt.Rows)
        {
          if(r["Name"].ToString() == "Hartford")
          {
            t = FillFromRow(r);
            break;
          }
        }
        return t;
      }
    }

    public static Town LosAngeles
    {
      get
      {
        Town t = null;
        DataTable dt = DS.Tables["TownInfo"];
        foreach(DataRow r in dt.Rows)
        {
          if(r["Name"].ToString() == "Los Angleles")
          {
            t = FillFromRow(r);
            break;
          }
        }
        return t;
      }
    }

    public static Town Orlando
    {
      get
      {
        Town t = null;
        DataTable dt = DS.Tables["TownInfo"];
        foreach(DataRow r in dt.Rows)
        {
          if(r["Name"].ToString() == "Orlando")
          {
            t = FillFromRow(r);
            break;
          }
        }
        return t;
      }
    }

    #endregion


    #region local methods

    private static Town FillFromRow(DataRow r)
    {
      Town t = new Town();
      t.Name      = (string)r["Name"];
      t.State     = (string)r["State"];
      t.County    = (string)r["County"];
      t.Mayor     = (string)r["Mayor"];
      t.Zip       = (string)r["Zip"];
      t.MillRate  = (float)r["MillRate"];
      return t;
    }

    private static DataTable GetData()
    {
      //Lets pretend that we are getting this data from a database table.
      //For now this shows that you can make the table by hand if you want to.
      //You can also get the data from an INI file, CFG file, or XML WEB service.
      //Any way you get the data it can be arranged in a table that has specific
      //demands.


      // Create a new DataTable.
      DataTable  dt = new DataTable("TownInfo");
      DataColumn dc;
      DataRow    dr;
 
      // Create town name
      dc            = new DataColumn();
      dc.DataType   = System.Type.GetType("System.String");
      dc.ColumnName = "Name";
      dc.ReadOnly   = true;
      dc.Unique     = true;
      // Add the column to the DataColumnCollection.
      dt.Columns.Add(dc);
 
      // Create state town is in
      dc            = new DataColumn();
      dc.DataType   = System.Type.GetType("System.String");
      dc.ColumnName = "State";
      dc.ReadOnly   = false;
      dc.Unique     = false;
      dt.Columns.Add(dc);
 
      // Create county town is in
      dc            = new DataColumn();
      dc.DataType   = System.Type.GetType("System.String");
      dc.ColumnName = "County";
      dc.ReadOnly   = false;
      dc.Unique     = false;
      dt.Columns.Add(dc);
 
      // Create mayor of town
      dc            = new DataColumn();
      dc.DataType   = System.Type.GetType("System.String");
      dc.ColumnName = "Mayor";
      dc.ReadOnly   = false;
      dc.Unique     = false;
      dt.Columns.Add(dc);
 
      // Create town zip code
      dc            = new DataColumn();
      dc.DataType   = System.Type.GetType("System.String");
      dc.ColumnName = "Zip";
      dc.ReadOnly   = false;
      dc.Unique     = true;
      dt.Columns.Add(dc);

      // Create town mill rate
      dc            = new DataColumn();
      dc.DataType   = System.Type.GetType("System.Single");
      dc.ColumnName = "MillRate";
      dc.ReadOnly   = false;
      dc.Unique     = false;
      dt.Columns.Add(dc);
 
      // Create 4 DataRow objects that represent towns.  Add them to the table
      dt.Rows.Add(new object[] {"Hartford", "CT", "Hartford", 
                                "Mike", "06011", 45.23f } );
      dt.Rows.Add(new object[] {"Los Angleles", "CA", "LA", 
                                "Fred", "23456", 64.85f } );
      dt.Rows.Add(new object[] {"Orlando", "FL", "Kissime", 
                                "Mikey", "45376", 25.00f } );

      return dt;
    }

    #endregion

	}
}
