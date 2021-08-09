using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class GroupMap
    {
        public GroupMap(EntityTypeBuilder<Group> entityBuilder)
        {
            entityBuilder.HasKey(item => item.Id);
            entityBuilder.Property(item => item.GroupName).IsRequired();
            entityBuilder.HasOne(item => item.Course).WithMany(item => item.Groups).IsRequired();//.HasForeignKey(item => item.CourseId);
            entityBuilder.HasMany(item => item.Students).WithOne(item => item.Group);
        }
    }
}
