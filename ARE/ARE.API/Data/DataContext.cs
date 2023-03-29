using ARE.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ARE.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Assistance> Assistances { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<ChargeDates> ChargeDates { get; set; }
        public DbSet<ChargeDetail> ChargeDetails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CivilStatus> CivilStatuses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<MethodOfPayment> MethodOfPayments { get; set; }
        public DbSet<PaymentPeriod> PaymentPeriods { get; set; }
        public DbSet<PendingCharges> PendingCharges { get; set; }
        public DbSet<SchoolGrade> SchoolGrades { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentType> StudentTypes { get; set; }
        public DbSet<StudentTypeRelationship> StudentTypeRelationships { get; set; }
        public DbSet<SubTypeOfCharge> SubTypeOfCharges { get; set; }
        public DbSet<TableDescription> TableDescriptions { get; set; }
        public DbSet<TypeOfCharge> TypeOfCharges { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assistance>().HasIndex("EntryDate","StudentId").IsUnique();
            modelBuilder.Entity<BloodType>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<BranchOffice>().HasIndex("Name", "CityId").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
            modelBuilder.Entity<CivilStatus>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Company>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<EmployeeType>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Job>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<MethodOfPayment>().HasIndex(m => m.Name).IsUnique();
            modelBuilder.Entity<PaymentPeriod>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<SchoolGrade>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Shift>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            modelBuilder.Entity<Student>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<StudentType>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<StudentTypeRelationship>().HasIndex(e => e.StudentId).IsUnique();
            modelBuilder.Entity<TableDescription>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<TypeOfCharge>().HasIndex(e => e.Name).IsUnique();

            /*modelBuilder.Entity<Country>().Navigation(c => c.States).AutoInclude();
            modelBuilder.Entity<State>().Navigation(c => c.Cities).AutoInclude();*/


        }
    }

}

