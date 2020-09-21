using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Models;
using GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public InstructorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var instructors = unitOfWork.InstructorRepository.GetAll();
            return View(instructors);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = unitOfWork.InstructorRepository.Get(id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.InstructorRepository.Add(instructor);
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = unitOfWork.InstructorRepository.Get(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Instructor instructor)
        {

            if (ModelState.IsValid)
            {
                Instructor edit = unitOfWork.InstructorRepository.Get(id);
                edit.InstructorName = instructor.InstructorName;
                edit.Qualification = instructor.Qualification;
                edit.Experience = instructor.Experience;
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = unitOfWork.InstructorRepository.Get(id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = unitOfWork.InstructorRepository.Get(id);
            unitOfWork.InstructorRepository.Remove(instructor);
            unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
