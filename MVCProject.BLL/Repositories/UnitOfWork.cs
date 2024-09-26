using MVCProject.BLL.Interfaces;
using MVCProject.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Repositories
{
    //we must know clr that unit of work have dispose to excute it 
    //to know him that he have this method we must implement spicific interface (IDisposable)  
    //so we will make iunitofwork inherit form idiposable 
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly AppDbContext _dbContext;

        //i need when create object of unitofwork to decleare EmployeeRepository ,
        //DepartmentRepository then i need object of AppDbContext
        public UnitOfWork(AppDbContext dbContext)
        {
            //Injection level Become Execute in unit of work not Repository
            //note in service when we added unit of work injection 
            //we delete service for repository because we do it here 
            _dbContext = dbContext;
            EmployeeRepository = new EmployeeRepository(_dbContext);
            DepartmentRepository= new DepartmentRepository(_dbContext);
        }
        // refernce of type IEmployeeRepository refer to  null
        public IEmployeeRepository EmployeeRepository { get; set; }
        //Automatic property Generate Backing Field attribute( hidden attribute ) i don't have access on it because i don't need it. 
        public IDepartmentRepository DepartmentRepository { get; set; }

        public int Complete()
        {
           return _dbContext.SaveChanges();
        }
        //CLR after you create object of unit of work he see if he have dispose
        //he will excute it after this object life time end
        public void Dispose()
        {
             _dbContext.Dispose();
        }
    }
}
