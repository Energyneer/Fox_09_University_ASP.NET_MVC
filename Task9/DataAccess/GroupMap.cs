using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GroupMap
    {
        public GroupMap(EntityTypeBuilder<Group> entityBuilder)
        {
            entityBuilder.HasKey(item => item.Id);
            entityBuilder.Property(item => item.GroupName).IsRequired();
            entityBuilder.HasOne(item => item.Course).WithMany(item => item.Groups);
            entityBuilder.HasMany(item => item.Students).WithOne(item => item.Group);
        }
    }
}
