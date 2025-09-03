using System;
using ADVC_C_05;

namespace MyApp
{
    internal class Program
    {

        #region q1
        enum LayOffCause
        {
            VacationStockNegative,   
            AgeAbove60             
        }
        #endregion
        static void Main(string[] args)
        {
            #region q1

            Employee emp = new Employee
            {
                EmployeeID = 1,
                BirthDate = new DateTime(1960, 5, 1),
                VacationStock = 5
            };

            emp.EmployeeLayOff += (sender, e) =>
            {
                Console.WriteLine($"Employee Laid Off due to: {e.Cause}");
            };

            emp.RequestVacation(DateTime.Now, DateTime.Now.AddDays(10));

            emp.EndOfYearOperation();

            #endregion

        }
    }
}