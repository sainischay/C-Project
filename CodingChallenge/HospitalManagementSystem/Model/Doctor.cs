using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Model
{
    internal class Doctor
    {
        private int doctorId;
        private string firstName;
        private string lastName;
        private string specialization;
        private string contactNumber;

        public int DoctorId { get { return doctorId; } set { doctorId = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Specialization { get {  return specialization; } set {  specialization = value; } }
        public string ContactNumber { get {  return contactNumber; } set {  contactNumber = value; } }
        
    }
}
