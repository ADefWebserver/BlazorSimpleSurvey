using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSimpleSurvey.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Security.Claims;
using BlazorSimpleSurvey.Models;
using System.Linq.Dynamic.Core;

namespace BlazorSimpleSurvey
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SimpleSurveyContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(AzureADB2CDefaults.AuthenticationScheme)
                .AddAzureADB2C(options => Configuration.Bind("AzureAdB2C", options));
            // This is where you wire up to events to detect when a user logs in
            services.Configure<OpenIdConnectOptions>(AzureADB2CDefaults.OpenIdScheme, options =>
            {
                options.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProvider = async ctxt =>
                    {
                        // Invoked before redirecting to the identity provider to authenticate. 
                        // This can be used to set ProtocolMessage.State
                        // that will be persisted through the authentication process. 
                        // The ProtocolMessage can also be used to add or customize
                        // parameters sent to the identity provider.
                        await Task.Yield();
                    },
                    OnAuthenticationFailed = async ctxt =>
                    {
                        // They tried to log in but it failed
                        await Task.Yield();
                    },
                    OnTicketReceived = async ctxt =>
                    {
                        if (ctxt.Principal.Identity is ClaimsIdentity identity)
                        {
                            // Set common values
                            AuthClaims objAuthClaims = new AuthClaims();

                            var colClaims = await ctxt.Principal.Claims.ToDynamicListAsync();

                            objAuthClaims.IdentityProvider = colClaims.FirstOrDefault(
                                c => c.Type == "http://schemas.microsoft.com/identity/claims/identityprovider")?.Value;

                            objAuthClaims.Objectidentifier = colClaims.FirstOrDefault(
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

                            // Insert into Database
                            var optionsBuilder = new DbContextOptionsBuilder<SimpleSurveyContext>();
                            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                            SimpleSurveyContext simpleSurveyContext = new SimpleSurveyContext(optionsBuilder.Options);

                            var ExistingUser = simpleSurveyContext.Users
                            .Where(x => x.Objectidentifier == objAuthClaims.Objectidentifier)
                            .FirstOrDefault();
                        }

                        await Task.Yield();
                    },
                };
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, 
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
