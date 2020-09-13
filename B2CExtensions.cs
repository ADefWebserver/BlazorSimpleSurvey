using BlazorSimpleSurvey.Models;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorSimpleSurvey
{
    internal class B2CExtensions
    {
        public async static Task<Task> OnTicketReceivedCallback(TicketReceivedContext context)
        {
            if (context.Principal.Identity is ClaimsIdentity identity)
            {
                // Set common values
                AuthClaims objAuthClaims = new AuthClaims();

                var colClaims = await context.Principal.Claims.ToDynamicListAsync();

                objAuthClaims.IdentityProvider = colClaims.FirstOrDefault(
                    c => c.Type == "http://schemas.microsoft.com/identity/claims/identityprovider")?.Value;

                objAuthClaims.NameIdentifier = colClaims.FirstOrDefault(
                    c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

                objAuthClaims.EmailAddress = colClaims.FirstOrDefault(
                    c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

                objAuthClaims.FirstName = colClaims.FirstOrDefault(
                    c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value;

                objAuthClaims.LastName = colClaims.FirstOrDefault(
                    c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value;

                objAuthClaims.AzureB2CFlow = colClaims.FirstOrDefault(
                    c => c.Type == "http://schemas.microsoft.com/claims/authnclassreference")?.Value;

                objAuthClaims.auth_time = colClaims.FirstOrDefault(
                    c => c.Type == "auth_time")?.Value;

                objAuthClaims.DisplayName = colClaims.FirstOrDefault(
                    c => c.Type == "name")?.Value;

                objAuthClaims.idp_access_token = colClaims.FirstOrDefault(
                    c => c.Type == "idp_access_token")?.Value;

                // Google login
                if (objAuthClaims.IdentityProvider.ToLower().Contains("google"))
                {
                    objAuthClaims.IdentityProvider = "Google";
                }

                // Microsoft account login
                if (objAuthClaims.IdentityProvider.ToLower().Contains("live"))
                {
                    objAuthClaims.IdentityProvider = "Microsoft";
                }

                // Twitter login
                if (objAuthClaims.IdentityProvider.ToLower().Contains("twitter"))
                {
                    objAuthClaims.IdentityProvider = "Twitter";
                }

                // Azure Active Directory login
                // But this will only work if Azure B2C Custom Policy is configured
                // to pass the idp_access_token
                // See \!AzureB2CConfig\TrustFrameworkExtensions.xml
                // for an example that does that
                if (objAuthClaims.idp_access_token != null)
                {
                    objAuthClaims.IdentityProvider = "Azure Active Directory";

                    try
                    {
                        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(objAuthClaims.idp_access_token);
                    }
                    catch (System.Exception)
                    {
                        // Could not decode - do nothing - Log it
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}