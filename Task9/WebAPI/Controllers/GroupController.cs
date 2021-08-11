using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Utilities;
using Service.ViewModel;

namespace WebAPI.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
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
        [Route("/Group/Create/{CourseId}")]
        public IActionResult Create([Bind("GroupName")] GroupViewModel groupView, int CourseId)
        {
            groupService.InsertGroup(Mapper.GetDefaultGroupsPresent(groupView, CourseId));
            return Redirect("/Group?id=" + CourseId);
        }

        public IActionResult Edit(int? id)
        {
            return View(groupService.GetGroup(id.Value));
        }

        [HttpPost]
        [Route("/Group/Edit/{CourseId?}")]
        public IActionResult EditComfim([Bind("Id,GroupName")] GroupViewModel groupView, int? courseId)
        {
            groupService.UpdateGroup(groupView);
            return Redirect("/Group" + (courseId.HasValue ? "?id=" + courseId.Value : ""));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id, int courseId)
        {
            groupService.DeleteGroup(id);
            return Redirect("/Group?id=" + courseId);
        }
    }
}
