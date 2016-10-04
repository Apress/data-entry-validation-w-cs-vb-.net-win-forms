
Imports System.Collections

#Region "public enumerations"

Public Enum GolfClubs
  One_iron
  Two_Iron
  Three_Iron
  Four_Iron
  Five_Iron
  Six_Iron
  Seven_Iron
  Eight_Iron
  Nine_Iron
  PW
  SW
  GW
  LW
  Driver
  Three_wood
  Five_wood
  Seven_wood
  Nine_wood
  Putter
End Enum

Public Enum CoursePar
  _27 = 27
  _35 = 35
  _36 = 36
  _54 = 54
  _70 = 70
  _71 = 71
  _72 = 72
End Enum

Public Enum YardMarker
  Red
  White
  Blue
End Enum

#End Region

Public Class Globals
  Public Shared ReadOnly Property MinSlope() As Int32
    Get
      Return 55
    End Get
  End Property
  Public Shared ReadOnly Property MaxSlope() As Int32
    Get
      Return 155
    End Get
  End Property
  Public Shared ReadOnly Property SlopeLen() As Int32
    Get
      Return IIf(MaxSlope.ToString.Length > MinSlope.ToString.Length, _
                 MaxSlope.ToString.Length, MinSlope.ToString.Length)
    End Get
  End Property
  Public Shared ReadOnly Property NineHoles() As Int32
    Get
      Return 9
    End Get
  End Property
  Public Shared ReadOnly Property EighteenHoles() As Int32
    Get
      Return 18
    End Get
  End Property
End Class

'-----------------------------------------------------------------------------
#Region "Courseinfo collection classes"

Public Class ICourseInfos
  Implements IEnumerable

  'Slower than Hash table but more flexible
  'Can get item three ways
  'Most like VB type collection
  Private mCol As SortedList

  Public Sub New()
    mCol = New SortedList()
  End Sub

  ' enables foreach processing
  Private Function GetMyEnumerator() As mEnum
    Return New mEnum(Me)
  End Function

  ' Implement the GetEnumerator() method:
  Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
    Return GetMyEnumerator()
  End Function

  'Property count
  Public ReadOnly Property Count() As Int32
    Get
      Return mCol.Count
    End Get
  End Property

  ' ----- add method ------
  Public Sub Add(ByVal card As ICourseInfo)
    mCol.Add(card.ToString(), card)
    mCol.TrimToSize()
  End Sub

  ' ----- overloaded remove method ------
  Public Sub Remove(ByVal Index As Int32)
    mCol.RemoveAt(Index)
  End Sub

  Public Sub Remove(ByVal key As String)
    mCol.Remove(key)
  End Sub

  ' ----- overloaded item method ------
  Public Function Item(ByVal index As Int32) As ICourseInfo
    Return CType(mCol.GetByIndex(index), ICourseInfo)
  End Function

  Public Function Item(ByVal key As String) As ICourseInfo
    Return CType(mCol(key), ICourseInfo)
  End Function

  ' Declare the enumerator and implement the IEnumerator interface:
  Private Class mEnum
    Implements IEnumerator

    Private nIndex As Int32
    Private collection As ICourseInfos

    ' constructor. make the collection
    Public Sub New(ByVal coll As ICourseInfos)
      collection = coll
      nIndex = -1
    End Sub

    ' start over
    Public Sub Reset() Implements IEnumerator.Reset
      nIndex = -1
    End Sub

    ' bump up the index
    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
      nIndex += 1
      Return (nIndex < collection.mCol.Count)
    End Function

    ' get the current object
    Public ReadOnly Property GetCurrent() As ICourseInfo
      Get
        Return CType(collection.mCol.GetByIndex(nIndex), ICourseInfo)
      End Get
    End Property

    ' The current property on the IEnumerator interface:
    Public ReadOnly Property Current() As Object Implements IEnumerator.Current
      Get
        Return GetCurrent
      End Get
    End Property
  End Class

End Class


Public Class ICourseInfo

#Region "locals"

  Private mName As String
  Private mLength As Int32
  Private mHoles As Int32
  Private mSlope As Int32
  Private mPar As CoursePar

  Public Hole As ArrayList = New ArrayList()  'Contains Tees objects
  Public ScoreCards As IScoreCardInfos

#End Region

  Public Sub New()
    mSlope = Globals.MinSlope
    mName = "Undefined Course"
    ScoreCards = New IScoreCardInfos()
  End Sub

  Public Sub New(ByVal name As String)
    mName = name
    mSlope = Globals.MinSlope
    NumberOfHoles = 9
    ScoreCards = New IScoreCardInfos()
  End Sub

#Region "Properties"

  Public Property Name() As String
    Get
      Return mName
    End Get
    Set(ByVal Value As String)
      mName = Value
    End Set
  End Property

  Public ReadOnly Property Length() As Int32
    Get
      Dim Tee As Tees
      For Each Tee In Hole
        mLength += Tee.BlueDistance
      Next
      Return mLength
    End Get
    '     set{mLength = value;}
  End Property

  Public Property NumberOfHoles() As Int32
    Get
      Return mHoles
    End Get
    Set(ByVal Value As Int32)

      mHoles = Value
      Hole.Clear()
      Dim k As Int32
      Dim tee As Tees
      For k = 0 To mHoles - 1
        tee = New Tees()
        tee.HoleNumber = k + 1
        tee.BlueDistance = 0
        tee.RedDistance = 0
        tee.WhiteDistance = 0
        Hole.Add(tee)
      Next
      Hole.TrimToSize()
    End Set
  End Property

  Public Property Slope() As Int32
    Get
      Return mSlope
    End Get
    Set(ByVal Value As Int32)
      mSlope = Value
    End Set
  End Property

  Public Property Par() As CoursePar
    Get
      Return mPar
    End Get
    Set(ByVal Value As CoursePar)
      mPar = Value
    End Set
  End Property

#End Region

#Region "Methods"

  Public Overrides Function ToString() As String
    Return Name
  End Function

#End Region

End Class


Public Class Tees
  Private mRedDistance As Int32
  Private mBlueDistance As Int32
  Private mWhiteDistance As Int32
  Private mHoleNumber As Int32
  Private mPar As Int32

  Public Property RedDistance() As Int32
    'Only accept positive values
    Get
      Return mRedDistance
    End Get
    Set(ByVal Value As Int32)
      mRedDistance = Value
    End Set
  End Property

  Public Property BlueDistance() As Int32
    'Only accept positive values
    Get
      Return mBlueDistance
    End Get
    Set(ByVal Value As Int32)
      mBlueDistance = Value
    End Set
  End Property

  Public Property WhiteDistance() As Int32
    'Only accept positive values
    Get
      Return mWhiteDistance
    End Get
    Set(ByVal Value As Int32)
      mWhiteDistance = Value
    End Set
  End Property

  Public Property HoleNumber() As Int32
    'Only accept positive values
    Get
      Return mHoleNumber
    End Get
    Set(ByVal Value As Int32)
      mHoleNumber = Value
    End Set
  End Property

  Public Property Par() As Int32
    'Only accept positive values
    Get
      Return mPar
    End Get
    Set(ByVal Value As Int32)
      mPar = Value
    End Set
  End Property

End Class

#End Region

'-----------------------------------------------------------------------------
#Region "ScoreCard classes"

Public Class IScoreCardInfos
  Implements IEnumerable

  'Slower than Hash table but more flexible
  'Can get item three ways
  'Most like VB type collection
  Private mCol As SortedList

  Public Sub New()
    mCol = New SortedList()
  End Sub

  ' enables foreach processing
  Private Function GetMyEnumerator() As mEnum
    Return New mEnum(Me)
  End Function

  ' Implement the GetEnumerator() method:
  Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
    Return GetMyEnumerator()
  End Function

  'Property count
  Public ReadOnly Property Count() As Int32
    Get
      Return mCol.Count
    End Get
  End Property

  ' ----- add method ------
  Public Sub Add(ByVal ScoreCard As IScoreCardInfo)
    mCol.Add(ScoreCard.PlayDate, ScoreCard)
  End Sub

  ' ----- overloaded remove method ------
  Public Sub Remove(ByVal Index As Int32)
    mCol.RemoveAt(Index)
  End Sub

  Public Sub Remove(ByVal key As String)
    mCol.Remove(key)
  End Sub

  ' ----- overloaded item method ------
  Public Function Item(ByVal index As Int32) As IScoreCardInfo
    Return CType(mCol.GetByIndex(index), IScoreCardInfo)
  End Function

  Public Function Item(ByVal key As String) As IScoreCardInfo
    Return CType(mCol(key), IScoreCardInfo)
  End Function

  ' Declare the enumerator and implement the IEnumerator interface:
  Private Class mEnum
    Implements IEnumerator

    Private nIndex As Int32
    Private collection As IScoreCardInfos

    ' constructor. make the collection
    Public Sub New(ByVal coll As IScoreCardInfos)
      collection = coll
      nIndex = -1
    End Sub

    ' start over
    Public Sub Reset() Implements IEnumerator.Reset
      nIndex = -1
    End Sub

    ' bump up the index
    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
      nIndex += 1
      Return (nIndex < collection.mCol.Count)
    End Function

    ' get the current object
    Public ReadOnly Property GetCurrent() As IScoreCardInfo
      Get
        Return CType(collection.mCol.GetByIndex(nIndex), IScoreCardInfo)
      End Get
    End Property

    ' The current property on the IEnumerator interface:
    Public ReadOnly Property Current() As Object Implements IEnumerator.Current
      Get
        Return GetCurrent
      End Get
    End Property
  End Class

End Class


Public Class IScoreCardInfo

  Public holes As IHoleDetailInfos
  Private mDate As DateTime

  Public Sub New()
    holes = New IHoleDetailInfos()
    mDate = DateTime.Now
  End Sub

  Public Sub New(ByVal numHoles As Int32)

    holes = New IHoleDetailInfos()
    Dim h As IHoleDetailInfo
    Dim k As Int32
    For k = 0 To numHoles - 1
      h = New IHoleDetailInfo()
      h.TotalShots = 0
      h.Hole = k + 1
      h.Putts = 0
      holes.Add(h)
    Next

    mDate = DateTime.Now
  End Sub

  Public Property PlayDate() As DateTime
    Get
      Return mDate
    End Get
    Set(ByVal Value As DateTime)
      mDate = Value
    End Set
  End Property

  Public ReadOnly Property RoundScore() As Int32
    Get
      Dim score As Int32 = 0
      Dim h As IHoleDetailInfo
      For Each h In holes
        score += h.TotalShots
      Next
      Return score
    End Get
  End Property

End Class

#End Region

'-----------------------------------------------------------------------------
#Region "Hole Detail collection Classes"

Public Class IHoleDetailInfos
  Implements IEnumerable

  'Slower than Hash table but more flexible
  'Can get item three ways
  'Most like VB type collection
  Private mCol As SortedList

  Public Sub New()
    mCol = New SortedList()
  End Sub

  ' enables foreach processing
  Private Function GetMyEnumerator() As mEnum
    Return New mEnum(Me)
  End Function

  ' Implement the GetEnumerator() method:
  Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
    Return GetMyEnumerator()
  End Function

  'Property count
  Public ReadOnly Property Count() As Int32
    Get
      Return mCol.Count
    End Get
  End Property

  ' ----- add method ------
  Public Sub Add(ByVal hole As IHoleDetailInfo)
    mCol.Add(hole.ToString(), hole)
    mCol.TrimToSize()
  End Sub

  ' ----- overloaded remove method ------
  Public Sub Remove(ByVal Index As Int32)
    mCol.RemoveAt(Index)
  End Sub

  Public Sub Remove(ByVal key As String)
    mCol.Remove(key)
  End Sub

  ' ----- overloaded item method ------
  Public Function Item(ByVal index As Int32) As IHoleDetailInfo
    Return CType(mCol.GetByIndex(index), IHoleDetailInfo)
  End Function

  Public Function Item(ByVal key As String) As IHoleDetailInfo
    Return CType(mCol(key), IHoleDetailInfo)
  End Function

  ' Declare the enumerator and implement the IEnumerator interface:
  Private Class mEnum
    Implements IEnumerator

    Private nIndex As Int32
    Private collection As IHoleDetailInfos

    ' constructor. make the collection
    Public Sub New(ByVal coll As IHoleDetailInfos)
      collection = coll
      nIndex = -1
    End Sub

    ' start over
    Public Sub Reset() Implements IEnumerator.Reset
      nIndex = -1
    End Sub

    ' bump up the index
    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
      nIndex += 1
      Return (nIndex < collection.mCol.Count)
    End Function

    ' The current property on the IEnumerator interface:
    Public ReadOnly Property Current() As Object Implements IEnumerator.Current
      Get
        Return collection.mCol.GetByIndex(nIndex)
      End Get
    End Property
  End Class

End Class


Public Class IHoleDetailInfo

#Region "Locals"

  Private mTeeBox As YardMarker
  Private mHole As Int32
  Private mPar As Int32
  Private mTeeClub As GolfClubs
  Private mSecondClub As GolfClubs
  Private mHitfairway As Boolean
  Private mGood2Shot As Boolean
  Private mShots2Green As Int32
  Private mPutts As Int32
  Private mTotalShots As Int32

#End Region

  Public Sub New()
    mTotalShots = 0
  End Sub

  Public Overrides Function ToString() As String
    Return mHole.ToString()
  End Function

#Region "Properties"

  Public ReadOnly Property GreenInReg() As Boolean
    Get
      Return (IIf(mPar - mShots2Green >= 2, True, False))
    End Get
  End Property

  Public Property TeeBox() As YardMarker
    Get
      Return mTeeBox
    End Get
    Set(ByVal Value As YardMarker)
      mTeeBox = Value
    End Set
  End Property

  Public Property ScondClub() As GolfClubs
    Get
      Return mSecondClub
    End Get
    Set(ByVal Value As GolfClubs)
      mSecondClub = Value
    End Set
  End Property

  Public Property TeeClub() As GolfClubs
    Get
      Return mTeeClub
    End Get
    Set(ByVal Value As GolfClubs)
      mTeeClub = Value
    End Set
  End Property

  Public Property GoodSecondShot() As Boolean
    Get
      Return mGood2Shot
    End Get
    Set(ByVal Value As Boolean)
      mGood2Shot = Value
    End Set
  End Property

  Public Property HitFairway() As Boolean
    Get
      Return mHitfairway
    End Get
    Set(ByVal Value As Boolean)
      mHitfairway = Value
    End Set
  End Property

  Public Property TotalShots() As Int32
    Get
      Return mTotalShots
    End Get
    Set(ByVal Value As Int32)
      mTotalShots = Value
    End Set
  End Property

  Public Property Putts() As Int32
    Get
      Return mPutts
    End Get
    Set(ByVal Value As Int32)
      mPutts = Value
    End Set
  End Property

  Public Property ShotsToGreen() As Int32
    Get
      Return mShots2Green
    End Get
    Set(ByVal Value As Int32)
      mShots2Green = Value
    End Set
  End Property

  Public Property Par() As Int32
    Get
      Return mPar
    End Get
    Set(ByVal Value As Int32)
      mPar = Value
    End Set
  End Property

  Public Property Hole() As Int32
    Get
      Return mHole
    End Get
    Set(ByVal Value As Int32)
      mHole = Value
    End Set
  End Property

#End Region
End Class

#End Region
