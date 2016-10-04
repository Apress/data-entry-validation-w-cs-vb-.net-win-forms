Option Strict On

Imports System
Imports System.Text.RegularExpressions

Module Module1

  Sub Main()
    '   Find()
    Replace2()

  End Sub

  Sub Find()
    Dim m As Match
    Dim text As String = "Space 1999 Spca 1999 Spac 1999 Spa 1999 Sp 1999"

    Dim r As Regex = New Regex("Sp[ace]{2} [1-9]*")

    m = r.Match(text)
    While m.Success
      Console.WriteLine(m.Value)
      m = m.NextMatch()
    End While

    Console.ReadLine()

  End Sub

  Sub Replace()
    'Replace all instances of the word could with the word should
    Dim OrgString As String = "This could be done. " + _
                              "It could be accomplished now. " + _
                              "I couldn't get it done in time"
    Dim SearchPattern As String = "could "
    Dim ReplacePattern As String = "should "

    Console.WriteLine(OrgString + vbCrLf + vbCrLf)
    Console.WriteLine(Regex.Replace(OrgString, SearchPattern, ReplacePattern))

    Console.ReadLine()
  End Sub

  Sub Replace2()
    'Replace all instances of the word could with the word should
    Dim OrgString As String = "Could it be done? It could be done now."

    Console.WriteLine(OrgString + "\n")
    OrgString = Regex.Replace(OrgString, "Could", "Should")
    Console.WriteLine(Regex.Replace(OrgString, "could", "should"))

    Console.ReadLine()
  End Sub

  'Matches string of consecutive numbers
  Function IsInteger(ByVal number As String) As Boolean
    Return (Regex.IsMatch(number, "^[+-]?[0-9]+$"))
  End Function

  'Matches string of consecutive letters
  Function IsAlpha(ByVal str As String) As Boolean
    Return (Regex.IsMatch(str, "^[A-Za-z]+$"))
  End Function

  'Checks for format of 5 or 5+4 zip code
  Function IsValidZip(ByVal code As String) As Boolean
    Return (Regex.IsMatch(code, "^\\d{5}(-\\d{4})?$"))
  End Function

  'Checks for format of most all email addresses
  Function IsValidEmail(ByVal email As String) As Boolean
    Return (Regex.IsMatch(email, "^([\\w-]+)@([\\w-]+\\.)+[A-Za-z]{2,3}$"))
  End Function

  'Checks for format of USA phone number
  Function IsValidPhone(ByVal phone As String) As Boolean
    Return (Regex.IsMatch(phone, "^([\\w-]+)@([\\w-]+\\.)+[A-Za-z]{2,3}$"))
  End Function

  'Checks for format of USA date
  'separators = /-.
  'format = xx/xx/xxxx or xx/xx/xx
  'Month and day must be within correct calendar range
  'Year can be anything either 2 or 4 digits
  Function IsValidUSAdate(ByVal dt As String) As Boolean
    Return (Regex.IsMatch(dt, "^(0[1-9]|1[0-2])[./-]" + _
                              "(0[1-9]|1[0-9]|2[0-9]|3[0-1])" + _
                              "[./-](\\d{2}|\\d{4})$"))
  End Function

  'Checks for format of military time
  Function IsValidMilitaryTime(ByVal tm As String) As Boolean
    Return (Regex.IsMatch(tm, "^([0-1][0-9]|2[0-3]):[0-5][0-9]$"))
    ' ([0-1][0-9]|2[0-3]) Check for 00-19 OR 20-23 as hours
    ' [0-5][0-9]          Check for 00-59 as minutes
  End Function

  'Checks for format of password
  'format = 6-15 characters 
  '         Must include 2 consecutive digits 
  '         Must include at least one lower case letter
  '         Must include at least one upper case letter
  Function IsPasswordFormatValid(ByVal Pword As String) As Boolean
    Return (Regex.IsMatch(Pword, "^(?=.*\\d{2})(?=.*[a-z])(?=.*[A-Z]).{6,15}$"))
    ' ?= means look ahead in the string for what follows
    ' (?=.*\\d{2}) Starting at the beginning find zero or more of any 
    '              character and at 2 consecutive digits in the string.
    ' (?=.*[a-z])  Starting at the beginning find zero or more of any 
    '              character and a lowere case letter somewhere in the string.
    ' (?=.*[A-Z])  Starting at the beginning find zero or more of any 
    '              character and an upper case letter somewhere in the string.
    ' .{6,15}      With all else being equal, There must be between 6 and 15
    '              characters in the string
  End Function

  Function LongWayPassword(ByVal Pword As String) As Boolean
    'Check length first
    If Pword.Length < 6 Or Pword.Length > 15 Then
      Return False
    End If

    Dim upper As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Dim lower As String = upper.ToLower()
    Dim FoundUpper As Boolean = False
    Dim FoundLower As Boolean = False
    Dim NumsFound As Int32 = 0

    Dim chars() As Char = Pword.ToCharArray()
    Dim c As Char
    For Each c In chars
      'look for at least one upper case letter
      If Char.IsUpper(c) Then
        FoundUpper = True
      End If
      'look for at least one lower case letter
      If Char.IsLower(c) Then
        FoundLower = True
      End If
      If Char.IsNumber(c) Then
        NumsFound += 1
      End If
    Next
    If FoundUpper And FoundLower And NumsFound > 1 Then
      Return True
    Else
      Return False
    End If
  End Function

End Module
