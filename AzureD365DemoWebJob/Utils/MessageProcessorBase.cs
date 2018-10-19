using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.KeyVault;
using Microsoft.Pfe.Xrm;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace AzureD365DemoWebJob
{
    public class MessageProcessorBase
    {
        public string JobName = "AzureD365DemoWebJob";
        protected JobSettings JobSettings;
        protected TelemetryClient TelemetryClient;
        protected OrganizationServiceManager OrganizationServiceManager;
        protected QueueClient ContactQueueClient;

        public MessageProcessorBase()
        {
            JobSettings = new JobSettings();
            InitializeTelemetryClient();
            InitializeOrganizationServiceManager();
            InitializeQueueClient();
            ApplyConnectionOptimizations();
        }

        /// <summary>
        /// Optimize connection performances
        /// </summary>
        private void ApplyConnectionOptimizations()
        {
            // Change max connections from .NET to a remote service default: 2
            // Webapp targeted is Basic (Large) 
            // Socket available is 256 for 1 app
            // We have 3 interfaces : (256 / 3) => 85 sockets per interface 
            // 
            // Resource : https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#per-sandbox-per-appper-site-numerical-limits
            ServicePointManager.DefaultConnectionLimit = 85;

            // Bump up the min threads reserved for this app to ramp connections faster - minWorkerThreads defaults to 4, minIOCP defaults to 4 
            ThreadPool.SetMinThreads(10, 10);

            // Turn off the Expect 100 to continue message - 'true' will cause the caller to wait until it round-trip confirms a connection to the server 
            ServicePointManager.Expect100Continue = false;

            // More info on Nagle at WikiPedia - can help perf (helps w/ conn reliability)
            ServicePointManager.UseNagleAlgorithm = false;

            //a new twist to existing connections
            var knownServicePointConnection = ServicePointManager.FindServicePoint(OrganizationServiceManager.ServiceUri);
            if (knownServicePointConnection != null)
            {
                knownServicePointConnection.ConnectionLimit = ServicePointManager.DefaultConnectionLimit;
                knownServicePointConnection.Expect100Continue = ServicePointManager.Expect100Continue;
                knownServicePointConnection.UseNagleAlgorithm = ServicePointManager.UseNagleAlgorithm;
            }
        }

        /// <summary>
        /// Initialize Application Insights client
        /// </summary>
        private void InitializeTelemetryClient()
        {
            TelemetryClient = new TelemetryClient();
            TelemetryConfiguration.Active.InstrumentationKey = JobSettings.TelemetryKey;

            Log($"Telemetry client initialized!");
        }

        /// <summary>
        /// Initialize Organization client for D365 integration
        /// </summary>
        private void InitializeOrganizationServiceManager()
        {
            // If you're using an old version of .NET this will enable TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;            

            var serverUri = XrmServiceUriFactory.CreateOnlineOrganizationServiceUri(JobSettings.CrmOrganizationName, CrmOnlineRegion.EMEA);
            OrganizationServiceManager = new OrganizationServiceManager(serverUri, JobSettings.CrmUserName, JobSettings.CrmUserPassword);
            Log($"Organization service initialized to {serverUri.ToString()} with user {JobSettings.CrmUserName}!");
        }

        /// <summary>
        /// Initialize Service Bus queue client
        /// </summary>
        private void InitializeQueueClient()
        {
            ContactQueueClient = QueueClient.CreateFromConnectionString(JobSettings.ServiceBusQueueKey, ReceiveMode.PeekLock);

            Log($"Queue 'Contact' client initialized!");
        }

        /// <summary>
        /// Output Job Settings to console
        /// </summary>
        protected void OutPutSettings()
        {
            Log($"Job parameters : ", true, false);
            Log(JobSettings.ToString(), false, false);
        }

        /// <summary>
        /// Output information to console
        /// </summary>
        /// <param name="message"></param>
        /// <param name="addTimeStamp"></param>
        /// <param name="trace"></param>
        /// <param name="jobName"></param>
        protected void Log(string message, bool addTimeStamp = true, bool trace = true, string jobName = null)
        {
            if (jobName != null)
            {
                message = $"{jobName} - {message}";
            }
            if (addTimeStamp)
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")} : {message}");
            }
            else
            {
                Console.WriteLine(message);
            }
            if (trace)
            {
                TelemetryClient.TrackTrace(message);
            }
        }

        /// <summary>
        /// Log custom event to App Insights
        /// </summary>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <param name="jobName"></param>
        protected void LogEvent(string name, Dictionary<string, string> properties, string jobName = null)
        {
            var defaultProperties = GetDefaultProperties();
            if(null == properties)
                properties = new Dictionary<string, string>();

            foreach (var property in defaultProperties)
            {
                properties.Add(property.Key, property.Value);
            }
            if (jobName != null)
            {
                properties.Add("Job Name", jobName);
            }
            TelemetryClient.TrackEvent(name, properties);
        }

        /// <summary>
        /// Log exception to App Insights
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="properties"></param>
        /// <param name="jobName"></param>
        protected void LogException(Exception exception, Dictionary<string, string> properties, string jobName = null)
        {
            var defaultProperties = GetDefaultProperties();
            foreach (var property in defaultProperties)
            {
                properties.Add(property.Key, property.Value);
            }
            if (jobName != null)
            {
                properties.Add("Job Name", jobName);
            }
            TelemetryClient.TrackException(exception, properties);
        }

        /// <summary>
        /// Define default properties based on configuration for App Insights logging
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetDefaultProperties()
        {
            return new Dictionary<string, string>()
            {
                { "Default", "Cool" }
            };
        }

    }
}
