using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AzureD365DemoWebJob
{
    public class JobSettings
    {
        public string CrmOrganizationName => GetParameter("Crm.Organization.Name");
        public string CrmUserName => GetParameter("Crm.User.Name");
        public string CrmUserPassword => GetParameter("Crm.User.Password");
        public string TelemetryKey => GetParameter("Telemetry.Key");
        public int ThreadNumber => GetParameterAsInteger("Process.Thread.Number");

        public string ServiceBusQueueKey => GetParameter("ServiceBus.Queue.Key");
        public string ServiceBusNamespaceKey => GetParameter("ServiceBus.Namespace.Key");
        public string WebJobUrl => GetParameter("WebJob.Url");
        public string WebJobLogin => GetParameter("WebJob.Login");
        public string WebJobPwd => GetParameter("WebJob.Pwd");

        const string DateFormat = "dd/MM/yyyy";
        static CultureInfo DateProvider = CultureInfo.InvariantCulture;

        public JobSettings()
        {

        }

        private string GetParameter(string key)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                throw new Exception($"Invalid configuration : setting '{key}' is missing in AppSettings section!");
            }             

            return ConfigurationManager.AppSettings[key];
        }

        private int GetParameterAsInteger(string key)
        {
            string paramValue = GetParameter(key);
            return int.Parse(paramValue);
        }

        private DateTime GetParameterAsDate(string key)
        {
            string paramValue = GetParameter(key);
            return DateTime.ParseExact(paramValue, DateFormat, DateProvider);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($" - Crm.Organization.Name = {CrmOrganizationName}");
            output.AppendLine($" - Crm.User.Name = {CrmUserName}");
            output.AppendLine($" - Crm.User.Password = {CrmUserPassword}");
            output.AppendLine($" - Telemetry.Key = {TelemetryKey}");
            output.AppendLine($" - Process.Thread.Number = {ThreadNumber}");

            return output.ToString();
        }
    }
}
