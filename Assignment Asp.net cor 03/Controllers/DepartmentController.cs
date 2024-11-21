using CompanyG02BLL.Interfaces;
using CompanyG02BLL.Repositries;
using CompanyG02DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;

namespace Assignment_Asp.net_cor_03.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {//Get All
            var Department = unitOfWork.Departmentrepository.GetAll();
            return View(Department);
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid) //Server side validation
            {

                unitOfWork.Departmentrepository.Add(department);
                int result = unitOfWork.Complete();
                if (result > 0)
                {
                    TempData["Massege"] = "Department is Created !";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }



        public IActionResult Details(int? id,string viewName= "Details")
        {
            if (id is null)
                return BadRequest();
            var Department = unitOfWork.Departmentrepository.Get(id.Value);

            if(Department is null)
                return NotFound();

            return View( viewName,Department);
        }
        
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id,"Edit");
            //if (id is null)
            //    return BadRequest();
            //var Department = departmentRepository.Get(id.Value);

            //if (Department is null)
            //    return NotFound();

            //return View(Department);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id,Department department)
        {
            if (id !=department.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.Departmentrepository.Update(department);
                    unitOfWork.Complete();
                    return RedirectToAction(nameof (Index));
                }
                catch(Exception ex) 
                {
                    //1.log exeption
                    //2. friendly message  
                    ModelState.AddModelError(string.Empty, ex.Message);
                }       
            }
            return View(department);
        }


        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete( [FromRoute] int id, Department department)
        {
            if (id !=department.Id)
                return BadRequest();
            try
            {
                unitOfWork.Departmentrepository.Delete(department);
                unitOfWork.Complete();
                return RedirectToAction(nameof (Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(department);
            }
        } 
    }
}
