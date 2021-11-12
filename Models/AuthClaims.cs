using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorSimpleSurvey.Models
{
    public class AuthClaims
    {
        public string? DisplayName { get; set; }
        public string? Objectidentifier { get; set; }
        public string? AzureB2CFlow { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentityProvider { get; set; }
        public string? AuthenticationType { get; set; }
        public string? TenantId { get; set; }
        public string? auth_time { get; set; }
        public string? idp_access_token { get; set; }
    }
}
