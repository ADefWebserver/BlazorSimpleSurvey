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
    }
}
