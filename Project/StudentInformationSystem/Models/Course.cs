using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseCode {  get; set; }
        public int CourseCredits { get; set; }
        public int TeacherId { get; set; }
        List<Enrollment> Enrollments { get; set; }
    }
}
