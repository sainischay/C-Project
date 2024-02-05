using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    internal interface IStudentRepository
    {
        int CreateStudent(Student student);

        int UpdateStudent(int studentId,string firstName,string lastName,DateTime dateOfBirth,string email,string phoneNumber);

        List<Student> GetListOfStudents();

        int DeleteStudent(int studentId);
    }
}
