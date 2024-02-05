using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    internal interface ITeacherRepository
    {
        int CreateTeacher(Teacher teacher);

        int UpdateTeacher(int teacherId, string firstName, string lastName, string email);

        List<Teacher> GetListOfTeachers();

        int DeleteTeacher(int teacherId);
    }
}
