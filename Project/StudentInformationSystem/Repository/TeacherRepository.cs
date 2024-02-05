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
    internal class TeacherRepository:ITeacherRepository
    {
        string databaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public TeacherRepository()
        {
            command = new SqlCommand();
        }

        public int CreateTeacher(Teacher teacher)
        {
            if (!ExceptionHandling.IsTeacherDataValid(teacher.FirstName, teacher.LastName, teacher.Email))
                throw new InvalidTeacherDataException("Invalid email exception");
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "insert into Teacher values(@firstName,@lastName,@email)";
                command.Parameters.AddWithValue("@firstName", teacher.FirstName);
                command.Parameters.AddWithValue("@lastName", teacher.LastName);
                command.Parameters.AddWithValue("@email", teacher.Email);
                
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateTeacher(int teacherId, string firstName, string lastName, string email)
        {
            if(!ExceptionHandling.IsTeacherDataValid(firstName, lastName, email))
                throw new InvalidTeacherDataException("Invalid Teacher date exception");
            if (!ExceptionHandling.IsTeacherExists(teacherId))
                throw new TeacherNotFoundException("Teacher Does not exist with this id");
            using (SqlConnection conection = new SqlConnection(databaseConnectionString))
            {
                conection.Open();
                command.Connection = conection;
                command.Parameters.Clear();
                command.CommandText = "update Teacher set first_name=@firstName,last_name=@lastName,email=@email where teacher_id=@teacherId";
                command.Parameters.AddWithValue("@teacherId", teacherId);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@email", email);

                return command.ExecuteNonQuery();


            }
        }

        public List<Teacher> GetListOfTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            using (SqlConnection conection = new SqlConnection(databaseConnectionString))
            {
                conection.Open();
                command.Connection = conection;
                command.Parameters.Clear();
                command.CommandText = "select * from Teacher";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.TeacherId = (int)reader["teacher_id"];
                    teacher.FirstName = (string)reader["first_name"];
                    teacher.LastName = (string)reader["last_name"];
                    teacher.Email = (string)reader["email"];
                    teachers.Add(teacher);

                }
                return teachers;
            }
        }

        public int DeleteTeacher(int teacherId)
        {
            if (!ExceptionHandling.IsTeacherExists(teacherId))
                throw new TeacherNotFoundException("Teacher Does not exist with this id");
            using (SqlConnection conection = new SqlConnection(databaseConnectionString))
            {
                conection.Open();
                command.Connection = conection;
                command.Parameters.Clear();
                command.CommandText = "delete from Teacher where teacher_id=@teacherId";
                command.Parameters.AddWithValue("@teacherId", teacherId);
                return command.ExecuteNonQuery();
            }
        }
    }
}
