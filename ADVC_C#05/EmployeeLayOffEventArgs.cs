using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVC_C_05
{
    public class EmployeeLayOffEventArgs : EventArgs
    {
        public LayOffCause Cause { get; set; }

        public EmployeeLayOffEventArgs(LayOffCause cause)
        {
            Cause = cause;
        }
    }
}
