using Assignment_Asp.net_cor_03.Helpers;
using Assignment_Asp.net_cor_03.ViewModels;
using AutoMapper;
using CompanyG02BLL.Interfaces;
using CompanyG02BLL.Repositries;
using CompanyG02DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Assignment_Asp.net_cor_03.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public IActionResult Index(string SearchValue)
        {
            //1) ViewData
            //ViewData["Message"] = "Hello from view Data";

            //2) ViewBag 
            //ViewBag.Massege = "Hello from view Bage";
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(SearchValue))
                employees = unitOfWork.Employeerepository.GetAll();
            else
                employees = unitOfWork.Employeerepository.GetEmployeeByName(SearchValue);

            var MappEmployee = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(MappEmployee);
        }

        public IActionResult Create()
        {
            //ViewBag.Departments = departmentRepository.GetAll();
            return View();
        }



        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid) //Server side validation
            {
                //Employee mappemployee = new Employee()
                //{
                //    Name = employeeVM.Name,
                //    Age = employeeVM.Age,
                //    Address = employeeVM.Address,
                //    salary = employeeVM.salary,
                //    Email = employeeVM.Email,
                //    IsActive = employeeVM.IsActive,
                //    HireDatr = employeeVM.HireDatr,
                //    DepartmentId = employeeVM.DepartmentId
                //};

                var MappedEmp = mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                MappedEmp.ImageName = DocumentSettings.UploadImage(employeeVM.Image, "images");
                unitOfWork.Employeerepository.Add(MappedEmp);
                int Result = unitOfWork.Complete();
                if (Result > 0)
                {
                    TempData["Massege"] = "Employee is Created !";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }



        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var employee = unitOfWork.Employeerepository.Get(id.Value);

            if (employee is null)
                return NotFound();
            
            var MappEmployee = mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(viewName, MappEmployee);
        }

          

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
            //if (id is null)
            //    return BadRequest();
            //var Department = departmentRepository.Get(id.Value);

            //if (Department is null)
            //    return NotFound();

            //return View(Department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var MappedEmp = mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    unitOfWork.Employeerepository.Update(MappedEmp);
                    unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //1.log exeption
                    //2. friendly message  
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeVM);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            try
            {
                var MappedEmp = mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                if(MappedEmp.ImageName is not null)
                {
                    DocumentSettings.DeleteFile(MappedEmp.ImageName, "images");
                }
                unitOfWork.Employeerepository.Delete(MappedEmp);
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employeeVM);
            }
        }
    }
}
