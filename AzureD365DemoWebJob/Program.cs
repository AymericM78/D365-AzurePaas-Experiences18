using Microsoft.Azure.WebJobs;

namespace AzureD365DemoWebJob
{
    class Program
    {
        static void Main()
        {
            var config = new JobHostConfiguration();
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            var host = new JobHost(config);

            MessageProcessor messageProcessor = new MessageProcessor();
            messageProcessor.Run();
            host.RunAndBlock();
        }
    }
}
