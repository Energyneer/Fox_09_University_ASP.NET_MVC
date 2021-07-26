using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Service;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        // GET: Course
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

        public IActionResult Edit(long? id)
        {
            return View(courseService.GetCourse(id.Value));
        }

        [HttpPost]
        [Route("/Course/Edit")]
        public IActionResult EditComfim([Bind("Id,CourseName,CourseDesc")] Course course)
        {
            courseService.UpdateCourse(course);
            return Redirect("/");
        }

        //[Route("/Course/Create")]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create([Bind("CourseName,CourseDesc")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseService.InsertCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
