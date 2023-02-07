using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Application.Services.Auth
{
    public record AuthResult
    (
        Guid Id,
         string firstName,
         string lastName,
         string email,
         string token
    );
}
