namespace DataAccess
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Group Group { get; set; }
    }
}
