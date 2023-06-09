﻿using SolidProductApi.Models;

namespace SolidProductApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Electronic> Electronics { get; set; }
    }
}
