using ApiDDD.Application.Common.Interfaces.Auth;
using ApiDDD.Application.Common.Interfaces.Persistences;
using ApiDDD.Domain.Entities;
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
        private readonly IUserRepository _userRepository;


        public AuthService(IJwtTokenGenerator jtwTokenGenerator, IUserRepository userRepository)
        {
            _jtwTokenGenerator = jtwTokenGenerator;
            _userRepository = userRepository;
        }


        public AuthResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            var token = _jtwTokenGenerator.GenerateToken(
                user
                );

            return new AuthResult(
              user,
               token);
        }

        public AuthResult Register(string firstName, string lastName, string email, string password)
        {

            //Check if user already exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists");
            }

            //Create user (generate uniqueId) to DB
            var user = new User 
            { 
                FirstName = firstName,
                LastName= lastName, 
                Email= email, 
                Password = password 
            };

            _userRepository.Add(user);

            //Create JWT Token
            var token = _jtwTokenGenerator.GenerateToken(user);

            return new AuthResult(
                user,
                token);
        }
    }
}
