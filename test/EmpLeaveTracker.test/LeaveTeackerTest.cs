using System;
using System.Data;
using Xunit;

namespace EmpLeaveTracker.test {
    public class LeaveTeackerTest {
        [Fact]
        public void test1 () {

            var EmpInfo = new Idinformation ();
            int empId = 102;
            string csvFileName = "employees.csv";

            string result = EmpInfo.CheckId (empId, csvFileName);
            string[] info = result.Split (",");

            Assert.Equal(empId, int.Parse(info[0]));
            Assert.Equal("Hazel Nutt", info[1]);

        }

        
    }
}