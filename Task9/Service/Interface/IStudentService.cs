using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudent();
        IEnumerable<Student> GetStudentsByGroup(Group group);
        Student GetStudent(long id);
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(long id);
    }
}
