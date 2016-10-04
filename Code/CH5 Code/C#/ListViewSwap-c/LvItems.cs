using System;
using System.Windows.Forms;
using System.Collections;

namespace ListViewSwap_c
{
	/// <summary>
	/// Summary description for LvItems.
	/// </summary>
	public class LvItems
	{
    private ArrayList mCol;

		public LvItems()
		{
      mCol = new ArrayList();
		}

    /// <summary>
    /// Add a string to an array of ListViewItems
    /// </summary>
    /// <param name="val"></param>
    public void Add(string val)
    {
      mCol.Add(new ListViewItem(val));
    }

    /// <summary>
    /// Add a ListViewItem to an array of ListViewItems
    /// </summary>
    /// <param name="val"></param>
    public void Add(ListViewItem val)
    {
      mCol.Add(val);
    }

    /// <summary>
    /// Gets a ListViewItem array
    /// </summary>
    public ListViewItem[] Items
    {
      get
      {
        mCol.TrimToSize();
        ListViewItem[] lvw = new ListViewItem[mCol.Count];
        mCol.CopyTo(lvw, 0);
        return lvw;
      }
    }
  }
}




