using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
