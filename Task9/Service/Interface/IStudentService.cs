using Service.ViewModel;
using System.Collections.Generic;

namespace Service
{
    public interface IStudentService
    {
        IEnumerable<StudentViewModel> GetStudent();
        IEnumerable<StudentViewModel> GetStudentsByGroup(int id);
        StudentViewModel GetStudent(int id);
        void InsertStudent(StudentViewModel studentView);
        void UpdateStudent(StudentViewModel studentView);
        void DeleteStudent(int id);
    }
}
