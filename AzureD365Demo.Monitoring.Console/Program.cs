using System;
using System.ComponentModel;
using System.Threading;
using AzureD365DemoWebJob.Utils;
using Microsoft.Xrm.Sdk.Query;

namespace AzureD365Demo.Monitoring.Console
{
    class Program
    {
        private static int expectedCount = 0;
        private const string ExitMessage = "Appuyez sur une touche pour arrêter la vérification avec le CRM.";
        private const string ProgressMessage = "Contacts dans mon CRM";
        private const string CoreCountStoppedMessage = "The process has been stopped by the user !";

        static void Main(string[] args)
        {
            PrintHeader();

            if (args.Length != 0)
            {
                var rawExpectedCount = args[0];
                expectedCount = int.Parse(rawExpectedCount);
            }

            System.Console.WriteLine(ExitMessage);
            var bg = InitializeBackgroundWorker();

            ConsoleHelper.DrawTextProgressBar(ProgressMessage, 0, expectedCount);
            bg.RunWorkerAsync();
            System.Console.ReadKey(true);
            System.Console.WriteLine();
            bg.CancelAsync();
            ConsoleHelper.Log(CoreCountStoppedMessage, ConsoleHelper.LogStatus.Warning);
            System.Console.ReadKey();
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
            var count = RetrieveMultipleHelper.RetrieveMultipleAllPages(GetContacts());
            Count += count.Entities.Count;
            worker.ReportProgress(Count);
        }

        private static void Bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!((BackgroundWorker)sender).CancellationPending)
                ConsoleHelper.DrawTextProgressBar(ProgressMessage, e.ProgressPercentage, expectedCount);
        }

        private static void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                CoreCount((BackgroundWorker)sender, e);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        private static void PrintHeader()
        {
            System.Console.Clear();
            ConsoleHelper.Log("=========================================");
            ConsoleHelper.Log("Microsoft MSExperiences 2018");
            ConsoleHelper.Log("Session : Etendre les capacités de Dynamics 365 avec les Services PaaS dans Azure", ConsoleHelper.LogStatus.Verbose);
            ConsoleHelper.Log("=========================================");
        }

    }
}
