﻿using ARE.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<PaymentPeriod> PaymentPeriods { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TableDescription> TableDescriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BranchOffice>().HasIndex("Name", "CityId").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
            modelBuilder.Entity<Company>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<EmployeeType>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Job>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<PaymentPeriod>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Shift>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            modelBuilder.Entity<TableDescription>().HasIndex(e => e.Name).IsUnique();

            /*modelBuilder.Entity<Country>().Navigation(c => c.States).AutoInclude();
            modelBuilder.Entity<State>().Navigation(c => c.Cities).AutoInclude();*/


        }
    }

}

