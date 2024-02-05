using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal interface IStudentInformationSystemService
    {
        bool EnrollStudentInCourse();

        bool RecordPayment();

        List<Enrollment> GetEnrolledCourses();

        List<Payment> GetPaymentHistory();

        bool AssignTeacherToCourse();

        List<Student> GetEnrollmentByCourse();

        List<Teacher> GetTeacherByCourse();

        List<Course> GetCourseByTeacher();

        List<Student> GetStudentByPayment();

        int GetAmountByPayment();

        DateTime GetDateByPayment();

        List<Payment> GeneratePaymentReport();


        List<Enrollment> CalculateCourseStatistics();
    }
}
