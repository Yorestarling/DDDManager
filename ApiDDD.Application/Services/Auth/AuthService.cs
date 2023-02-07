using ApiDDD.Application.Common.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services.Auth
{
     
    public class AuthService : IAuthService
    {

        private readonly IJwtTokenGenerator _jtwTokenGenerator;

        public AuthService(IJwtTokenGenerator jtwTokenGenerator)
        {
            _jtwTokenGenerator = jtwTokenGenerator;
        }

        
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

            //Check if user already exists

            //Create user (generate uniqueId)

            //Create JWT Token
            Guid userId = Guid.NewGuid();
            var token = _jtwTokenGenerator.GenerateToken(userId,firstName, lastName);



            return new AuthResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                token);
        }
    }
}
