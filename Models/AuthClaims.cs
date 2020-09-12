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
        public string UserName { get; set; }
        public string nameidentifier { get; set; }
        public string authnclassreference { get; set; }
        public string emailaddress { get; set; }
        public string givenname { get; set; }
        public string surname { get; set; }
        public string identityprovider { get; set; }
        public string tenantid { get; set; }
        public string auth_time { get; set; }
        public string idp_access_token { get; set; }
    }
}
