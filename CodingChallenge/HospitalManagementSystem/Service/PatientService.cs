using HospitalManagementSystem.Model;
using HospitalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    internal class PatientService:IPatientService
    {
        IPatientRepository _patientRepository = new PatientRepository();
        public bool CreatePatient()
        {
            try
            {
                Patient patient = new Patient();
                Console.WriteLine("Enter Firstname");
                patient.FirstName = Console.ReadLine();
                Console.WriteLine("Enter LastName");
                patient.LastName = Console.ReadLine();
                Console.WriteLine("Enter DateOfBirth");
                patient.DateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Gender");
                patient.Gender = Console.ReadLine();
                Console.WriteLine("Enter ContactNumber");
                patient.ContactNumber = Console.ReadLine();
                Console.WriteLine("Enter Adderss");
                patient.Address = Console.ReadLine();
                int status = _patientRepository.CreatePatient(patient);
                if (status > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = _patientRepository.GetAllPatients();
            return patients;
        }

        public bool UpdatePatient()
        {
            try
            {
                PrintingService.GetAllPatients();
                Console.WriteLine("Enter the ids from above list");
                Patient patient = new Patient();
                Console.WriteLine("Enter PatientId");
                patient.PatientId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Firstname");
                patient.FirstName = Console.ReadLine();
                Console.WriteLine("Enter LastName");
                patient.LastName = Console.ReadLine();
                Console.WriteLine("Enter DateOfBirth");
                patient.DateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Gender");
                patient.Gender = Console.ReadLine();
                Console.WriteLine("Enter ContactNumber");
                patient.ContactNumber = Console.ReadLine();
                Console.WriteLine("Enter Adderss");
                patient.Address = Console.ReadLine();
                int status = _patientRepository.UpdatePatient(patient);
                if (status > 0)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeletePatient()
        {
            try
            {
                PrintingService.GetAllPatients();
                Console.WriteLine("Enter the ids from above list");
                Console.WriteLine("Enter Patientid");
                int patientId = int.Parse(Console.ReadLine());
                int status = _patientRepository.DeletePatient(patientId);
                if (status > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                    Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
