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

        public async Task<IActionResult> Details(int projectId)
        {
            var project = await _unitOfWork.Project.FirstOrDefaultAsync(u => u.Id == projectId);
            return View(project);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
