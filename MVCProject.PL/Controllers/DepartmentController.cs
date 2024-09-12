using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVCProject.BLL.Interfaces;
using MVCProject.BLL.Repositories;
using MVCProject.DAL.Data;
using MVCProject.DAL.Models;

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
            //view is helper method inheretied form controller
            //view have 4 overloading
            //1.no paramater  : return view with name of the method(index)
            //2.name of model : data that you want to send to view
            //3.name of view that you want to show 
            //4. model + view
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }
        //when you click in create departmnet he will open view that contain form
        [HttpGet]
        public IActionResult Create() 
        {
            return View();

        }
        //When you click submet he will excute this action 
        //we will get department from form
        [HttpPost]
        public IActionResult Create(Department department)
        {
            //ModelState Property inherited form contraller
            //have is vallid that check if model vaild or not
            //depande on the validation in department model is achive this validation
            if (ModelState.IsValid)
            {
              var result = _departmentRepository.Add(department);
              if(result>0)
                {
                    return RedirectToAction("Index");
                }
            }
            // if add of department field we want to return the create with date user enterd
            return View(department );
        }
    }
}
