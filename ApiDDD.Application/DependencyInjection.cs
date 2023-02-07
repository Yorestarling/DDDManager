using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApiDDD.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDDD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
            return service;
        }

    }
}
