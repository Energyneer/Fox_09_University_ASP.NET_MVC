using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CourseMap(modelBuilder.Entity<Course>());
            new GroupMap(modelBuilder.Entity<Group>());
            new StudentMap(modelBuilder.Entity<Student>());
        }
    }
}
