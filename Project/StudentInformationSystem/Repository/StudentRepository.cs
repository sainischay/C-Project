using StudentInformationSystem.Utils;
using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using StudentInformationSystem.Exceptions;

namespace StudentInformationSystem.Repository
{
    internal class StudentRepository:IStudentRepository
    {
        string databaseConnectionString= DbConnUtil.GetConnectionString();
        SqlCommand command;

        public StudentRepository()
        {
            command = new SqlCommand();
        }

        public int CreateStudent(Student student)
        {
            if(!ExceptionHandling.IsStudentDetailsValidate(student.DateOfBirth,student.Email,student.FirstName,student.LastName))
                throw new InvalidStudentDataException("Invalid date of birth or email");
            using (SqlConnection connection = new SqlConnection(databaseConnectionString)) { 
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "insert into Students values(@firstName,@lastName,@dateOfBirth,@email,@phoneNumber)";
                command.Parameters.AddWithValue("@firstName", student.FirstName);
                command.Parameters.AddWithValue("@lastName", student.LastName);
                command.Parameters.AddWithValue("@dateOfBirth", student.DateOfBirth);
                command.Parameters.AddWithValue("@email", student.Email);
                command.Parameters.AddWithValue("@phoneNumber", student.PhoneNumber);
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateStudent(int studentId, string firstName, string lastName, DateTime dateOfBirth,string email, string phoneNumber)
        {
            if (!ExceptionHandling.IsStudentDetailsValidate(dateOfBirth, email,firstName,lastName))
                throw new InvalidStudentDataException("Invalid date of birth or email");
            if (!ExceptionHandling.IsStudentExists(studentId))
                throw new StudentNotFoundException("Student Does not exist with this id");
            using (SqlConnection conection = new SqlConnection(databaseConnectionString)) {
                conection.Open();
                command.Connection= conection;
                command.Parameters.Clear();
                command.CommandText = "update Students set first_name=@firstName,last_name=@lastName,date_of_birth=@dateOfBirth,phone_number=@phoneNumber,email=@email where student_id=@studentId";
                command.Parameters.AddWithValue("@studentId", studentId);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                return command.ExecuteNonQuery();


            }
        }

        public List<Student> GetListOfStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conection = new SqlConnection(databaseConnectionString))
            {
                conection.Open();
                command.Connection = conection;
                command.Parameters.Clear();
                command.CommandText = "select * from Students";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentId = (int)reader["student_id"];
                    student.FirstName = (string)reader["first_name"];
                    student.LastName= (string)reader["last_name"];
                    student.DateOfBirth = (DateTime)reader["date_of_birth"];
                    student.Email = (string)reader["email"];
                    student.PhoneNumber = (string)reader["phone_number"];
                    students.Add(student);

                }
                return students;
            }
            }

        public int DeleteStudent(int studentId)
        {
            if (!ExceptionHandling.IsStudentExists(studentId))
                throw new StudentNotFoundException("Student Does not exist with this id");
            using (SqlConnection conection = new SqlConnection(databaseConnectionString))
            {
                conection.Open();
                command.Connection = conection;
                command.Parameters.Clear();
                command.CommandText = "delete from Students where student_id=@studentId";
                command.Parameters.AddWithValue("@studentId", studentId);
                return command.ExecuteNonQuery();
            }
        }
    }
}
