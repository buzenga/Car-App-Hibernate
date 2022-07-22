using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.ConsoleInterface.CarRelated
{
    public class CarOperations
    {
        public static void CreateCar()
        {
            Console.Clear();
            Console.WriteLine("Adding new car...");

            Console.Write("Insert plate number: ");
            string plateNumber = Console.ReadLine().ToUpper();

            Console.Write("Insert producer name: ");
            string producer = Console.ReadLine().ToUpper();

            Console.Write("Insert model: ");
            string model = Console.ReadLine().ToUpper();

            var car = GlobalConfig.Connection.CreateCar(plateNumber, producer, model);
           
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{car.Producer} {car.Model} with plate number: {car.PlateNumber} has been added to DataBase. It's ID: {car.ID}");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
        }
        public static void RemoveCar()
        {
            Console.WriteLine("Find ID of a car You want to remove from DataBase from the list underneath:");
            Console.WriteLine();

            GrabCarsData();

            Console.WriteLine();
            Console.Write("Insert ID you want to remove from DataBase: ");

            string query = Console.ReadLine();
            Console.WriteLine();

            int intQuery;
            bool isValid = int.TryParse(query, out intQuery);

            if (isValid == false)
            {
                Console.WriteLine("The ID was in invalid format. Please insert a number");
                Console.ReadLine();
                    return;
            }

            GlobalConfig.Connection.DeleteCar(intQuery);

            Console.WriteLine("You've deleted the car successfully.");
            Console.ReadLine();

        }
        public static void DisplayAllCars()
        {
            Console.WriteLine("These are all cars in your DataBase:");
            Console.WriteLine();

            GrabCarsData();
           
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
        }
        private static void GrabCarsData()
        {
            var allCars = GlobalConfig.Connection.GetAllCars();
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
        }
        public static void DisplayCarByID()
        {
            Console.Write("Insert the ID of a car You want to display: ");
            string query = Console.ReadLine();

            Console.WriteLine();

            int intQuery;
            bool isValid = int.TryParse(query, out intQuery);

            if (isValid == false)
            {
                Console.WriteLine("The ID was in invalid format. Please insert a number");
                Console.ReadLine();
                return;
            }

            var car = GlobalConfig.Connection.GetCarByID(intQuery);
            if (car.Owner == null)
            {
                Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model}");
            }
            else
            {
                Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model} || Owner: {car.Owner.FirstName} {car.Owner.LastName}");
            }
            Console.ReadLine();
        }
        public static void DisplayCarsByPlateNumber()
        {
            Console.Write("Insert the plate number of a car You want to display: ");
            string query = Console.ReadLine();

            Console.WriteLine();

            var cars = GlobalConfig.Connection.GetCarsByPlateNumber(query);
            if (!cars.Any())
            {
                Console.WriteLine("No such cars in the DataBase:");
                Console.ReadLine();
                return;
            }
            foreach( Car car in cars)
            {
                if (car.Owner == null)
                {
                    Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model}");
                }
                else
                {
                    Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model} || Owner: {car.Owner.FirstName} {car.Owner.LastName}");
                }       
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void DisplayCarsByProducer()
        {
            Console.Write("Insert the producer of a car You want to display: ");
            string query = Console.ReadLine();

            Console.WriteLine();

            var cars = GlobalConfig.Connection.GetCarsByProducer(query);
            if (!cars.Any())
            {
                Console.WriteLine("No such cars in the DataBase:");
                Console.ReadLine();
                return;
            }
            foreach (Car car in cars)
            {
                if (car.Owner == null)
                {
                    Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model}");
                }
                else
                {
                    Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model} || Owner: {car.Owner.FirstName} {car.Owner.LastName}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void DisplayCarsByModel()
        {
            Console.Write("Insert the model name of a car You want to display: ");
            string query = Console.ReadLine();

            Console.WriteLine();

            var cars = GlobalConfig.Connection.GetCarsByModel(query);
            if (!cars.Any())
            {
                Console.WriteLine("No such cars in the DataBase:");
                Console.ReadLine();
                return;
            }
            foreach (Car car in cars)
            {
                if (car.Owner == null)
                {
                    Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model}");
                }
                else
                {
                    Console.WriteLine($"{car.ID} | {car.PlateNumber} | {car.Producer} | {car.Model} || Owner: {car.Owner.FirstName} {car.Owner.LastName}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void ConnectCarToOwner()
        {
            Console.Write("Insert ID of the owner: ");
            string ownerQuery = Console.ReadLine();
            Console.WriteLine("Insert ID of the car");
            string carQuery = Console.ReadLine();

            bool validOwnerID = int.TryParse(ownerQuery, out int ownerID);
            bool validCarID = int.TryParse(carQuery, out int carID);
            
            if (validOwnerID == false)
            {
                Console.WriteLine("No such Owner ID in DatatBase");
                return;
            }
            if (validCarID == false)
            {
                Console.WriteLine("No such Car ID in DatatBase");
                return;
            }

            GlobalConfig.Connection.SetOrChangeCarOwner(ownerID, carID);

            Console.WriteLine("New Connection has been set");
            Console.ReadLine();
        }
    }
}
