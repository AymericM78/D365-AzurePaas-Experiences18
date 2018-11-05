using Microsoft.Pfe.Xrm;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace AzureD365DemoWebJob
{
    public class CrmRecordCounter
    {
        private DateTime LastCountDateTime = new DateTime(2018, 01, 01);
        private OrganizationServiceManager OrganizationServiceManager;
        private JobSettings JobSettings;

        public CrmRecordCounter(JobSettings jobSettings)
        {
            this.JobSettings = jobSettings;
            InitializeOrganizationServiceManager();
        }

        private void InitializeOrganizationServiceManager()
        {
            // If you're using an old version of .NET this will enable TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var serverUri = XrmServiceUriFactory.CreateOnlineOrganizationServiceUri(JobSettings.CrmOrganizationName, CrmOnlineRegion.EMEA);
            OrganizationServiceManager = new OrganizationServiceManager(serverUri, JobSettings.CrmUserName, JobSettings.CrmUserPassword);

            // Change max connections from .NET to a remote service default: 2
            // Webapp targeted is Basic (Large) 
            // Socket available is 256 for 1 app
            // We have 3 interfaces : (256 / 3) => 85 sockets per interface 
            // 
            // Resource : https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#per-sandbox-per-appper-site-numerical-limits
            ServicePointManager.DefaultConnectionLimit = 85;

            // Bump up the min threads reserved for this app to ramp connections faster - minWorkerThreads defaults to 4, minIOCP defaults to 4 
            ThreadPool.SetMinThreads(10, 10);

            // Turn off the Expect 100 to continue message - 'true' will cause the caller to wait until it round-trip confirms a connection to the server 
            ServicePointManager.Expect100Continue = false;

            // More info on Nagle at WikiPedia - can help perf (helps w/ conn reliability)
            ServicePointManager.UseNagleAlgorithm = false;

            //a new twist to existing connections
            var knownServicePointConnection = ServicePointManager.FindServicePoint(OrganizationServiceManager.ServiceUri);
            if (knownServicePointConnection != null)
            {
                knownServicePointConnection.ConnectionLimit = ServicePointManager.DefaultConnectionLimit;
                knownServicePointConnection.Expect100Continue = ServicePointManager.Expect100Continue;
                knownServicePointConnection.UseNagleAlgorithm = ServicePointManager.UseNagleAlgorithm;
            }
        }

        public int Execute(string entityName)
        {
            var query = new QueryExpression("contact")
            {
                ColumnSet = new ColumnSet("contactid"),
                NoLock = true
            };
            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, LastCountDateTime);
            var queries = new Dictionary<string, QueryBase>();
            queries.Add("contact", query);

            var results = this.OrganizationServiceManager.ParallelProxy.RetrieveMultiple(queries, true);
            var contactCount = results.First().Value.Entities.Count;

            LastCountDateTime = DateTime.Now;

            return contactCount;
        }


    }
}
