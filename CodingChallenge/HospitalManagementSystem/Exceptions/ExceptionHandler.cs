using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Exceptions
{
    static class ExceptionHandler
    {
        public const string pattern = @"^[+]?91[-\s]?[6-9][0-9]{9}$";

        public static bool ValidateNum(string num)
        {
            if (num != null)
            {
                return Regex.IsMatch(num, pattern);
            }
            return false;
        }


        public static bool DateOfBirthValidator(DateTime dateofBirth)
        {
            if (dateofBirth >= DateTime.Now)
                return true;
            else
                return false;
        }

        public static bool AppointmentDateValidator(DateTime dateofBirth)
        {
            if (dateofBirth <= DateTime.Now)
                return true;
            else
                return false;
        }
    }
}
