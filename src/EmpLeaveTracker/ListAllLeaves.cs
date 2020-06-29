using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace EmpLeaveTracker
{

    public class ListAllLeaves
    {
        public void Leaves(int id, int ColNum)
        { 
            string csv_file_path = (Directory.GetCurrentDirectory() + @"\Leave.csv");
            var strLines = File.ReadLines(csv_file_path);
            // Console.WriteLine("Id\tEmpName \t ManagerNm \t Title \t Desc \t Start-dt \t End-dt \t Status \n");
            Console.WriteLine("************** Leaves ********************* \n");
            foreach (var line in strLines)
            {
                if (line.Split(',')[0] == "Id")
                {
                    continue;
                }
                if (int.Parse(line.Split(',')[ColNum]).Equals(id))
                {
                    string[] LvInfo = line.Split(",");
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7} \n", LvInfo);
                }
            }
        }
    }


}