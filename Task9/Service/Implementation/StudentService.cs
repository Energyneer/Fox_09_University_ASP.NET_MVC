using DataAccess;
using Repository;
using Service.Utilities;
using Service.ViewModel;
using System.Linq;

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

        public StudentsPresent GetStudent()
        {
            return Mapper.GetDefaultStudentsPresent(studentRepository.GetAll());
        }

        public StudentsPresent GetStudent(int id)
        {
            Student student = studentRepository.Get(id);
            StudentsPresent result = Mapper.GetDefaultStudentsPresent(student);
            result.GroupId = student.Group.Id;
            result.GroupName = student.Group.GroupName;
            return result;
        }

        public void InsertStudent(StudentsPresent studentView)
        {
            Student student = Mapper.GetModelStudent(studentView.Students.First());
            student.Group = groupRepository.Get(studentView.GroupId);
            studentRepository.Insert(student);
        }

        public void UpdateStudent(StudentViewModel studentView)
        {
            studentRepository.Update(Mapper.GetModelStudent(studentView));
        }

        public void DeleteStudent(int id)
        {
            Student student = studentRepository.Get(id);
            studentRepository.Delete(student);
        }

        public StudentsPresent GetStudentsByGroup(int id)
        {
            Group group = groupRepository.Get(id);
            StudentsPresent result = Mapper.GetDefaultStudentsPresent(group.Students);
            result.CourseId = group.Course.Id;
            result.GroupId = group.Id;
            result.GroupName = group.GroupName;
            return result;
        }
    }
}
