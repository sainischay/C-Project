using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Model
{
    internal class Appointment
    {
        private int appointmentId;
        private int patientId;
        private int doctorId;
        private DateTime appointmentDate;
        private string description;

        private Doctor doctor;
        private Patient patient;

        public int AppointmentId {  get { return appointmentId; } set {  appointmentId = value; } }
        public int PatientId { get { return patientId; } set {  patientId = value; } }
        public int DoctorId { get { return doctorId; } set {  doctorId = value; } }
        public DateTime AppointmentDate { get {  return appointmentDate; } set { appointmentDate = value; } }
        public string Description { get { return description; } set { description = value; } }
        public Doctor Doctor { get {  return doctor; } set { doctor = value; } }
        public Patient Patient { get {  return patient; } set {patient = value; } }
    }
}
