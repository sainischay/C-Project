using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal interface ITeacherService
    {
        bool CreateTeacher();

        bool UpdateTeacher();

        List<Teacher> GetListOfTeachers();

        bool DeleteTeacher();
    }
}
