using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal class CourseService:ICourseService
    {
        ICourseRepository courseRepository;
        public CourseService()
        {
            courseRepository = new CourseRepository();
        }
        public bool CreateCourse()
        {
            Course course = new Course();
            Console.WriteLine("Enter courseName");
            course.CourseName = Console.ReadLine();
            PrintingService.GetListOfTeachers();
            Console.WriteLine("Enter teacherId to associate with course from above");
            int teacherId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter course credits");
            course.CourseCredits=int.Parse(Console.ReadLine());
            try
            {
                int status = courseRepository.CreateCourse(course, teacherId);
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateCourse()
        {
            PrintingService.GetListOfCourses();
            Console.WriteLine("Enter courseId to be updated from above");
            int courseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter courseName");
            string courseName = Console.ReadLine();
            PrintingService.GetListOfTeachers();
            Console.WriteLine("Enter teacherId to associate with course");
            int teacherId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter credits for course");
            int credits = int.Parse(Console.ReadLine());
            try
            {
                int status = courseRepository.UpdateCourse(courseId,courseName, teacherId,credits);
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Course> GetListOfCourse()
        {
            List<Course> courseList = new List<Course>();
            try
            {
                courseList = courseRepository.GetListOfCourse();
                return courseList;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return courseList;
            }
        }

        public bool DeleteCourse()
        {
            PrintingService.GetListOfCourses();
            Console.WriteLine("Enter courseId to be deleted from above");
            int courseId = int.Parse(Console.ReadLine());
            try
            {
                int status = courseRepository.DeleteCourse(courseId);
                return status>0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
