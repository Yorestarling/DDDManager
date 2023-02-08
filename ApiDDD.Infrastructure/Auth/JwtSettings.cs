using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Infrastructure.Auth
{
    public class JwtSettings
    {
        public const string _SectionName = "JwtSettings";

        public string? Secret { get; init; }

        public int ExpirationTimeInMinutes { get; init; }
        public string? Issuer { get; init; }

        public string? Audience { get; init; }
    }
}
