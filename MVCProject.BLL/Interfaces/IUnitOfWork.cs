using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Interfaces
{
    // i want to connect to db using this unit
    public interface IUnitOfWork
    {
        //i want property for employee repository that inside of him talk to dbcontext
        public IEmployeeRepository EmployeeRepository { get; set; }
        //i want property for department repository that inside of him talk to dbcontext
        public IDepartmentRepository DepartmentRepository { get; set; }
        //property for save change i want to build method like saveChange function
        int Complete();

        int Dispose();
    }
}
