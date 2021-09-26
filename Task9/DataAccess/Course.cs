using System.Collections.Generic;

namespace DataAccess
{
    public class Course :BaseEntity
    {
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
        public virtual ICollection<Group> Groups { get; set; } 
    }
}
