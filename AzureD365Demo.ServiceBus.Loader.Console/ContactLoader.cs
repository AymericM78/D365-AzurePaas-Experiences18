using AzureD365Demo.ServiceBus.Loader.Console.Utils;
using AzureD365DemoWebJob;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AzureD365Demo.ServiceBus.Loader.Console
{
    internal class ContactLoader
    {
        const string QueueSas = "Endpoint=sb://azured365demo-asb.servicebus.windows.net/;SharedAccessKeyName=Default;SharedAccessKey=TO_BE_DEFINED;EntityPath=contact";
        private int contactsExpected;
        private Stopwatch stopWatch => new Stopwatch();
        public ContactLoader(int contactsExpected)
        {
            this.contactsExpected = contactsExpected;
        }

        public void Run()
        {
            var messages = GenerateRandomContactMessages();
            SendMessages(messages);
            PrintEndProcess();
        }

        private void PrintEndProcess()
        {

        }

        /// <summary>
        /// Load a collection of random messages
        /// </summary>
        /// <returns></returns>
        private List<BrokeredMessage> GenerateRandomContactMessages()
        {
            stopWatch.Start();
            var messages = new List<BrokeredMessage>();
            for (int i = 0; i < contactsExpected; i++)
            {
                var message = GenerateRandomContactMessage();
                messages.Add(message);
            }
            stopWatch.Stop();
            System.Console.WriteLine($"{messages.Count} contacts generated in {stopWatch.Elapsed.ToString("G")}");
            stopWatch.Reset();

            return messages;
        }

        private void SendMessages(IList<BrokeredMessage> messages)
        {
            stopWatch.Start();
            var client = QueueClient.CreateFromConnectionString(QueueSas);
            //var chunks = messages.ChunkBy(bm => bm.Size, MaxServiceBusMessages);
            //foreach (var chunk in chunks)
            //{
            //    client.SendBatch(chunk);
            //}

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 500
            };
            Parallel.ForEach(messages, options, (message) =>
            {
                client.Send(message);
            });

            stopWatch.Stop();
            System.Console.WriteLine($"{messages.Count} contacts sent in {stopWatch.Elapsed.ToString("G")}");

        }

        /// <summary>
        /// Generate a random contact message in json
        /// </summary>
        /// <returns></returns>
        private BrokeredMessage GenerateRandomContactMessage()
        {
            var year = DataRandomizer.GetRandomInt(1950, 2000);
            var month = DataRandomizer.GetRandomInt(1, 12);
            var day = DataRandomizer.GetRandomInt(1, 25);
            var birthDate = new DateTime(year, month, day);

            var contact = new Contact
            {
                birthdate = birthDate,
                contactid = Guid.NewGuid(),
                description = DataRandomizer.GetRandomString(5, 30),
                emailaddress1 = string.Concat(DataRandomizer.GetRandomString(5, 10), "@nonexistingdomain.disabled"),
                firstname = DataRandomizer.GetRandomString(5, 10),
                gendercode = DataRandomizer.GetRandomInt(1, 2).ToString(),
                jobtitle = DataRandomizer.GetRandomString(5, 20),
                lastname = DataRandomizer.GetRandomString(5, 10),
                mobilephone = DataRandomizer.GetRandomPhoneNumber(true),
                telephone1 = DataRandomizer.GetRandomPhoneNumber(),
                telephone2 = DataRandomizer.GetRandomPhoneNumber()
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                NullValueHandling = NullValueHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(contact, jsonSerializerSettings);

            return new BrokeredMessage(json)
            {
                ContentType = "application/json"
            };
        }
    }
}
