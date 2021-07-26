using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IGroupService
    {
        IEnumerable<Group> GetGroup();
        IEnumerable<Group> GetGroupsByCourse(Course course);
        Group GetGroup(long id);
        void InsertGroup(Group group);
        void UpdateGroup(Group group);
        void DeleteGroup(long id);
    }
}
