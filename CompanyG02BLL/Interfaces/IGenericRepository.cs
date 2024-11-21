using CompanyG02DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Add(T item);

        void Delete(T item);

        void Update(T item);
    }
}
