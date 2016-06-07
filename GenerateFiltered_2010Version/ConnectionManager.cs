using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk.Client;

namespace GenerateFiltered_2010Version
{
    public class ConnectionManager
    {
        internal static IOrganizationService GetOrganizationProxy(string serverBaseUrl, string domain, string user, string password)
        {
            IServiceConfiguration<IOrganizationService> orgServiceConfiguration =
                ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(
                new Uri(String.Format("{0}/XRMServices/2011/Organization.svc", serverBaseUrl))
                );
            ClientCredentials credentials = new ClientCredentials();
            credentials.Windows.ClientCredential = new System.Net.NetworkCredential(user, password, domain);
            IOrganizationService organizationServiceProxy = new OrganizationServiceProxy(orgServiceConfiguration, credentials);
            return organizationServiceProxy;
        }

        internal static IOrganizationService GetOrganizationProxy(string serverBaseUrl)
        {
            IServiceConfiguration<IOrganizationService> orgServiceConfiguration =
                ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(
                new Uri(String.Format("{0}/XRMServices/2011/Organization.svc", serverBaseUrl))
                );
            ClientCredentials credentials = new ClientCredentials();
            credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
            OrganizationServiceProxy organizationServiceProxy = new OrganizationServiceProxy(orgServiceConfiguration, credentials);
            organizationServiceProxy.EnableProxyTypes();
            organizationServiceProxy.Timeout = new TimeSpan(0, 5, 0);
            return organizationServiceProxy;
        }
    }
}
