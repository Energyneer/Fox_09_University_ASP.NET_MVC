namespace DataAccess.ViewModel
{
    public class CourseViewModel : BaseEntity
    {
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }

        public CourseViewModel()
        {
        }

        public CourseViewModel(int id, string courseName, string courseDesc)
        {
            Id = id;
            CourseName = courseName;
            CourseDesc = courseDesc;
        }
    }
}
