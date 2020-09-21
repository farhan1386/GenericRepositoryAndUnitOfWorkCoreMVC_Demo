using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models;
using System.Collections.Generic;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetStudentsWithCourse();
        Student GetStudentsWithCourseById(int? id);
    }
}
