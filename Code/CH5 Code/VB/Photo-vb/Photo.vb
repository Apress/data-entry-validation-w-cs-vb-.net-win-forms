Option Strict On
Imports System.IO
Imports System.Drawing

Public Class Photo

  Dim mPic As Image
  Dim mName As String
  Dim mLocation As String
  Dim mDateShot As String

  Public Sub New(ByVal picname As String)
    mPic = Image.FromFile(picname)
    mName = Path.GetFileNameWithoutExtension(picname)
    mDateShot = DateTime.Today.ToShortDateString()
    mLocation = mName
  End Sub

  Public Overrides Function ToString() As String
    Return "Photo"
  End Function


  Public ReadOnly Property Location() As String
    Get
      Return mLocation
    End Get
  End Property

  Public ReadOnly Property Name() As String
    Get
      Return mName
    End Get
  End Property

  Public ReadOnly Property DateShot() As String
    Get
      Return mDateShot
    End Get
  End Property

  Public ReadOnly Property Picture() As Image
    Get
      Return mPic
    End Get
  End Property


End Class
