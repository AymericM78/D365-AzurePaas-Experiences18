using AzureD365Demo.ServiceBus.Loader.Console.Utils;
using AzureD365DemoWebJob;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AzureD365DemoWebJob.Utils;

namespace AzureD365Demo.ServiceBus.Loader.Console
{
    internal class ContactLoader
    {
        private const string ContactCountSentMessage = "Contacts envoyés dans le service bus";
        // TODO : In app.config 
        private const string QueueSas = "Endpoint=sb://azured365demo-asb.servicebus.windows.net/;SharedAccessKeyName=Default;SharedAccessKey=TO_BE_DEFINED;EntityPath=contact";
        private int contactsExpected;

        private Stopwatch stopWatch;
        public ContactLoader(int contactsExpected)
        {
            this.contactsExpected = contactsExpected;
            ServicePointManager.DefaultConnectionLimit = 20;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            ThreadPool.SetMinThreads(10, 10);
        }

        public void Run()
        {
            stopWatch = new Stopwatch();
            var messages = GenerateRandomContactMessages();
            ConsoleHelper.DrawTextProgressBar(ContactCountSentMessage, 0, contactsExpected);
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
            System.Console.WriteLine($"{messages.Count} contacts générés en {stopWatch.Elapsed.TotalSeconds} secondes");
            stopWatch.Reset();

            return messages;
        }

        private static int CountContactsSent;
        private void SendMessages(IList<BrokeredMessage> brokeredMessages)
        {
            stopWatch.Reset();
            stopWatch.Start();
            var client = QueueClient.CreateFromConnectionString(QueueSas);
            var chunks = brokeredMessages.ChunkBy(bm => bm.Size, 2000);

            Parallel.ForEach(chunks, new ParallelOptions() { MaxDegreeOfParallelism = 100 }, (messages) =>
             {
                 client.SendBatch(messages);
                 Interlocked.Add(ref CountContactsSent, messages.Count);
                 messages.ForEach(e =>
                 {
                     e.Dispose();
                 });
                 DrawProgressBar();
             });

            stopWatch.Stop();

            System.Console.WriteLine();
            ConsoleHelper.Log($"{brokeredMessages.Count} contacts envoyés en {stopWatch.Elapsed.TotalSeconds} secondes", ConsoleHelper.LogStatus.Success);

        }

        private void DrawProgressBar(bool force = false)
        {
            lock (lockDrawingMessage)
                if (0 == CountContactsSent % 1000 || force)
                    ConsoleHelper.DrawTextProgressBar(ContactCountSentMessage, CountContactsSent,
                        contactsExpected);
        }

        private object lockDrawingMessage = new object();
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
