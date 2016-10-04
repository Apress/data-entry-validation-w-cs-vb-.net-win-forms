Module Module1

    Sub Main()
    Dim ByEmp As Boolean = False
    Dim Emps As SortedList = New SortedList()

    Emps.Add("500", "Person A")
    Emps.Add("502", "Person B")
    Emps.Add("501", "Person C")
    Emps.Add("503", "Person D")

    Console.WriteLine("Welcome to the Console Application for Data Entry.\n")

    While (True)
      Console.WriteLine("Enter the sort key for employees.")
        Console.WriteLine("\n'N' for Sort by name, " + _
                          "'C' for Sort by clock #, 'X' to exit program.")
      Dim SortOrder As String = Console.ReadLine()
      If (SortOrder.ToUpper() = "N") Then
        ByEmp = True
        Exit While
      ElseIf (SortOrder.ToUpper() = "C") Then
        ByEmp = False
        Exit While
      ElseIf (SortOrder.ToUpper() = "X") Then
        Return
      Else
        Console.WriteLine("Only 'N' for Sort by name, " + _
                          "'C' for Sort by clock # is allowed." + _
                          " ('X' to exit program)")
        Console.WriteLine("\n\n")
      End If
    End While

    Dim PrintEmp As SortedList = New SortedList()
    Dim Header As String = _
                 IIf(ByEmp, "\tNames\t   Clock #", "\tClock #\t  Names")

    Dim k As Int32
    For k = 0 To Emps.Count - 1
      If (ByEmp) Then
        PrintEmp.Add(Emps.GetByIndex(k), Emps.GetKey(k))
      Else
        PrintEmp.Add(Emps.GetKey(k), Emps.GetByIndex(k))
      End If
    Next

    Console.WriteLine("\n{0}", Header)
    Console.WriteLine("\t--------------------")
    For k = 0 To PrintEmp.Count - 1
      Console.WriteLine("\t{0}\t{1}", PrintEmp.GetKey(k), _
                                      PrintEmp.GetByIndex(k))
    Next

    Console.ReadLine()

  End Sub

End Module
