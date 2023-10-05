using SmartWay.DataAccess.Data;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;


namespace SmartWay.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Project obj)
        {
            //Updating one property instead of Updating all of the properties
            var objFromDb = _db.Projects.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;

                if (obj.ProjectImage != null)
                {
                    objFromDb.ProjectImage = obj.ProjectImage;
                }
            }
        }
    }
}
