using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApiDDD.Application.Common.Interfaces.Auth;
using ApiDDD.Application.Services.Auth;
using ApiDDD.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDDD.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
            return service;
        }

    }
}
