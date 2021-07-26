using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class GroupByCourse
    {
        public IEnumerable<Group> Groups { get; set; }
        public string CourseDisplayName { get; set; }
        public long CourseId { get; set; }

        public GroupByCourse(IEnumerable<Group> groups, string courseDisplayName, long courseId)
        {
            Groups = groups;
            CourseDisplayName = courseDisplayName;
            CourseId = courseId;
        }
    }
}
