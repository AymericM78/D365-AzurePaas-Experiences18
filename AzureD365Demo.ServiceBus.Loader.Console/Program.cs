using AzureD365DemoWebJob.Utils;

namespace AzureD365Demo.ServiceBus.Loader.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            var countContacts = AskForHowManyContacts();
            new ContactLoader(countContacts).Run();

            // TODO . When the job reach the end 
            //    => Open AzureD365Demo.CRM.Monitoring.Console with countContacts as parameter

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
            ConsoleHelper.Log("Combien de contact souhaitez-vous charger ? ", withoutReturn:true, status: ConsoleHelper.LogStatus.Information);
            var line = System.Console.ReadLine();
            var entry = int.Parse(line);
            return entry;
        }
    }
}