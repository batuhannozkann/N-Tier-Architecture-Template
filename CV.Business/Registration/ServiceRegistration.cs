using CV.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Business.Registration
{
    public static class ServiceRegistration {
        public static IServiceCollection ServiceRegistrationBusiness(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CvApplicationContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });
            return services;
        }

    }
    
}
