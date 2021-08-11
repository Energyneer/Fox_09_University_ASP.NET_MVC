using DataAccess;
using Repository;
using Service.Utilities;
using Service.ViewModel;
using System;
using System.Linq;

namespace Service
{
    public class GroupService : IGroupService
    {
        private IRepository<Course> courseRepository;
        private IRepository<Group> groupRepository;

        public GroupService(IRepository<Course> courseRepository, IRepository<Group> groupRepository)
        {
            this.courseRepository = courseRepository;
            this.groupRepository = groupRepository;
        }

        public GroupsPresent GetGroup()
        {
            return Mapper.GetDefaultGroupsPresent(groupRepository.GetAll());
        }

        public GroupsPresent GetGroup(int id)
        {
            Group group = groupRepository.Get(id);
            GroupsPresent result = Mapper.GetDefaultGroupsPresent(group);
            result.CourseId = group.Course.Id;
            result.CourseName = group.Course.CourseName;
            return result;
        }

        public void InsertGroup(GroupsPresent groupsPresent)
        {
            Group group = Mapper.GetModelGroup(groupsPresent.Groups.First());
            group.Course = courseRepository.Get(groupsPresent.CourseId);
            groupRepository.Insert(group);
        }

        public void UpdateGroup(GroupViewModel groupView)
        {
            Group group = groupRepository.Get(groupView.Id);
            group.GroupName = groupView.GroupName;
            groupRepository.Update(group);
        }

        public void DeleteGroup(int id)
        {
            Group group = groupRepository.Get(id);
            if (group.Students != null && group.Students.Count() > 0)
            {
                throw new ArgumentException("Students list is not empty!");
            }
            groupRepository.Delete(group);
        }

        public GroupsPresent GetGroupsByCourse(int id)
        {
            Course course = courseRepository.Get(id);
            GroupsPresent result = Mapper.GetDefaultGroupsPresent(course.Groups);
            result.CourseId = course.Id;
            result.CourseName = course.CourseName;
            return result;
        }
    }
}
