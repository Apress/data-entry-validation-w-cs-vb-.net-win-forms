using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Golf_c
{
	/// <summary>
	/// This program is intended to bring together most aspects of the data entry and validation
	/// chapters in this book.
	/// 
	/// It is not a complete program but can easily be made so.
	/// </summary>
	public class GolfStat : System.Windows.Forms.Form
	{


    #region locals

    public Database db;

    #endregion

    private System.Windows.Forms.MainMenu mnu;
    private System.ComponentModel.Container components = null;

		public GolfStat()
		{
			InitializeComponent();

      InitScreen();
      db = new Database();
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
      this.mnu = new System.Windows.Forms.MainMenu();
      // 
      // GolfStat
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(792, 566);
      this.IsMdiContainer = true;
      this.Menu = this.mnu;
      this.Name = "GolfStat";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "GolfStat";
      this.Load += new System.EventHandler(this.GolfStat_Load);

    }
		#endregion

    [STAThread]
    static void Main() 
    {
      Application.Run(new GolfStat());
    }


    private void GolfStat_Load(object sender, System.EventArgs e)
    {
    }

    private void InitScreen()
    {
      MenuItem mi = mnu.MenuItems.Add("&File");
      mi.MenuItems.Add("&Edit Course", new EventHandler(EditCourse));
      mi.MenuItems.Add("-");
      mi.MenuItems.Add("&Save",        new EventHandler(SaveCourse));
      mi.MenuItems.Add("Save &As...",  new EventHandler(SaveCourseAs));
      mi.MenuItems.Add("-");
      mi.MenuItems.Add("&Print");
      mi.MenuItems.Add("-");
      mi.MenuItems.Add("E&xit",        new EventHandler(ProgramExit));      

      mi = mnu.MenuItems.Add("&Statistics", new EventHandler(Stats));

    }

    #region Menu events

    private void EditCourse(object sender, EventArgs e)
    {
      Course frm = new Course();
      frm.MdiParent = this;
      frm.Show();
    }

    private void Stats(object sender, EventArgs e)
    {
      Statistics frm = new Statistics();
      frm.MdiParent  = this;
      frm.Show();
    }

    private void SaveCourse(object sender, EventArgs e)
    {
    }

    private void SaveCourseAs(object sender, EventArgs e)
    {
    }

    private void ProgramExit(object sender, EventArgs e)
    {
    }


    #endregion



	}
}
