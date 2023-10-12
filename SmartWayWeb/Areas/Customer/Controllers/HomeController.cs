using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;

namespace SmartWay.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IEmailSender _emailSender;
        public HomeController(IUnitOfWork unitOfWork/*, IEmailSender emailSender*/)
        {
            _unitOfWork = unitOfWork;
            //_emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserContact User)
        {
            //IEnumerable<Project> projectList = _unitOfWork.Project.GetAll(includeProperties: "Category");
            _unitOfWork.UserContact.Add(User);
            _unitOfWork.Save();
            TempData["success"] = "Your Messege Sended Successfully";
            return View();
           
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
