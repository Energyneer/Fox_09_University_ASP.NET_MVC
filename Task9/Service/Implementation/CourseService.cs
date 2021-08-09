using DataAccess;
using Repository;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class CourseService : ICourseService
    {
        private IRepository<Course> courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public IEnumerable<CourseViewModel> GetCourse()
        {
            List<CourseViewModel> result = new List<CourseViewModel>();
            foreach (Course course in courseRepository.GetAll())
            {
                result.Add(new CourseViewModel(course.Id, course.CourseName, course.CourseDesc));
            }
            return result;
        }

        public CourseViewModel GetCourse(int id)
        {
            Course course = courseRepository.Get(id);
            return new CourseViewModel(course.Id, course.CourseName, course.CourseDesc);
        }

        public void InsertCourse(CourseViewModel courseView)
        {
            Course course = new Course();
            course.CourseName = courseView.CourseName;
            course.CourseDesc = courseView.CourseDesc;
            courseRepository.Insert(course);
        }

        public void UpdateCourse(CourseViewModel courseView)
        {
            Course course = new Course();
            course.Id = courseView.Id;
            course.CourseName = courseView.CourseName;
            course.CourseDesc = courseView.CourseDesc;
            courseRepository.Update(course);
        }

        public void DeleteCourse(int id)
        {
            Course course = courseRepository.Get(id);
            if (course.Groups != null && course.Groups.Count() > 0)
            {
                throw new ArgumentException("Group list is not empty!");
            }
            courseRepository.Delete(course);
        }
    }
}
