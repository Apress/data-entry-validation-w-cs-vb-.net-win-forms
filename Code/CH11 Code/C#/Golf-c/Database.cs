using System;

namespace Golf_c
{
  /// <summary>
  /// This is the database abstraction code.
  /// Note that the rest of the program knows nothing 
  /// about the database or even that there is one.
  /// The only thing it knows about is the GolfCourse collection
  /// </summary>
  public class Database
  {

    #region locals

    public ICourseInfos GolfCourses;

    #endregion
    
    public Database()
		{
      GolfCourses = new ICourseInfos();

      //You could either put some code here to get the complete database at the 
      //start or you could make a mehtod that needs to be called explicitly to 
      //do it. This database, even after years of playing, would be very small.  
      //Caching the whole thing in memory is not a big deal.

      //This simulates getting the data from a database.
      GetGolfCourses();
    }

    public void SaveCourse(ICourseInfo GolfCourse)
    {

      if(GolfCourses.Item(GolfCourse.Name) == null)
        GolfCourses.Add(GolfCourse);

      //Put some code in here to save to a database.
    }

    private void GetGolfCourses()
    {
      //Go out to the database and get the golf course info here
      ICourseInfo course = new ICourseInfo();
      course.NumberOfHoles  = 9;
      course.Name           = "My Back Yard";
      course.Par            = CoursePar._35;
      course.Slope          = 127;

      Tees tee;
      for(int k=0; k<course.Hole.Count; k++)
      {
        tee = (Tees)course.Hole[k];
        tee.BlueDistance    = 450;
        tee.WhiteDistance   = 430;
        tee.RedDistance     = 400;
        tee.Par             = k<5 ? 4 : 5;
        tee.HoleNumber      = k+1;
      }

      IScoreCardInfo card = new IScoreCardInfo();
      card.PlayDate = DateTime.Now;

      IHoleDetailInfo detail;
      for(int k=0; k<course.NumberOfHoles; k++)
      {
        detail = new IHoleDetailInfo();
        detail.Hole = k+1;
        detail.TeeClub = GolfClubs.Driver;
        detail.HitFairway = true;
        detail.ScondClub = GolfClubs.Nine_wood;
        detail.GoodSecondShot = true;
        detail.ShotsToGreen = 2;
        detail.Putts = 2;
        detail.TotalShots = 4;
        detail.Par = ((Tees)course.Hole[k]).Par;
        detail.TeeBox = YardMarker.White;
        card.holes.Add(detail);
      }
      course.ScoreCards.Add(card);

      GolfCourses.Add(course);

    }
	}
}
