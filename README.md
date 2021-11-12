![Blazor Simple Survey Logo Large](https://user-images.githubusercontent.com/1857799/141389995-aabd3af0-a083-4c17-836b-a45c81925469.png)
## Live Example: 
#### [Blazor Simple Survey (https://blazorsimplesurvey.azurewebsites.net/)](https://blazorsimplesurvey.azurewebsites.net/)
![Animation](https://user-images.githubusercontent.com/1857799/95696373-ac419300-0bef-11eb-945d-85ba107e50e6.gif)
## Articles:

* [Blazor Simple Survey: Creating Dynamic Surveys](https://blazorhelpwebsite.com/ViewBlogPost/44)
* [Blazor and Azure B2C: The Big Picture](https://blazorhelpwebsite.com/ViewBlogPost/42)
* [Blazor Azure B2C User And Group Management](https://blazorhelpwebsite.com/ViewBlogPost/43)

## Features

* Unlimited Surveys
* Unlimited Survey Questions
* Survey responses in pie charts 
* Survey Question Types
  * Text Box
  * Text Area
  * Date
  * Date Time
  * Dropdown
  * Multi-Select Dropdown
* Azure B2C Integration
* View Azure B2C Authorization Claims
* Administration
  * User Management
  * Search and edit users in Azure B2C Tenant
  * Custom designate Azure B2C group as Administration Group 
* Activity Logs


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

![ScreenShot-001](https://user-images.githubusercontent.com/1857799/95694318-50bed780-0be6-11eb-9ed1-97bc5b1945b6.png)
![ScreenShot-002](https://user-images.githubusercontent.com/1857799/95694320-51576e00-0be6-11eb-89fb-6568eeb4a8d3.png)
![ScreenShot-003](https://user-images.githubusercontent.com/1857799/95694322-51576e00-0be6-11eb-9b49-9c863fd24548.png)
![ScreenShot-004](https://user-images.githubusercontent.com/1857799/95694314-50264100-0be6-11eb-90ae-83470d69f803.png)
![ScreenShot-005](https://user-images.githubusercontent.com/1857799/95694316-50bed780-0be6-11eb-8366-cb7811b2057b.png)
![ScreenShot-006](https://user-images.githubusercontent.com/1857799/95694317-50bed780-0be6-11eb-9ed8-f2dd4a62b58a.png)
