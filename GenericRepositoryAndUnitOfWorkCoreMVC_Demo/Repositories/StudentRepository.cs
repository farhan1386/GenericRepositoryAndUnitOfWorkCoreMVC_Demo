using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Data;
using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            return Context.Students.Include(s => s.Course).Include(s => s.Instructor).ToList();
        }

        public Student GetStudentsWithCourseById(int? id)
        {
            return Context.Students.Include(s => s.Course).Include(s => s.Instructor).FirstOrDefault(s => s.Id == id);
        }
    }
}
