Option Strict On

Imports System
Imports System.Diagnostics

Public Class EventLogger

  Private Const LE_Error As Int32 = 1
  Private Const LE_BadEntry As Int32 = 2
  Private Const LE_Started As Int32 = 3
  Private Const LE_Ended As Int32 = 4
  Private Const LE_Login As Int32 = 5
  Private Const LE_Logout As Int32 = 6
  Private Const ProdName As String = "Logger"
  Private Const SourceName As String = "Test Logger"

  Shared DataLog As EventLog

  Shared Sub New()
    If Not EventLog.SourceExists(ProdName) Then
      EventLog.CreateEventSource(ProdName, SourceName)
    End If

    'It is possible to enable an event to notify you of 
    'a log entry being written
    DataLog = New EventLog()
    DataLog.Source = SourceName
    DataLog.EnableRaisingEvents = True
    AddHandler DataLog.EntryWritten, New _
                           EntryWrittenEventHandler(AddressOf EventLogWritten)

  End Sub

  Private Shared Sub EventLogWritten(ByVal sender As Object, _
                                     ByVal e As EntryWrittenEventArgs)
    Dim s As String = String.Empty
    Select Case (e.Entry.EventID)
      Case LE_Error
        s = "Error Event Written"
      Case LE_BadEntry
        s = "Bad Entry Event Written"
      Case LE_Started
        s = "Program Started Event Written"
      Case LE_Ended
        s = "Program Ended Event Written"
      Case LE_Login
        s = "Login Event Written"
      Case LE_Logout
        s = "Logout Event Written"
      Case Else
        s = "Event Written"
    End Select
    System.Windows.Forms.MessageBox.Show(s)
  End Sub

  Public Shared Sub ProgramStart()
    'Write to the log file that the program was started
    DataLog.WriteEntry("Program Started", _
                       EventLogEntryType.Information, LE_Started)
  End Sub

  Public Shared Sub ProgramEnd()
    'Write to the log file that the program was started
    DataLog.WriteEntry("Program Ended", _
                       EventLogEntryType.Information, LE_Started)
  End Sub

  Public Shared Sub LoginOK(ByVal LoginName As String)
    DataLog.WriteEntry("Successfull Login:" + LoginName, _
                       EventLogEntryType.SuccessAudit, LE_Login)
  End Sub

  Public Shared Sub LoginFailed(ByVal LoginName As String)
    DataLog.WriteEntry("Failed Login:" + LoginName, _
                       EventLogEntryType.FailureAudit, LE_Login)
  End Sub

  Public Shared Sub LoginCanceled(ByVal LoginName As String)
    If LoginName = String.Empty Then
      LoginName = "Unknown Login Name"
    End If

    DataLog.WriteEntry("Failed Login:" + LoginName, _
                        EventLogEntryType.FailureAudit, LE_Login)
  End Sub

  Public Shared Sub LogoutOK(ByVal LoginName As String)
    DataLog.WriteEntry("Successfull Logout:" + LoginName, _
                        EventLogEntryType.SuccessAudit, LE_Logout)
  End Sub

End Class
