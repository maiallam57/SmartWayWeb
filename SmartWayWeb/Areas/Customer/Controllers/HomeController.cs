using Microsoft.AspNetCore.Mvc;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;

namespace SmartWay.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserContact User)
        {
            _unitOfWork.UserContact.Add(User);
            _unitOfWork.Save();
            TempData["success"] = "Your Messege Sended Successfully";
            return View();
           
        }  
       
        public IActionResult About()
        {
            return View();
        }        
        public IActionResult CompanyProfile()
        {
            return View();
        }        
        public IActionResult KeyPersonnal()
        {
            return View();
        }        
        public IActionResult OurTeam()
        {
            return View();
        }        
        public IActionResult Services()
        {
            return View();
        }         
        public IActionResult Careers()
        {
            return View();
        } 
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }  
        
        [HttpPost]
        public IActionResult Contact(UserContact User)
        {
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
