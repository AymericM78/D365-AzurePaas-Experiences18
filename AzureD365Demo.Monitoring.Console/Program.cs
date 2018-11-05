using System;
using System.ComponentModel;
using System.Threading;
using AzureD365DemoWebJob;
using AzureD365DemoWebJob.Utils;
using Microsoft.ServiceBus;
using Microsoft.Xrm.Sdk.Query;

namespace AzureD365Demo.Monitoring.Console
{
    class Program
    {
        static JobSettings JobSettings;
        private static int expectedCount = 0;
        private static int currentCount = 0;

        private const string ExitMessage = "Appuyez sur une touche pour arrêter la vérification avec le CRM.";
        private const string ProgressMessage = "Contacts restant dans le service bus";
        private const string CoreCountStoppedMessage = "Arrêt de la vérification au CRM !";
        private static CrmRecordCounter CrmRecordCounter;

        static void Main(string[] args)
        {
            PrintHeader();
            JobSettings = new JobSettings();
            CrmRecordCounter = new CrmRecordCounter(JobSettings);

            if (args.Length != 0)
            {
                var rawExpectedCount = args[0];
                expectedCount = int.Parse(rawExpectedCount);
            }

            System.Console.WriteLine(ExitMessage);
            var bg = InitializeBackgroundWorker();
            expectedCount = (int)MessagesCountInSB();
            currentCount = expectedCount;
            ConsoleHelper.Log($"Messages dans le service bus : {expectedCount}");
            ConsoleHelper.DrawTextProgressBar(ProgressMessage, 0, expectedCount);

            bg.RunWorkerAsync();
            System.Console.ReadKey(true);
            System.Console.WriteLine();
            bg.CancelAsync();

            ConsoleHelper.Log(CoreCountStoppedMessage, ConsoleHelper.LogStatus.Warning);
            System.Console.ReadKey();
        }

        private static long MessagesCountInSB()
        {
            var namespaceManager = NamespaceManager.CreateFromConnectionString(JobSettings.ServiceBusNamespaceKey);
            var queueDescription = namespaceManager.GetQueue("contact");
            long activeMessageCount = queueDescription.MessageCountDetails.ActiveMessageCount;
            return activeMessageCount;
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

        public static BackgroundWorker InitializeBackgroundWorker()
        {
            var bg = new BackgroundWorker();
            bg.DoWork += Bg_DoWork;
            bg.ProgressChanged += Bg_ProgressChanged;
            bg.WorkerReportsProgress = true;
            bg.WorkerSupportsCancellation = true;
            return bg;
        }

        //Fake : Need to remove it when the whole process will be ok 
        private static int Count;

        private static void CoreCount(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            currentCount = (int) MessagesCountInSB();
            worker.ReportProgress(currentCount);
        }

        private static int updateContactsFromCRM = 0;
        private static int ContactCount = 0;
        private static void Bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!((BackgroundWorker) sender).CancellationPending)
            {
                if (++updateContactsFromCRM % 12 == 0)
                {
                    ContactCount += CrmRecordCounter.Execute("contact");
                    var extraInfo =
                        $" (Info : {ContactCount} contacts enregistrés)";
                    ConsoleHelper.DrawTextProgressBar(ProgressMessage + $" {extraInfo}", currentCount, expectedCount);
                }
            }
        }

        private static void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            while (currentCount != 0)
            {
                currentCount = (int)MessagesCountInSB();
                CoreCount((BackgroundWorker)sender, e);
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }

        private static void PrintHeader()
        {
            System.Console.Clear();
            ConsoleHelper.Log("=========================================");
            ConsoleHelper.Log("Microsoft Experiences 2018");
            ConsoleHelper.Log("Session : Etendre les capacités de Dynamics 365 avec les Services PaaS dans Azure", ConsoleHelper.LogStatus.Verbose);
            ConsoleHelper.Log("=========================================");
        }

    }
}
