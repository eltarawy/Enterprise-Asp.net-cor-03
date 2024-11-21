 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeerepository Employeerepository { get ; set ; }
        IDepartmentRepository Departmentrepository { get; set; }

        int Complete();
        public void Dispose(); 
    }
    
}
