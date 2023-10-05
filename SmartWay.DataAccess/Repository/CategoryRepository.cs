﻿using SmartWay.DataAccess.Data;
using SmartWay.DataAccess.Repository.IRepository;
using SmartWay.Models;


namespace SmartWay.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
