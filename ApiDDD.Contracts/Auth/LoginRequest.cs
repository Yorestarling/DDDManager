using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Contracts.Auth
{
    public record LoginRequest
    (
        string email,
        string password
    );
}
