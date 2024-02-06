using HospitalManagementSystem.Exceptions;
using HospitalManagementSystem.Model;
using HospitalManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    internal class HospitalRepository:IHospitalRepository
    {
        string dataBaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public HospitalRepository()
        {
            command = new SqlCommand();
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            try
            {
                Appointment appointment = null;
                using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "select *,p.firstName as pfirstname,p.LastName as plastName,d.firstName as dfirstName,d.lastName as dlastName from Appointment a join Doctor d on d.doctorId=a.doctorId join Patient p on p.patientId=a.patientId where a.appointmentId=@appointmentId";
                    command.Parameters.AddWithValue("@appointmentId", appointmentId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        appointment = new Appointment();
                        appointment.AppointmentId = (int)reader["appointmentId"];
                        Doctor doctor = new Doctor();
                        doctor.FirstName = (string)reader["dfirstName"];
                        doctor.LastName = (string)reader["dlastName"];
                        Patient patient = new Patient();
                        patient.FirstName = (string)reader["pfirstName"];
                        patient.LastName = (string)reader["plastName"];
                        appointment.AppointmentDate = (DateTime)reader["appointmentDate"];
                        appointment.Description = (string)reader["description"];
                        appointment.Doctor = doctor;
                        appointment.Patient = patient;
                    }
                    return appointment;
                }

            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            }
        

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            try
            {
                List<Appointment> appointmentList = new List<Appointment>();
                using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "select *,p.firstName as pfirstname,p.LastName as plastName,d.firstName as dfirstName,d.lastName as dlastName from Appointment a join Doctor d on d.doctorId=a.doctorId join Patient p on p.patientId=a.patientId where a.patientId=@patientId";
                    command.Parameters.AddWithValue("@patientId", patientId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment = new Appointment();
                        appointment.AppointmentId = (int)reader["appointmentId"];
                        Doctor doctor = new Doctor();
                        doctor.FirstName = (string)reader["dfirstName"];
                        doctor.LastName = (string)reader["dlastName"];
                        Patient patient = new Patient();
                        patient.FirstName = (string)reader["pfirstName"];
                        patient.LastName = (string)reader["plastName"];
                        appointment.AppointmentDate = (DateTime)reader["appointmentDate"];
                        appointment.Description = (string)reader["description"];
                        appointment.Doctor = doctor;
                        appointment.Patient = patient;
                        appointmentList.Add(appointment);
                    }
                    return appointmentList;
                }
            }
            catch (SqlException ex)
            {
                throw new PatientNumberNotFoundException("Invalid Patient Number");
            }

        }


        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            try
            {
                List<Appointment> appointmentList = new List<Appointment>();
                using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "select *,p.firstName as pfirstname,p.LastName as plastName,d.firstName as dfirstName,d.lastName as dlastName from Appointment a join Doctor d on d.doctorId=a.doctorId join Patient p on p.patientId=a.patientId where a.doctorId=@doctorId";
                    command.Parameters.AddWithValue("@doctorId", doctorId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment = new Appointment();
                        appointment.AppointmentId = (int)reader["appointmentId"];
                        Doctor doctor = new Doctor();
                        doctor.FirstName = (string)reader["dfirstName"];
                        doctor.LastName = (string)reader["dlastName"];
                        Patient patient = new Patient();
                        patient.FirstName = (string)reader["pfirstName"];
                        patient.LastName = (string)reader["plastName"];
                        appointment.AppointmentDate = (DateTime)reader["appointmentDate"];
                        appointment.Description = (string)reader["description"];
                        appointment.Doctor = doctor;
                        appointment.Patient = patient;
                        appointmentList.Add(appointment);
                    }
                    return appointmentList;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ScheduleAppointment(Appointment appointment)
        {
            if (ExceptionHandler.AppointmentDateValidator(appointment.AppointmentDate))
                throw new DateException("AppointmentDate should be greater than currentDate");
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "insert into Appointment values(@patientid,@doctorId,@appointmentDate,@description)";
                command.Parameters.AddWithValue("@patientId", appointment.PatientId);
                command.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                command.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@description", appointment.Description);
                return command.ExecuteNonQuery();
            }
        }


        public int UpdateAppointment(Appointment appointment)
        {
            if (ExceptionHandler.AppointmentDateValidator(appointment.AppointmentDate))
                throw new DateException("AppointmentDate should be greater than currentDate");
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "update Appointment set patientId=@patientid,doctorId=@doctorId,appointmentDate=@appointmentDate,description=@description where appointmentId=@appointmentId";
                    command.Parameters.AddWithValue("@patientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@description", appointment.Description);
                    command.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public int CancelAppointment(int appointmentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "delete from Appointment where appointmentId=@appointmentId";
                    command.Parameters.AddWithValue("@appointmentId", appointmentId);
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
