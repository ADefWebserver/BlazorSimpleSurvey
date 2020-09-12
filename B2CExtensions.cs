using Microsoft.AspNetCore.Authentication;
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
                var colClaims = await context.Principal.Claims.ToDynamicListAsync();

                var identityprovider = colClaims.FirstOrDefault(
                    c => c.Type == "http://schemas.microsoft.com/identity/claims/identityprovider")?.Value;

                var idp_access_token = colClaims.FirstOrDefault(
                    c => c.Type == "idp_access_token")?.Value;

                // Google login
                if (identityprovider.ToLower().Contains("google"))
                {

                }

                // Microsoft account login
                if (identityprovider.ToLower().Contains("live"))
                {

                }

                // Twitter login
                if (identityprovider.ToLower().Contains("twitter"))
                {

                }

                // Azure Active Directory login
                // But this will only work if Azure B2C Custom Policy is configured
                // to pass the idp_access_token
                // See \!AzureB2CConfig\TrustFrameworkExtensions.xml
                // for an example that does that
                if (idp_access_token != null)
                {

                }
            }

            return Task.CompletedTask;
        }
    }
}