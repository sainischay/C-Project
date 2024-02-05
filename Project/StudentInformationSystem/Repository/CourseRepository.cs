using StudentInformationSystem.Exceptions;
using StudentInformationSystem.Models;
using StudentInformationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    internal class CourseRepository:ICourseRepository
    {
        string databaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public CourseRepository()
        {
            command = new SqlCommand();
        }

        public int CreateCourse(Course course,int teacherId)
        {
            if (!ExceptionHandling.IsCourseDataValid(course.CourseName, course.CourseCredits))
                throw new InvalidCourseDataException("Invalid course data");
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "insert into Courses values(@courseName,@teacherId,@credits)";
                command.Parameters.AddWithValue("@courseName", course.CourseName);
                command.Parameters.AddWithValue("@credits", course.CourseCredits);
                command.Parameters.AddWithValue("@teacherId", teacherId);

                return command.ExecuteNonQuery();
            }
        }

        public int UpdateCourse(int courseId, string courseName, int teacherId, int credits)
        {
            if (!ExceptionHandling.IsCourseDataValid(courseName, credits))
                throw new InvalidCourseDataException("Invalid course data");
            if (!ExceptionHandling.IsCourseExists(courseId))
                throw new CourseNotFoundException("Course Does not exist with this id");
            using (SqlConnection conection = new SqlConnection(databaseConnectionString))
            {
                conection.Open();
                command.Connection = conection;
                command.Parameters.Clear();
                command.CommandText = "update Courses set course_name=@courseName,teacher_id=@teacherId,credits=@credits where course_id=@course_id";
                command.Parameters.AddWithValue("@teacherId", teacherId);
                command.Parameters.AddWithValue("@course_id", courseId);
                command.Parameters.AddWithValue("@courseName", courseName);
                command.Parameters.AddWithValue("@credits", credits);

                return command.ExecuteNonQuery();


            }
        }

        public List<Course> GetListOfCourse()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conection = new SqlConnection(databaseConnectionString))
            {
                conection.Open();
                command.Connection = conection;
                command.Parameters.Clear();
                command.CommandText = "select * from Courses";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseId = (int)reader["course_id"];
                    course.CourseName = (string)reader["course_name"];
                    course.TeacherId = (int)reader["teacher_id"];
                    course.CourseCredits = (int)reader["credits"];
                    
                    courses.Add(course);

                }
                return courses;
            }
        }

        public int DeleteCourse(int courseId)
        {
            if (!ExceptionHandling.IsCourseExists(courseId))
                throw new CourseNotFoundException("Course Does not exist with this id");
            using (SqlConnection conection = new SqlConnection(databaseConnectionString))
            {
                conection.Open();
                command.Connection = conection;
                command.Parameters.Clear();
                command.CommandText = "delete from Courses where course_id=@courseId";
                command.Parameters.AddWithValue("@courseId", courseId);
                return command.ExecuteNonQuery();
            }
        }
    }
}
