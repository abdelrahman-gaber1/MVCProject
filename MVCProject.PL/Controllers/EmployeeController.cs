using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MVCProject.BLL.Interfaces;
using MVCProject.BLL.Repositories;
using MVCProject.DAL.Models;
using System;

namespace MVCProject.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository; 
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment env)
        {
            _employeeRepository = employeeRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeRepository.Add(employee);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var employee = _employeeRepository.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(viewName, employee);
        }
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            try
            {
                _employeeRepository.Update(employee);
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
                return View(employee);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee)
        {
            try
            {
                _employeeRepository.Delete(employee);
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
                return View(employee);
            }
        }
    }
}
