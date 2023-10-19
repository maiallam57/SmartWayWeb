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
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        //API END POINT
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var UserContactList = _unitOfWork.UserContact.GetAll();
            return Json(new { data = UserContactList});
        }

        //POST ACTION API
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.UserContact.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = " Error while Deleting!" });
            }
            _unitOfWork.UserContact.Remove(obj);
            _unitOfWork.Save();                  //To be added and saved to the database
            return Json(new { success = true, message = " Message Deleted successfully " });
        }
        #endregion
    }

}
