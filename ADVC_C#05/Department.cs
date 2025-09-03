using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVC_C_05
{
    public class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        private List<Employee> Staff = new List<Employee>();

        public void AddStaff(Employee e)
        {
            Staff.Add(e);

            e.EmployeeLayOff += RemoveStaff;
        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee emp)
            {
                Staff.Remove(emp);
                Console.WriteLine($"Employee {emp.EmployeeID} removed from Department {DeptName} due to {e.Cause}");
            }
        }
    }
}
