using SmartWay.DataAccess.Data;
using SmartWay.DataAccess.Repository.IRepository;


namespace SmartWay.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Project = new ProjectRepository(_db);

        }

        public ICategoryRepository Category { get; private set; }
        public IProjectRepository Project { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
