Option Strict On

''/ <summary>
''/ This is the database abstraction code.
''/ Note that the rest of the program knows nothing 
''/ about the database or even that there is one.
''/ The only thing it knows about is the GolfCourse collection
''/ This database abstraction includes some multithreaded code.
''/ </summary>
Public Class Database

#Region "locals"

  Public GolfCourses As ICourseInfos

#End Region

  Public Sub New()
    GolfCourses = New ICourseInfos()

    'You could either put some code here to get the complete database at the 
    'start or you could make a mehtod that needs to be called explicitly to 
    'do it. This database, even after years of playing, would be very small.  
    'Caching the whole thing in memory is not a big deal.

    'This simulates getting the data from a database.

    GetGolfCourses()
  End Sub

  Public Sub SaveCourse(ByVal GolfCourse As ICourseInfo)

    If GolfCourses.Item(GolfCourse.Name) Is Nothing Then
      GolfCourses.Add(GolfCourse)
    End If

    'Put some code in here to save to a database.
  End Sub

  Private Sub GetGolfCourses()
    'Go out to the database and get the golf course info here
    Dim course As ICourseInfo = New ICourseInfo()
    course.NumberOfHoles = 9
    course.Name = "My Back Yard"
    course.Par = CoursePar._35
    course.Slope = 127

    Dim tee As Tees
    Dim k As Int32
    For k = 0 To course.Hole.Count - 1
      tee = CType(course.Hole(k), Tees)
      tee.BlueDistance = 450
      tee.WhiteDistance = 430
      tee.RedDistance = 400
      If k < 5 Then
        tee.Par = 4
      Else
        tee.Par = 5
      End If
      tee.HoleNumber = k + 1
    Next

    Dim card As IScoreCardInfo = New IScoreCardInfo()
    card.PlayDate = DateTime.Now

    Dim detail As IHoleDetailInfo

    For k = 0 To course.NumberOfHoles - 1
      detail = New IHoleDetailInfo()
      detail.Hole = k + 1
      detail.TeeClub = GolfClubs.Driver
      detail.HitFairway = True
      detail.ScondClub = GolfClubs.Nine_wood
      detail.GoodSecondShot = True
      detail.ShotsToGreen = 2
      detail.Putts = 2
      detail.TotalShots = 4
      detail.Par = (CType(course.Hole(k), Tees)).Par
      detail.TeeBox = YardMarker.White
      card.holes.Add(detail)
    Next
    course.ScoreCards.Add(card)

    GolfCourses.Add(course)

  End Sub

End Class
