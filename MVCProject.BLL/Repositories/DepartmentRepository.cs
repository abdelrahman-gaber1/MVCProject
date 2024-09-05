using Microsoft.EntityFrameworkCore;
using MVCProject.BLL.Interfaces;
using MVCProject.DAL.Data;
using MVCProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        // Object member method because they are non static
        // so if i want to use any of them i must create object form this class

        // to create object form this class we use constructor
        // if i want to add or delete or other in data base i must open connection with data base
        // so i must create object form DbContext
        //DepartmentRepository must have object from DbContext

        // readonly to initialize it on constructor only
        private readonly AppDbContext _DbContext; // Default value is Null of this object
        //_DbContext must refer to object of AppDbContext 
        // this operation will done in constructor


        //when i create object from DepartmentRepository he want 
        //object from AppDbContext 
        //Create object from DepartmentRepository depend on Create object from AppDbContext 
        //Create object from Model depend on Create object from Another Model (Dependency Injection)
        public DepartmentRepository(AppDbContext dbContext) // ask CLR for creating object from DbContext
        {
            // this operation not correct because if i have request will do more than one operation
            // so for each operation he will open now connection with DB (new object )
            // and the first connection still open so that way not correct
            // i want to use the same connection for both operation (the same table)
            ///_DbContext = new AppDbContext();
            // so the CLR will open the connection (Create object)
            // if i want to use this connection again he will send the same object
            _DbContext = dbContext;
        }
        public int Add(Department department)
        {
            _DbContext.Department.Add(department); // change state to added 
            return _DbContext.SaveChanges(); // SQL script to add this department
        }

        public int Delete(Department department)
        {
            _DbContext.Department.Remove(department); // State Deleted
            return _DbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _DbContext.Department.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            //var department = _DbContext.Department.Local.Where(x => x.Id == id).FirstOrDefault(); 
            //if (department == null)
            //    department= _DbContext.Department.Where(x=> x.Id == id).FirstOrDefault();

            // Find Search in cache (local) first then in data base
            return _DbContext.Department.Find(id);
            return _DbContext.Department.Find(new {empId = 1 , deptId = 10}); // find take composite pk
            return _DbContext.Find<Department>(id); 
        }

        public int Update(Department department)
        {
            _DbContext.Department.Update(department);
            return _DbContext.SaveChanges();
        }
    }
}
