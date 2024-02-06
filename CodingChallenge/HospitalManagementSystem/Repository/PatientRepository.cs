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
    internal class PatientRepository:IPatientRepository
    {
        string dataBaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public PatientRepository()
        {
            command = new SqlCommand();
        }

        public int CreatePatient(Patient patient)
        {
            if (ExceptionHandler.DateOfBirthValidator(patient.DateOfBirth))
                throw new DateException("Invalid DateOfBirth It should be less than Current Date");
            if (!ExceptionHandler.ValidateNum(patient.ContactNumber))
                throw new InvalidPhoneNumber("Invalid Phone Number");
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "insert into Patient values(@firstName,@lastName,@dateOfBirth,@gender,@contactNumber,@address)";
                command.Parameters.AddWithValue("@firstName", patient.FirstName);
                command.Parameters.AddWithValue("@lastName", patient.LastName);
                command.Parameters.AddWithValue("@dateOfBirth", patient.DateOfBirth);
                command.Parameters.AddWithValue("@gender", patient.Gender);
                command.Parameters.AddWithValue("@contactNumber", patient.ContactNumber);
                command.Parameters.AddWithValue("@address", patient.Address);
                return command.ExecuteNonQuery();
            }
        }


        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Patient";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Patient patient = new Patient();
                    patient.PatientId = (int)reader["patientId"];
                    patient.FirstName = (string)reader["firstName"];
                    patient.LastName = (string)reader["lastName"];
                    patient.DateOfBirth = (DateTime)reader["dateOfBirth"];
                    patient.Gender = (string)reader["gender"];
                    patient.ContactNumber = (string)reader["contactNumber"];
                    patients.Add(patient);
                }
                return patients;
            }
        }

        public int UpdatePatient(Patient patient)
        {
            if (ExceptionHandler.DateOfBirthValidator(patient.DateOfBirth))
                throw new DateException("Invalid DateOfBirth It should be less than Current Date");
            if (!ExceptionHandler.ValidateNum(patient.ContactNumber))
                throw new InvalidPhoneNumber("Invalid Phone Number");
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "update Patient set firstName=@firstName,lastName=@lastName,dateOfBirth=@dateOfBirth,gender=@gender,contactNumber=@contactNumber,address=@address where patientId=@patientId";
                command.Parameters.AddWithValue("@patientId", patient.PatientId);
                command.Parameters.AddWithValue("@firstName", patient.FirstName);
                command.Parameters.AddWithValue("@lastName", patient.LastName);
                command.Parameters.AddWithValue("@dateOfBirth", patient.DateOfBirth);
                command.Parameters.AddWithValue("@gender", patient.Gender);
                command.Parameters.AddWithValue("@contactNumber", patient.ContactNumber);
                command.Parameters.AddWithValue("@address", patient.Address);
                return command.ExecuteNonQuery();
            }
        }


        public int DeletePatient(int patientId)
        {
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "delete from Patient where patientId=@patientId";
                command.Parameters.AddWithValue("@patientId", patientId);
                return command.ExecuteNonQuery();
            }
        }
    }
}
