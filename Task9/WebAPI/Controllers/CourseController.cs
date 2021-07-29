using Microsoft.AspNetCore.Mvc;
using Service;
using DataAccess.ViewModel;

namespace WebAPI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(courseService.GetCourse());
        }

        [Route("/Error")]
        public IActionResult Error(string message)
        {
            ErrorModel errorModel = new ErrorModel();
            errorModel.ErrorCause = message;
            return View(errorModel);
        }

        public IActionResult Edit(int? id)
        {
            return View(courseService.GetCourse(id.Value));
        }

        [HttpPost]
        [Route("/Course/Edit")]
        public IActionResult EditComfim([Bind("Id,CourseName,CourseDesc")] CourseViewModel courseView)
        {
            courseService.UpdateCourse(courseView);
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult Create([Bind("CourseName,CourseDesc")] CourseViewModel courseView)
        {
            if (ModelState.IsValid)
            {
                courseService.InsertCourse(courseView);
                return RedirectToAction(nameof(Index));
            }
            return View(courseView);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
