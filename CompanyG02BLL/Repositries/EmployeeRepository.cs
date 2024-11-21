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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeerepository
    {
        private readonly CompanyDbContext dbContext;

        public EmployeeRepository(CompanyDbContext dbContext):base(dbContext) 
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeeByaddress(string address)
        {
            return dbContext.Employees.Where(A => A.Address == address);
        }

        public IQueryable<Employee> GetEmployeeByName(string name)
            =>dbContext.Employees.Where( E => E.Name.ToLower().Contains(name.ToLower()));  


        //private readonly CompanyDbContext dbContext;

        //public EmployeeRepository(CompanyDbContext dbContext) 
        //{
        //    this.dbContext = dbContext;
        //}
        //public int Add(Employee employee)
        //{
        //    dbContext.Employees.Add(employee);
        //    return dbContext.SaveChanges();

        //}

        //public int Delete(Employee employee)
        //{
        //    dbContext.Employees.Remove(employee);
        //    return dbContext.SaveChanges();
        //}

        //public Employee Get(int id)
        //    => dbContext.Employees.Find(id);

        //public IEnumerable<Employee> GetAll()
        //    => dbContext.Employees.ToList();

        //public int Update(Employee employee)
        //{
        //    dbContext.Employees.Update(employee);
        //    return dbContext.SaveChanges();
        //}
    }
}
