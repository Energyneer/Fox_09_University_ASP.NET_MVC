using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Utilities;
using Service.ViewModel;

namespace WebAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
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
        [Route("/Student/Create/{GroupId}")]
        public IActionResult Create([Bind("FirstName,LastName")] StudentViewModel studentView, int GroupId)
        {
            studentService.InsertStudent(Mapper.GetDefaultStudentsPresent(studentView, GroupId));
            return Redirect("/Student?id=" + GroupId);
        }

        public IActionResult Edit(int? id)
        {
            return View(studentService.GetStudent(id.Value));
        }

        [HttpPost]
        [Route("/Student/Edit/{GroupId?}")]
        public IActionResult EditComfim([Bind("Id,FirstName,LastName")] StudentViewModel studentView, int? GroupId)
        {
            studentService.UpdateStudent(studentView);
            return Redirect("/Student" + (GroupId.HasValue ? "?id=" + GroupId.Value : ""));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id, int GroupId)
        {
            studentService.DeleteStudent(id);
            return Redirect("/Student?id=" + GroupId);
        }
    }
}
