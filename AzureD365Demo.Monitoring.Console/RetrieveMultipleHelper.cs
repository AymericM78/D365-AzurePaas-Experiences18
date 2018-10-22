using System.Configuration;
using System.Net;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace AzureD365Demo.Monitoring.Console
{
    
    public static class RetrieveMultipleHelper
    {
        private static IOrganizationService GetProxy()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new CrmServiceClient(ConfigurationManager.ConnectionStrings["Xrm"].ConnectionString);
            return client.OrganizationServiceProxy;
        }

        public static EntityCollection RetrieveMultipleAllPages(QueryExpression pagequery)
        {
            // Query using the paging cookie.
            // Define the paging attributes.
            // The number of records per page to retrieve.
            int queryCount = 5000;

            // Initialize the page number.
            int pageNumber = 1;

            // Create the query expression and add condition.
            // Assign the pageinfo properties to the query expression.
            pagequery.PageInfo = new PagingInfo {Count = queryCount, PageNumber = pageNumber, PagingCookie = null};

            // The current paging cookie. When retrieving the first page, 
            // pagingCookie should be null.
            //Retrieving records in pages...
            EntityCollection results = new EntityCollection();

            IOrganizationService crmService = GetProxy();
            while (true)
            {
                // Retrieve the page.                   
                var result = crmService.RetrieveMultiple(pagequery);
                results.Entities.AddRange(result.Entities);


                // Check for more records, if it returns true.
                if (result.MoreRecords)
                {
                    // Increment the page number to retrieve the next page.
                    pagequery.PageInfo.PageNumber++;

                    // Set the paging cookie to the paging cookie returned from current results.
                    pagequery.PageInfo.PagingCookie = result.PagingCookie;

                }
                else
                {
                    // If no more records are in the result nodes, exit the loop.
                    break;
                }
            }
            return results;
        }
    }
}
