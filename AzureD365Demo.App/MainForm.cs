using AzureD365Demo.ServiceBus.Loader.Console.Utils;
using AzureD365DemoWebJob;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureD365Demo.App
{
    public partial class MainForm : Form
    {
        JobSettings JobSettings;
        CrmRecordCounter CrmRecordCounter;
        private Stopwatch StopWatch = new Stopwatch();
        int PreviousMessageCount = 0;

        public MainForm()
        {
            InitializeComponent();
            ServicePointManager.DefaultConnectionLimit = 20;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            ThreadPool.SetMinThreads(10, 10);
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            JobSettings = new JobSettings();
            CrmRecordCounter = new CrmRecordCounter(JobSettings);

            bgWorkerCrmCounter.RunWorkerAsync();
            bgWorkerServiceBus.RunWorkerAsync();
        }

        #region Load Contacts

        /// <summary>
        /// Load Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            Log($"Chargement de {txtContactToLoad.Text} contacts ...");
            
            bgWorkerLoad.RunWorkerAsync();
        }

        /// <summary>
        /// Load DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            var messages = GenerateRandomContactMessages();
            SendMessages(messages);
        }

        /// <summary>
        /// Push messages to Service Bus queue
        /// </summary>
        /// <param name="brokeredMessages"></param>
        private void SendMessages(IList<BrokeredMessage> brokeredMessages)
        {
            StopWatch.Reset();
            StopWatch.Start();
            var client = QueueClient.CreateFromConnectionString(JobSettings.ServiceBusQueueKey);
            var chunks = brokeredMessages.ChunkBy(bm => bm.Size, 2000);

            Parallel.ForEach(chunks, new ParallelOptions() { MaxDegreeOfParallelism = 100 }, (messages) =>
            {
                client.SendBatch(messages);
                messages.ForEach(e =>
                {
                    e.Dispose();
                });
            });

            StopWatch.Stop();
        }

        /// <summary>
        /// Load a collection of random messages
        /// </summary>
        /// <returns></returns>
        private List<BrokeredMessage> GenerateRandomContactMessages()
        {
            StopWatch.Start();
            var messages = new List<BrokeredMessage>();
            int contactToLoad = int.Parse(txtContactToLoad.Text);
            for (int i = 0; i < contactToLoad; i++)
            {
                var message = GenerateRandomContactMessage();
                messages.Add(message);
            }
            StopWatch.Stop();
            StopWatch.Reset();

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

            TextInfo textInfo = new CultureInfo("fr-FR", false).TextInfo;


            var contact = new Contact
            {
                birthdate = birthDate,
                contactid = Guid.NewGuid(),
                description = DataRandomizer.GetRandomString(5, 30),
                emailaddress1 = string.Concat(DataRandomizer.GetRandomString(5, 10), "@nonexistingdomain.disabled"),
                firstname = textInfo.ToTitleCase(DataRandomizer.GetRandomString(5, 10)),
                gendercode = DataRandomizer.GetRandomInt(1, 2).ToString(),
                jobtitle = DataRandomizer.GetRandomString(5, 20),
                lastname = textInfo.ToTitleCase(DataRandomizer.GetRandomString(5, 10)),
                mobilephone = DataRandomizer.GetRandomPhoneNumber(true),
                telephone1 = DataRandomizer.GetRandomPhoneNumber(),
                telephone2 = DataRandomizer.GetRandomPhoneNumber()
            };

            var errorRatio = DataRandomizer.GetRandomInt(1, 20);
            if(errorRatio == 1)
            {
                contact.jobtitle = DataRandomizer.GetRandomString(110, 120);
            }
            if (errorRatio == 7)
            {
                contact.birthdate = DateTime.MinValue;
            }

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

        /// <summary>
        /// Load Progress Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            if (worker.CancellationPending)
            {
                return;
            }
        }

        /// <summary>
        /// Load completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Log($"Chargement de {txtContactToLoad.Text} contacts terminé !");
        }

        #endregion Load Contacts

        #region Service Bus

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerServiceBus_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            var namespaceManager = NamespaceManager.CreateFromConnectionString(JobSettings.ServiceBusNamespaceKey);
            var queueDescription = namespaceManager.GetQueue("contact");
            int activeMessageCount = (int) queueDescription.MessageCountDetails.ActiveMessageCount;



            worker.ReportProgress(activeMessageCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerServiceBus_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            float activeMessageCount = (float) e.ProgressPercentage;

            if(string.IsNullOrEmpty(txtContactToLoad.Text))
            {
                return;
            }
            float expectedContactMessages = float.Parse(txtContactToLoad.Text);
            float progress = (activeMessageCount / (expectedContactMessages))*100;
            pgbServiceBus.Value = (int) progress;
            lblSbMessageCount.Text = e.ProgressPercentage.ToString();
            lblProgressValue.Text = $"{progress}%";
            
            if (PreviousMessageCount > 0 && activeMessageCount == 0)
            {
                Log($"Tous les contacts ont été chargés dans D365 !");
            }
            PreviousMessageCount = e.ProgressPercentage;

            Application.DoEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerServiceBus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            worker.RunWorkerAsync();
        }

        #endregion Service Bus

        #region Crm Counter

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerCrmCounter_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            int crmContactCount = CrmRecordCounter.Execute("contact");
            worker.ReportProgress(crmContactCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkerCrmCounter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            if (worker.CancellationPending)
            {
                return;
            }
            int crmContactCount = e.ProgressPercentage;
            lblCrmContactCount.Text = crmContactCount.ToString();

            Application.DoEvents();
        }
        
        private void bgWorkerCrmCounter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            worker.RunWorkerAsync();
        }

        #endregion Crm Counter

        /// <summary>
        /// Write message to console
        /// </summary>
        /// <param name="message"></param>
        private void Log(string message)
        {
            txtConsole.Text += $"{DateTime.Now.ToLongTimeString() } => {message} {Environment.NewLine}";
        }

        /// <summary>
        /// Start webjob
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartWebJob_Click(object sender, EventArgs e)
        {
            Log($"Execution du webjob Service Bus > D365");
            var webjobUrl = JobSettings.WebJobUrl;
            var webjobLogin = JobSettings.WebJobLogin;
            var webjobPassword = JobSettings.WebJobPwd;

            using (var client = new WebClient { Credentials = new NetworkCredential(webjobLogin, webjobPassword) })
            {
                client.UploadString(webjobUrl, "post", "");
            }
        }
    }
}
