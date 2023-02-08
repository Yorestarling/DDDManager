using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApiDDD.Application.Common.Interfaces.Auth;
using ApiDDD.Application.Common.Interfaces.Persistences;
using ApiDDD.Application.Common.Interfaces.Services;
using ApiDDD.Application.Services.Auth;
using ApiDDD.Infrastructure.Auth;
using ApiDDD.Infrastructure.Persistences;
using ApiDDD.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDDD.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection service, 
            ConfigurationManager configuration)
        {
            service.Configure<JwtSettings>(configuration.GetSection(JwtSettings._SectionName));
            
            service.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
            service.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            service.AddScoped<IUserRepository, UserRepository>();
            return service;
        }

    }
}
