using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}
