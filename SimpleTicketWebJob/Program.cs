using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.WebJobs;
using Microsoft.Pfe.Xrm;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;

namespace SimpleTicketWebJob
{
    class TicketData
    {
        public string sender { get; set; }
        public double score { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
    }

    class Program
    {
        static void Main()
        {
            #region Webjob stuffs
            var config = new JobHostConfiguration();
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            var host = new JobHost(config);
            #endregion Webjob stuffs

            // Initialize connection to Service Bus queue
            var queueClient = QueueClient.CreateFromConnectionString("Endpoint=sb://azured365demo-asb.servicebus.windows.net/;SharedAccessKeyName=Flow;SharedAccessKey=TO_BE_DEFINED;EntityPath=tickets", ReceiveMode.PeekLock);

            // Listen for incoming messages
            queueClient.OnMessage((BrokeredMessage message) =>
            {
                // Initialize Application Insight client
                var telemetryClient = new TelemetryClient();
                var contextProperties = new Dictionary<string, string>();
                TelemetryConfiguration.Active.InstrumentationKey = "cbc998b9-bd03-4847-9ea8-3909f5e49243";

                // Initialize connection to D365
                var serverUri = XrmServiceUriFactory.CreateOnlineOrganizationServiceUri("msexperience18", CrmOnlineRegion.EMEA);
                var organizationServiceManager = new OrganizationServiceManager(serverUri, "TO_BE_DEFINED", "TO_BE_DEFINED");
                using (var proxy = organizationServiceManager.GetProxy())
                {
                    try
                    {
                        // Retrieve message content (Stream)
                        var messageContent = string.Empty; // = message.GetBody<string>();
                        using (Stream stream = message.GetBody<Stream>())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                messageContent = reader.ReadToEnd();
                            }
                        }
                    
                        // Track message reception in Application Insight
                        contextProperties.Add("Message.Id", message.MessageId);
                        contextProperties.Add("Message.Content", messageContent);
                        telemetryClient.TrackEvent("Message received", contextProperties);

                        // Convert json message to object
                        var jsonSerializerSettings = new JsonSerializerSettings
                        {
                            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
                        };
                        var ticketData = JsonConvert.DeserializeObject<TicketData>(messageContent, jsonSerializerSettings);

                        // Create contact from email sender (ticket creation is not possible without a customer)
                        var crmContact = new Entity("contact");
                        crmContact["emailaddress1"] = ticketData.sender;
                        crmContact["firstname"] = ticketData.sender.Remove(ticketData.sender.IndexOf("@"));
                        crmContact.Id = proxy.Create(crmContact);

                        // Track contact creation in Application Insight
                        contextProperties.Add("Contact.Id", crmContact.Id.ToString());
                        contextProperties.Add("Contact.Email", ticketData.sender);
                        telemetryClient.TrackEvent("Contact created", contextProperties);

                        // Create an incident
                        var crmIncident = new Entity("incident");
                        crmIncident["sentimentvalue"] = ticketData.score;
                        crmIncident["title"] = $"Email sensible : {ticketData.subject} de {ticketData.sender}";
                        crmIncident["description"] = $"Contenu du message : {ticketData.body}";
                        crmIncident["customerid"] = crmContact.ToEntityReference();
                        crmIncident.Id = proxy.Create(crmIncident);

                        // Track incident creation in Application Insight
                        contextProperties.Add("Incident.Id", crmIncident.Id.ToString());
                        contextProperties.Add("Incident.Title", crmIncident["title"].ToString());
                        contextProperties.Add("Incident.Description", crmIncident["description"].ToString());
                        contextProperties.Add("Incident.SentimentValue", crmIncident["sentimentvalue"].ToString());
                        telemetryClient.TrackEvent("Ticket created", contextProperties);

                        // Mark the service bus message as processed
                        message.Complete();
                    }
                    catch (Exception exception)
                    {
                        telemetryClient.TrackException(exception, contextProperties);
                    }
                }
            });
            host.RunAndBlock();
        }
    }
}
