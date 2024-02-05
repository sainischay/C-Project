using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal class TeacherService:ITeacherService
    {
        ITeacherRepository teacherRepository;
        public TeacherService()
        {
            teacherRepository = new TeacherRepository();
        }
        public bool CreateTeacher()
        {
            Teacher teacher = new Teacher();
            Console.WriteLine("Enter first name");
            teacher.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            teacher.LastName = Console.ReadLine();
            Console.WriteLine("Enter email");
            teacher.Email = Console.ReadLine();

            try
            {
                int status = teacherRepository.CreateTeacher(teacher);
                return status > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateTeacher()
        {
            PrintingService.GetListOfTeachers();
            Console.WriteLine("Enter teacherId from above");
            int teacherId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            try
            {
                int status = teacherRepository.UpdateTeacher(teacherId,firstName,lastName,email);
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Teacher> GetListOfTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                teachers = teacherRepository.GetListOfTeachers();
                return teachers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return teachers;
            }
        }

        public bool DeleteTeacher()
        {
            PrintingService.GetListOfTeachers();
            Console.WriteLine("Enter teacherId from above");
            int teacherId = int.Parse(Console.ReadLine());
            try
            {
                int status = teacherRepository.DeleteTeacher(teacherId);
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
