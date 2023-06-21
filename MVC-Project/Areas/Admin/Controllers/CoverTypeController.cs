using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetAll()
        {
            var coverTypes = _unitOfWork.CoverType.GetAll();
            return View(coverTypes);
        }

        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CoverType obj)
        {
            if(obj.Name == "No Cover") 
            {
                ModelState.AddModelError("Name", "CoverType Name Can't Be No Cover");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Commit();
                TempData["success"] = "New CoverType Has Been Added";
                return RedirectToAction("GetAll");
            }
            else
                return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(entity => entity.Id == id);
            if (coverType == null)
                return NotFound();
            
                return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Commit();
                TempData["success"] = "CoverType Has Been Edited Successfully";
                return RedirectToAction("GetAll");
            }
            else
                return View(obj);
        }

        public IActionResult Delete(int id)
        {
            if(id == null || id == 0)
                return NotFound();
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(entity => entity.Id == id);
            if(coverType == null)
                return NotFound();
            return View(coverType);
        }

        [HttpPost]
        public IActionResult Delete(CoverType coverType) 
        {
            if(coverType != null)
            {
                _unitOfWork.CoverType.Remove(coverType);
                _unitOfWork.Commit();
                TempData["success"] = "CoverType Has Been Removed Successfully";
                return RedirectToAction("GetAll");
            }
            return View(coverType);
        }


    }
}
