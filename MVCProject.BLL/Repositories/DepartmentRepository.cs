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
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        // Object member method because they are non static
        // so if i want to use any of them i must create object form this class

        // to create object form this class we use constructor
        // if i want to add or delete or other in data base i must open connection with data base
        // so i must create object form DbContext
        //DepartmentRepository must have object from DbContext

        // readonly to initialize it on constructor only
        //private readonly AppDbContext _DbContext; // Default value is Null of this object
        //_DbContext must refer to object of AppDbContext 
        // this operation will done in constructor


        //when i create object from DepartmentRepository he want 
        //object from AppDbContext 
        //Create object from DepartmentRepository depend on Create object from AppDbContext 
        //Create object from Model depend on Create object from Another Model (Dependency Injection)
        public DepartmentRepository(AppDbContext dbContext)  : base(dbContext)// ask CLR for creating object from DbContext
        {
            // this operation not correct because if i have request will do more than one operation
            // so for each operation he will open now connection with DB (new object )
            // and the first connection still open so that way not correct
            // i want to use the same connection for both operation (the same table)
            ///_DbContext = new AppDbContext();
            // so the CLR will open the connection (Create object)
            // if i want to use this connection again he will send the same object
            //_DbContext = dbContext;
        }
    }
}
