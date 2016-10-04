using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace MovieList_c
{
  /// <summary>
  /// Summary description for MovieList.
  /// </summary>
  public class MovieList
  {
    private const string OUT = "Out";
    private const string INHOUSE = "In";

    private ArrayList mCol;
    private char      mDelimiter = '^';
    private string    mGenre;

    public MovieList()
    {
      mCol = new ArrayList();
    }

    public MovieList(string fname)
    {
      string buffer;

      mCol = new ArrayList();
      FileInfo fIn = new FileInfo(fname);
      try
      {
        StreamReader sr = new StreamReader( fIn.OpenRead() );
        while (sr.Peek() != -1)
        {
          buffer = sr.ReadLine();
          string[] List = buffer.Split(mDelimiter);
          if(List.GetLength(0) == 1)
          {
            if(buffer != string.Empty)
              mGenre = buffer;
          }
          else if(List.GetLength(0) > 1)
          {
            ListViewItem l = new ListViewItem(List);
            l.Tag = new Movie(l.Text);
            mCol.Add(l);
          }
        }
        sr.Close();
      }
      catch(Exception e)
      {
        MessageBox.Show("Unable to read file " + fname);
        throw e;
      }

    }

    public override string ToString() { return mGenre; }
    public string Genre { get{return mGenre;} }

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
    /// Remove a ListViewItem from the array of ListViewItems
    /// </summary>
    /// <param name="val"></param>
    public void Remove(ListViewItem val)
    {
      mCol.Remove(val);
    }

    /// <summary>
    /// Checkout a movie
    /// </summary>
    /// <param name="val"></param>
    public bool CheckOut(ListViewItem val)
    {
      string stock = val.SubItems[val.SubItems.Count-1].Text;

      if(stock == OUT)
        return false;

      mCol.Remove(val);
      val.SubItems[val.SubItems.Count-1].Text = OUT;
      mCol.Add(val);
      return true;
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
