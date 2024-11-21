using CompanyG02DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Assignment_Asp.net_cor_03.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max lengh is 50 chars")]
        [MinLength(5, ErrorMessage = "min lengh is 50 chars")]
        public string Name { get; set; }


        [Range(22, 35, ErrorMessage = "Age mast be in range 35")]
        public int? Age { get; set; }



        [RegularExpression("^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address must be like 123-street-city-country")]
        public string Address { get; set; }


        [DataType(DataType.Currency)]
        public decimal salary { get; set; }


        public bool IsActive { get; set; }


        [EmailAddress]
        public string Email { get; set; }


        public DateTime HireDatr { get; set; }

        public IFormFile Image { get; set; }

        public string ImageName { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        //fk Optional => onDelete  :REstrict  exaption
        //fk Required => onDelete  :Cascate allDelet

        public Department Department { get; set; }
    }
}
