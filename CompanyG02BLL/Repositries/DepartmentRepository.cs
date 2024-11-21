using CompanyG02BLL.Interfaces;
using CompanyG02DAL.Contexts;
using CompanyG02DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02BLL.Repositries
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CompanyDbContext dbContext):base(dbContext)  
        {
                
        }

       
        //private readonly CompanyDbContext dbContext;
        //public DepartmentRepository(CompanyDbContext dbContext) // Ask CLR for creating object from dbcontext
        //{
        //    //dbContext = new CompanyDbContext();
        //    this.dbContext = dbContext;
        //}
        //public int Add(Department department)
        //{
        //    dbContext.Departments.Add(department);
        //    return dbContext.SaveChanges();
        //}

        //public int Delete(Department department)
        //{
        //    dbContext.Departments.Remove(department);
        //    return dbContext.SaveChanges();
        //}

        //public Department Get(int id)
        ////{
        ////    return dbContext.Departments.Where(d =>d.Id == id).FirstOrDefault(); 
        ////}
        //   => dbContext.Find<Department>(id);

        //public IEnumerable<Department> GetAll()
        //    => dbContext.Departments.ToList();

        //public int Update(Department department)
        //{
        //    dbContext.Departments.Update(department);
        //    return dbContext.SaveChanges();
        //}
    }
}
