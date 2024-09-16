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
    // we need to add the same constrain of interface to this class 
    // to insure that T will send to Generic Repository will be Model Base
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        //private protected any class inherit from this class will inherit this property with private access method
        private protected readonly AppDbContext _DbContext; 


        public GenericRepository(AppDbContext dbContext) 
        {
            _DbContext = dbContext;
        }
        public int Add(T item)
        {
            //Set<T> to select Table we need 
            //because we didn't know the table (Type of T)
            _DbContext.Set<T>().Add(item); // change state to added 
            _DbContext.Add(item); // add is intelligent to detect table automatic
            return _DbContext.SaveChanges(); // SQL script to add this department
        }

        public int Delete(T item)
        {
            _DbContext.Set<T>().Remove(item); // State Deleted
            return _DbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _DbContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            //var department = _DbContext.Department.Local.Where(x => x.Id == id).FirstOrDefault(); 
            //if (department == null)
            //    department= _DbContext.Department.Where(x=> x.Id == id).FirstOrDefault();

            // Find Search in cache (local) first then in data base
            return _DbContext.Set<T>().Find(id);
            return _DbContext.Set<T>().Find(new { empId = 1, deptId = 10 }); // find take composite pk
            return _DbContext.Find<T>(id);
        }

        public int Update(T item)
        {
            _DbContext.Set<T>().Update(item);
            return _DbContext.SaveChanges();
        }
    }
}