using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Data;
using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }
        public IRepository<Student> StudentRepository => new Repository<Student>(db);

        public IRepository<Course> CourseRepositroy => new Repository<Course>(db);

        public IRepository<Instructor> InstructorRepository => new Repository<Instructor>(db);

        public IStudentRepository Students => new StudentRepository(db);
        public IStudentRepository Student => new StudentRepository(db);

        public int Complete()
        {
            return db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
