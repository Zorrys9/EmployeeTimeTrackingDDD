using Autofac;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.EmployeeModels;
using Domain.Interfaces.EmployeeReports;
using Domain.Interfaces.Employees;
using Domain.Interfaces.Reports;
using Infrastructure.Data.Repositories;
using Infrastructure.Logics;
using Infrastructure.Services;
using Serilog;

namespace Infrastructure.Modules
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = builder.Properties["ConnectionString"].ToString();


            builder.Register(component =>
            {
                var context = component.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>()
                .As<IEmployeeRepository>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionString", connectionString);

            builder.RegisterType<ReportRepository>()
                .As<IReportRepository>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionString", connectionString);

            builder.RegisterType<EmployeeReportRepository>()
                .As<IEmployeeReportRepository>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionString", connectionString);

            builder.RegisterType<SummaryReportRepository>()
                .As<ISummaryReportRepository>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionString", connectionString);

            builder.RegisterType<DetailReportRepository>()
                .As<IDetailReportRepository>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionString", connectionString);

            builder.RegisterType<EmployeeService>()
                .As<IEmployeeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ReportService>()
                .As<IReportService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeReportService>()
                .As<IEmployeeReportService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FileService>()
                .As<IFileService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TrackingLogic>()
                .As<ITrackingLogic>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountLogic>()
                .As<IAccountLogic>()
                .InstancePerLifetimeScope();
        }
    }
}
