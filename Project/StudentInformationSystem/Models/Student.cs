using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email {  get; set; }
        public string PhoneNumber { get; set; }

        private List<Enrollment> enrollments;
        private List<Payment> payments;

        public Student()
        {
            
        }
        public Student(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            enrollments = new List<Enrollment>();
            payments = new List<Payment>();
        }
    }
}
