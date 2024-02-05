using StudentInformationSystem.Models;
using StudentInformationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    internal interface IStudentInformationSystemRepository
    {
        int EnrollStudentInCourse(int studentId, int courseId,DateTime enrollmentDate);

        int RecordPayment(int studentId,int amount,DateTime paymentDate);

        List<Enrollment> GetEnrolledCourses(int studentId);

        List<Payment> GetPaymentHistory(int studentId);

        int AssignTeacherToCourse(int teacherId, int courseId);

        List<Student> GetEnrollmentByCourse(int courseId);

        List<Teacher> GetTeacherByCourse(string courseName);

        List<Course> GetCourseByTeacher(int teacherId);

        List<Student> GetStudentByPayment(int paymentId);

        int GetAmountByPayment(int paymentId);

        DateTime GetDateByPayment(int paymentId);

        List<Payment> GeneratePaymentReport(int studentId);


        List<Enrollment> CalculateCourseStatistics(int courseId);
    }
}
