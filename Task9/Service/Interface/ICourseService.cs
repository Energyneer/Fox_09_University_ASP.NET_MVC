using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICourseService
    {
        IEnumerable<DataAccess.Course> GetCourse();
        Course GetCourse(long id);
        void InsertCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(long id);
    }
}
