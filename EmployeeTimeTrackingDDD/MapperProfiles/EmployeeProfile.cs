using Api.DTOs.Employee;
using AutoMapper;
using Domain.Entities.Employees;
using Domain.Models.EmployeeReport;
using Domain.Models.Employees;
using Domain.Models.Reports;

namespace Api.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {

            CreateMap<EmployeeModel, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<EmployeeModel, Employee>().ReverseMap();

            CreateMap<EmployeeModel, EmployeeReportModel>()
                .ForMember(model => model.FullNameEmployee, model => model.MapFrom(model => $"{model.FirstName} {model.SecondName} {model.LastName}"))
                .ForMember(model => model.PositionEmployee, model => model.MapFrom(model => model.Position))
                .ReverseMap();

            CreateMap<EmployeeModel, EmployeeReportDto>()
                .ForMember(dto => dto.FullNameEmployee, dto => dto.MapFrom(model => $"{model.FirstName} {model.SecondName} {model.LastName}"))
                .ForMember(dto => dto.PositionEmployee, dto => dto.MapFrom(model => model.Position))
                .ReverseMap();


        }
    }
}
