using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        public AuthResult Login(string email, string password)
        {
            return new AuthResult(
               Guid.NewGuid(),
               "firstName",
               "lastName",
               email,
               "token");
        }

        public AuthResult Register(string firstName, string lastName, string email, string password)
        {
            return new AuthResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                "token");
        }
    }
}
