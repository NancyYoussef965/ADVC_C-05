using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVC_C_05
{
    public class Club
    {




        public int ClubID { get; set; }
        public string ClubName { get; set; }

        private List<Employee> Members = new List<Employee>();

        public void AddMember(Employee e)
        {
            Members.Add(e);
            e.EmployeeLayOff += RemoveMember;
        }

        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee emp)
            {
                if (e.Cause == LayOffCause.VacationStockNegative)
                {
                    Members.Remove(emp);
                    Console.WriteLine($"Employee {emp.EmployeeID} removed from Club {ClubName} due to {e.Cause}");
                }
                else if (e.Cause == LayOffCause.AgeAbove60)
                {
                    Console.WriteLine($"Employee {emp.EmployeeID} is still a member of Club {ClubName} despite age > 60.");
                }
            }
        }
    }
}
