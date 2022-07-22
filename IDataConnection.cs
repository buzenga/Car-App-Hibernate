using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager
{
    public interface IDataConnection
    {
        /*public void InsertCar(Car car, Owner owner);
        public void InsertCar(Car car);
        public Owner InsertOwner(Owner owner);
        public void ReadCarDB();
        public void ReadOwnerDB();
        public void DeleteCarDBData();
        public void DeleteOwnerDBData();
        public void FindCarByPlateNumber(string searchString);
        public Owner FindOwnerByID(int id);
        public void ChangeOwnerByID(string plateNumber, int ownerID);
        public void DeleteOwnerByID(int id);
        public void DeleteCarByPlateNumber(string plateNumber);*/
        ////////////////////////////////////////////////////////
        public Car CreateCar(string plateNumber, string producer, string model);
        public Owner CreateOwner(string firstName, string lastName);
        public List<Car> GetAllCars();
        public List<Owner> GetAllOwners();
        public Owner SetOrChangeCarOwner(int ownerID, int carID);
        public Owner GetOwnerByID(int ownerID);
        public List<Owner> GetOwnerByFirstName(string firstName);
        public Car GetCarByID(int carID);
        public List<Car> GetCarsByPlateNumber (string plateNumber);
        public List<Car> GetCarsByProducer(string producer);
        public List<Car> GetCarsByModel(string model);
        public Car ChangeCarPlateNumber(int carID, string plateNumber);
        public Car ChangeCarPlateProducer(int carID, string carProducer);
        public Car ChangeCarModel(int carID, string carModel);
        public Owner ChangeOwnerFirstName(int ownerID, string ownerFirstName);
        public Owner ChangeOwnerLastName(int ownerID, string ownerLastName);

        public void DeleteCar(int carID);
        public void DeleteOwner(int ownerID);

    }
}
