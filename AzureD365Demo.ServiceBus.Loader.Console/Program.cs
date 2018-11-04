﻿using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AzureD365DemoWebJob.Utils;
using Microsoft.Xrm.Sdk.Query;

namespace AzureD365Demo.ServiceBus.Loader.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            // Pre-check -> Contacts in my CRM 
            ConsoleHelper.Log("Nombre de contact dans mon CRM", withoutReturn: true);
            var previousCount = RetrieveMultipleHelper.RetrieveMultipleAllPages(GetContacts());
            System.Console.Write(previousCount.Entities.Count);

            var countContacts = AskForHowManyContacts();
            new ContactLoader(countContacts).Run();
            ConsoleHelper.Log("Contacts chargés. Appuyez sur une touche pour quitter.", ConsoleHelper.LogStatus.Success);
            System.Console.ReadKey();
        }

        private static void PrintHeader()
        {
            System.Console.Clear();
            ConsoleHelper.Log("=========================================");
            ConsoleHelper.Log("Microsoft MSExperiences 2018");
            ConsoleHelper.Log("Session : Etendre les capacités de Dynamics 365 avec les Services PaaS dans Azure", ConsoleHelper.LogStatus.Verbose);
            ConsoleHelper.Log("=========================================");
        }

        private static int AskForHowManyContacts()
        {
            ConsoleHelper.Log("Combien de contact souhaitez-vous charger ? ", withoutReturn: true, status: ConsoleHelper.LogStatus.Information);
            var line = System.Console.ReadLine();
            var entry = int.Parse(line);
            return entry;
        }

        public static QueryExpression GetContacts()
        {
            // Need to use Count in Fetch xml ? 
            return new QueryExpression("contact")
            {
                ColumnSet = new ColumnSet("contactid"),
                NoLock = true
            };
        }
    }
}