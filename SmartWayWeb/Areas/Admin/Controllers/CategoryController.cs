using SmartWay.DataAccess;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;
using SmartWay.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace SmartWay.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Edit
        //GET ACTION METHOD
        public IActionResult Upsert(int? id)
        {
            Category Category = new();
            if (id == null || id == 0)
            {
                //create the product
                return View(Category);
            }
            else
            {
                //update the product
                //when i click on edit it will load the product data automatically
                Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
                TempData["success"] = "Category Updated Successfully";
                return View(Category);
            }

        }


        //POST ACTION METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            //server side Validation
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    var Companies = _unitOfWork.Category.GetAll();
                    foreach (string name in Companies.Select(x => x.Name).ToList())
                    {
                        if (name.ToLower() == obj.Name.ToLower())
                        {
                            ModelState.AddModelError("name", "The Category name is already exists.");
                        }

                    }
                    _unitOfWork.Category.Add(obj);
                    TempData["success"] = "Category Added Successfully";
                }
                else
                {
                    _unitOfWork.Category.Update(obj);
                    TempData["success"] = "Category Updated Successfully";
                }
                _unitOfWork.Save();                  //To be added and saved to the database
                return RedirectToAction("Index");   //Instead of directing it io a view,  we Redirect it to Action "Index"
            }
            return View(obj);

        }

        //API END POINT
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Category.GetAll();
            return Json(new { data = companyList });
        }

        //POST ACTION API
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = " Error while Deleting!" });
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();                  //To be added and saved to the database
            return Json(new { success = true, message = " Category Deleted successfully " });
        }
        #endregion
    }

}
