
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVC_C_05
{
    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        private int vacationStock;
        public int VacationStock
        {
            get { return vacationStock; }
            set { vacationStock = value; }
        }

        public bool RequestVacation(DateTime from, DateTime to)
        {
            int days = (to - from).Days + 1;
            VacationStock -= days;

            if (VacationStock < 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.VacationStockNegative));
                return false;
            }

            return true;
        }

        public void EndOfYearOperation()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate.Date > DateTime.Now.AddYears(-age)) age--;

            if (age > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(LayOffCause.AgeAbove60));
            }
        }
    }

    public enum LayOffCause
    {
        VacationStockNegative,
        AgeAbove60
    }
}