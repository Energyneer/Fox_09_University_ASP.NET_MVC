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
    public class StudentController : Controller
    {
        private readonly IGroupService groupService;
        private readonly IStudentService studentService;

        public StudentController(IGroupService groupService, IStudentService studentService)
        {
            this.groupService = groupService;
            this.studentService = studentService;
        }

        // GET: Student
        [Route("/Student/{id?}")]
        public IActionResult Index(long? id)
        {
            if (id != null)
            {
                Group group = groupService.GetGroup(id.Value);
                IEnumerable<Student> students = studentService.GetStudentsByGroup(group);
                string groupDisplayName = group.GroupName;
                long groupId = group.Id;
                StudentByGroup sbg = new StudentByGroup(students, groupDisplayName, groupId);
                return View(sbg);
            }
            return View(new StudentByGroup(studentService.GetStudent(), "All", 0));
        }

        [HttpPost]
        [Route("/Student/Create")]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(string FirstName, string LastName, long GroupId)
        {
            Group group = groupService.GetGroup(GroupId);

            Student student = new Student();
            student.FirstName = FirstName;
            student.LastName = LastName;
            student.Group = group;
            studentService.InsertStudent(student);

            return Redirect("/Student/" + GroupId);
        }

        public IActionResult Edit(long? id)
        {
            return View(studentService.GetStudent(id.Value));
        }

        [HttpPost]
        [Route("/Student/Edit")]
        public IActionResult EditComfim([Bind("Id,FirstName,LastName")] Student student)
        {
            studentService.UpdateStudent(student);
            return Redirect("/Student");
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id, long GroupId)
        {
            studentService.DeleteStudent(id);
            return Redirect("/Student/" + GroupId);
        }
    }
}
