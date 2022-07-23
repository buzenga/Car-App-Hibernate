using CarManager.ConsoleInterface;

namespace CarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CarManagementApp";

            GlobalConfig.InitializeConnections(DatabaseType.Hibernate);

            MainMenu.StartMainMenu();
        }
    }
}