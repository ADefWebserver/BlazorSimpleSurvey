using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class GraphUser
{
    public string[]? businessPhones { get; set; }
    public string? displayName { get; set; }
    public string? givenName { get; set; }
    public string? jobTitle { get; set; }
    public string? mail { get; set; }
    public string? mobilePhone { get; set; }
    public object? officeLocation { get; set; }
    public string? preferredLanguage { get; set; }
    public string? surname { get; set; }
    public string? userPrincipalName { get; set; }
    public string? id { get; set; }
}


public class GraphGroup
{
    public string? id { get; set; }
    public object? deletedDateTime { get; set; }
    public object? classification { get; set; }
    public DateTime createdDateTime { get; set; }
    public object[]? creationOptions { get; set; }
    public string? description { get; set; }
    public string? displayName { get; set; }
    public object? expirationDateTime { get; set; }
    public object[]? groupTypes { get; set; }
    public object? isAssignableToRole { get; set; }
    public object? mail { get; set; }
    public bool mailEnabled { get; set; }
    public string? mailNickname { get; set; }
    public object? membershipRule { get; set; }
    public object? membershipRuleProcessingState { get; set; }
    public object? onPremisesDomainName { get; set; }
    public object? onPremisesLastSyncDateTime { get; set; }
    public object? onPremisesNetBiosName { get; set; }
    public object? onPremisesSamAccountName { get; set; }
    public object? onPremisesSecurityIdentifier { get; set; }
    public object? onPremisesSyncEnabled { get; set; }
    public object? preferredDataLocation { get; set; }
    public object? preferredLanguage { get; set; }
    public object[]? proxyAddresses { get; set; }
    public DateTime renewedDateTime { get; set; }
    public object[]? resourceBehaviorOptions { get; set; }
    public object[]? resourceProvisioningOptions { get; set; }
    public bool securityEnabled { get; set; }
    public string? securityIdentifier { get; set; }
    public object? theme { get; set; }
    public object? visibility { get; set; }
    public object[]? onPremisesProvisioningErrors { get; set; }
}

