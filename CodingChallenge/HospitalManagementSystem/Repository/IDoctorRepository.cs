using HospitalManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    internal interface IDoctorRepository
    {
        int CreateDoctor(Doctor doctor);

        List<Doctor> GetAllDoctors();

        int UpdateDoctor(Doctor doctor);

        int DeleteDoctor(int doctorId);
    }
}
