using System.Linq;
using System;
using System.IO;

namespace EmpLeaveTracker
{

    public class AddLeave
    { 
            public void Add_New_Leave (String[] EmploeeData) {
            LeaveData LvData = new LeaveData ();

            LvData.employeeId = int.Parse(EmploeeData[0]);
            LvData.creator = EmploeeData[1];
            LvData.Managerid = int.Parse(EmploeeData[2]);

            LvData.status = "Pending";

            Console.WriteLine ("Assign_to (Manager ID):");
            var manager_id = Convert.ToInt32 (Console.ReadLine ());

            Console.WriteLine ("Enter Title:");
            LvData.title = Console.ReadLine ();

            Console.WriteLine ("Enter Description:");
            LvData.description = Console.ReadLine ();

            Console.WriteLine ("Enter Start-Date(dd-mm-yyyy):");
            string stDate = Console.ReadLine ();
            LvData.startDate = DateTime.ParseExact (stDate, "dd-MM-yyyy", null);

            Console.WriteLine ("Enter End-Date(dd-mm-yyyy):");
            string endDate = Console.ReadLine ();
            LvData.endDate = DateTime.ParseExact (endDate, "dd-MM-yyyy", null);

            var LeaveCsv = Directory.GetCurrentDirectory () + @"\Leave.csv";

            if (manager_id == int.Parse (EmploeeData[2])) {
                var ManagerName = GetManagerName(manager_id);
                LvData.manager = ManagerName;

            } else {
                Console.WriteLine ($"Manager ID {manager_id} is not associated With current Employee Enter valid ManagerId\n");
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder ();
            bool fileExist = File.Exists (LeaveCsv);
            if (!fileExist) {
                File.WriteAllText (LeaveCsv, "Id,Creator,Manager,Title,Description,Start-Date,End-Date,Status,EmployeeId, ManagerId\n");
            } 
            int count = File.ReadAllLines(LeaveCsv).Length - 1;
            LvData.id = count + 1;

            File.AppendAllText(LeaveCsv,LvData.ToString() +  Environment.NewLine);
            
            // employeeList.Add(obj_Comapny1);
            Console.WriteLine ("Employee Deatil Added Successfully...!!!!:");
        }
        
        public string GetManagerName(int ManagerId)
        {
            string csv_file_path = (Directory.GetCurrentDirectory() + @"\manager.csv");
            var strLines = File.ReadLines(csv_file_path);
            foreach (var line in strLines)
            {
                if (line.Split(',')[0] == "Id")
                {
                    continue;
                }
                if (int.Parse(line.Split(',')[0]).Equals(ManagerId))
                    return line.Split(',')[1];
            }

            return "";
        }
    }


}