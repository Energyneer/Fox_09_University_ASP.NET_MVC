using Service.ViewModel;

namespace Service
{
    public interface IGroupService
    {
        GroupsPresent GetGroup();
        GroupsPresent GetGroupsByCourse(int id);

        GroupsPresent GetGroup(int id);
        void InsertGroup(GroupsPresent groupView);
        void UpdateGroup(GroupViewModel groupView);
        void DeleteGroup(int id);
    }
}
