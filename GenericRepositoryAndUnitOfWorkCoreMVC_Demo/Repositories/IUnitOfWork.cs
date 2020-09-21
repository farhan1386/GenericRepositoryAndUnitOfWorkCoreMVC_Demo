using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models;
using System;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Course> CourseRepositroy { get; }
        IRepository<Instructor> InstructorRepository { get; }
        IStudentRepository Students { get; }
        IStudentRepository Student { get; }
        int Complete();
    }
}
