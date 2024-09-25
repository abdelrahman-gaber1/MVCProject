using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVCProject.BLL.Interfaces;
using MVCProject.BLL.Repositories;
using MVCProject.DAL.Models;
using MVCProject.PL.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MVCProject.PL.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        //private readonly IDepartmentRepository _departmentRepository;

        //we have performance issue because we create IDepartmentRepository and didn't use it in all action
        //this problem occur because we inject in constructor and all action call this constructor
        // to solve this problem we want to inject inside the part we need it inside view of create and edit

        // To use auto mapper we need to inject object from auto mapper in constructor of employee then add this service in startup
        public EmployeeController(/*IEmployeeRepository employeeRepository*/ IUnitOfWork unitOfWork, IWebHostEnvironment env  /*IDepartmentRepository departmentRepository*/ , IMapper mapper)
        {
            //_employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _env = env;
            _mapper = mapper;
            //_departmentRepository = departmentRepository;
        }

        //[HttpGet]
        // form execute post action so this action will be post as default
        // one action without method if i call it by form he will post
        // Two action one get and one post so form will execute post
        // one action with method Get if i call it by form no thing will happen
        public IActionResult Index(string searchInp)
        {
            ViewData["Message"] = "Hello ViewData"; //Dictionary
            ViewBag.message = "Hello ViewBag";     //Dynamic
            if (string.IsNullOrEmpty(searchInp))
            {

                var employees = _unitOfWork.EmployeeRepository.GetAll();
                var mappedEmp = _mapper.Map <IEnumerable<Employee>,IEnumerable< EmployeeViewModel>>(employees);
                return View(mappedEmp);

            }
            else
            {
                var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(searchInp);
                var mappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
                return View(mappedEmp);
            }


        }
        [HttpGet]
        public IActionResult Create()
        {
            //model bind in only one type
            //how i can access getAll of department and I'm in Employee controller
            //using department repository
            //we can use viewBag
            //var department = _departmentRepository.GetAll();
            //ViewData["Departments"] = department;
            return View();

        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            //This Action Take EmployeeViewModel As parameter from Create view and we must map it to Model before Send it to Database
            //There are two type of mapping Manual and AutoMapper (Package That Show viewModel as Model)
            //Auto mapper Package for Manual Mapping To Convert View Model to Model or opposite 


            if (ModelState.IsValid)
            {
                //var mappedEmp = new Employee
                //{
                //    //Manual Mapping
                //    //if i have some property on model not found in view model i can add default value for it in model
                //    Name = employeeVM.Name,
                //    Age = employeeVM.Age,
                //    Address = employeeVM.Address,
                //    Salary = employeeVM.Salary,
                //    Email = employeeVM.Email,
                //    PhoneNumber = employeeVM.PhoneNumber,
                //    IsActive = employeeVM.IsActive,
                //    HireDate = employeeVM.HireDate,
                //};

                //Auto Mapper
                var mappedEmp = _mapper.Map<EmployeeViewModel,Employee>(employeeVM);
                //convert from EmployeeViewModel to Employee =>Data will convert employeeVM
                //Note he Need to Know how to convert how mapping using Profile 
                 _unitOfWork.EmployeeRepository.Add(mappedEmp); //state added
                var result = _unitOfWork.Complete();
                //_dbcontext.SaveChanges(); // I can't do it because i didn't have an object of AppDbContext
                //controller connect with dbcontext undirectly using repository
                //i want if i have action that do some operation like added and update and delete from db
                //i want to do one save change after all this state change 
                //the problem is i didn't have access to dbcontext here so
                //we will add layer bettwen contraller and repository ( Unit Of Work )
                // Unit Of Work contaon
                if (result > 0)
                {
                    TempData["Message"] = "Employee Created Successfully";
                }
                else
                {
                    TempData["Message"] = "An Error Occurred";
                }
                return RedirectToAction("Index");
            }
            return View(employeeVM);
        }
        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            var mappedEmp = _mapper.Map<Employee, EmployeeViewModel>(employee);

            //var department = _departmentRepository.GetAll();
            //ViewData["Departments"] = department;
            if (mappedEmp == null)
            {
                return NotFound();
            }
            return View(viewName, mappedEmp);
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(employeeVM);
            }
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                _unitOfWork.EmployeeRepository.Update(mappedEmp);
                _unitOfWork.Complete();
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
                    ModelState.AddModelError(string.Empty, "An Error occurred during update department");
                }
                return View(employeeVM);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeViewModel employeeVM)
        {
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                _unitOfWork.EmployeeRepository.Delete(mappedEmp);
                _unitOfWork.Complete();
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
                return View(employeeVM);
            }
        }
    }
}
