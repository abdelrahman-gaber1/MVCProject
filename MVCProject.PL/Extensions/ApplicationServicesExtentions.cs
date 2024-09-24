using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.DependencyInjection;
using MVCProject.BLL.Interfaces;
using MVCProject.BLL.Repositories;

namespace MVCProject.PL.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            // if any one need IDepartmentRepository CLR will create DepartmentRepository
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //register of service of repository always scope 
            //because if request have more than one operation he will create one object
            //after end of request the object became unreachable object
            //and remove it from heap when garbage collector work
            return services;
        }
    }
}
