using System;
using System.IO;

namespace EmpLeaveTracker
{

    public class LeaveData
    {
        public int id { get; set; }
        public int employeeId { get; set; }
        public int Managerid { get; set; }
        public string creator { get; set; }
        public string manager { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; }

        public override string ToString () { 
            return  this.id + "," + this.creator + "," + this.manager + "," + this.title + "," + this.description + "," + this.startDate.ToShortDateString() + "," + this.endDate.ToShortDateString() + "," + this.status + "," + this.employeeId + "," + this.Managerid;
        }
    }
    public class EmployeeData
    { 
        public int EmpId { get; set; }
        public string name { get; set; }
        public int ManagerId { get; set; }
    }


}
