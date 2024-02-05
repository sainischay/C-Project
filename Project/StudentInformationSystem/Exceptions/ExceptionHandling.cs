using StudentInformationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Exceptions
{
    internal static class ExceptionHandling
    {
        public static bool IsStudentAlreadyEnrolled(int studentId, int courseId)
        {
            string databaseConnectionString = DbConnUtil.GetConnectionString();
            SqlCommand command = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Enrollments where student_id = @studentId AND course_id = @courseId";
                command.Parameters.AddWithValue("@studentId", studentId);
                command.Parameters.AddWithValue("@courseId", courseId);

                SqlDataReader reader = command.ExecuteReader();

                return reader.HasRows;
            }
        }

        public static bool IsCourseExists(int courseId)
        {
            string databaseConnectionString = DbConnUtil.GetConnectionString();
            SqlCommand command = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select COUNT(*) FROM Courses WHERE course_id = @courseId";
                command.Parameters.AddWithValue("@courseId", courseId);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool IsCourseExistsWithName(string courseName)
        {
            string databaseConnectionString = DbConnUtil.GetConnectionString();
            SqlCommand command = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select COUNT(*) FROM Courses where course_name = @CourseName";
                command.Parameters.AddWithValue("@courseName", courseName);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public static bool IsStudentExists(int studentId)
        {
            string databaseConnectionString = DbConnUtil.GetConnectionString();
            SqlCommand command = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();

                command.CommandText = "select COUNT(*) from Students where student_id = @studentId";
                command.Parameters.AddWithValue("@studentId", studentId);

                int count = (int)command.ExecuteScalar();

                return count > 0;
               
            }
        }



        public static bool IsTeacherExists(int teacherId)
        {
            string databaseConnectionString = DbConnUtil.GetConnectionString();
            SqlCommand command = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();

                command.CommandText = "select COUNT(*) from Teacher where teacher_id = @teacherId";
                command.Parameters.AddWithValue("@teacherId", teacherId);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }

        }

        public static bool IsPaymentValidate(int amount,DateTime paymentDate)
        {
            if(paymentDate>DateTime.Now || (amount)<5000 || (amount) > 100000)
            {
                return false;
            }
            return true;
        }


        public static bool IsStudentDetailsValidate(DateTime dateOfBirth,string email,string firstName,string lastName)
        {
            if(dateOfBirth>DateTime.Now || !email.Contains("@gmail.com"))
                return false;
            else
                return true;
        }


        public static bool IsCourseDataValid(string courseName,int credits)
        {
            if (credits > 5)
                return false;
            return true;
        }


        public static bool IsTeacherDataValid(string firstName,string lastName,string email)
        {
            if (!email.Contains("@gmail.com"))
                return false;
            else
                return true;
        }
    }
}
