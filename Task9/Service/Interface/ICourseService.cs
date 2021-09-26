using Service.ViewModel;
using System.Collections.Generic;

namespace Service
{
    public interface ICourseService
    {
        IEnumerable<CourseViewModel> GetCourse();
        CourseViewModel GetCourse(int id);
        void InsertCourse(CourseViewModel courseView);
        void UpdateCourse(CourseViewModel courseView);
        void DeleteCourse(int id);
    }
}
