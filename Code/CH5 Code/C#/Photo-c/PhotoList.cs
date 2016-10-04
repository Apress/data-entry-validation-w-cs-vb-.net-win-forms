using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Photo_c
{
	/// <summary>
	/// Class that holds all photographs regardless of classification
	/// </summary>
	public class PhotoList
	{
    ArrayList mPics;

    public PhotoList()
    {
      mPics = new ArrayList();

      //Normally you would detect these pictures and load them.
      mPics.Add(new Photo("desert1.jpg"));
      mPics.Add(new Photo("desert2.jpg"));
      mPics.Add(new Photo("desert3.jpg"));
      mPics.Add(new Photo("fields1.jpg"));
      mPics.Add(new Photo("fields2.jpg"));
      mPics.Add(new Photo("flowers1.jpg"));
      mPics.Add(new Photo("flowers2.jpg"));
      mPics.Add(new Photo("flowers3.jpg"));
      mPics.Add(new Photo("flowers4.jpg"));
      mPics.Add(new Photo("sea1.jpg"));
      mPics.Add(new Photo("sea2.jpg"));
      mPics.Add(new Photo("sea3.jpg"));
      mPics.Add(new Photo("sea4.jpg"));
      mPics.Add(new Photo("spring1.jpg"));
      mPics.Add(new Photo("spring2.jpg"));
      mPics.Add(new Photo("spring3.jpg"));
      mPics.TrimToSize();
    }

    /// <summary>
    /// Gets an Image array
    /// </summary>
    public ListViewItem[] Items
    {
      get
      {
        mPics.TrimToSize();
        ListViewItem[] lst = new ListViewItem[mPics.Count];


        ArrayList aList = new ArrayList();
        foreach(Photo p in mPics)
        {
          ListViewItem l = new ListViewItem(p.Name);
          l.Tag = p;
          l.SubItems.Add(p.Date);
          l.SubItems.Add(p.Location);
          l.SubItems.Add("JPG");

          aList.Add(l);
        }
        aList.TrimToSize();
        aList.CopyTo(lst, 0);
        return lst;
      }
    }
  }
}
