using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmpLeaveTracker {

    public class SearchLeaves {
        public void SearchEmpLeaves (string[] EmpData) {
            string csv_file_path = (Directory.GetCurrentDirectory () + @"\Leave.csv");
            int Employee_id = int.Parse (EmpData[0]);
            var strLines = File.ReadLines (csv_file_path);
            Console.WriteLine ("\n Search By \n 1. Title \n 2. Status (Pending/Approved/Rejected) \n");
            var input = Console.ReadLine ();
            try {
                int choice = int.Parse (input);
                if (choice == 1)
                    SearchByTitile (Employee_id, strLines, choice);
                else if (choice == 2)
                    SearchByStatus (Employee_id, strLines);
                else
                    Console.WriteLine ("Invalid Option Entred");
            } catch (FormatException) {
                Console.WriteLine ("{0} is not an integer Please enter Inter 1-2 only", input);
            }

        }

        private static void SearchByStatus (int Employee_id, IEnumerable<string> strLines) {
            Console.WriteLine ("\n Enter 1-3 For \n 1.Pending Leaves \n 2. Approved Leaves \n 3. Rejected Leaves \n");
            int Input = 0;
            Boolean RecordFound = false;
            try {
                Input = int.Parse (Console.ReadLine ());
            } catch (FormatException) {
                Console.WriteLine ("Please enter Inter 1-3 only");
            }
            string SearchStatus = "";

            if (Input == 1)
                SearchStatus = "Pending";
            else if (Input == 2)
                SearchStatus = "Approved";
            else if (Input == 3)
                SearchStatus = "Rejected";

            foreach (var line in strLines) {
                if (line.Split (',') [0] == "Id") {
                    continue;
                } else if ((line.Split (',') [7]).Equals (SearchStatus) && int.Parse (line.Split (',') [8]).Equals (Employee_id)) {
                    string[] LvInfo = line.Split (",");
                    Console.WriteLine ("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7} \n", LvInfo);
                    RecordFound = true;
                }

            }
            if (RecordFound == false)
                Console.WriteLine ("No Records Found");
        }

        private static void SearchByTitile (int Employee_id, IEnumerable<string> strLines, int choice) {

            Console.WriteLine ("\nEnter the Title to search :");
            var titleString = Console.ReadLine ();
            Boolean RecordFound = false;
            foreach (var line in strLines) {
                if (line.Split (',') [0] == "Id") {
                    continue;
                } else if ((line.Split (',') [3]).Contains (titleString) && int.Parse (line.Split (',') [8]).Equals (Employee_id)) {
                    string[] LvInfo = line.Split (",");
                    Console.WriteLine ("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7} \n", LvInfo);
                    RecordFound = true;
                }

            }
            if (RecordFound == false)
                Console.WriteLine ("No Records Found");

        }
    }

}