using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Repositories;
using TAO.HAS.Persistence.Contexts;
using TAO.HAS.Persistence.Repositories;

namespace TAO.HAS.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                         options.UseSqlServer(
                                                             configuration.GetConnectionString("SqlServer")));
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            return services;

        }
    }
}
