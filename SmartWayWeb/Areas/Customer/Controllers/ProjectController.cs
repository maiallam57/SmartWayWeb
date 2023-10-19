using Microsoft.AspNetCore.Mvc;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;

namespace SmartWay.Areas.Customer.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MessageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Project> projectList = _unitOfWork.Project.GetAll(includeProperties: "Category");
            return View(projectList);        
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
