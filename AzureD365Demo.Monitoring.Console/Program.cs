using System;
using System.ComponentModel;
using System.Threading;
using Microsoft.Xrm.Sdk.Query;

namespace AzureD365Demo.Monitoring.Console
{
    class Program
    {
        private static int expectedCount = 0;
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                var rawExpectedCount = args[0];
                expectedCount = int.Parse(rawExpectedCount);
            }
            
            System.Console.WriteLine("Press any button to exit");
            var bg = InitializeBackgroundWorker();
            DrawTextProgressBar("Contacts dans mon CRM", 0, expectedCount);
            bg.RunWorkerAsync();
            System.Console.ReadKey();
        }

        public static QueryExpression GetContacts()
        {
            return new QueryExpression("contact")
            {
                ColumnSet = new ColumnSet("contactid"),
                NoLock = true
            };
        }

        public static BackgroundWorker InitializeBackgroundWorker()
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += Bg_DoWork;
            bg.ProgressChanged += Bg_ProgressChanged;
            bg.WorkerReportsProgress = true;
            return bg;
        }

        //Fake
        private static int Count;

        private static void CoreCount(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            var count = RetrieveMultipleHelper.RetrieveMultipleAllPages(GetContacts());
            Count += count.Entities.Count;
            worker.ReportProgress(Count);
        }

        private static void Bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DrawTextProgressBar("Contacts dans mon CRM", e.ProgressPercentage, expectedCount);
        }

        private static void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                CoreCount((BackgroundWorker) sender, e);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        public static void DrawTextProgressBar(string stepDescription, int progress, int total)
        {
            int totalChunks = 30;

            //draw empty progress bar
            System.Console.CursorLeft = 0;
            System.Console.Write("["); //start
            System.Console.CursorLeft = totalChunks + 1;
            System.Console.Write("]"); //end
            System.Console.CursorLeft = 1;

            double pctComplete = Convert.ToDouble(progress) / total;
            int numChunksComplete = Convert.ToInt16(totalChunks * pctComplete);

            //draw completed chunks
            System.Console.BackgroundColor = ConsoleColor.Green;
            System.Console.Write("".PadRight(numChunksComplete));

            //draw incomplete chunks
            System.Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.Write("".PadRight(totalChunks - numChunksComplete));

            //draw totals
            System.Console.CursorLeft = totalChunks + 5;
            System.Console.BackgroundColor = ConsoleColor.Black;

            string output = progress.ToString() + " of " + total.ToString();
            System.Console.Write(output.PadRight(15) + stepDescription); //pad the output so when changing from 3 to 4 digits we avoid text shifting
        }
    }
}
