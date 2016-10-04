Option Strict On

Imports System.Text
Imports System.Text.RegularExpressions

Public Class ValidationErrorEventArgs
  Inherits EventArgs

  Private mMask As String
  Private mText As String

  Public Sub New(ByVal mask As String, ByVal OffendingText As String)
    mMask = mask
    mText = OffendingText
  End Sub

  Public ReadOnly Property Mask() As String
    Get
      Return mMask
    End Get
  End Property

  Public ReadOnly Property Text() As String
    Get
      Return mText
    End Get
  End Property

End Class
Public Delegate Sub ValidationErrorEventHandler(ByVal sender As Object, _
                                                ByVal e As _
                                                ValidationErrorEventArgs)

Public Class MaskedTextBox_VB
  Inherits System.Windows.Forms.TextBox

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    InitializeComponent()

    mValidationErrors = 0
    AddHandler Me.Enter, New EventHandler(AddressOf MaskBoxEnter)
    AddHandler Me.Leave, New EventHandler(AddressOf MaskBoxLeave)
    AddHandler Me.KeyDown, New KeyEventHandler(AddressOf MaskBoxKeyDown)
    AddHandler Me.KeyPress, New KeyPressEventHandler(AddressOf MaskBoxKeyPress)
    AddHandler Me.Validated, New EventHandler(AddressOf MaskBoxValidated)
    AddHandler Me.ValidationError, _
                New ValidationErrorEventHandler(AddressOf DefaultHandler)

  End Sub

  'UserControl1 overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '
    'UserControl1
    '
    Me.Name = "UserControl1"

  End Sub

#End Region

#Region "local variables"

  Public Event ValidationError As ValidationErrorEventHandler

  Public Enum FormatType
    None
    DateFormat
    Numbers
    Alpha
  End Enum

  Dim mUserMask As String
  Dim mFmt As FormatType = FormatType.None
  Dim mNumberPlace As Char = "#"c
  Dim mCue As Char = "_"c
  Dim mRegNum As String = "[0-9]"
  Dim mAlphaPlace As Char = "?"c
  Dim mRegAlpha As String = "[A-Za-z]"
  Dim mAnything As String = ".*"
  Dim mRegExpression As String = String.Empty
  Dim mText As StringBuilder = New StringBuilder()
  Dim mValidationErrors As Int32

#End Region

#Region "New properties"

  Public Property Format() As FormatType
    Get
      Return mFmt
    End Get
    Set(ByVal Value As FormatType)
      mFmt = Value
      mText = New StringBuilder()

      If mFmt = FormatType.None Then
        mUserMask = ""
        mRegExpression = mAnything
      ElseIf mFmt = FormatType.DateFormat Then
        mUserMask = "##/##/####"
        mText.Append("__/__/____")
        mRegExpression = "\\d{2}/\\d{2}/\\d{4}"
      ElseIf mFmt = FormatType.Alpha Then
        mUserMask = "????????"
        mRegExpression = mRegAlpha + "{8}"
        mText.Append("________")
      ElseIf mFmt = FormatType.Numbers Then
        mUserMask = "########"
        mRegExpression = mRegNum + "{8}"
        mText.Append("________")
      End If
      Mask = mUserMask
    End Set
  End Property

  Public Property Mask() As String
    Get
      Return mUserMask
    End Get
    Set(ByVal Value As String)
      If mFmt = FormatType.None Then
        mRegExpression = String.Empty
        mText = New StringBuilder()
        mUserMask = Value
        Dim chars() As Char = mUserMask.ToCharArray()
        Dim c As Char
        For Each c In chars
          If c = mNumberPlace Then
            mRegExpression += mRegNum
            mText.Append(mCue)
          ElseIf c = mAlphaPlace Then
            mRegExpression += mRegAlpha
            mText.Append(mCue)
          Else
            mRegExpression += c.ToString()
            mText.Append(c)
          End If
        Next
        Me.Text = mText.ToString()
      End If
    End Set
  End Property

#End Region

#Region "hooked events"

  Private Sub MaskBoxValidated(ByVal sender As Object, ByVal e As EventArgs)
    If Not Regex.IsMatch(mText.ToString(), mRegExpression) Then
      RaiseError()
    End If
  End Sub

  Private Sub MaskBoxEnter(ByVal sender As Object, ByVal e As EventArgs)
    Me.Text = mText.ToString()
    Me.SelectionLength = 0
  End Sub

  Private Sub MaskBoxLeave(ByVal sender As Object, ByVal e As EventArgs)
    If mUserMask = String.Empty Then
      mText = New StringBuilder(Me.Text)
    End If
  End Sub

  Private Sub MaskBoxKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
    'No mask so let in any character
    If mUserMask = String.Empty Then
      Return
    End If

    Dim pos As Int32 = Me.SelectionStart
    If e.KeyData = Keys.Delete Then
      Me.Text = DeleteLetter(pos)
      Me.SelectionStart = pos
    End If
    e.Handled = True
  End Sub

  Private Sub MaskBoxKeyPress(ByVal sender As Object, _
                              ByVal e As KeyPressEventArgs)
    'No mask so let in any character
    If mUserMask = String.Empty Then
      Return
    End If

    Dim pos As Int32 = Me.SelectionStart
    Me.Text = EnterLetter(pos, e.KeyChar)
    e.Handled = True
    Me.SelectionStart = pos
  End Sub

  'Special event to handle case of no-one connecting to my delegate
  'avoids a null reference
  Private Sub DefaultHandler(ByVal sender As Object, _
                             ByVal e As ValidationErrorEventArgs)
    mValidationErrors += 1
  End Sub

#End Region

#Region "OnXXX event stuff"

  Public Sub RaiseError()
    Dim e As ValidationErrorEventArgs = _
          New ValidationErrorEventArgs(mUserMask, mText.ToString())
    OnValidationError(e)
  End Sub

  Protected Sub OnValidationError(ByVal e As ValidationErrorEventArgs)
    RaiseEvent ValidationError(Me, e)
  End Sub

#End Region

#Region "Helper stuff"

  Public Function EnterLetter(ByRef position As Int32, _
                              ByVal c As Char) As String
    'User pressed delete key
    If Val(c) = 8 Then
      position -= 1
      Return DeleteLetter(position)
    End If

    'User trying to go beyond bounds
    If position >= mText.Length Then
      Return mText.ToString()
    End If

    'If we have hit a literal then advance one
    'Do this in a loop in case there are more literals.
    If mText.Chars(position) <> mCue Then
      position += 1
    End If

    'check to see if the character is ok
    If mUserMask.Chars(position) = mNumberPlace Then
      If Regex.IsMatch(c.ToString(), mRegNum) Then
        mText.Chars(position) = c
        position += 1
      End If
    ElseIf mUserMask.Chars(position) = mAlphaPlace Then
      If Regex.IsMatch(c.ToString(), mRegAlpha) Then
        mText.Chars(position) = c
        position += 1
      End If
    End If

    Return mText.ToString()
  End Function

  Public Function DeleteLetter(ByRef pos As Int32) As String
    'If the character to be deleted is a cue the bail out
    If mText.Chars(pos) <> mCue Then
      'If the character to be dleted is valid then change it back to a cue
      If mUserMask.Chars(pos) = mNumberPlace Or _
         mUserMask.Chars(pos) = mAlphaPlace Then
        mText.Chars(pos) = mCue
      End If
    End If
    Return mText.ToString()
  End Function

#End Region


End Class
