using Api.DTOs.Employee;
using AutoMapper;
using Domain.Entities.EmployeeReports;
using Domain.Models.EmployeeReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.MapperProfiles
{
    public class EmployeeReportProfile : Profile
    {
        public EmployeeReportProfile()
        {
            CreateMap<EmployeeReportModel, EmployeeReport>().ReverseMap();
            CreateMap<EmployeeReportModel, EmployeeReportDto>().ReverseMap();
            CreateMap<EmployeeReport, EmployeeReportDto>().ReverseMap();
        }
    }
}
