using HospitalManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    internal interface IHospitalRepository
    {
        Appointment GetAppointmentById(int appointmentId);

        List<Appointment> GetAppointmentsForPatient(int patientId);

        List<Appointment> GetAppointmentsForDoctor(int doctorId);

        int ScheduleAppointment(Appointment appointment);

        int UpdateAppointment(Appointment appointment);

        int CancelAppointment(int appointmentId);
    }
}
