using SmartWay.DataAccess.Data;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;


namespace SmartWay.DataAccess.Repository
{
    public class UserContactRepository : Repository<UserContact>, IUserContactRepository
    {
        private readonly ApplicationDbContext _db;

        public UserContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
