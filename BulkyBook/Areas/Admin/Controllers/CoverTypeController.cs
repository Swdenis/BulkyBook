using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBook.Areas.Admin.Controllers
{   [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            if(id==null)
            {
                return View(coverType);
            }

            coverType = _unitOfWork.CoverType.Get(id.GetValueOrDefault());
            if(coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {

                if (coverType.Id == 0)
                {
                    _unitOfWork.CoverType.Add(coverType);
                }
                else
                {
                    _unitOfWork.CoverType.Update(coverType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(coverType);
        }


        #region API CALL

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.CoverType.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.CoverType.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            } else
            {
                _unitOfWork.CoverType.Remove(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Delete successful" });
            }
        }
        #endregion
    }
}
