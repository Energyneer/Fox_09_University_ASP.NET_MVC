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

        // GET: Group
        [Route("/Group/{id?}")]
        public IActionResult Index(long? id)
        {
            if (id != null)
            {
                return View(new GroupByCourse(
                    groupService.GetGroupsByCourse(courseService.GetCourse(id.Value)), 
                    courseService.GetCourse(id.Value).CourseName, 
                    id.Value));
            }
            return View(new GroupByCourse(groupService.GetGroup(), "all", 0));
        }

        [HttpPost]
        [Route("/Group/Create")]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(string GroupName, long CourseId)
        {
            Course course = courseService.GetCourse(CourseId);
            Group group = new Group();
            group.GroupName = GroupName;
            group.Course = course;
            groupService.InsertGroup(group);

            return Redirect("/Group/" + CourseId);
        }

        public IActionResult Edit(long? id)
        {
            return View(groupService.GetGroup(id.Value));
        }

        [HttpPost]
        [Route("/Group/Edit")]
        public IActionResult EditComfim([Bind("Id,GroupName")] Group group)
        {
            groupService.UpdateGroup(group);
            return Redirect("/Group");
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id, long courseId)
        {
            Group group = groupService.GetGroup(id);
            if (group == null)
                return RedirectToAction("Error", "Course", new { @message = "Wrong parameter: group ID" });
            if (studentService.GetStudentsByGroup(group).Count() > 0)
                return RedirectToAction("Error", "Course", new { @message = "Group is not empty! First delete all students." });
            groupService.DeleteGroup(id);
            return Redirect("/Group/" + courseId);
        }
    }
}
