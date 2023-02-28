﻿using ARE.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<EmployeeType>().HasIndex(e => e.Name).IsUnique();

        }
    }

}

