using CompanyG02DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02DAL.Contexts
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext>options):base(options)  
        {
             
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  =>  optionsBuilder.UseSqlServer("server=.;database=CompanyMVCG02;trusted_connection=true"); 

        public DbSet<Department> Departments { get; set; }  
        public DbSet<Employee> Employees { get; set; }
    }
}
