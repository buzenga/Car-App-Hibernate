using CarManager.ConsoleInterface;

namespace CarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CarManagementApp";

            GlobalConfig.InitializeConnections(DatabaseType.Hibernate);

            //MainMenu.StartMainMenu();


            //GlobalConfig.Connection.DeleteOwner(9);



            using (GlobalConfig.mySession.BeginTransaction())
            {
                var owner = GlobalConfig.mySession.Get<Owner>(2);
                if (owner == null)
                {
                    Console.WriteLine("No such Person in DataBase");
                    return;
                }
                var car = GlobalConfig.mySession.Get<Car>(11);
                if (car == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return;
                }

                owner.Cars.Add(car);
                car.Owner = owner;

                GlobalConfig.mySession.Update(owner);
                GlobalConfig.mySession.Update(car);
                GlobalConfig.mySession.Transaction.Commit();
            }
            var allOwners = GlobalConfig.Connection.GetAllOwners();
            var allCars = GlobalConfig.Connection.GetAllCars();


            // Display Cars

            foreach (var car in allCars)
            {
                if (car.Owner == null)
                {
                    Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model}");
                }
                else
                {
                    Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model} || {car.Owner.FirstName} {car.Owner.LastName}");
                }
            }

            //Display owners

            foreach (var owner in allOwners)
            {
                if (!owner.Cars.Any())
                {
                    Console.WriteLine($"{owner.ID} | {owner.FirstName} | {owner.LastName} | NO CAR PROPERTY");
                }
                else
                {
                    string carsString = "";
                    foreach (var car in owner.Cars)
                    {
                        carsString += @$" {car.PlateNumber} * {car.Producer} * {car.Model} /\";
                    }

                    carsString = carsString.Remove(carsString.Length - 2);

                    Console.WriteLine($"{owner.ID} | {owner.FirstName} | {owner.LastName} | {carsString}");
                }
            }
        }
    }
}