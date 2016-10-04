Option Strict On

Public Class Town

  Private mName As String
  Private mCounty As String
  Private mState As String
  Private mMayor As String
  Private mZip As String
  Private mMillRate As Single

  Public Property Name() As String
    Get
      Return mName
    End Get
    Set(ByVal Value As String)
      mName = Value
    End Set
  End Property

  Public Property County() As String
    Get
      Return mCounty
    End Get
    Set(ByVal Value As String)
      mCounty = Value
    End Set
  End Property

  Public Property State() As String
    Get
      Return mState
    End Get
    Set(ByVal Value As String)
      mState = Value
    End Set
  End Property

  Public Property Mayor() As String
    Get
      Return mMayor
    End Get
    Set(ByVal Value As String)
      mMayor = Value
    End Set
  End Property

  Public Property Zip() As String
    Get
      Return mZip
    End Get
    Set(ByVal Value As String)
      mZip = Value
    End Set
  End Property

  Public Property MillRate() As Single
    Get
      Return mMillRate
    End Get
    Set(ByVal Value As Single)
      mMillRate = Value
    End Set
  End Property


End Class
