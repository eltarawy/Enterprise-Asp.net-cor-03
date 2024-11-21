using Assignment_Asp.net_cor_03.ViewModels;
using AutoMapper;
using CompanyG02DAL.Models;

namespace Assignment_Asp.net_cor_03.MapperProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
