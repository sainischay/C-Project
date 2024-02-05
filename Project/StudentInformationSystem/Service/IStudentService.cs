using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal interface IStudentService
    {
        bool CreateStudent();

        bool UpdateStudent();

        List<Student> GetListOfStudents();

        bool DeleteStudent();
    }
}
