using System;

namespace GridRestrict_c
{
	/// <summary>
	/// This class contains information about a town.
	/// </summary>
  public class Town
  {
    private string mName;
    private string mCounty;
    private string mState;
    private string mMayor;
    private string mZip;
    private float  mMillRate;

    public string Name
    {
      get { return mName; }
      set { mName = value; }
    }

    public string County
    {
      get { return mCounty; }
      set { mCounty = value; }
    }

    public string State
    {
      get { return mState; }
      set { mState = value; }
    }

    public string Mayor
    {
      get { return mMayor; }
      set { mMayor = value; }
    }

    public string Zip
    {
      get { return mZip; }
      set { mZip = value; }
    }

    public float MillRate
    {
      get { return mMillRate; }
      set { mMillRate = value; }
    }

  }
}
