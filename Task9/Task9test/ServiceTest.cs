using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using Service;
using Service.Utilities;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI;

namespace Task9test
{
    [TestFixture]
    public class ServiceTest
    {
        private ICourseService CourseService;
        private IGroupService GroupService;
        private IStudentService StudentService;
        private CourseViewModel CourseView;
        private GroupViewModel GroupView;
        private StudentViewModel StudentView;

        [SetUp]
        public void Init()
        {
            TestServer testServer = new TestServer(
                new WebHostBuilder().ConfigureAppConfiguration(_ => { }).UseStartup<Startup>());
            CourseService = testServer.Services.GetService(typeof(ICourseService)) as ICourseService;
            GroupService = testServer.Services.GetService(typeof(IGroupService)) as IGroupService;
            StudentService = testServer.Services.GetService(typeof(IStudentService)) as IStudentService;
        }

        [Test, Order(1)]
        public void TestCreateCourse()
        {
            CourseViewModel courseViewModel = ViewModelBuilder.GetCourse();
            CourseService.InsertCourse(courseViewModel);
            CourseView = CourseService.GetCourse().LastOrDefault();
            Assert.AreEqual(courseViewModel.CourseName, CourseView.CourseName);
        }

        [Test, Order(2)]
        public void TestEditCourse()
        {
            string editCourseName = "TestNameEdit2";
            CourseView.CourseName = editCourseName;
            CourseService.UpdateCourse(CourseView);
            CourseView = CourseService.GetCourse().LastOrDefault();
            Assert.AreEqual(editCourseName, CourseView.CourseName);
        }

        [Test, Order(3)]
        public void TestCreateGroup()
        {
            GroupViewModel groupViewModel = ViewModelBuilder.GetGroup(CourseView.Id);
            GroupsPresent present = Mapper.GetDefaultGroupsPresent(groupViewModel, CourseView.Id);
            GroupService.InsertGroup(present);
            GroupView = GroupService.GetGroup().Groups.LastOrDefault();
            Assert.AreEqual(groupViewModel.GroupName, GroupView.GroupName);
        }

        [Test, Order(4)]
        public void TestEditGroup()
        {
            string editGroupName = "TestGroupEdit2";
            GroupView.GroupName = editGroupName;
            GroupService.UpdateGroup(GroupView);
            GroupView = GroupService.GetGroup().Groups.LastOrDefault();
            Assert.AreEqual(editGroupName, GroupView.GroupName);
        }

        [Test, Order(5)]
        public void TestCreateStudent()
        {
            StudentViewModel studentViewModel = ViewModelBuilder.GetStudent(GroupView.Id);
            StudentsPresent present = Mapper.GetDefaultStudentsPresent(studentViewModel, GroupView.Id);
            StudentService.InsertStudent(present);
            StudentView = StudentService.GetStudent().Students.LastOrDefault();
            Assert.AreEqual(studentViewModel.FirstName, StudentView.FirstName);
        }

        [Test, Order(6)]
        public void TestEditStudent()
        {
            string editStudentFirstName = "TestStudentEdit2";
            StudentView.FirstName = editStudentFirstName;
            StudentService.UpdateStudent(StudentView);
            StudentView = StudentService.GetStudent().Students.LastOrDefault();
            Assert.AreEqual(editStudentFirstName, StudentView.FirstName);
        }

        [Test, Order(7)]
        public void TestDeleteStudent()
        {
            StudentService.DeleteStudent(StudentView.Id);
            Assert.Throws<NullReferenceException>(() => StudentService.GetStudent(StudentView.Id));
        }

        [Test, Order(8)]
        public void TestDeleteGroup()
        {
            GroupService.DeleteGroup(GroupView.Id);
            Assert.Throws<NullReferenceException>(() => GroupService.GetGroup(GroupView.Id));
        }

        [Test, Order(9)]
        public void DeleteTest()
        {
            CourseService.DeleteCourse(CourseView.Id);
            Assert.Throws<NullReferenceException>(() => CourseService.GetCourse(CourseView.Id));
        }
    }
}
