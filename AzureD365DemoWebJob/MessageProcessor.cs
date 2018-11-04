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
        
        /// <summary>
        /// Process messages in queue and push them into D365
        /// </summary>
        public void Run()
        {
            base.OutPutSettings();
            while (true)
            {
                var messages = GetMessages();
                var requests = TransformMessagesToRequests(messages).ToList();
                SendRequests(requests);

                Thread.Sleep(1 * 1000);
            }
        }

        /// <summary>
        /// Retrieve messages from queue
        /// </summary>
        /// <returns></returns>
        private IEnumerable<BrokeredMessage> GetMessages()
        {
            var messages = ContactQueueClient.ReceiveBatch(MessageMax, TimeSpan.FromSeconds(5)).ToList();
            if (messages.Count > 0) 
            {
                ContactQueueClient.CompleteBatch(messages.Select(m => m.LockToken));
            }
            return messages;
        }

        /// <summary>
        /// Convert queue messages to D365 entity create request
        /// </summary>
        private IEnumerable<OrganizationRequest> TransformMessagesToRequests(IEnumerable<BrokeredMessage> messages)
        {
            var requests = new ConcurrentBag<OrganizationRequest>();
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = JobSettings.ThreadNumber
            };

            Parallel.ForEach(messages, options, (message) =>
            {
                var messageContent = message.GetBody<string>();
                var contact = JsonHelper.ConvertTo<Contact>(messageContent);
                var crmContact = TransformToEntity(contact);
                var request = new CreateRequest
                {
                    Target = crmContact
                };
                requests.Add(request);

            });
            return requests;
        }

        /// <summary>
        /// Send SDK request to D365 endpoint
        /// </summary>
        private void SendRequests(List<OrganizationRequest> requests)
        {
            //Parallel.ForEach(
            //        requests, // these are your items to process - should be many many thousands in here 
            //        new ParallelOptions()
            //        {
            //            MaxDegreeOfParallelism = JobSettings.ThreadNumber
            //        },
            //        () =>
            //        {
            //            // partition initialize // localInit - called once per Task.
            //            // get the proxy to use in the thread parition - this creates ONE proxy "per thread"
            //            // that proxy is then re-used inside of that ONE thread 
            //            var threadLocalProxy = OrganizationServiceManager.GetProxy();

            //            // you can log thread parition being opened/created 
            //            // HOWEVER use appinsights or something like ent lib for threadsafety
            //            // do not log to text otherwise it *will* slow you down a lot 

            //            // return the context so the thread Body can use the context 
            //            return new
            //            {
            //                threadLocalProxy
            //            };
            //        },
            //        (item, loopState, context) =>
            //        {
            //            // partition body - put the 'guts' of your operation in here 
            //            // ensure this method is one-off and all it's own 'thing' and doesn't share resources 
            //            try
            //            {
            //                var response = context.threadLocalProxy.Execute(item);
            //                // TODO : transform response into app insight metrics
            //                LogEvent(response.ResponseName, null, this.JobName);
            //            }
            //            catch (Exception ex)
            //            {
            //                LogException(ex, new Dictionary<string, string>(), this.JobName);
            //            }

            //            // any and all current or downstream logging *must* be threadsafe and multi-thread optimized 
            //            // use appinsights or ent lib to log so that it doesn't block any other threads 
            //            // if you hit thread contention in logging it will slow down your execution greatly 

            //            // return the context to be re-used or to be 'closed' 
            //            return context;
            //        },
            //        (context) =>
            //        {
            //            // final method per parition / task
            //            // this is only called when the thread partition is being shut down / closed / completed
            //            context.threadLocalProxy.Dispose();
            //        });

            var requestsGroups = requests.ChunkBy(requests.Count / 4);

            Parallel.ForEach(requestsGroups, new ParallelOptions(){ MaxDegreeOfParallelism = 10}, (requestsGroup) =>
            {
                var responses = OrganizationServiceManager.ParallelProxy
                    .Execute<OrganizationRequest, OrganizationResponse>
                    (
                        requestsGroup,
                        (request, ex) => { LogException(ex, new Dictionary<string, string>(), this.JobName); }
                    );
                foreach (var response in responses)
                {
                    LogEvent(response.ResponseName, null, this.JobName);
                }
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
                crmRecord[CrmContact.Fields.ContactId] = contactJson.contactid;
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
