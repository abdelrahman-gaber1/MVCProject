using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MVCProject.BLL.Interfaces;
using MVCProject.BLL.Repositories;
using MVCProject.DAL.Data;
using MVCProject.DAL.Models;
using System;

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
        //private readonly IDepartmentRepository _departmentRepository; //Null
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        // Department controller title cobbled on Department Repository
        // IWebHostEnvironment : i want this interface to check environment
        //i didn't need to inject form IDepartmentRepository because iunitofwork contain it and IEmployeeRepository
        public DepartmentController(/*IDepartmentRepository departmentRepository*/ IUnitOfWork unitOfWork , IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            //_departmentRepository = new DepartmentRepository(new AppDbContext(new DbContextOptions()));
            //_departmentRepository = departmentRepository;

            _env = env;
        }
        //BaseURL/Department/Index
        
        public IActionResult Index()
        {
            //Get All
            //view is helper method inherited form controller
            //view have 4 overloading
            //1.no parameter  : return view with name of the method(index)
            //2.name of model : data that you want to send to view
            //3.name of view that you want to show 
            //4. model + view
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }
        //when you click in create department he will open view that contain form
        [HttpGet]
        public IActionResult Create() 
        {
            return View();

        }
        //When you click submit he will execute this action 
        //we will get department from form
        [HttpPost]
        public IActionResult Create(Department department)
        {
            //ModelState Property inherited form controller
            //have is valid that check if model valid or not
            //Depend on the validation in department model is achieve this validation
            if (ModelState.IsValid)
            {
                //var result = _departmentRepository.Add(department);
                _unitOfWork.DepartmentRepository.Add(department);
                var result = _unitOfWork.Complete();
                if(result>0)
                {
                    return RedirectToAction("Index");
                }
            }
            // if add of department field we want to return the create with date user entered
            return View(department);
        }
        [HttpGet]
        public IActionResult Details(int? id ,string viewName = "Details")
        {
            //if user want to found details of department and didn't send id 
            //i want to handle this error
            if (!id.HasValue)
            {
                //client side error 400
                //went to access action but didn't send id
                //wrong data
                return BadRequest();
            }
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department == null)
            {
                //client side error 404
                //no department with this id
                return NotFound();
            }
            return View(viewName,department);
        }
        [HttpGet]

        public IActionResult Edit(int? id) 
        {
            //if (!id.HasValue)
            //{
            //    return BadRequest();
            //}
            //var department = _departmentRepository.GetById(id.Value);
            //if (department == null)
            //{
            //    return NotFound();
            //}
            //return View(department);
            return Details(id, "Edit");
        }


        // to prevent any tool like postman else your browser to access your website 
        // to validate that token come from browser
        [ValidateAntiForgeryToken]
        [HttpPost]
        //model bind data first from form to prevent any one form add id from inspect
        //we will Force him to take id from only route
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            //may we when update this dep cause some error so we went to handle it
            //so we want to handle exception
            try
            {
                //here i add code that may be send exception
                _unitOfWork.DepartmentRepository.Update(department);
                return RedirectToAction(nameof(Index));
            }
            //Exception parent class for all exception
            catch (Exception ex)
            {
                //to handle exception
                //1.log exception : to view it by support team and solve problem
                //life time for log is Sengelton 
                //2.Frindly massage for user not development environment
                // i want to check in which environment i am
                if (_env.IsDevelopment())
                {
                    //to display exception for this error
                    //to add this error
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An Error occurred during update department");
                }
                return View(department);
            }
        }

        [HttpGet]
        // when you delete you see confirmation massage
        // we want before you delete see information about department you will delete it
        public IActionResult Delete(int? id)
        {
            return Details(id,"Delete");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            try
            {
                _unitOfWork.DepartmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An Error occurred during Delete department");
                }
                return View(department);
            }
        }
    }
}