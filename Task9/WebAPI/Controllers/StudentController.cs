using Microsoft.AspNetCore.Mvc;
using Service;
using DataAccess.ViewModel;

namespace WebAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGroupService groupService;
        private readonly IStudentService studentService;

        public StudentController(IGroupService groupService, IStudentService studentService)
        {
            this.groupService = groupService;
            this.studentService = studentService;
        }

        [Route("/Student")]
        public IActionResult Index(int? id)
        {
            if (id != null && id.Value > 0)
            {
                return View(studentService.GetStudentsByGroup(id.Value));
            }
            return View(studentService.GetStudent());
        }

        [HttpPost]
        [Route("/Student/Create")]
        public IActionResult Create([Bind("FirstName,LastName,GroupId")] StudentViewModel studentView)
        {
            studentService.InsertStudent(studentView);
            return Redirect("/Student?id=" + studentView.GroupId);
        }

        public IActionResult Edit(int? id)
        {
            return View(studentService.GetStudent(id.Value));
        }

        [HttpPost]
        [Route("/Student/Edit")]
        public IActionResult EditComfim([Bind("Id,FirstName,LastName")] StudentViewModel studentView)
        {
            studentService.UpdateStudent(studentView);
            return Redirect("/Student?id=" + studentView.GroupId);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id, int GroupId)
        {
            studentService.DeleteStudent(id);
            return Redirect("/Student?id=" + GroupId);
        }
    }
}
