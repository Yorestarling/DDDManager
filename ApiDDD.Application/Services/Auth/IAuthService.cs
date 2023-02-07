using ApiDDD.Contracts.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services.Auth
{
    public interface IAuthService
    {
        AuthResult Login(string email, string password);
        AuthResult Register(string firstName,string lastName,string email, string password);
    }
}
