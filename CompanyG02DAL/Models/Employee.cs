using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]       
        public string Name { get; set; }


        public int? Age {  get; set; }


        public string Address {  get; set; }
        
        
        [DataType(DataType.Currency)]
        public decimal salary { get; set; }
       
        
        public bool IsActive { get; set; }

        
        
        public string Email { get; set; }
       
        
        public DateTime HireDatr { get; set; }
        
        public string ImageName { get; set; }
        
        public DateTime CreationData { get; set;} =DateTime.Now;


        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        //fk Optional => onDelete  :REstrict  exaption
        //fk Required => onDelete  :Cascate allDelet

        public Department Department { get; set; }
    }
}
