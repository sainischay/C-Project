using HospitalManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Service
{
    internal interface IHospitalService
    {
        Appointment GetAppointmentById();

        List<Appointment> GetAppointmentsForPatient();

        List<Appointment> GetAppointmentsForDoctor();

        bool ScheduleAppointment();

        bool UpdateAppointment();

        bool CancelAppointment();
    }
}
