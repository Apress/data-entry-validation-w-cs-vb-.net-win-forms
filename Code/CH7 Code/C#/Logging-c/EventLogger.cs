using System;
using System.Diagnostics;

namespace Logging_c
{
	/// <summary>
	/// Summary description for EventLogger.
	/// </summary>
	public class EventLogger
	{
    private const int LE_Error      = 1;
    private const int LE_BadEntry   = 2;
    private const int LE_Started    = 3;
    private const int LE_Ended      = 4;
    private const int LE_Login      = 5;
    private const int LE_Logout     = 6;
    private const string ProdName   = "Logger";
    private const string SourceName = "Test Logger";

    static EventLog DataLog;

		static EventLogger()
		{
      if(!EventLog.SourceExists(ProdName))
        EventLog.CreateEventSource(ProdName, SourceName);

      //It is possible to enable an event to notify you of 
      //a log entry being written
      DataLog = new EventLog();
      DataLog.Source = SourceName;
      DataLog.EnableRaisingEvents = true;
      DataLog.EntryWritten += new EntryWrittenEventHandler(EventLogWritten);

		}

    private static void EventLogWritten(object sender, EntryWrittenEventArgs e)
    {
      string s = string.Empty;
      switch(e.Entry.EventID)
      {
        case LE_Error:
          s="Error Event Written";
          break;
        case LE_BadEntry:
          s="Bad Entry Event Written";
          break;
        case LE_Started:
          s="Program Started Event Written";
          break;
        case LE_Ended:
          s="Program Ended Event Written";
          break;
        case LE_Login:
          s="Login Event Written";
          break;
        case LE_Logout:
          s="Logout Event Written";
          break;
        default:
          s="Event Written";
          break;
      }
      System.Windows.Forms.MessageBox.Show(s);
    }

    public static void ProgramStart()
    {
      //Write to the log file that the program was started
      DataLog.WriteEntry("Program Started", 
                         EventLogEntryType.Information, LE_Started);
    }

    public static void ProgramEnd()
    {
      //Write to the log file that the program was started
      DataLog.WriteEntry("Program Ended", 
                         EventLogEntryType.Information, LE_Started);
    }

    public static void LoginOK(string LoginName)
    {
      DataLog.WriteEntry("Successfull Login:" + LoginName, 
                         EventLogEntryType.SuccessAudit, LE_Login);
    }

    public static void LoginFailed(string LoginName)
    {
      DataLog.WriteEntry("Failed Login:" + LoginName, 
                         EventLogEntryType.FailureAudit, LE_Login);
    }

    public static void LoginCanceled(string LoginName)
    {
      if (LoginName == String.Empty)
        LoginName = "Unknown Login Name";

      DataLog.WriteEntry("Failed Login:" + LoginName, 
                          EventLogEntryType.FailureAudit, LE_Login);
    }

    public static void LogoutOK(string LoginName)
    {
      DataLog.WriteEntry("Successfull Logout:" + LoginName, 
                          EventLogEntryType.SuccessAudit, LE_Logout);
    }

	}
}
