using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;
using StudentInformationSystem.Service;
using System.Data.SqlClient;

namespace StudentInformationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentService studentService = new StudentService();
            ITeacherService teacherService = new TeacherService();
            ICourseService courseService = new CourseService();
            IStudentInformationSystemService studentInformationSystemService = new StudentInformationSystemService();
            bool con = true;


            while (con) {
                Console.WriteLine("Enter 1 for StudentSerive\n" +
                    "Enter 2 for TeacherService\n" +
                    "Enter 3 for CourseService\n" +
                    "Enter 4 for StudentInformationSystem Service\n" +
                    "Enter 0 for Exit");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: Console.WriteLine("Enter 1 for Adding New Student\n" +
                        "Enter 2 for Getting all student Details\n" +
                        "Enter 3 for Updating Student Details\n" +
                        "Enter 4 for Deleting Student Details");
                        int studentChoice = int.Parse(Console.ReadLine());
                        switch (studentChoice)
                        {
                            case 1:
                                Console.WriteLine(studentService.CreateStudent());
                                break;
                            case 2: PrintingService.GetListOfStudents();
                                break;
                            case 3: Console.WriteLine(studentService.UpdateStudent());
                                break;
                            case 4: Console.WriteLine(studentService.DeleteStudent());
                                break;
                            default: Console.WriteLine("Wrong choice");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter 1 for Adding New Teacher\n" +
                        "Enter 2 for Getting all Teacher Details\n" +
                        "Enter 3 for Updating Teacher Details\n" +
                        "Enter 4 for Deleting Teacher Details");
                        int teacherChoice = int.Parse(Console.ReadLine());
                        switch (teacherChoice)
                        {
                            case 1:
                                Console.WriteLine(teacherService.CreateTeacher());
                                break;
                            case 2:
                                PrintingService.GetListOfTeachers();
                                break;  
                            case 3:
                                Console.WriteLine(teacherService.UpdateTeacher());
                                break;
                            case 4:
                                Console.WriteLine(teacherService.DeleteTeacher());
                                break;
                            default:
                                Console.WriteLine("Wrong choice");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter 1 for Adding New Course\n" +
                        "Enter 2 for Getting all Course Details\n" +
                        "Enter 3 for Updating Course Details\n" +
                        "Enter 4 for Deleting Course Details");
                        int courseChoice = int.Parse(Console.ReadLine());
                        switch (courseChoice)
                        {
                            case 1:
                                Console.WriteLine(courseService.CreateCourse());
                                break;
                            case 2:
                                PrintingService.GetListOfCourses();
                                break;
                            case 3:
                                Console.WriteLine(courseService.UpdateCourse());
                                break;
                            case 4:
                                Console.WriteLine(courseService.DeleteCourse());
                                break;
                            default:
                                Console.WriteLine("Wrong choice");
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter 1 for adding Enrollment for student");
                        Console.WriteLine("Enter 2 for Making Payment for student");
                        Console.WriteLine("Enter 3 for Getting Courses enrolled for a specific student");
                        Console.WriteLine("Enter 4 for Getiing Payments made by a specific student");
                        Console.WriteLine("Enter 5 for assigning a teacher to a course");
                        Console.WriteLine("Enter 6 for Getting enrollments for a particular course");
                        Console.WriteLine("Enter 7 for Getting Teacher details for a particular course");
                        Console.WriteLine("Enter 8 for Getting Course details for a particular Teacher");
                        Console.WriteLine("Enter 9 for Getting Student details for a particular Payment");
                        Console.WriteLine("Enter 10 for Getting Amount details for a particular Payment");
                        Console.WriteLine("Enter 11 for Getting Date for a particular Payment");
                        Console.WriteLine("Enter 12 for Getting Coursestatistics for a particular Course");
                        int sisChoice = int.Parse(Console.ReadLine());
                        switch (sisChoice)
                        {
                            case 1: Console.WriteLine(studentInformationSystemService.EnrollStudentInCourse());
                                break;
                            case 2:
                                Console.WriteLine(studentInformationSystemService.RecordPayment());
                                break;
                            case 3:
                                PrintingService.GetEnrolledCourses();
                                break;
                            case 4:
                                PrintingService.GetPaymentHistory();
                                break;
                            case 5:
                                Console.WriteLine(studentInformationSystemService.AssignTeacherToCourse()); ;
                                break;
                            case 6:
                                PrintingService.GetEnrollmentByCourse();
                                break;
                            case 7:
                                PrintingService.GetTeacherByCourse();
                                break;
                            case 8:
                                PrintingService.GetCourseByTeacher();
                                break;
                            case 9:
                                PrintingService.GetStudentByPayment();
                                break;
                            case 10:
                                Console.WriteLine(studentInformationSystemService.GetAmountByPayment());
                                break;
                            case 11:
                                Console.WriteLine(studentInformationSystemService.GetDateByPayment());
                                break;
                            case 12:
                                PrintingService.CalculateCourseStatistics();
                                break;
                        }
                        break;
                    case 0: con = false;
                        break;
                    default: Console.WriteLine("Wrong Choice");
                        break;
                }
            }
        }
    }
}

