using HRM.BE;
using HRM.BE.BussinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HRM.DAL.DatabaseContext
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        { }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department{ Id=1,Name= "IT"},
                new Department { Id = 2, Name = "HR" },
                new Department { Id = 3, Name = "Management" },
                new Department { Id = 4, Name = "Law" }
            );
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../HRM.API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<EmployeeContext>();
            var connectionString = configuration.GetConnectionString("myconn");
            builder.UseSqlServer(connectionString);
            return new EmployeeContext(builder.Options);
        }
    }
}
