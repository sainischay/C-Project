using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Model;
using HospitalManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    internal class DoctorRepository:IDoctorRepository
    {
        string dataBaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public DoctorRepository()
        {
            command = new SqlCommand();
        }

        public int CreateDoctor(Doctor doctor)
        {
            if (!ExceptionHandler.ValidateNum(doctor.ContactNumber))
                throw new InvalidPhoneNumber("Invalid Phone Number");
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "insert into Doctor values(@firstName,@lastName,@specialization,@contactNumber)";
                command.Parameters.AddWithValue("@firstName", doctor.FirstName);
                command.Parameters.AddWithValue("@lastName", doctor.LastName);
                command.Parameters.AddWithValue("@specialization", doctor.Specialization);
                command.Parameters.AddWithValue("@contactNumber", doctor.ContactNumber);
                return command.ExecuteNonQuery();
            }
        }


        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Doctor";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.DoctorId = (int)reader["doctorId"];
                    doctor.FirstName = (string)reader["firstName"];
                    doctor.LastName = (string)reader["lastName"];
                    doctor.Specialization = (string)reader["specialization"];
                    doctor.ContactNumber = (string)reader["contactNumber"];
                    doctors.Add(doctor);
                }
                return doctors;
            }
        }

        public int UpdateDoctor(Doctor doctor)
        {
            if (!ExceptionHandler.ValidateNum(doctor.ContactNumber))
                throw new InvalidPhoneNumber("Invalid Phone Number");
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "update Doctor set firstName=@firstName,lastName=@lastName,specialization=@specialization,contactNumber=@contactNumber where doctorId=@doctorId";
                command.Parameters.AddWithValue("@doctorId", doctor.DoctorId);
                command.Parameters.AddWithValue("@firstName", doctor.FirstName);
                command.Parameters.AddWithValue("@lastName", doctor.LastName);
                command.Parameters.AddWithValue("@specialization", doctor.Specialization);
                command.Parameters.AddWithValue("@contactNumber", doctor.ContactNumber);
                return command.ExecuteNonQuery();
            }
        }


        public int DeleteDoctor(int doctorId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "delete from Doctor where doctorId=@doctorId";
                    command.Parameters.AddWithValue("@doctorId", doctorId);
                    return command.ExecuteNonQuery();
                }
            }
            catch(SqlException ex) { 
                throw new Exception(ex.Message);
            }
        }
    }
}
