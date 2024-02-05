using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal class StudentService : IStudentService
    {
        IStudentRepository studentRepository;
        public StudentService()
        {
            studentRepository = new StudentRepository();
        }
        public bool CreateStudent()
        {
            Student student = new Student();
            Console.WriteLine("Enter student first name");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Enter student last name");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Enter date of birth");
            student.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter email");
            student.Email = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            student.PhoneNumber = Console.ReadLine();

            try
            {
                int status = studentRepository.CreateStudent(student);
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public List<Student> GetListOfStudents(){
            List<Student> students = new List<Student>();
            try
            {
                students = studentRepository.GetListOfStudents();
                return students;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return students;
            }
        }


        public bool UpdateStudent()
        {
            PrintingService.GetListOfStudents();
            Console.WriteLine("Enter studentId from the above");
            int studentId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter student last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter date of birth");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string phoneNumber = Console.ReadLine();

            try
            {
                int status = studentRepository.UpdateStudent(studentId,firstName, lastName, dateOfBirth, email, phoneNumber);
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteStudent()
        {
            PrintingService.GetListOfStudents();
            Console.WriteLine("Enter studentId from above");
            int studentId = int.Parse(Console.ReadLine());
            try
            {
                int status = studentRepository.DeleteStudent(studentId);
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
