using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Service
{
    internal interface ICourseService
    {
        bool CreateCourse();

        bool UpdateCourse();

        List<Course> GetListOfCourse();

        bool DeleteCourse();
    }
}
