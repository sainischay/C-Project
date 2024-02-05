using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    internal class Enrollment
    {
        public int EnrollmentId {  get; set; }  
        public int StudentId { get; set; }
        public int CourseId {  get; set; }
        public DateTime EnrollmentDate { get; set; }

        public List<Course> CourseList { get; set; }

        public List<Student> StudentList { get; set; }
        public List<Payment> Payments { get; set; }
        public Enrollment()
        {
            CourseList = new List<Course>();
            Payments = new List<Payment>();
        }
    }
}
