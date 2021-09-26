using DataAccess;
using Service.ViewModel;
using System.Collections.Generic;

namespace Service.Utilities
{
    public class Mapper
    {
        public static CourseViewModel GetViewCourse(Course course)
        {
            CourseViewModel result = new CourseViewModel();
            result.Id = course.Id;
            result.CourseName = course.CourseName;
            result.CourseDesc = course.CourseDesc;
            return result;
        }

        public static GroupViewModel GetViewGroup(Group group)
        {
            GroupViewModel result = new GroupViewModel();
            result.Id = group.Id;
            result.GroupName = group.GroupName;
            return result;
        }

        public static StudentViewModel GetViewStudent(Student student)
        {
            StudentViewModel result = new StudentViewModel();
            result.Id = student.Id;
            result.FirstName = student.FirstName;
            result.LastName = student.LastName;
            return result;
        }

        public static Course GetModelCourse(CourseViewModel courseView)
        {
            Course result = new Course();
            result.Id = courseView.Id;
            result.CourseName = courseView.CourseName;
            result.CourseDesc = courseView.CourseDesc;
            return result;
        }

        public static Group GetModelGroup(GroupViewModel groupView)
        {
            Group result = new Group();
            result.Id = groupView.Id;
            result.GroupName = groupView.GroupName;
            return result;
        }

        public static Student GetModelStudent(StudentViewModel studentView)
        {
            Student result = new Student();
            result.Id = studentView.Id;
            result.FirstName = studentView.FirstName;
            result.LastName = studentView.LastName;
            return result;
        }

        public static GroupsPresent GetDefaultGroupsPresent(IEnumerable<Group> groups)
        {
            GroupsPresent result = CreateGroupsPresent();
            foreach (Group group in groups)
            {
                result.Groups.Add(GetViewGroup(group));
            }
            return result;
        }

        public static GroupsPresent GetDefaultGroupsPresent(Group group)
        {
            GroupsPresent result = CreateGroupsPresent();
            result.Groups.Add(GetViewGroup(group));
            return result;
        }

        public static GroupsPresent GetDefaultGroupsPresent(GroupViewModel groupView, int id)
        {
            GroupsPresent result = CreateGroupsPresent();
            result.Groups.Add(groupView);
            result.CourseId = id;
            return result;
        }

        private static GroupsPresent CreateGroupsPresent()
        {
            GroupsPresent result = new GroupsPresent();
            result.Groups = new List<GroupViewModel>();
            result.CourseId = 0;
            result.CourseName = "All";
            return result;
        }

        public static StudentsPresent GetDefaultStudentsPresent(IEnumerable<Student> students)
        {
            StudentsPresent result = CreateStudentsPresent();
            foreach (Student student in students)
            {
                result.Students.Add(GetViewStudent(student));
            }
            return result;
        }

        public static StudentsPresent GetDefaultStudentsPresent(Student student)
        {
            StudentsPresent result = CreateStudentsPresent();
            result.Students.Add(GetViewStudent(student));
            return result;
        }

        public static StudentsPresent GetDefaultStudentsPresent(StudentViewModel viewModel, int id)
        {
            StudentsPresent result = CreateStudentsPresent();
            result.Students.Add(viewModel);
            result.GroupId = id;
            return result;
        }

        private static StudentsPresent CreateStudentsPresent()
        {
            StudentsPresent result = new StudentsPresent();
            result.Students = new List<StudentViewModel>();
            result.CourseId = 0;
            result.GroupId = 0;
            result.GroupName = "All";
            return result;
        }
    }
}
