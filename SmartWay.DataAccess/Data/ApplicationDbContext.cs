﻿using Microsoft.EntityFrameworkCore;


namespace SmartWay.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Project> Projects { get; set; }
    }
}
