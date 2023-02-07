using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Contracts.Auth
{
    public record RegisterRequest
    (
        string firstName,
        string lastName,
        string email,
        string password
    );
}
