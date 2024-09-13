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
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _DbContext; 
        public EmployeeRepository(AppDbContext dbContext) 
        {
            _DbContext = dbContext;
        }
        public int Add(Employee employee)
        {
            _DbContext.Employee.Add(employee);
            return _DbContext.SaveChanges(); 
        }

        public int Delete(Employee employee)
        {
            _DbContext.Employee.Remove(employee); 
            return _DbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _DbContext.Employee.AsNoTracking().ToList();
        }

        public Employee GetById(int id)
        {
            return _DbContext.Employee.Find(id);
        }

        public int Update(Employee employee)
        {
            _DbContext.Employee.Update(employee);
            return _DbContext.SaveChanges();
        }
    }
}
