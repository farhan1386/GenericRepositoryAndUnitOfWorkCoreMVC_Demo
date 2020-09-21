using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models;
using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var students = unitOfWork.Students.GetStudentsWithCourse();
            return View(students);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = unitOfWork.Student.GetStudentsWithCourseById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(unitOfWork.CourseRepositroy.GetAll(), "Id", "CourseName");
            ViewData["InstructorId"] = new SelectList(unitOfWork.InstructorRepository.GetAll(), "Id", "InstructorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.StudentRepository.Add(student);
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(unitOfWork.CourseRepositroy.GetAll(), "Id", "CourseName");
            ViewData["InstructorId"] = new SelectList(unitOfWork.InstructorRepository.GetAll(), "Id", "InstructorName");
            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = unitOfWork.StudentRepository.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(unitOfWork.CourseRepositroy.GetAll(), "Id", "CourseName");
            ViewData["InstructorId"] = new SelectList(unitOfWork.InstructorRepository.GetAll(), "Id", "InstructorName");
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                Student edit = unitOfWork.StudentRepository.Get(id);
                edit.StudentName = student.StudentName;
                edit.Course = unitOfWork.CourseRepositroy.Get(student.CourseId);
                edit.CourseFee = student.CourseFee;
                edit.CourseDuration = student.CourseDuration;
                edit.CourseStartDate = student.CourseStartDate;
                edit.BatchTiming = student.BatchTiming;
                edit.Instructor = unitOfWork.InstructorRepository.Get(student.InstructorId);
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(unitOfWork.CourseRepositroy.GetAll(), "Id", "CourseName");
            ViewData["InstructorId"] = new SelectList(unitOfWork.InstructorRepository.GetAll(), "Id", "InstructorName");
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = unitOfWork.Student.GetStudentsWithCourseById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = unitOfWork.StudentRepository.Get(id);
            unitOfWork.StudentRepository.Remove(student);
            unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
