using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StudentMap
    {
        public StudentMap(EntityTypeBuilder<Student> entityBuilder)
        {
            entityBuilder.HasKey(item => item.Id);
            entityBuilder.Property(item => item.FirstName).IsRequired();
            entityBuilder.Property(item => item.LastName).IsRequired();
            entityBuilder.HasOne(item => item.Group).WithMany(item => item.Students);
        }
    }
}
