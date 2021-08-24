using Api.DTOs.Employee;
using Api.DTOs.Report;
using AutoMapper;
using Domain.Entities.Reports;
using Domain.Models.EmployeeReport;
using Domain.Models.Filters;
using Domain.Models.Reports;

namespace Api.MapperProfiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportModel, ReportDto>()
                .ForMember(view => view.ReportId, view => view.MapFrom(model => model.Id))
                .ReverseMap();

            CreateMap<Report, ReportModel>().ReverseMap();
            CreateMap<ReportModel, EmployeeReportDto>()
                .ForMember(view => view.Recycling, view => view.MapFrom(model => model.Recycling > 0))
                .ForMember(view => view.Date, view => view.MapFrom(model => model.Date.ToShortDateString()))
                .ReverseMap();

            CreateMap<ReportModel, EmployeeReportModel>().ReverseMap();

            CreateMap<SummaryReportModel, SummaryReportDto>().ReverseMap();
            CreateMap<SummaryReportModel, SummaryReport>().ReverseMap();
            CreateMap<SummaryReport, SummaryReportDto>().ReverseMap();

            CreateMap<EmployeeReportModel, DetailReportDto>().ReverseMap();

            CreateMap<DetailReportModel, DetailReportDto>().ReverseMap();
            CreateMap<DetailReportModel, DetailReport>().ReverseMap();
            CreateMap<DetailReport, DetailReportDto>().ReverseMap();

            CreateMap<SearchModel, SearchReportDto>().ReverseMap();
            CreateMap<DetailReportModel, EmployeeReportModel>().ReverseMap();
        }
    }
}
