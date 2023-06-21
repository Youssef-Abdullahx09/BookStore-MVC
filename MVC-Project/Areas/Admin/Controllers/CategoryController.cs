using Microsoft.AspNetCore.Mvc;
using Models;
using DataAccess.Repository.IRepository;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult GetAll()
        {
            var categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Category obj)
        {
            if (obj.Name == "Ahmed")
            {
                ModelState.AddModelError("name", "Name Can't Be Ahmed.........");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Commit();
                TempData["success"] = "Category Added Successfully.";
                return RedirectToAction("GetAll");
            }
            else
                return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _unitOfWork.Category.GetFirstOrDefault(entity => entity.Id == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Commit();
                TempData["success"] = "Category Edited Successfully.";
                return RedirectToAction("GetAll");
            }
            else
                return View(obj);
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();
            var category = _unitOfWork.Category.GetFirstOrDefault(entity => entity.Id == id);
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            if (obj != null)
            {
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Commit();
                TempData["success"] = "Category Deleted Successfully.";
                return RedirectToAction("GetAll");
            }
            else
                return View(obj);
        }
    }
}
