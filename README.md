![Blazor Simple Survey Logo Large](BlazorSimpleSurveyLogo_Large.png)
## Live Example: 
#### [Blazor Simple Survey (https://blazorsimplesurvey.azurewebsites.net/)](https://blazorsimplesurvey.azurewebsites.net/)

## Articles:

* [Blazor Multi-Tenant Azure B2C](https://blazorhelpwebsite.com/ViewBlogPost/42)
* [Blazor Azure B2C User And Group Management](https://blazorhelpwebsite.com/ViewBlogPost/43)

## Set-Up:

### Database Set-up
* Create a Database and run scripts in **!SQL** directory	
* Edit *appsettings.json* to set the database connection

### Azure B2C Setup
* Follow the directions in: [Azure AD B2C Quickstart with Visual Studio & Blazor](https://medium.com/marcus-tee-anytime/azure-ad-b2c-quickstart-with-visual-studio-blazor-563efdff6fdd) to set-up a Azure AD B2C Tenant
* Copy the settings to the appsettings.json file (AzureAdB2C section). 

### Azure B2C Management Configuration
Microsoft Graph allows you to manage many of the resources within your Azure AD B2C tenant. To configure this follow these directions:
* [Register a Microsoft Graph application](https://docs.microsoft.com/en-us/azure/active-directory-b2c/microsoft-graph-get-started?tabs=app-reg-ga)
* Ensure you add these permissions to the Azure Application you create:
  * AuditLog.Read.All
  * Directory.ReadWrite.All
  * Policy.ReadWrite.TrustFramework
  * User.Read
  * User.ReadWrite.All
* Copy the settings to the appsettings.json file (AzureAdB2CManagement section). 

### Azure B2C *Advanced Configuration* (optional)
If you desire to allow any Azure AD tenant to log in, you need to use Custom Policies. This application can also be configured to use Azure Active Directory B2C Custom Policy files. 

See an overview of this process here: [Blazor Multi-Tenant Azure B2C](https://blazorhelpwebsite.com/ViewBlogPost/42). To get started see [Get started with custom policies in Azure Active Directory B2C](https://docs.microsoft.com/en-us/azure/active-directory-b2c/custom-policy-get-started)

After you follow the directions, you will make a new policy in the Identity Experience Framework. 
You will create a **Relying Party (RP)** file like **B2C_1A_signup_signin**.
Update the **SignUpSignInPolicyId** property in the appsettings.json file with the name of this file to use it. 

You can get the sample Azure B2C Custom policy .xml files in the **!AzureB2CConfig** directory (you will need to update the custom values)
* If using **Azure Active Directory Multi-Tenant** login follow these steps: [B2C-Token-Includes-AzureAD-BearerToken](https://github.com/azure-ad-b2c/samples/tree/master/policies/B2C-Token-Includes-AzureAD-BearerToken)
* If using **Google** login follow these steps: [Set up sign-in with a Google account using custom policies in Azure Active Directory B2C](https://docs.microsoft.com/en-us/azure/active-directory-b2c/identity-provider-google-custom?tabs=app-reg-ga)
* If using **Twitter** login follow these steps: [Set up sign-in with a Twitter account using custom policies in Azure Active Directory B2C](https://docs.microsoft.com/en-us/azure/active-directory-b2c/identity-provider-twitter-custom?tabs=app-reg-ga)
* If using **Microsoft Accounts** for login follow these steps: [Set up sign-in with a Microsoft account using custom policies in Azure Active Directory B2C](https://docs.microsoft.com/en-us/azure/active-directory-b2c/identity-provider-microsoft-account-custom?tabs=app-reg-ga)

### Screen Shots

![Image 001](https://user-images.githubusercontent.com/1857799/93725999-4cb01480-fb68-11ea-93b8-7e33c6899048.png)
![Image 002](https://user-images.githubusercontent.com/1857799/93726000-4d48ab00-fb68-11ea-88ae-44e1cf4d5a98.png)
![Image 003](https://user-images.githubusercontent.com/1857799/93726001-4de14180-fb68-11ea-8bf2-e847fd44ffee.png)
