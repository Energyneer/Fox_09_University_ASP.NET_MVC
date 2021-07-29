namespace DataAccess.ViewModel
{
    public class GroupViewModel : BaseEntity
    {
        public string GroupName { get; set; }
        public int CourseId { get; set; }

        public GroupViewModel()
        {
        }

        public GroupViewModel(int id, string groupName, int courseId)
        {
            Id = id;
            GroupName = groupName;
            CourseId = courseId;
        }
    }
}
