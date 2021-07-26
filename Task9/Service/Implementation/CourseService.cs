using DataAccess;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CourseService : ICourseService
    {
        private IRepository<Course> courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public IEnumerable<Course> GetCourse()
        {
            return courseRepository.GetAll();
        }

        public Course GetCourse(long id)
        {
            return courseRepository.Get(id);
        }

        public void InsertCourse(Course course)
        {
            courseRepository.Insert(course);
        }

        public void UpdateCourse(Course course)
        {
            courseRepository.Update(course);
        }

        public void DeleteCourse(long id)
        {
            courseRepository.Remove(GetCourse(id));
        }
    }
}
