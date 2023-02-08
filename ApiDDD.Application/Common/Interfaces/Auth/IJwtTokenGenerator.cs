using ApiDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
