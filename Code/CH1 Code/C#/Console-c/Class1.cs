using System;
using System.Collections;

namespace Console_c
{
  /// <summary>
  /// Console application for simple data entry
  /// </summary>
	class Class1
	{

    [STAThread]
    static void Main(string[] args)
    {
      bool ByEmp = false;
      SortedList Emps = new SortedList();

      Emps.Add("500", "Person A");
      Emps.Add("502", "Person B");
      Emps.Add("501", "Person C");
      Emps.Add("503", "Person D");
      
      Console.WriteLine("Welcome to the Console Application for Data Entry.\n");

      while(true)
      {
        Console.WriteLine("Enter the sort key for employees."); 
        Console.WriteLine("\n'N' for Sort by name, " +
                          "'C' for Sort by clock #, 'X' to exit program.");
        string SortOrder = Console.ReadLine();
        if(SortOrder.ToUpper() == "N" )
        {
          ByEmp = true;
          break;
        }
        else if(SortOrder.ToUpper() == "C" )
        {
          ByEmp = false;
          break;
        }
        else if(SortOrder.ToUpper() == "X" )
          return;
        else
        {
          Console.WriteLine("Only 'N' for Sort by name, " +
                            "'C' for Sort by clock # is allowed." +
                            " ('X' to exit program)");
          Console.WriteLine("\n\n");
        }
      }

      SortedList PrintEmp = new SortedList();
      string Header = ByEmp ? "\tNames\t   Clock #" : "\tClock #\t  Names";
      

      for(int k=0; k<Emps.Count; k++)
      {
        if(ByEmp)
          PrintEmp.Add(Emps.GetByIndex(k), Emps.GetKey(k));
        else
          PrintEmp.Add(Emps.GetKey(k), Emps.GetByIndex(k));
      }
      
      Console.WriteLine("\n{0}", Header);
      Console.WriteLine("\t--------------------");
      for(int k=0; k<PrintEmp.Count; k++)
      {
        Console.WriteLine("\t{0}\t{1}", PrintEmp.GetKey(k), 
                                        PrintEmp.GetByIndex(k));
      }
      
      Console.ReadLine();
    }
	}
}
