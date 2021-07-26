using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Course :BaseEntity
    {
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
        public virtual ICollection<Group> Groups { get; set; } 
    }
}
