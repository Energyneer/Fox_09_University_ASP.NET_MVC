using DataAccess;
using Repository;
using Service.Utilities;
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
                result.Add(Mapper.GetViewCourse(course));
            }
            return result;
        }

        public CourseViewModel GetCourse(int id)
        {
            return Mapper.GetViewCourse(courseRepository.Get(id));
        }

        public void InsertCourse(CourseViewModel courseView)
        {
            courseRepository.Insert(Mapper.GetModelCourse(courseView));
        }

        public void UpdateCourse(CourseViewModel courseView)
        {
            courseRepository.Update(Mapper.GetModelCourse(courseView));
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
