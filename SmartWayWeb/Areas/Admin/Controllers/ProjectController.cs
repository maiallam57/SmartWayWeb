using SmartWay.DataAccess;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;
using SmartWay.Models.ViewModels;
using SmartWay.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace SmartWay.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]

    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
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

            ProjectVM vm = new ProjectVM()
            {
                Project = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            
            if (id == null || id == 0)
            {
                //create the product
                return View(vm);
            }
            else
            {
                //update the product
                //when i click on edit it will load the product data automatically
                vm.Project = _unitOfWork.Project.GetFirstOrDefault(u=>u.Id==id);
                return View(vm);
            }

        }


        //POST ACTION METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProjectVM obj, IFormFile? file)
        {
            //server side Validation
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    //check file extension and size
                    Project image = new Project();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        //Convert Image to byte[]
                        file.CopyTo(ms);
                        image.ProjectImage = ms.ToArray();
                        obj.Project.ProjectImage = image.ProjectImage;

                    }
                }
                
                if(obj.Project.ProjectImage == null)
                {
                    TempData["error"] = "Please upload an image! ";
                    return View(obj);
                }

                if (obj.Project.Id == 0)
                {
                    _unitOfWork.Project.Add(obj.Project);
                    TempData["success"] = "Project Added Successfully";

                }
                else
                {
                    _unitOfWork.Project.Update(obj.Project);
                    TempData["success"] = "Project Updated Successfully";
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
            var projectList = _unitOfWork.Project.GetAll(includeProperties:"Category");
            return Json(new { data = projectList });
        }

        //POST ACTION API
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Project.GetFirstOrDefault(c => c.Id == id);
            if(obj == null)
            {
                return Json(new { success = false, message = " Error while Deleting!" });
            }
            _unitOfWork.Project.Remove(obj);
            _unitOfWork.Save();                  //To be added and saved to the database
            return Json(new { success = true, message = " Product Deleted successfully " });
        }
        #endregion
    }

}
 