using System;
using System.Collections;

namespace Golf_c
{
  /// <summary>
  /// Collections of courses and collections of scorecards
  /// </summary>
  /// 

  #region public enumerations

  public enum GolfClubs
  {
    One_iron,
    Two_Iron,
    Three_Iron,
    Four_Iron,
    Five_Iron,
    Six_Iron,
    Seven_Iron,
    Eight_Iron,
    Nine_Iron,
    PW,
    SW,
    GW,
    LW,
    Driver,
    Three_wood,
    Five_wood,
    Seven_wood,
    Nine_wood,
    Putter
  }

  public enum CoursePar
  {
    _27 = 27,
    _35 = 35,
    _36 = 36,
    _54 = 54,
    _70 = 70,
    _71 = 71,
    _72 = 72
  }

  public enum YardMarker
  {
    Red,
    White,
    Blue
  }

  #endregion

  public class Globals
  {
    public static int MinSlope{get{return 55;}}
    public static int MaxSlope{get{return 155;}}
    public static int SlopeLen
    {
      get
      {
        return(MaxSlope.ToString().Length > MinSlope.ToString().Length ? 
               MaxSlope.ToString().Length : MinSlope.ToString().Length);
      }
    }
    public static int NineHoles{get{return 9;}}
    public static int EighteenHoles{get{return 18;}}
  }


  //-----------------------------------------------------------------------------
  #region Courseinfo collection classes

  //This is a home grown strongly typed collection class and its object
  //Not only is it strongly typed but it allows me to hide some of the 
  //normal add/delete methods from other classes if need be.
  public class ICourseInfos : IEnumerable
  {
    //Slower than Hash table but more flexible
    //Can get item three ways
    //Most like VB type collection
    private SortedList      mCol;

    public ICourseInfos()
    {
      mCol = new  SortedList();
    }

    #region collection methods

    // enables foreach processing
    private mEnum GetEnumerator() 
    {
      return new mEnum(this);
    }

    //Property count
    public int Count
    {
      get { return mCol.Count; }
    }

    // ----- add method ------
    public void Add(ICourseInfo GolfCourse)
    {
      mCol.Add(GolfCourse.Name, GolfCourse);
    }

    // ----- overloaded remove method ------
    public void Remove(int Index)
    {
      mCol.RemoveAt(Index);
    }
    public void Remove(string key)
    {
      mCol.Remove(key);
    }

    // ----- overloaded item method ------
    public ICourseInfo Item(int index)
    {
      return (ICourseInfo) mCol.GetByIndex(index);
    }
    public ICourseInfo Item(string key)
    {
      return (ICourseInfo) mCol[key];
    }

    #endregion

    #region enumeration methods

    // Implement the GetEnumerator() method:
    IEnumerator IEnumerable.GetEnumerator() 
    {
      return GetEnumerator();
    }

    // Declare the enumerator and implement the IEnumerator interface:
    private class mEnum: IEnumerator 
    {
      private int nIndex;
      private ICourseInfos collection;

      // constructor. make the collection
      public mEnum(ICourseInfos coll) 
      {
        collection = coll;
        nIndex = -1;
      }

      // start over
      public void Reset() 
      {
        nIndex = -1;
      }

      // bump up the index
      public bool MoveNext() 
      {
        nIndex++;
        return(nIndex <  collection.mCol.Count);
      }

      // get the current object
      public ICourseInfo Current 
      {
        get {return (ICourseInfo) collection.mCol.GetByIndex(nIndex); }
      }

      // The current property on the IEnumerator interface:
      object IEnumerator.Current 
      {
        get { return(Current); }
      }

      #endregion
    }
  }

  public class ICourseInfo
  {
    #region locals

    private string    mName;
    private int       mLength;
    private int       mHoles;
    private int       mSlope;
    private CoursePar mPar;

    public ArrayList Hole = new ArrayList(); //Contains Tees objects
    public IScoreCardInfos  ScoreCards;

    #endregion

    public ICourseInfo()
    {
      mSlope = Globals.MinSlope;
      mName = "Undefined Course";
      ScoreCards = new IScoreCardInfos();
    }

    public ICourseInfo(string name)
    {
      mName = name;
      mSlope = Globals.MinSlope;
      NumberOfHoles = 9;
      ScoreCards = new IScoreCardInfos();
    }

    #region  Properties

    public string Name
    {
      get{return mName;}
      set{mName = value;}
    }

    public int Length
    {
      get
      {
        foreach(Tees Tee in Hole)
        {
          mLength += Tee.BlueDistance;
        }
        return mLength;
      }
 //     set{mLength = value;}
    }

    public int NumberOfHoles
    {
      get{return mHoles;}
      set
      {
        mHoles = value;
        Hole.Clear();
        for(int k=0; k<mHoles; k++)
        {
          Tees tee = new Tees();
          tee.HoleNumber = k+1;
          tee.BlueDistance = 0;
          tee.RedDistance = 0;
          tee.WhiteDistance = 0;
          Hole.Add(tee);
        }
        Hole.TrimToSize();
      }
    }

    public int Slope
    {
      get{return mSlope;}
      set{mSlope = value;}
    }

    public CoursePar Par
    {
      get{return mPar;}
      set{mPar = value;}
    }

    #endregion

    #region Methods

    public override string ToString()
    {
      return Name;
    }
    #endregion

  }

  public class Tees
  {
    private int mRedDistance;
    private int mBlueDistance;
    private int mWhiteDistance;
    private int mHoleNumber;
    private int mPar;

    public int RedDistance
    {
      //Only accept positive values
      get{return mRedDistance;}
      set{mRedDistance = value;}
    }
    public int BlueDistance
    {
      get{return mBlueDistance;}
      set{mBlueDistance = value;}
    }
    public int WhiteDistance
    {
      get{return mWhiteDistance;}
      set{mWhiteDistance = value;}
    }
    public int HoleNumber
    {
      get{return mHoleNumber;}
      set{mHoleNumber = value;}
    }
    public int Par
    {
      get{return mPar;}
      set{mPar = value;}
    }
  }

  #endregion

  //-----------------------------------------------------------------------------
  #region Scorecard collection classes

  public class IScoreCardInfos : IEnumerable
  {
    //Slower than Hash table but more flexible
    //Can get item three ways
    //Most like VB type collection
    private SortedList mCol;

    public IScoreCardInfos()
    {
      mCol = new  SortedList();
    }

    #region collection methods

    // enables foreach processing
    private mEnum GetEnumerator() 
    {
      return new mEnum(this);
    }

    //Property count
    public int Count
    {
      get { return mCol.Count; }
    }

    // ----- add method ------
    public void Add(IScoreCardInfo ScoreCard)
    {
      mCol.Add(ScoreCard.PlayDate, ScoreCard);
    }

    // ----- overloaded remove method ------
    public void Remove(int Index)
    {
      mCol.RemoveAt(Index);
    }
    public void Remove(string key)
    {
      mCol.Remove(key);
    }

    // ----- overloaded item method ------
    public IScoreCardInfo Item(int index)
    {
      return (IScoreCardInfo) mCol.GetByIndex(index);
    }
    public IScoreCardInfo Item(string key)
    {
      return (IScoreCardInfo) mCol[key];
    }

    #endregion

    #region enumeration methods

    // Implement the GetEnumerator() method:
    IEnumerator IEnumerable.GetEnumerator() 
    {
      return GetEnumerator();
    }

    // Declare the enumerator and implement the IEnumerator interface:
    private class mEnum: IEnumerator 
    {
      private int nIndex;
      private IScoreCardInfos collection;

      // constructor. make the collection
      public mEnum(IScoreCardInfos coll) 
      {
        collection = coll;
        nIndex = -1;
      }

      // start over
      public void Reset() 
      {
        nIndex = -1;
      }

      // bump up the index
      public bool MoveNext() 
      {
        nIndex++;
        return(nIndex <  collection.mCol.Count);
      }

      // get the current object
      public IScoreCardInfo Current 
      {
        get {return (IScoreCardInfo) collection.mCol.GetByIndex(nIndex); }
      }

      // The current property on the IEnumerator interface:
      object IEnumerator.Current 
      {
        get { return(Current); }
      }

      #endregion
    }
  }


  public class IScoreCardInfo
  {
    public IHoleDetailInfos holes;
    private DateTime mDate;

    public IScoreCardInfo()
    {
      holes = new IHoleDetailInfos();
      mDate = DateTime.Now;
    }

    public IScoreCardInfo(int numHoles)
    {
      holes = new IHoleDetailInfos();
      IHoleDetailInfo h;
      for(int k=0; k<numHoles; k++)
      {
        h = new IHoleDetailInfo();
        h.TotalShots = 0;
        h.Hole  = k+1;
        h.Putts = 0;
        holes.Add(h);
      }

      mDate = DateTime.Now;
    }

    public DateTime PlayDate
    {
      get{return mDate;}
      set{mDate = value;}
    }

    public int RoundScore
    {
      get
      {
        int score = 0;
        foreach(IHoleDetailInfo h in holes)
          score += h.TotalShots;
        return score;
      }
    }

  }

  #endregion

  //-----------------------------------------------------------------------------
  #region Hole Detail collection Classes

  public class IHoleDetailInfos : IEnumerable
  {
    //Slower than Hash table but more flexible
    //Can get item three ways
    //Most like VB type collection
    private SortedList mCol;

    public IHoleDetailInfos()
    {
      mCol = new  SortedList();
    }

    #region collection methods

    // enables foreach processing
    private mEnum GetEnumerator() 
    {
      return new mEnum(this);
    }

    //Property count
    public int Count
    {
      get { return mCol.Count; }
    }

    // ----- add method ------
    public void Add(IHoleDetailInfo hole)
    {
      mCol.Add(hole.ToString(), hole);
      mCol.TrimToSize();
    }

    // ----- overloaded remove method ------
    public void Remove(int Index)
    {
      mCol.RemoveAt(Index);
    }
    public void Remove(string key)
    {
      mCol.Remove(key);
    }

    // ----- overloaded item method ------
    public IHoleDetailInfo Item(int index)
    {
      return (IHoleDetailInfo) mCol.GetByIndex(index);
    }
    public IHoleDetailInfo Item(string key)
    {
      return (IHoleDetailInfo) mCol[key];
    }

    #endregion

    #region enumeration methods

    // Implement the GetEnumerator() method:
    IEnumerator IEnumerable.GetEnumerator() 
    {
      return GetEnumerator();
    }

    // Declare the enumerator and implement the IEnumerator interface:
    private class mEnum: IEnumerator 
    {
      private int nIndex;
      private IHoleDetailInfos collection;

      // constructor. make the collection
      public mEnum(IHoleDetailInfos coll) 
      {
        collection = coll;
        nIndex = -1;
      }

      // start over
      public void Reset() 
      {
        nIndex = -1;
      }

      // bump up the index
      public bool MoveNext() 
      {
        nIndex++;
        return(nIndex <  collection.mCol.Count);
      }

      // The current property on the IEnumerator interface:
      object IEnumerator.Current 
      {
        get { return(collection.mCol.GetByIndex(nIndex)); }
      }
    }

    #endregion
  }


  public class IHoleDetailInfo
  {
    #region Locals

    private YardMarker  mTeeBox;
    private int         mHole;
    private int         mPar;
    private GolfClubs   mTeeClub;
    private GolfClubs   mSecondClub;
    private bool        mHitfairway;
    private bool        mGood2Shot;
    private int         mShots2Green;
    private int         mPutts;
    private int         mTotalShots;

    #endregion

    public IHoleDetailInfo()
    {
      mTotalShots = 0;
    }

    public override string ToString()
    {
      return mHole.ToString();
    }

    #region Properties

    public YardMarker TeeBox
    {
      get{return mTeeBox;}
      set{mTeeBox = value;}
    }

    public GolfClubs ScondClub
    {
      get{return mSecondClub;}
      set{mSecondClub = value;}
    }

    public GolfClubs TeeClub
    {
      get{return mTeeClub;}
      set{mTeeClub = value;}
    }

    public bool GoodSecondShot
    {
      get{return mGood2Shot;}
      set{mGood2Shot = value;}
    }

    public bool HitFairway
    {
      get{return mHitfairway;}
      set{mHitfairway = value;}
    }

    public int TotalShots
    {
      get{return mTotalShots;}
      set{mTotalShots = value;}
    }

    public int Putts
    {
      get{return mPutts;}
      set{mPutts = value;}
    }

    public int ShotsToGreen
    {
      get{return mShots2Green;}
      set{mShots2Green = value;}
    }

    public bool GreenInReg
    {
      get{return((mPar - mShots2Green >= 2) ? true : false);}
    }

    public int Par
    {
      get{return mPar;}
      set{mPar = value;}
    }

    public int Hole
    {
      get{return mHole;}
      set{mHole = value;}
    }

    #endregion
  }

  #endregion

}
