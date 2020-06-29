using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace EmpLeaveTracker {
    public class ManagerInfo {

        public void ManagerMenu () {
            Console.WriteLine ("Enter Manager Id :");
            var MngidInput = Console.ReadLine ();
            int Manager_id = parseInt (MngidInput);
            var IdInfo = new Idinformation ();
            string csv_file_name = "manager.csv";
            string ManagerExist = IdInfo.CheckId (Manager_id, csv_file_name);
            string[] ManagerData = ManagerExist.Split (",");

            if (ManagerExist == "")
                Console.WriteLine ("Manager Id Not Found ");
            else
                MainMenu (ManagerData);

        }

        public void MainMenu (string[] ManagerData) {
            Console.WriteLine ("****************************************");
            Console.WriteLine ("\n1. Update Leave \n2. Exit \n");
            Console.WriteLine ("Enter One of the Choice :");
            int choice = parseInt(Console.ReadLine ());

            switch (choice) {
                case 1:
                    var response = UpdateEmployeeLeave(ManagerData);
                    Console.WriteLine(response);
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine ("Invalid Input ");
                    break;
            }

        }

        public string UpdateEmployeeLeave(string[] ManagerData)
        {
            var ListLeaves = new ListAllLeaves();
            int ManagerId = int.Parse(ManagerData[0]);
            int ColNum = 9;
            ListLeaves.Leaves(ManagerId, ColNum);
            Console.WriteLine("Enter Leave Id To Update: ");
            int LeaveID = parseInt (Console.ReadLine ());

            Console.WriteLine("Enter Status To update \n 1. Approved \n 2. Rejected");
            Console.WriteLine ("Enter One of the Choice :");
            int statusChoice = parseInt (Console.ReadLine ());
            var status = "";
            if (statusChoice == 1)
            {
                status = "Approved";
            }
            else if (statusChoice == 2)
            {
                status = "Rejected";
            }
            else
            {
                Console.WriteLine("Wrong Value Entred");
            }
            var updateLeave = new UpdateLeave();
            var response = updateLeave.UpdateEmpLeave(LeaveID, status);
            return response;
        }

        public int parseInt (string entredValue) {
            var intValue = 0;
            try {
                intValue = int.Parse (entredValue);
            } catch (FormatException) {

                Console.WriteLine ("{0} is not an Valid Input Please Enter Proper Integer Input ", entredValue);
            } 
            return intValue;
        }

    }

}