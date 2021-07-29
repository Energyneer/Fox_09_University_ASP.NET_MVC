using System.Collections.Generic;

namespace DataAccess
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
