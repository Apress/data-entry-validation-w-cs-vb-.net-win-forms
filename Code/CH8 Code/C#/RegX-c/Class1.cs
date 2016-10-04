using System;
using System.Text.RegularExpressions;

namespace RegX_c
{
  class Class1
  {
    [STAThread]
    static void Main(string[] args)
    {
      bool q = IsInteger("121743");
      q = IsAlpha("test");
      q = IsValidZip("93726-1234");
      q = IsValidEmail("nicksymmonds@attbi.com");
      q = IsPasswordFormatValid("a47sdAS");
      q = LongWayPassword("a4sdAS");
      q = IsValidMilitaryTime("12:64");
      q = IsValidUSAdate("02/13/1989");
    }

    private static void Find()
    {
//      Regex r  = new Regex("Sp[ace] [1-9]*");
//      Regex r  = new Regex("Sp[ace]? [1-9]*");
//      Regex r  = new Regex("Sp[ace]+ [1-9]*");
//      Regex r  = new Regex("Sp[ace]* [1-9]*");
      Regex r  = new Regex("Sp[ace]{2} [1-9]*");

      for (Match m = r.Match("Space 1999 Spac 1999 Spa 1999 Sp 1999"); m.Success; m = m.NextMatch()) 
        Console.WriteLine(m.Value);

      Console.ReadLine();
    }

    private static void Replace1()
    {
      //Replace all instances of the word could with the word should
      string OrgString = "This could be done. It could be accomplished now. " +
        "I couldn't get it done in time";
      string SearchPattern = "could ";
      string ReplacePattern = "should ";

      Console.WriteLine(OrgString + "\n\n");
      Console.WriteLine(Regex.Replace(OrgString, SearchPattern, ReplacePattern));

      Console.ReadLine();
    }

    private static void Replace2()
    {
      //Replace all instances of the word could with the word should
      string OrgString      = "Could it be done? It could be done now.";

      Console.WriteLine(OrgString + "\n");
      OrgString = Regex.Replace(OrgString, "Could", "Should");
      Console.WriteLine(Regex.Replace(OrgString, "could", "should"));

      Console.ReadLine();
    }

    private static void Validate()
    {
      string s = "01234567894736";
      string p = "[^0-9]";
      bool q = Regex.IsMatch(s, p);

    }

    //Matches string of consecutive numbers
    private static bool IsInteger(string number)
    {
      return(Regex.IsMatch(number, "^[+-]?[0-9]+$"));
    }

    //Matches string of consecutive letters
    private static bool IsAlpha(string str)
    {
      return(Regex.IsMatch(str, "^[A-Za-z]+$"));
    }

    //Checks for format of 5 or 5+4 zip code
    private static bool IsValidZip(string code)
    {
      return(Regex.IsMatch(code, "^\\d{5}(-\\d{4})?$"));
    }

    //Checks for format of most all email addresses
    private static bool IsValidEmail(string email)
    {
      return(Regex.IsMatch(email, "^([\\w-]+)@([\\w-]+\\.)+[A-Za-z]{2,3}$"));
    }

    //Checks for format of USA phone number
    private static bool IsValidPhone(string phone)
    {
      return(Regex.IsMatch(phone, "^([\\w-]+)@([\\w-]+\\.)+[A-Za-z]{2,3}$"));
    }

    //Checks for format of USA date
    //separators = /-.
    //format = xx/xx/xxxx or xx/xx/xx
    //Month and day must be within correct calendar range
    //Year can be anything either 2 or 4 digits
    private static bool IsValidUSAdate(string dt)
    {
      return(Regex.IsMatch(dt, "^(0[1-9]|1[0-2])[./-]" +
                               "(0[1-9]|1[0-9]|2[0-9]|3[0-1])" +
                               "[./-](\\d{2}|\\d{4})$"));
    }

    //Checks for format of military time
    private static bool IsValidMilitaryTime(string tm)
    {
      return(Regex.IsMatch(tm, "^([0-1][0-9]|2[0-3]):[0-5][0-9]$"));
      // ([0-1][0-9]|2[0-3]) Check for 00-19 OR 20-23 as hours
      // [0-5][0-9]          Check for 00-59 as minutes
    }

    //Checks for format of password
    //format = 6-15 characters 
    //         Must include 2 consecutive digits 
    //         Must include at least one lower case letter
    //         Must include at least one upper case letter
    private static bool IsPasswordFormatValid(string Pword)
    {
      return(Regex.IsMatch(Pword,"^(?=.*\\d{2})(?=.*[a-z])(?=.*[A-Z]).{6,15}$"));
      // ?= means look ahead in the string for what follows
      // (?=.*\\d{2}) Starting at the beginning find zero or more of any 
      //              character and at 2 consecutive digits in the string.
      // (?=.*[a-z])  Starting at the beginning find zero or more of any 
      //              character and a lowere case letter somewhere in the string.
      // (?=.*[A-Z])  Starting at the beginning find zero or more of any 
      //              character and an upper case letter somewhere in the string.
      // .{6,15}      With all else being equal, There must be between 6 and 15
      //              characters in the string
    }

    private static bool LongWayPassword(string Pword)
    {
      //Check length first
      if(Pword.Length < 6 || Pword.Length > 15)
        return false;

      string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      string lower = upper.ToLower();
      bool FoundUpper = false;
      bool FoundLower = false;
      int  NumsFound  = 0;

      char[] chars = Pword.ToCharArray();
      foreach(char c in chars)
      {
        //look for at least one upper case letter
        if(Char.IsUpper(c))
          FoundUpper = true;
        //look for at least one lower case letter
        if(Char.IsLower(c))
          FoundLower = true;
        if(Char.IsNumber(c))
          NumsFound++;
      }
      if(FoundUpper && FoundLower && NumsFound > 1)
        return true;
      else
        return false;
    }


  }
}
