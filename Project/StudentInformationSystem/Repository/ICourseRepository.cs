using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repository
{
    internal interface ICourseRepository
    {
        int CreateCourse(Course course,int teacherId);

        int UpdateCourse(int courseId,string courseName,int teacherId,int credits);

        List<Course> GetListOfCourse();

        int DeleteCourse(int courseId);
    }
}
