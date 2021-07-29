using DataAccess;
using DataAccess.ViewModel;
using Repository;
using System;
using System.Collections.Generic;
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

        public IEnumerable<GroupViewModel> GetGroup()
        {
            List<GroupViewModel> result = new List<GroupViewModel>();
            foreach (Group group in groupRepository.GetAll(new Group()))
            {
                result.Add(new GroupViewModel(group.Id, group.GroupName, group.Course.Id));
            }
            return result;
        }

        public GroupViewModel GetGroup(int id)
        {
            Group group = groupRepository.Get(id);
            return new GroupViewModel(group.Id, group.GroupName, group.Course.Id);
        }

        public void InsertGroup(GroupViewModel groupView)
        {
            Group group = new Group();
            group.GroupName = groupView.GroupName;
            group.Course = courseRepository.Get(groupView.CourseId);
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
            groupRepository.Remove(group);
        }

        public IEnumerable<GroupViewModel> GetGroupsByCourse(int id)
        {
            List<GroupViewModel> result = new List<GroupViewModel>();
            foreach (Group group in courseRepository.Get(id).Groups)
            {
                result.Add(new GroupViewModel(group.Id, group.GroupName, id));
            }
            return result;
        }
    }
}
