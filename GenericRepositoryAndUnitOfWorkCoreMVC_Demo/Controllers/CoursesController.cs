using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models;
using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CoursesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var courses = unitOfWork.CourseRepositroy.GetAll();
            return View(courses);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = unitOfWork.CourseRepositroy.Get(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CourseRepositroy.Add(course);
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = unitOfWork.CourseRepositroy.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (ModelState.IsValid)
            {
                Course edit = unitOfWork.CourseRepositroy.Get(id);
                edit.CourseName = course.CourseName;
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = unitOfWork.CourseRepositroy.Get(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = unitOfWork.CourseRepositroy.Get(id);
            unitOfWork.CourseRepositroy.Remove(course);
            unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
