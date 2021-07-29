using DataAccess.ViewModel;
using System.Collections.Generic;

namespace Service
{
    public interface IGroupService
    {
        IEnumerable<GroupViewModel> GetGroup();
        IEnumerable<GroupViewModel> GetGroupsByCourse(int id);
        GroupViewModel GetGroup(int id);
        void InsertGroup(GroupViewModel groupView);
        void UpdateGroup(GroupViewModel groupView);
        void DeleteGroup(int id);
    }
}
