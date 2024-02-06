using HospitalManagementSystem.Model;
using HospitalManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    static class PrintingService
    {
        static string dataBaseConnectionString = DbConnUtil.GetConnectionString();
        static SqlCommand command= new SqlCommand();

        static IPatientService _patientService = new PatientService();
        static IDoctorService _doctorService = new DoctorService();
        static IHospitalService _hospitalService = new HospitalService();

        
        public static void GetAllDoctors()
        {
            try
            {
                List<Doctor> doctors = _doctorService.GetAllDoctors();
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "DoctorId", "FirstName", "LastName", "Specialization", "ContactNumber");
                foreach (Doctor doctor in doctors)
                {
                    Console.WriteLine($"{doctor.DoctorId,-15} {doctor.FirstName,-15} {doctor.LastName,-15} {doctor.Specialization,-15} {doctor.ContactNumber,-15}");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void GetAllPatients() {
            try
            {
                List<Patient> patients = _patientService.GetAllPatients();
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15}", "PatientId", "FirstName", "LastName", "DateOfBirth", "Gender", "ContactNumber");
                foreach (Patient patient in patients)
                {
                    DateTime dateTime = patient.DateOfBirth;
                    string formattedDate = dateTime.ToString("yyyy-MM-dd");
                    Console.WriteLine($"{patient.PatientId,-15} {patient.FirstName,-15} {patient.LastName,-15} {formattedDate,-15} {patient.Gender,-15} {patient.ContactNumber,-15}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetAppointmentById()
        {
            try
            {
                Appointment appointment1 = _hospitalService.GetAppointmentById();
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "AppointmentId", "PatientName", "DoctorName", "AppointmentDate", "Description");
                DateTime dateTime = appointment1.AppointmentDate;
                string formattedDate = dateTime.ToString("yyyy-MM-dd");
                Console.WriteLine($"{appointment1.AppointmentId,-15} {appointment1.Patient.FirstName + " " + appointment1.Patient.LastName,-15} {appointment1.Doctor.FirstName + " " + appointment1.Doctor.LastName,-15} {formattedDate,-15} {appointment1.Description,-15}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetAppointmentsForPatient()
        {
            try
            {
                List<Appointment> appointments = _hospitalService.GetAppointmentsForPatient();
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "AppointmentId", "PatientName", "DoctorName", "AppointmentDate", "Description");
                foreach (Appointment appointment1 in appointments)
                {
                    DateTime dateTime = appointment1.AppointmentDate;
                    string formattedDate = dateTime.ToString("yyyy-MM-dd");
                    Console.WriteLine($"{appointment1.AppointmentId,-15} {appointment1.Patient.FirstName + " " + appointment1.Patient.LastName,-15} {appointment1.Doctor.FirstName + " " + appointment1.Doctor.LastName,-15} {formattedDate,-15} {appointment1.Description,-15}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void GetAppointmentsForDoctor()
        {
            try
            {
                List<Appointment> appointments = _hospitalService.GetAppointmentsForDoctor();
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "AppointmentId", "PatientName", "DoctorName", "AppointmentDate", "Description");
                foreach (Appointment appointment1 in appointments)
                {
                    DateTime dateTime = appointment1.AppointmentDate;
                    string formattedDate = dateTime.ToString("yyyy-MM-dd");
                    Console.WriteLine($"{appointment1.AppointmentId,-15} {appointment1.Patient.FirstName + " " + appointment1.Patient.LastName,-15} {appointment1.Doctor.FirstName + " " + appointment1.Doctor.LastName,-15} {formattedDate,-15} {appointment1.Description,-15}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(dataBaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select *,p.firstName as pfirstname,p.LastName as plastName,d.firstName as dfirstName,d.lastName as dlastName from Appointment a join Doctor d on d.doctorId=a.doctorId join Patient p on p.patientId=a.patientId";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Appointment appointment = new Appointment();
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
                    appointments.Add(appointment);
                }
            }
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", "AppointmentId", "PatientName", "DoctorName", "AppointmentDate", "Description");
            foreach (Appointment appointment1 in appointments)
            {
                DateTime dateTime = appointment1.AppointmentDate;
                string formattedDate = dateTime.ToString("yyyy-MM-dd");
                Console.WriteLine($"{appointment1.AppointmentId,-15} {appointment1.Patient.FirstName + " " + appointment1.Patient.LastName,-15} {appointment1.Doctor.FirstName + " " + appointment1.Doctor.LastName,-15} {formattedDate,-15} {appointment1.Description,-15}");
            }
        }



    }
}
