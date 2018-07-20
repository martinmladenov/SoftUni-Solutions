namespace Employees
{
    using AutoMapper;
    using Data.Models;
    using Dtos;

    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, ManagerDto>();
            CreateMap<Employee, EmployeeOlderThanDto>();
        }
    }
}