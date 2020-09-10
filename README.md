![Blazor Simple Survey Logo Large](BlazorSimpleSurveyLogo_Large.png)
## Live Example: 
#### [Blazor Simple Survey (https://blazorsimplesurvey.azurewebsites.net/)](https://blazorsimplesurvey.azurewebsites.net/)
## Set-Up:
### Azure B2C
* Follow the directions in: [Azure AD B2C Quickstart with Visual Studio & Blazor](https://medium.com/marcus-tee-anytime/azure-ad-b2c-quickstart-with-visual-studio-blazor-563efdff6fdd) to set-up a Azure AD B2C Tenant
* Copy the settings to the appsettings.json file 
* If using Azure Active Directory Multi-Tenant login - follow these steps: [B2C-Token-Includes-AzureAD-BearerToken](https://github.com/azure-ad-b2c/samples/tree/master/policies/B2C-Token-Includes-AzureAD-BearerToken)
* If using Google login follow these steps: [Set up sign-in with a Google account using custom policies in Azure Active Directory B2C](https://docs.microsoft.com/en-us/azure/active-directory-b2c/identity-provider-google-custom?tabs=app-reg-ga)

### Database Set-up
* Create Database and run scripts in !SQL directory	
* Edit *appsettings.json* to set the database connection