# Generic Repository And UnitOfWork Core MVC

### Step-1 Create ASP.Net Core MVC project with Visual Studio 2019.
From the Visual Studio select Create a new project.Select ASP.NET Core Web Application and then select Next.Name the project GenericRepositoryAndUnitOfWorkCoreMVC_Demo and select Create.
Select Web Application(Model-View-Controller), and then select Create.Visual Studio used the default template for the MVC project you just created. You have a working app right now by entering a project name and selecting a few options. This is a basic starter project.
### Step-2 Create Model Classes like Student, Course and Instructor.
Right-click the Models folder > Add > Class. Name the file Student.cs, Course.cs and Instructor.cs.
### Step-3 Create Data folder and ApplicationDbContext class under the folder
Right-click project solution create Data folde. Now right click Data folder > Add > Class. Name the file ApplicationDbContext.cs
### Step-4 Add connection string in appsettings.json file 


```
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StudentDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```
  
### Step-5 Add service and database in Startup.cs

```
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```
Step- 6 Create Repositories folder and create following repository
* IRepository
* Repository
* IUnitOfWork
* UnitOfWork
* IStudentRepository
* StudentRepository

### IRepository
~~~
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int? id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
~~~
### Repository
~~~
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;
        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public TEntity Get(int? id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }
    }
~~~
### IUnitOfWork
~~~
 public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Course> CourseRepositroy { get; }
        IRepository<Instructor> InstructorRepository { get; }
        IStudentRepository Students { get; }
        IStudentRepository Student { get; }
        int Complete();
    }
~~~
### UnitOfWork
~~~
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
~~~
