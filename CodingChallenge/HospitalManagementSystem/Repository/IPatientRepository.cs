using HospitalManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    internal interface IPatientRepository
    {
        int CreatePatient(Patient patient);

        List<Patient> GetAllPatients();

        int UpdatePatient(Patient patient);

        int DeletePatient(int patientId);
    }
}
