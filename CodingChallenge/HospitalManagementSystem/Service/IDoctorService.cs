using HospitalManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    internal interface IDoctorService
    {
        bool CreateDoctor();

        List<Doctor> GetAllDoctors();

        bool UpdateDoctor();

        bool DeleteDoctor();
    }
}
