using DataAccess;
using Repository;
using Service.ViewModel;
using System.Collections.Generic;

namespace Service
{
    public class StudentService : IStudentService
    {
        public IRepository<Group> groupRepository;
        public IRepository<Student> studentRepository;

        public StudentService(IRepository<Group> groupRepository, IRepository<Student> studentRepository)
        {
            this.groupRepository = groupRepository;
            this.studentRepository = studentRepository;
        }

        public IEnumerable<StudentViewModel> GetStudent()
        {
            List<StudentViewModel> result = new List<StudentViewModel>();
            foreach (Student student in studentRepository.GetAll())
            {
                result.Add(new StudentViewModel(student.Id, student.FirstName, student.LastName, student.Group.Id));
            }
            return result;
        }

        public StudentViewModel GetStudent(int id)
        {
            Student student = studentRepository.Get(id);
            return new StudentViewModel(student.Id, student.FirstName, student.LastName, student.Group.Id);
        }

        public void InsertStudent(StudentViewModel studentView)
        {
            Student student = new Student();
            student.FirstName = studentView.FirstName;
            student.LastName = studentView.LastName;
            student.Group = groupRepository.Get(studentView.GroupId);
            studentRepository.Insert(student);
        }

        public void UpdateStudent(StudentViewModel studentView)
        {
            Student student = studentRepository.Get(studentView.Id);
            student.FirstName = studentView.FirstName;
            student.LastName = studentView.LastName;
            studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            Student student = studentRepository.Get(id);
            studentRepository.Delete(student);
        }

        public IEnumerable<StudentViewModel> GetStudentsByGroup(int id)
        {
            List<StudentViewModel> result = new List<StudentViewModel>();
            foreach (Student student in groupRepository.Get(id).Students)
            {
                result.Add(new StudentViewModel(student.Id, student.FirstName, student.LastName, student.Group.Id));
            }
            return result;
        }
    }
}
