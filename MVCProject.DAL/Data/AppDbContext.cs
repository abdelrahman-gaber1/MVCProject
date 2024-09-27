using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCProject.DAL.Data.Configration;
using MVCProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.DAL.Data
{
    public class AppDbContext : IdentityDbContext
    {
        //Create object from AppDbContext depend on Create object from DbContextOptions 
        // ask CLR for creating object from DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //when you send option we need to send our connection string
            //we will do it using addDbContext in startup
            
        }

        // we didn't need to override onConfiguring because DbContextOptions will execute it
        // if we didn't override it but when execute it we need to send our connection string
        // we went to execute parent on configuring and use our connection string
        //note we override it to use our connection string
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=. ; Database, Trusted_Connection=True");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DepartmentConfigration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfigration());
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            //OnModelCreating only for apply fluent api
            //i must add this base because the table i inherited from identityDbContext that have table that has fluent api
            //this fluent api write in onModelCreating of base so we must run bast to run this fluent api
            base.OnModelCreating(modelBuilder);
            //TO CHANGE NAME OF ANY TABLE IN identityDbContext
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        ////IdentityUser is Generic and This T detect the type of ID Default is String and generate it with GUID
        //public IdentityUser<int> Users { get; set; }

        //IdentityRole is Generic and This T detect the type of ID Default is String and generate it with GUID
        //public IdentityRole Roles { get; set; }
    }
}
