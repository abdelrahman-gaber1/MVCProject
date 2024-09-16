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
    // he will take five action form generic repository and reminder from IEmployeeRepository
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        //private readonly AppDbContext _DbContext; 
        //Dependency Injection move from Generic repository to employee repository
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            //_DbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            return _DbContext.Employee.Where(E=>E.Address.ToLower().Contains(address.ToLower()));
        }
    }
}
