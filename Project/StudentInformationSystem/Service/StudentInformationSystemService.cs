using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal class StudentInformationSystemService:IStudentInformationSystemService
    {
        IStudentInformationSystemRepository _studentInformationSystem;
        public StudentInformationSystemService()
        {
            _studentInformationSystem = new StudentInformationSystemRepository();
        }
        public bool EnrollStudentInCourse()
        {
            PrintingService.GetListOfStudents();
            Console.WriteLine("Enter StudentId from above ids");
            int studentId =int.Parse(Console.ReadLine());
            PrintingService.GetListOfCourses();
            Console.WriteLine("Enter the courseid from above courseId");
            int courseId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter enrollmentDate");
            DateTime time = DateTime.Parse(Console.ReadLine());
            try
            {
                int status = _studentInformationSystem.EnrollStudentInCourse(studentId, courseId, time);
                return status > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool RecordPayment()
        {
            PrintingService.GetListOfStudents();
            Console.WriteLine("Enter StudentId from above ids");
            int studentId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter paymentDate");
            DateTime time = DateTime.Parse(Console.ReadLine());
            try
            {
                int status = _studentInformationSystem.RecordPayment(studentId, amount, time);
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Enrollment> GetEnrolledCourses()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            PrintingService.GetListOfStudents();
            Console.WriteLine("Enter StudentId from from above ids");
            int studentId = int.Parse(Console.ReadLine());
            try
            {
                enrollments = _studentInformationSystem.GetEnrolledCourses(studentId);
                return enrollments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return enrollments;
            }
        }

        public List<Payment> GetPaymentHistory()
        {
            List<Payment> payments = new List<Payment>();
            PrintingService.GetListOfStudents();
            Console.WriteLine("Enter StudentId from above ids");
            int studentId = int.Parse(Console.ReadLine());
            try
            {
                payments = _studentInformationSystem.GetPaymentHistory(studentId);
                return payments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return payments;
            }
        }

        public bool AssignTeacherToCourse()
        {
            PrintingService.GetListOfTeachers();
            Console.WriteLine("Enter TeacherId from above ids");
            int teacherId = int.Parse(Console.ReadLine());
            PrintingService.GetListOfCourses();
            Console.WriteLine("Enter CourseId from above ids");
            int courseId = int.Parse(Console.ReadLine());
            try
            {
                int status = _studentInformationSystem.AssignTeacherToCourse(teacherId, courseId);
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Student> GetEnrollmentByCourse()
        {
            List<Student> students = new List<Student>();
            PrintingService.GetListOfCourses();
            Console.WriteLine("Enter CourseId from above ids");
            int courseId = int.Parse(Console.ReadLine());
            try
            {
                students = _studentInformationSystem.GetEnrollmentByCourse(courseId);
                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return students;
            }
        }

        public List<Teacher> GetTeacherByCourse()
        {
            List<Teacher> teachers = new List<Teacher>();
            PrintingService.GetListOfCourses();
            Console.WriteLine("Enter CourseName from above course");
            string courseName = Console.ReadLine();
            try
            {
                teachers = _studentInformationSystem.GetTeacherByCourse(courseName);
                return teachers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return teachers;
            }
        }

        public List<Course> GetCourseByTeacher()
        {
            List<Course> courses = new List<Course>();
            PrintingService.GetListOfTeachers();
            Console.WriteLine("Enter TeacherId from above ids");
            int teacherId = int.Parse(Console.ReadLine());
            try
            {
                courses = _studentInformationSystem.GetCourseByTeacher(teacherId);
                return courses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return courses;
            }

        }

        public List<Student> GetStudentByPayment()
        {
            List<Student> students = new List<Student>();
            PrintingService.GetListOfPayments();
            Console.WriteLine("Enter paymentId payments");
            int paymenyId=int.Parse(Console.ReadLine());
            try
            {
                students = _studentInformationSystem.GetStudentByPayment(paymenyId);
                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return students;
            }
        }

        public int GetAmountByPayment()
        {
            int amount = 0;
            PrintingService.GetListOfPayments();
            Console.WriteLine("Enter paymentId");
            int paymentId = int.Parse(Console.ReadLine());
            try
            {
                amount = _studentInformationSystem.GetAmountByPayment(paymentId);
                return amount;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return amount;
            }
        }

        public DateTime GetDateByPayment()
        {
            DateTime date=new DateTime();
            PrintingService.GetListOfPayments();
            Console.WriteLine("Enter paymentId");
            int paymentId = int.Parse(Console.ReadLine());
            try
            {
                date = _studentInformationSystem.GetDateByPayment(paymentId);
                return date;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return date;
            }
        }

        public List<Payment> GeneratePaymentReport()
        {
            List<Payment> payments = new List<Payment>();
            PrintingService.GetListOfStudents();
            Console.WriteLine("Enter StudentId from above ids");
            int studentId = int.Parse(Console.ReadLine());
            try
            {
                payments = _studentInformationSystem.GeneratePaymentReport(studentId);
                return payments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return payments;
            }
        }


        public List<Enrollment> CalculateCourseStatistics()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            PrintingService.GetListOfCourses();
            Console.WriteLine("Enter CourseId from above ids");
            int courseId = int.Parse(Console.ReadLine());
            try
            {
                enrollments = _studentInformationSystem.CalculateCourseStatistics(courseId);
                return enrollments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return enrollments;
            }
        }
    }
}
