using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace EmpLeaveTracker {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine("Choose One of the following \n 1. Employee \n 2. Manager");
            var UserInput = Console.ReadLine();
            int Choice = 0;
            try {
                Choice = int.Parse (UserInput);
            } catch (FormatException) {
                Console.WriteLine ("{0} is not an ValidId Please enter Inter Proper Input Between (1-2)", UserInput);
            }
            switch (Choice) {
                case 1:
                    var EmployeeInfo = new EmpLeaveMenu ();
                    EmployeeInfo.LeaveMenu ();
                    break;
                case 2:
                    var ManagerInfo = new ManagerInfo ();
                    ManagerInfo.ManagerMenu ();
                    break;
                default:
                    Console.WriteLine ("Invalid Choice Entred ");
                    break;
            }

        }

    }

}