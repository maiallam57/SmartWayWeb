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
        
        public async Task<IActionResult> Details(int id)
        {
            var prject = await _unitOfWork.Project.FirstOrDefaultAsync(a => a.Id == id, includeProperties: c => c.Category);

            if (prject == null)
                return NotFound();

            return View(prject);

        }


        public IActionResult Error()
        {
            return View();
        }

    }
}
