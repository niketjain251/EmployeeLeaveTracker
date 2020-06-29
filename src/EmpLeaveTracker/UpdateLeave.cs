using System.Collections.Generic;
using System;
using System.IO;

namespace EmpLeaveTracker
{
    public class UpdateLeave
    {

        public string UpdateEmpLeave(int id, string status)
        {
            string csv_file_path = (Directory.GetCurrentDirectory() + $@"\leave.csv");
            List<String> lines = new List<String>();
            if (File.Exists(csv_file_path))
            {
                using (StreamReader reader = new StreamReader(csv_file_path))
                {
                    String line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(","))
                        {
                            String[] split = line.Split(',');
                            if (split[0] == "Id")
                            {
                                line = String.Join(",", split);
                                
                            }
                            else if (int.Parse(split[0]).Equals(id))
                            {
                                split[7] = status;
                                line = String.Join(",", split);
                            }
                        }

                        lines.Add(line);
                    }
                }
                using (StreamWriter writer = new StreamWriter(csv_file_path, false))
                {
                    foreach (String line in lines)
                        writer.WriteLine(line);
                }        
                return "Record Updated Suscessfull ................!";
            }
            else
                return "Record Not Updated ";



        }



    }

}