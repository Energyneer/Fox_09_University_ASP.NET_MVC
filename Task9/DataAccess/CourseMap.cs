using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class CourseMap
    {
        public CourseMap(EntityTypeBuilder<Course> entityBuilder)
        {
            entityBuilder.HasKey(item => item.Id);
            entityBuilder.Property(item => item.CourseName).IsRequired();
            entityBuilder.Property(item => item.CourseDesc);
            entityBuilder.HasMany(item => item.Groups).WithOne(item => item.Course);
        }
    }
}
