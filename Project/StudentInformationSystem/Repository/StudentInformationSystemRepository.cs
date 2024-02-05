using StudentInformationSystem.Exceptions;
using StudentInformationSystem.Models;
using StudentInformationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    internal class StudentInformationSystemRepository : IStudentInformationSystemRepository
    {
        string databaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public StudentInformationSystemRepository()
        {
            command = new SqlCommand();
        }

        public int EnrollStudentInCourse(int studentId, int courseId, DateTime enrollmentDate)
        {
            if (!ExceptionHandling.IsStudentExists(studentId))
                throw new StudentNotFoundException("Student Does not exist with this id");
            if (!ExceptionHandling.IsCourseExists(courseId))
                throw new CourseNotFoundException("Course Does not exist with this id");
            if (ExceptionHandling.IsStudentAlreadyEnrolled(studentId, courseId))
                throw new DuplicateEnrollmentException("Student already enrolled with this course");
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "insert into Enrollments values(@studentId,@courseId,@enrollmentDate)";
                command.Parameters.AddWithValue("@studentId", studentId);
                command.Parameters.AddWithValue("@courseId", courseId);
                command.Parameters.AddWithValue("@enrollmentDate", enrollmentDate);

                return command.ExecuteNonQuery();
            }

        }

        public int RecordPayment(int studentId, int amount, DateTime paymentDate)
        {
            if (!ExceptionHandling.IsPaymentValidate(amount, paymentDate)){
                throw new PaymentValidationException("Entered amount or payment date is invalid");
            }
            if (!ExceptionHandling.IsStudentExists(studentId))
                throw new StudentNotFoundException("Student Does not exist with this id");
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "insert into Payments values(@studentId,@amount,@paymentDate)";
                command.Parameters.AddWithValue("@studentId", studentId);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@paymentDate", paymentDate);

                return command.ExecuteNonQuery();
            }
        }

        public List<Enrollment> GetEnrolledCourses(int studentId)
        {
            if (!ExceptionHandling.IsStudentExists(studentId))
                throw new StudentNotFoundException("Student Does not exist with this id");
            List<Enrollment> enrollments = new List<Enrollment>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Enrollments e join Courses c on c.course_id=e.course_id where e.student_id=@studentId";
                command.Parameters.AddWithValue("@studentId", studentId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Enrollment enrollment = new Enrollment();
                    enrollment.EnrollmentDate = (DateTime)reader["enrollment_date"];
                    Course course = new Course();
                    course.CourseId = (int)reader["course_id"];
                    course.CourseName = (string)reader["course_name"];
                    course.CourseCredits = (int)reader["credits"];
                    enrollment.CourseList.Add(course);
                    enrollments.Add(enrollment);
                }
                return enrollments;
            }
        }


        public List<Payment> GetPaymentHistory(int studentId)
        {
            if (!ExceptionHandling.IsStudentExists(studentId))
                throw new StudentNotFoundException("Student Does not exist with this id");
            List<Payment> payments = new List<Payment>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Payments where student_id=@studentId";
                command.Parameters.AddWithValue("@studentId", studentId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Payment payment = new Payment();

                    payment.PaymentId = (int)reader["payment_id"];
                    payment.StudentId = (int)reader["student_id"];
                    payment.Amount = (int)reader["amount"];
                    payment.PaymentDate = (DateTime)reader["payment_date"];
                    
                    payments.Add(payment);
                }
                return payments;
            }
        }


        public int AssignTeacherToCourse(int teacherId, int courseId)
        {
            if (!ExceptionHandling.IsTeacherExists(teacherId))
                throw new TeacherNotFoundException("Teacher Does not exist with this id");
            if (!ExceptionHandling.IsCourseExists(courseId))
                throw new CourseNotFoundException("Course Does not exist with this id");
            Course course = new Course();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Courses where course_id = @courseId";
                command.Parameters.AddWithValue("@courseId", courseId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    course.CourseName = (string)reader["course_name"];
                    course.CourseCredits = (int)reader["credits"];
                }
                command.CommandText = "insert into Courses values(@courseName,@teacherId,@credits)";
                command.Parameters.AddWithValue("@courseName", course.CourseName);
                command.Parameters.AddWithValue("@teacherId", teacherId);
                command.Parameters.AddWithValue("@credits", course.CourseCredits);
                reader.Close();
                return command.ExecuteNonQuery();
            }
        }


        public List<Student> GetEnrollmentByCourse(int courseId)
        {
            if (!ExceptionHandling.IsCourseExists(courseId))
                throw new CourseNotFoundException("Course Does not exist with this id");
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Enrollments e join Students s on s.student_id=e.student_id where e.course_id=@courseId";
                command.Parameters.AddWithValue("@courseId", courseId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Student student = new Student();
                    student.FirstName = (string)reader["first_name"];
                    student.LastName = (string)reader["last_name"];
                    students.Add(student);
                }
                return students;
            }
        }


        public List<Teacher> GetTeacherByCourse(string courseName)
        {
            if (!ExceptionHandling.IsCourseExistsWithName(courseName))
                throw new CourseNotFoundException("Course Does not exist with this id");
            List<Teacher> teachers = new List<Teacher>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Courses c join Teacher t on t.teacher_id=c.teacher_id where c.course_name=@courseName";
                command.Parameters.AddWithValue("@courseName", courseName);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.FirstName = (string)reader["first_name"];
                    teacher.LastName = (string)reader["last_name"];
                    teachers.Add(teacher);
                }
                return teachers;
            }
        }



        public List<Course> GetCourseByTeacher(int teacherId)
        {
            if (!ExceptionHandling.IsTeacherExists(teacherId))
                throw new TeacherNotFoundException("Teacher Does not exist with this id");
            List<Course> courses = new List<Course>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Courses c join Teacher t on t.teacher_id=c.teacher_id where t.teacher_id=@teacherId";
                command.Parameters.AddWithValue("@teacherId", teacherId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseName = (string)reader["course_name"];
                    course.CourseCredits = (int)reader["credits"];
                    courses.Add(course);
                }
                return courses;
            }
        }


        public List<Student> GetStudentByPayment(int paymentId)
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Payments p join Students s on s.student_id=p.student_id where p.payment_id=@paymentId";
                command.Parameters.AddWithValue("paymentId", paymentId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.FirstName = (string)reader["first_name"];
                    student.LastName = (string)reader["last_name"];
                    students.Add(student);
                }
                return students;
            }
        }


        public int GetAmountByPayment(int paymentId)
        {
            int amount = 0;
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Payments where payment_id=@paymentId";
                command.Parameters.AddWithValue("paymentId", paymentId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    amount = (int)reader["amount"];
                }
                return amount;
            }
        }


        public DateTime GetDateByPayment(int paymentId)
        {
            DateTime date = new DateTime();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Payments where payment_id=@paymentId";
                command.Parameters.AddWithValue("paymentId", paymentId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    date = (DateTime)reader["payment_date"];
                }
                return date;
            }
        }


        public List<Payment> GeneratePaymentReport(int studentId)
        {
            if (!ExceptionHandling.IsStudentExists(studentId))
                throw new StudentNotFoundException("Student Does not exist with this id");
            List<Payment> payments = new List<Payment>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Payments where student_id=@studentId";
                command.Parameters.AddWithValue("studentId", studentId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Payment payment = new Payment();
                    payment.PaymentId = (int)reader["payment_id"];
                    payment.Amount = (int)reader["amount"];
                    payment.PaymentDate = (DateTime)reader["payment_date"];
                    payments.Add(payment);
                }
                return payments;
            }
        }


        public List<Enrollment> CalculateCourseStatistics(int courseId)
        {
            if (!ExceptionHandling.IsCourseExists(courseId))
                throw new CourseNotFoundException("Course Does not exist with this id");
            List<Enrollment> enrollments = new List<Enrollment>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select count(*) as Enrollment_count,sum(amount) as Total_Amount from Enrollments e join Payments p on e.student_id=p.student_id where e.course_id=@courseId and e.enrollment_date=p.payment_date";
                command.Parameters.AddWithValue("@courseId", courseId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Enrollment enrollment = new Enrollment();
                    enrollment.EnrollmentId = (int)reader["Enrollment_count"];
                    Payment payment = new Payment();
                    payment.Amount = (int)reader["Total_Amount"];
                    enrollment.Payments.Add(payment);
                    enrollments.Add(enrollment);
                }
                return enrollments;
            }
        }



    }
}
