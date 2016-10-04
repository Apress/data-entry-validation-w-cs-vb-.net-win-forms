using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ContainedControls_c
{
  /// <summary>
  /// This class knows about itself
  /// </summary>
	public class SomePart
	{
    private ContextMenu mnu = new ContextMenu();
    private Decimal     mPrice;
    private string      mIdentifier;
    private string      mToolsNeeded;
    private ArrayList   mAr;
    private Image       mImg;
    static  int         mPartsCount=0;

    private struct menu_item
    {
      public MenuItem m;
      public string   s;
      public void DoSomething(string Title)
      {
        if(s != null)
          MessageBox.Show(s, Title);
        else
          MessageBox.Show("No Action", Title);
      }
    }

		public SomePart()
		{
      mPartsCount += 1;
      GetData();
      InitMenu();
    }

    // This private function is supposed to get the record for 
    // this part from the database and set up whatever fields are necessary
    private void GetData()
    {
      //Fake getting this from the database
      mPrice = 54.952M + mPartsCount;
      mToolsNeeded = "Linemans pliers\n Phillips screwdriver\n Half a brain";
      mIdentifier = "Some Part #" + mPartsCount.ToString();

      mImg = Image.FromFile(mPartsCount.ToString() + ".ico");

    }

    private void InitMenu()
    {
      mAr = new ArrayList();
      menu_item m;
      
      m = new menu_item();
      m.m = new MenuItem("Customer Price", new EventHandler(this.MenuHandler));
      m.s = "Customer Price = " + mPrice.ToString("C");
      mAr.Add(m);

      m = new menu_item();
      m.m = new MenuItem("Tools Needed", new EventHandler(this.MenuHandler));
      m.s = "Suggested Tools = " + mToolsNeeded;
      mAr.Add(m);

      for(int k=0; k<mPartsCount; k++)
      {
        m = new menu_item();
        m.m = new MenuItem("Item #" + k.ToString(), new EventHandler(this.MenuHandler));
        mAr.Add(m);
      }

      mAr.TrimToSize();

    }

    private void MenuHandler(object sender, EventArgs e)
    {
      MenuItem m = (MenuItem)sender;

      foreach(menu_item menu in mAr)
      {
        if (menu.m == m)
          menu.DoSomething(mIdentifier);
      }
    }

    public void ShowMenu(Control c, Point p)
    {
      foreach(menu_item m in mAr)
      {
        mnu.MenuItems.Add(m.m);
      }

      mnu.Show(c, p);
      mnu.MenuItems.Clear();
    }

    public Decimal Price { get{ return mPrice; } }
    public string  ID    { get{ return mIdentifier; } }
    public Image   img   { get{ return mImg; } }

	}
}
