namespace DataAccess.ViewModel
{
    public class StudentViewModel : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }

        public StudentViewModel()
        {
        }

        public StudentViewModel(int id, string firstName, string lastName, int groupId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            GroupId = groupId;
        }
    }
}
