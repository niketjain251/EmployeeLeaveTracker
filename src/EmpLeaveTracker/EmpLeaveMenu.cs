using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace EmpLeaveTracker {
    public class EmpLeaveMenu {

        public void LeaveMenu () {
            Console.WriteLine("Enter Employee Id :");
            var EmpidInput = Console.ReadLine();
            int Employee_id = 0;
            try
            {
                Employee_id = int.Parse(EmpidInput);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not an ValidId Please enter Inter Proper Emplotee Id", EmpidInput);
            }

            var empployeeInfo = new Idinformation();
            string csv_file_name = "employees.csv";
            string EmployeeExist = empployeeInfo.CheckId(Employee_id, csv_file_name);
            string[] EmpData = EmployeeExist.Split(",");

            if (EmployeeExist == "")
                Console.WriteLine("Employee Id Not Found ");
            else
                EmployeeMenu(EmpData);
        }

        public void EmployeeMenu (string[] EmpData) {
            while (true) {

                Console.WriteLine ("\n****************************************");
                Console.WriteLine ("Employee Leave Traclikng System");
                Console.WriteLine ("****************************************");
                Console.WriteLine (" 1. Create Leave \n 2. List my Leaves \n 3. Search Leave");
                Console.WriteLine ("Enter One of the Choice OR 'q' to Exit :");
                Console.WriteLine ("****************************************");
                var input = Console.ReadLine ();
                int choice = 0;
                if (input == "q") {
                    break;
                }
                try {

                    choice = int.Parse (input);

                } catch (FormatException) {
                    Console.WriteLine ("{0} is not an integer Please enter Inter 1-4 only", input);

                }
            switch (choice) {
                case 1:
                    var AddLeave = new AddLeave ();
                    AddLeave.Add_New_Leave (EmpData);
                    break;
                case 2:
                    var ListLeaves = new ListAllLeaves ();
                    int EmpId = int.Parse(EmpData[0]);
                    int ColNum = 8;
                    ListLeaves.Leaves (EmpId, ColNum);
                    break;
                case 3:
                    var SearchLeaves = new SearchLeaves ();
                    SearchLeaves.SearchEmpLeaves (EmpData);
                    break;
                default:
                    break;
            }
            }

        }

    }

}