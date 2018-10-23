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
            ConsoleHelper.Log("How many contacts do you want to load ? ", withoutReturn:true, status: ConsoleHelper.LogStatus.Information);
            var line = System.Console.ReadLine();
            var entry = int.Parse(line);
            return entry;
        }
    }
}