using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.BLL.Interfaces;
using MVCProject.BLL.Repositories;
using MVCProject.DAL.Data;

namespace MVCProject.PL.Controllers
{
    public class DepartmentController : Controller
    {
        // 1. Inheritance : DepartmentController is a Controller
        // 2. Association : DepartmentController has a DepartmentRepository [Aggregation,Composition]
        /// <summary>
        /// Composition : Required
        /// Aggregation : Optional [Null]
        /// </summary>
        private readonly IDepartmentRepository _departmentRepository; //Null
        // Department controller title cobbled on Department Repository
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            //_departmentRepository = new DepartmentRepository(new AppDbContext(new DbContextOptions()));
            _departmentRepository = departmentRepository;
        }
        //BaseURL/Department/Index
        public IActionResult Index()
        {
            //Get All
            
            return View(_departmentRepository.GetAll());
        }
    }
}
