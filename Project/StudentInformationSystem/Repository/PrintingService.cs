using StudentInformationSystem.Models;
using StudentInformationSystem.Service;
using StudentInformationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    static class PrintingService
    {
        static IStudentService studentService = new StudentService();
        static ITeacherService teacherService = new TeacherService();
        static ICourseService courseService = new CourseService();
        static IStudentInformationSystemService studentInformationSystemService = new StudentInformationSystemService();
        public static void GetListOfStudents()
        {
            List<Student> students = studentService.GetListOfStudents();
            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-15} {4,-20} {5,-15}", "StudentId", "FirstName", "LastName", "DateOfBirth", "Email", "PhoneNumber");
            foreach (Student student in students)
            {
                DateTime dateTime = student.DateOfBirth;
                string formattedDate = dateTime.ToString("yyyy-MM-dd");
                Console.WriteLine($"{student.StudentId,-10} {student.FirstName,-15} {student.LastName,-15} {formattedDate,-15} {student.Email,-20} {student.PhoneNumber,-15}");
            }
        }

        public static void GetListOfTeachers()
        {
            List<Teacher> teachers = teacherService.GetListOfTeachers();
            Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-20}", "TeacherId", "FirstName", "LastName", "Email");
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine($"{teacher.TeacherId,-10} {teacher.FirstName,-15} {teacher.LastName,-15} {teacher.Email,-20}");
            }
        }

        public static void GetListOfCourses()
        {
            List<Course> courses = courseService.GetListOfCourse();
            Console.WriteLine("{0,-10} {1,-15} {2,-10} {3,-10}", "CourseId", "CourseName", "TeacherId", "Credits");
            foreach (Course course in courses)
            {
                Console.WriteLine($"{course.CourseId,-10} {course.CourseName,-15} {course.TeacherId,-10} {course.CourseCredits,-10}");
            }
        }

        public static void GetEnrolledCourses()
        {
            List<Enrollment> enrollments = studentInformationSystemService.GetEnrolledCourses();
            Console.WriteLine("{0,-15} {1,-10} {2,-10}", "EnrollmentDate", "CourseId", "CourseName");
            foreach (Enrollment enrollment in enrollments)
            {
                DateTime dateTime = enrollment.EnrollmentDate;
                string formattedDate = dateTime.ToString("yyyy-MM-dd");
                Console.Write($"{formattedDate,-15}");
                foreach (Course course in enrollment.CourseList)
                    Console.WriteLine($"{course.CourseId,-10} {course.CourseName,-10}");
            }
        }

        public static void GetPaymentHistory() {
            List<Payment> payments = studentInformationSystemService.GetPaymentHistory();
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15}", "PaymentId", "StudentId", "Amount", "PaymentDate");
            foreach (Payment payment in payments)
            {
                DateTime dateTime = payment.PaymentDate;
                string formattedDate = dateTime.ToString("yyyy-MM-dd");
                Console.WriteLine($"{payment.PaymentId,-10} {payment.StudentId,-10} {payment.Amount,-10} {formattedDate,-15}");
            }
        }

        public static void GetEnrollmentByCourse()
        {
            List<Student> studentsEnrolled = studentInformationSystemService.GetEnrollmentByCourse();
            Console.WriteLine("{0,-15} {1,-15}", "FirstName", "LastName");
            foreach (Student studentEnrolled in studentsEnrolled)
            {
                Console.WriteLine($"{studentEnrolled.FirstName,-15} {studentEnrolled.LastName,-15}");
            }
        }

        public static void GetTeacherByCourse()
        {
            List<Teacher> teachersByCourse = studentInformationSystemService.GetTeacherByCourse();
            Console.WriteLine("{0,-15} {1,-15}", "FirstName", "LastName");
            foreach (Teacher teacherByCourse in teachersByCourse)
            {
                Console.WriteLine($"{teacherByCourse.FirstName,-15} {teacherByCourse.LastName,-15}");
            }
        }

        public static void GetCourseByTeacher()
        {
            List<Course> coursesByTeacher = studentInformationSystemService.GetCourseByTeacher();
            Console.WriteLine("{0,-15} {1,-10}", "CourseName", "Credits");
            foreach (Course courseByTeacher in coursesByTeacher)
            {
                Console.WriteLine($"{courseByTeacher.CourseName,-15} {courseByTeacher.CourseCredits,-10}");
            }
        }

        public static void GetStudentByPayment()
        {
            List<Student> studentsByPayment = studentInformationSystemService.GetStudentByPayment();
            Console.WriteLine("{0,-15} {1,-15}", "FirstName", "LastName");
            foreach (Student studentByPayment in studentsByPayment)
            {
                Console.WriteLine($"{studentByPayment.FirstName,-15} {studentByPayment.LastName,-15}");
            }
        }


        public static void CalculateCourseStatistics()
        {
            List<Enrollment> courseStatistics = studentInformationSystemService.CalculateCourseStatistics();
            Console.WriteLine("{0,-15} {1,-15}", "EnrollmentCount", "TotalPayment");
            foreach (Enrollment stat in courseStatistics)
            {
                Console.Write($"{stat.EnrollmentId,-15}");
                foreach (Payment payment in stat.Payments)
                    Console.WriteLine($"{payment.Amount,-15}");
            }
        }

        public static void GetListOfPayments()
        {
            List<Payment> payments = new List<Payment>();
            using(SqlConnection connection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection= connection;
                command.CommandText = "select * from Payments";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Payment payment = new Payment();
                    payment.PaymentId = (int)reader["payment_id"];
                    payment.StudentId = (int)reader["student_id"];
                    payment.Amount = (int)reader["amount"];
                    payment.PaymentDate = (DateTime)reader["payment_date"];
                    payments.Add(payment);
                }
            }
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}", "PaymentId", "StudentId", "Amount","PaymentDate");
            foreach (Payment payment in payments)
            {
                DateTime dateTime = payment.PaymentDate;
                string formattedDate = dateTime.ToString("yyyy-MM-dd");
                Console.WriteLine($"{payment.PaymentId,-15} {payment.StudentId,-15} {payment.Amount,-15} {formattedDate,-15}");
            }
        }
    }
}
