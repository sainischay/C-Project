using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Exceptions
{
    internal class DateException:ApplicationException
    {
        public DateException(string msg):base(msg)
        {
            
        }
    }
}
