using DataAccess;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StudentService : IStudentService
    {
        public IRepository<Student> studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetStudent()
        {
            return studentRepository.GetAll();
        }

        public Student GetStudent(long id)
        {
            return studentRepository.Get(id);
        }

        public void InsertStudent(Student student)
        {
            studentRepository.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            studentRepository.Update(student);
        }

        public void DeleteStudent(long id)
        {
            Student student = GetStudent(id);
            studentRepository.Remove(student);
            studentRepository.SaveChanges();
        }

        public IEnumerable<Student> GetStudentsByGroup(Group group)
        {
            return studentRepository.GetAll().Where(item => item.Group == group);
        }
    }
}
