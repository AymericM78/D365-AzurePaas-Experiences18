using Microsoft.Pfe.Xrm;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AzureD365DemoWebJob
{
    public class MessageProcessor : MessageProcessorBase
    {
        ConcurrentBag<MessageEntityData> MessagesEntityData = new ConcurrentBag<MessageEntityData>();

        /// <summary>
        /// Process messages in queue and push them into D365
        /// </summary>
        public void Run()
        {
            base.OutPutSettings();
            while (true)
            {
                var messages = GetMessages();
                if (messages.Count() == 0)
                {
                    break;
                }
                var requests = TransformMessagesToRequests(messages).ToList();
                SendRequests(requests);

                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// Retrieve messages from queue
        /// </summary>
        /// <returns></returns>
        private IEnumerable<BrokeredMessage> GetMessages()
        {
            // Retrieve multiple messages from queue (500 or less)
            var messages = ContactQueueClient.ReceiveBatch(MessageMax, TimeSpan.FromSeconds(5)).ToList();
            return messages;
        }

        /// <summary>
        /// Convert queue messages to D365 entity create request
        /// </summary>
        private IEnumerable<OrganizationRequest> TransformMessagesToRequests(IEnumerable<BrokeredMessage> messages)
        {
            var requests = new ConcurrentBag<OrganizationRequest>();

            Parallel.ForEach(messages, new ParallelOptions() { MaxDegreeOfParallelism = JobSettings.ThreadNumber }, (message) =>
            {
                // Retrieve message string content
                var messageContent = message.GetBody<string>();

                // Convert json to contact object (custom class)
                var contact = JsonHelper.ConvertTo<Contact>(messageContent);

                // Transform custom object to CRM Entity
                var crmContact = TransformToEntity(contact);

                // Load CRM entity record to a CRM create request
                var requestId = Guid.NewGuid();
                var request = new CreateRequest
                {
                    Target = crmContact,
                    RequestId = requestId
                };
                requests.Add(request);

                // Add information to cache for Application Insights tracking
                var messageEntityData = new MessageEntityData
                {
                    MessageId = message.MessageId,
                    RecordId = crmContact.Id,
                    RequestId = requestId
                };
                messageEntityData.Properties.Add("Message.Id", message.MessageId);
                messageEntityData.Properties.Add("Record.Id", crmContact.Id.ToString());
                messageEntityData.Properties.Add("Request.Id", requestId.ToString());
                messageEntityData.Properties.Add("Message.Content", messageContent);
                MessagesEntityData.Add(messageEntityData);

            });
            return requests;
        }

        /// <summary>
        /// Send SDK request to D365 endpoint
        /// </summary>
        private void SendRequests(List<OrganizationRequest> requests)
        {
            // HOW TO : PFE Xrm Core
            // ===================
            // https://github.com/seanmcne/XrmCoreLibrary/blob/master/Samples/Microsoft.Pfe.Xrm.Core.Samples/ParallelExecuteSamples.cs
            // https://github.com/seanmcne/XrmCoreLibrary/blob/master/Documentation/ParallelProxy-Property.md

            // Use PFE Xrm Core Parallel Proxy to process CRM request collection 
            var responses = OrganizationServiceManager.ParallelProxy.Execute<OrganizationRequest, OrganizationResponse>
            (
                requests,
                (request, ex) =>
                {
                    // Report failures to Application Insights
                    var messageEntityData = MessagesEntityData.Where(m => m.RequestId == request.RequestId.Value).FirstOrDefault();
                    LogException(ex, messageEntityData.Properties, this.JobName);
                }
            );

            // Track response to Application Insights
            Parallel.ForEach(responses, new ParallelOptions() { MaxDegreeOfParallelism = JobSettings.ThreadNumber }, (response) =>
            {
                var recordId = (Guid) response.Results["id"];
                var messageEntityData = MessagesEntityData.Where(m => m.RecordId == recordId).FirstOrDefault();
                LogEvent("Contact created successfully!", messageEntityData.Properties, this.JobName);
            });
        }

        /// <summary>
        /// Transforms Contact object to Contact Crm entity.
        /// </summary>
        /// <param name="contactJson">The Contact object.</param>
        /// <returns>Contact entity.</returns>
        public static Entity TransformToEntity(Contact contactJson)
        {
            Entity crmRecord = new Entity("contact");

            if (contactJson.birthdate.HasValue)
            {
                crmRecord[CrmContact.Fields.BirthDate] = contactJson.birthdate.Value;
            }

            if (contactJson.contactid.HasValue)
            {
                crmRecord[CrmContact.Fields.ContactId] = contactJson.contactid.Value;
                crmRecord.Id = contactJson.contactid.Value;
            }

            if (contactJson.description.IsJsonPropertyDefined())
            {
                crmRecord[CrmContact.Fields.Description] = contactJson.description;
            }

            if (contactJson.emailaddress1.IsJsonPropertyDefined())
            {
                crmRecord[CrmContact.Fields.EMailAddress1] = contactJson.emailaddress1;
            }

            if (contactJson.firstname.IsJsonPropertyDefined())
            {
                crmRecord[CrmContact.Fields.FirstName] = contactJson.firstname;
            }

            if (contactJson.jobtitle.IsJsonPropertyDefined())
            {
                crmRecord[CrmContact.Fields.JobTitle] = contactJson.jobtitle;
            }

            if (contactJson.lastname.IsJsonPropertyDefined())
            {
                crmRecord[CrmContact.Fields.LastName] = contactJson.lastname;
            }

            if (contactJson.mobilephone.IsJsonPropertyDefined())
            {
                crmRecord[CrmContact.Fields.MobilePhone] = contactJson.mobilephone;
            }

            if (contactJson.telephone1.IsJsonPropertyDefined())
            {
                crmRecord[CrmContact.Fields.Telephone1] = contactJson.telephone1;
            }

            if (contactJson.telephone2.IsJsonPropertyDefined())
            {
                crmRecord[CrmContact.Fields.Telephone2] = contactJson.telephone2;
            }

            return crmRecord;
        }
    }
}
