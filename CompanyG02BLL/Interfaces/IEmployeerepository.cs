using CompanyG02DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02BLL.Interfaces
{
    public interface IEmployeerepository:IGenericRepository<Employee>
    {
        public IQueryable<Employee> GetEmployeeByaddress(string address);

        public IQueryable<Employee> GetEmployeeByName(string name);
        //IEnumerable<Employee> GetAll();
        //Employee Get(int id);
        //int Add(Employee employee);
        //int Delete(Employee employee);
        //int Update(Employee employee);
    }
}
