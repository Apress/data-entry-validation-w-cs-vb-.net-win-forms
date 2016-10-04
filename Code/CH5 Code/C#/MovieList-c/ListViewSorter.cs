using System;
using System.Windows.Forms;
using System.Collections;

namespace MovieList_c
{
	/// <summary>
	/// This class sorts a ListView control by column
	/// </summary>
	public class ListViewSorter: IComparer
	{
    private int       mCol;
    private SortOrder mOrder;

    public ListViewSorter(int column, SortOrder order) 
    {
      mCol=column;
      mOrder = order;
    }
    public int Compare(object x, object y) 
    {
      int returnVal = String.Compare(((ListViewItem)x).SubItems[mCol].Text,
        ((ListViewItem)y).SubItems[mCol].Text);
      if(mOrder == SortOrder.Descending)
        return (returnVal *= -1);
      else
        return returnVal;
    }
  }

}
