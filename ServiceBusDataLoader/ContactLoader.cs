using AzureD365DemoWebJob;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusDataLoader
{
    internal class ContactLoader
    {
        const int ContactNumber = 50000;
        const long MaxServiceBusMessages = 256000;
        const string QueueSas = "Endpoint=sb://azured365demo-asb.servicebus.windows.net/;SharedAccessKeyName=Default;SharedAccessKey=TO_BE_DEFINED;EntityPath=contact";
        
        public ContactLoader()
        {

        }

        public void Run()
        {
            var keyvaultManager = new KeyVaultManager("https://azured365demo-kv.vault.azure.net/", "", "");

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var messages = GenerateRandomContactMessages();
            stopWatch.Stop();
            Console.WriteLine($"{messages.Count} contacts generated in {stopWatch.Elapsed.ToString("G")}");
            stopWatch.Reset();

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
            Console.WriteLine($"{messages.Count} contacts sent in {stopWatch.Elapsed.ToString("G")}");

            Console.ReadLine();

        }

        /// <summary>
        /// Load a collection of random messages
        /// </summary>
        /// <returns></returns>
        private List<BrokeredMessage> GenerateRandomContactMessages()
        {
            var messages = new List<BrokeredMessage>();
            for (int i = 0; i < ContactNumber; i++)
            {
                var message = GenerateRandomContactMessage();
                messages.Add(message);
            }
            return messages;
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
                telephone1 = DataRandomizer.GetRandomPhoneNumber(false),
                telephone2 = DataRandomizer.GetRandomPhoneNumber(false)
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
