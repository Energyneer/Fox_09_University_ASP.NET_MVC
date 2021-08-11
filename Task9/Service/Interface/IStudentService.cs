using Service.ViewModel;

namespace Service
{
    public interface IStudentService
    {
        StudentsPresent GetStudent();
        StudentsPresent GetStudentsByGroup(int id);
        StudentsPresent GetStudent(int id);
        void InsertStudent(StudentsPresent studentView);
        void UpdateStudent(StudentViewModel studentView);
        void DeleteStudent(int id);
    }
}
