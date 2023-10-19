using Microsoft.AspNetCore.Mvc;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;

namespace SmartWay.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Project> projectList = _unitOfWork.Project.GetAll(includeProperties: "Category");
            return View(projectList);        
        }

        public IActionResult Details(int? projecId)
        {
            Project ProjectObj = _unitOfWork.Project.GetFirstOrDefault(u => u.Id == projecId, includeProperties: "Category");
            return View(ProjectObj);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
