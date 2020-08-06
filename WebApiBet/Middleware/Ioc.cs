using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBet.Services;
using WebApiBet.Services.Contracts;

namespace WebApiBet.Middleware
{
    public static class Ioc
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRouletteServices, RouletteServices>();

            return services;
        }
    }
}
