using System;
using System.IO;
using System.Drawing;

namespace Photo_c
{
	/// <summary>
	/// class that has a photographic memory :)
	/// </summary>
  public class Photo
  {
    Image mPic;
    string mName;
    string mLocation;
    string mDateShot;

    public Photo(string picname)
    {
      mPic = Image.FromFile(picname);
      mName = Path.GetFileNameWithoutExtension(picname);
      mDateShot = DateTime.Today.ToShortDateString();
      mLocation = mName;
    }

    public override string ToString(){ return "Photo"; }

    public string Location  { get {return mLocation;} }
    public string Name      { get {return mName;} }
    public string Date      { get {return mDateShot;} }
    public Image Picture    { get {return mPic;} }
  }
}
