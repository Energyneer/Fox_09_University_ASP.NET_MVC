using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel
{
    public class GroupsPresent
    {
        public List<GroupViewModel> Groups { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
