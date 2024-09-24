using MVCProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        // here you can add method that belong to employee only
        // like detect employee by address
        IQueryable<Employee> GetEmployeeByAddress(string address);

        IQueryable<Employee> GetEmployeeByName(string name);

    }
}
