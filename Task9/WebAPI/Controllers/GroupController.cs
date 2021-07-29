using Microsoft.AspNetCore.Mvc;
using Service;
using DataAccess.ViewModel;

namespace WebAPI.Controllers
{
    public class GroupController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IGroupService groupService;
        private readonly IStudentService studentService;

        public GroupController(ICourseService courseService, IGroupService groupService, IStudentService studentService)
        {
            this.courseService = courseService;
            this.groupService = groupService;
            this.studentService = studentService;
        }

        [Route("/Group")]
        public IActionResult Index(int? id)
        {
            if (id != null && id.Value > 0)
            {
                return View(groupService.GetGroupsByCourse(id.Value));
            }
            return View(groupService.GetGroup());
        }

        [HttpPost]
        [Route("/Group/Create")]
        public IActionResult Create([Bind("GroupName,CourseId")] GroupViewModel groupView)
        {
            groupService.InsertGroup(groupView);
            return Redirect("/Group?id=" + groupView.CourseId);
        }

        public IActionResult Edit(int? id)
        {
            return View(groupService.GetGroup(id.Value));
        }

        [HttpPost]
        [Route("/Group/Edit")]
        public IActionResult EditComfim([Bind("Id,GroupName,CourseId")] GroupViewModel groupView)
        {
            groupService.UpdateGroup(groupView);
            return Redirect("/Group?id=" + groupView.CourseId);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id, int courseId)
        {
            groupService.DeleteGroup(id);
            return Redirect("/Group?id=" + courseId);
        }
    }
}
