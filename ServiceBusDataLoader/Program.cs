

namespace ServiceBusDataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactLoader contactLoader = new ContactLoader();
            contactLoader.Run();
        }
    }
}
