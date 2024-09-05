using Microsoft.AspNetCore.Mvc;
using MVCProject.BLL.Interfaces;
using MVCProject.BLL.Repositories;

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
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            //Get All
            
            return View(_departmentRepository.GetAll());
        }
    }
}
