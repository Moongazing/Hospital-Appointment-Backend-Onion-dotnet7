using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Features.Department.Rules;
using TAO.HAS.Application.Features.Profession.Rules;

namespace TAO.HAS.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ProfessionBusinessRules>();
            services.AddScoped<DepartmentBusinessRules>();
            return services;

        }
    }
}
