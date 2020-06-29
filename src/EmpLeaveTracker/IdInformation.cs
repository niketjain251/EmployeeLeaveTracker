using System.Collections.Generic;
using System;
using System.IO;

namespace EmpLeaveTracker
{
    public class Idinformation
    {

        public string CheckId(int id, string csvFileName)
        {
            string csv_file_path = (Directory.GetCurrentDirectory() + $@"\{csvFileName}");
            var strLines = File.ReadLines(csv_file_path);
            
            foreach (var line in strLines)
            {
                if (line.Split(',')[0] == "Id")
                {
                    continue;
                }
                if (int.Parse(line.Split(',')[0]).Equals(id))
                    
                    return line;
            }

            return "";
        }
    }



}
