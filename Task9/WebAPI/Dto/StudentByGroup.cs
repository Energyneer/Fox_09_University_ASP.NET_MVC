using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class StudentByGroup
    {
        public IEnumerable<Student> Students { get; set; }
        public string groupDisplayName { get; set; }
        public long groupId { get; set; }

        public StudentByGroup(IEnumerable<Student> students, string groupDisplayName, long groupId)
        {
            Students = students;
            this.groupDisplayName = groupDisplayName;
            this.groupId = groupId;
        }
    }
}
