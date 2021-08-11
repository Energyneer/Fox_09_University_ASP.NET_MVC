using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel
{
    public class StudentsPresent
    {
        public List<StudentViewModel> Students { get; set; }
        public int CourseId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
