using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.ConsoleInterface.OwnerRelated
{
    public class OwnersOperations
    {
        public static void CreateOwner()
        {
            Console.Clear();
            Console.WriteLine("Adding new Owner...");

            Console.Write("Insert first name: ");
            string firstName = Console.ReadLine().ToUpper();

            Console.Write("Insert last name: ");
            string lastName = Console.ReadLine().ToUpper();

            var owner = GlobalConfig.Connection.CreateOwner(firstName, lastName);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{owner.FirstName} {owner.LastName} has been added to the DataBase with ID of: {owner.ID}");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        public static void RemoveOwner()
        {
            Console.WriteLine("Find ID of an owner You want to remove from DataBase on the list underneath:");
            Console.WriteLine();

            GrabOwnersData();

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

            GlobalConfig.Connection.DeleteOwner(intQuery);

            Console.WriteLine("You've deleted the owner successfully.");
            Console.ReadLine();

            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        private static void GrabOwnersData()
        {
            var allOwners = GlobalConfig.Connection.GetAllOwners();
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
        public static void DisplayAllOwners()
        {
            Console.WriteLine("These are all owners in your DataBase:");
            Console.WriteLine();

            GrabOwnersData();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        public static void DisplayOwnerByID()
        {
            Console.Write("Insert the ID of an Owner You want to display: ");
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

            var owner = GlobalConfig.Connection.GetOwnerByID(intQuery);

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
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        public static void DisplayOwnersByFirstName()
        {
            Console.Write("Insert the first name of an owner You want to display: ");
            string query = Console.ReadLine();

            Console.WriteLine();

            var owners = GlobalConfig.Connection.GetOwnerByFirstName(query);

            foreach (var owner in owners)
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
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        public static void DisplayOwnersByLastName()
        {
            Console.Write("Insert the last name of an owner You want to display: ");
            string query = Console.ReadLine();

            Console.WriteLine();

            var owners = GlobalConfig.Connection.GetOwnerByLastName(query);

            foreach (var owner in owners)
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
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        public static void ChangeOwnersFirstName()
        {
            Console.WriteLine("Insert ID of the owner: ");
            string ownerQuery = Console.ReadLine();
            Console.Write("Insert new first name: ");
            string ownerFirstName = Console.ReadLine();

            bool validOwnerId = int.TryParse(ownerQuery, out int ownerID);

            if (validOwnerId == false)
            {
                Console.WriteLine("No such Owner ID in DatatBase");
                return;
            }


            var owner = GlobalConfig.Connection.ChangeOwnerFirstName(ownerID, ownerFirstName);

            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine($"First name of an owner with ID: {owner.ID}, has ben set to: {owner.FirstName}");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        public static void ChangeOwnersLastName()
        {
            Console.WriteLine("Insert ID of the owner: ");
            string ownerQuery = Console.ReadLine();
            Console.Write("Insert new last name: ");
            string ownerLastName = Console.ReadLine();

            bool validOwnerId = int.TryParse(ownerQuery, out int ownerID);

            if (validOwnerId == false)
            {
                Console.WriteLine("No such Owner ID in DatatBase");
                return;
            }


            var owner = GlobalConfig.Connection.ChangeOwnerLastName(ownerID, ownerLastName);

            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine($"Last name of an owner with ID: {owner.ID}, has ben set to: {owner.LastName}");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
