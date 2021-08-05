using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9test
{
    public class ViewModelBuilder
    {
        public static CourseViewModel GetCourse()
        {
            CourseViewModel courseView = new CourseViewModel();
            courseView.CourseName = "TestCourseName";
            courseView.CourseDesc = "TestCourseDescription";
            return courseView;
        }

        public static GroupViewModel GetGroup(int courseId)
        {
            GroupViewModel groupView = new GroupViewModel();
            groupView.GroupName = "TestGroupName";
            groupView.CourseId = courseId;
            return groupView;
        }

        public static StudentViewModel GetStudent(int groupId)
        {
            StudentViewModel studentView = new StudentViewModel();
            studentView.FirstName = "TestFirstName";
            studentView.LastName = "TestLastName";
            studentView.GroupId = groupId;
            return studentView;
        }
    }
}
