using DataAccess;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GroupService : IGroupService
    {
        private IRepository<Group> groupRepository;

        public GroupService(IRepository<Group> groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public IEnumerable<Group> GetGroup()
        {
            return groupRepository.GetAll();
        }

        public Group GetGroup(long id)
        {
            return groupRepository.Get(id);
        }

        public void InsertGroup(Group group)
        {
            groupRepository.Insert(group);
        }

        public void UpdateGroup(Group group)
        {
            groupRepository.Update(group);
        }

        public void DeleteGroup(long id)
        {
            Group group = GetGroup(id);
            groupRepository.Remove(group);
            groupRepository.SaveChanges();
        }

        public IEnumerable<Group> GetGroupsByCourse(Course course)
        {
            return groupRepository.GetAll().Where(item => item.Course == course);
        }
    }
}
