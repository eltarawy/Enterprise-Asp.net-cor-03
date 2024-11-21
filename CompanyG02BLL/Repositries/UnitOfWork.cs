using CompanyG02BLL.Interfaces;
using CompanyG02DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02BLL.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext dbContext;

        public IEmployeerepository Employeerepository { get; set; }
        public IDepartmentRepository Departmentrepository { get ; set ; }

        public UnitOfWork(CompanyDbContext dbContext)
        {
            Employeerepository = new EmployeeRepository(dbContext);
            Departmentrepository = new DepartmentRepository(dbContext);
            this.dbContext = dbContext;
        }

        public int Complete()  
            =>dbContext.SaveChanges();

        public void Dispose()
            => dbContext.Dispose();
    }
}
