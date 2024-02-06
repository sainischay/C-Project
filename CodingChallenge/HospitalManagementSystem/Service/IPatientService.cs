using HospitalManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    internal interface IPatientService
    {
        bool CreatePatient();

        List<Patient> GetAllPatients();

        bool UpdatePatient();

        bool DeletePatient();
    }
}
