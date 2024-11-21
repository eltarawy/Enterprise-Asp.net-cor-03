using CompanyG02BLL.Interfaces;
using CompanyG02DAL.Contexts;
using CompanyG02DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02BLL.Repositries
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        //Dependency Injection 
        private readonly CompanyDbContext dbContext;
        public GenericRepository(CompanyDbContext dbContext) // Ask CLR for creating object from dbcontext
        {
            this.dbContext = dbContext;
        }
        public void Add(T item)
            =>dbContext.Set<T>().Add(item);

        public void Delete(T item)
            =>dbContext.Set<T>().Remove(item);

        public T Get(int id)
           => dbContext.Set<T>().Find(id);

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>)dbContext.Employees.Include(e => e.Department).ToList();
            }
            return dbContext.Set<T>().ToList();
        }

        public void Update(T item)
            =>dbContext.Set<T>().Update(item);


    }
}
