using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager
{
    public class HibernateConnector : IDataConnection
    {
        public Owner SetOrChangeCarOwner(int ownerID, int carID)
        {
            Owner owner;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                owner = GlobalConfig.mySession.Get<Owner>(ownerID);
                if (owner == null)
                {
                    Console.WriteLine("No such Person in DataBase");
                    return null;
                }
                var car = GlobalConfig.mySession.Get<Car>(carID);
                if (car == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return null;
                }

                owner.Cars.Add(car);
                car.Owner = owner;

                GlobalConfig.mySession.Update(owner);
                GlobalConfig.mySession.Update(car);
                GlobalConfig.mySession.Transaction.Commit();
            }

            return owner;
        }

        public Car CreateCar(string plateNumber, string producer, string model)
        {
            var car = new Car
            {
                PlateNumber = plateNumber.ToUpper(),
                Producer = producer.ToUpper(),
                Model = model.ToUpper()
            };

            using (GlobalConfig.mySession.BeginTransaction())
            {
                GlobalConfig.mySession.Save(car);
                GlobalConfig.mySession.Transaction.Commit();
            }

            return car;
        }

        public Owner CreateOwner(string firstName, string lastName)
        {
            var owner = new Owner
            {
                FirstName = firstName.ToUpper(),
                LastName = lastName.ToUpper()
            };
            using (GlobalConfig.mySession.BeginTransaction())
            {
                GlobalConfig.mySession.Save(owner);
                GlobalConfig.mySession.Transaction.Commit();
            }

            return owner;
        }

        public List<Car> GetAllCars()
        {
            List<Car> output = null;

            using (GlobalConfig.mySession.BeginTransaction())
            {
                // Do sprawdzenia
                output = (List<Car>)GlobalConfig.mySession.CreateCriteria<Car>().List<Car>();

                GlobalConfig.mySession.Transaction.Commit();
            }

            if (!output.Any()) Console.WriteLine("No Cars in DB");

            return output;
        }

        public List<Owner> GetAllOwners()
        {
            List<Owner> output = null;

            using (GlobalConfig.mySession.BeginTransaction())
            {
                // Do sprawdzenia
                output = (List<Owner>)GlobalConfig.mySession.CreateCriteria<Owner>().List<Owner>();

                GlobalConfig.mySession.Transaction.Commit();
            }

            if (!output.Any()) Console.WriteLine("No Car Owners in DB");

            return output;
        }

        public Car GetCarByID(int carID)
        {
            Car car;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                car = GlobalConfig.mySession.Get<Car>(carID);
                if (car == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return null;
                }

                GlobalConfig.mySession.Transaction.Commit();
            }

            ///// do usuniecia
            //Console.WriteLine($"{car.ID} {car.Producer} {car.Model} {car.PlateNumber}");


            return car;
        }

        public Owner GetOwnerByID(int ownerID)
        {
            Owner owner;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                owner = GlobalConfig.mySession.Get<Owner>(ownerID);
                if (owner == null)
                {
                    Console.WriteLine("No such Person in DataBase");
                    return null;
                }

                GlobalConfig.mySession.Transaction.Commit();
            }

            ///// do usuniecia
            Console.WriteLine($"{owner.ID} {owner.FirstName} {owner.LastName} {owner.Cars.Count}");


            return owner; 
        }

        public List<Car> GetCarsByPlateNumber(string plateNumber)
        {
            List<Car> output = null;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                ICriteria criteria = GlobalConfig.mySession.CreateCriteria<Car>();
                IList<Car> cars = criteria.List<Car>().Where(x => x.PlateNumber.Contains(plateNumber.ToUpper())).ToList();
               
                output = (List<Car>)cars;
                GlobalConfig.mySession.Transaction.Commit();
            }
            return output;
        }

        public List<Car> GetCarsByProducer(string producer)
        {
            List<Car> output = null;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                ICriteria criteria = GlobalConfig.mySession.CreateCriteria<Car>();
                IList<Car> cars = criteria.List<Car>().Where(x => x.Producer.Contains(producer.ToUpper())).ToList();

                output = (List<Car>)cars;
                GlobalConfig.mySession.Transaction.Commit();
            }
            return output;
        }

        public List<Car> GetCarsByModel(string model)
        {
            List<Car> output = null;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                ICriteria criteria = GlobalConfig.mySession.CreateCriteria<Car>();
                IList<Car> cars = criteria.List<Car>().Where(x => x.Model.Contains(model.ToUpper())).ToList();

                output = (List<Car>)cars;
                GlobalConfig.mySession.Transaction.Commit();
            }
            return output;
        }

        public Car ChangeCarPlateNumber(int carID, string plateNumber)
        {
            Car car;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                car = GlobalConfig.mySession.Get<Car>(carID);
                if (car == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return null;
                }

                car.PlateNumber = plateNumber.ToUpper();

                GlobalConfig.mySession.Update(car);
                GlobalConfig.mySession.Transaction.Commit();
            }

            return car;
        }

        public Car ChangeCarPlateProducer(int carID, string carProducer)
        {
            Car car;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                car = GlobalConfig.mySession.Get<Car>(carID);
                if (car == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return null;
                }

                car.Producer = carProducer.ToUpper();

                GlobalConfig.mySession.Update(car);
                GlobalConfig.mySession.Transaction.Commit();
            }

            return car;
        }

        public Car ChangeCarModel(int carID, string carModel)
        {
            Car car;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                car = GlobalConfig.mySession.Get<Car>(carID);
                if (car == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return null;
                }

                car.Model = carModel.ToUpper();

                GlobalConfig.mySession.Update(car);
                GlobalConfig.mySession.Transaction.Commit();
            }

            return car;
        }

        public Owner ChangeOwnerFirstName(int ownerID, string ownerFirstName)
        {
            Owner owner;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                owner = GlobalConfig.mySession.Get<Owner>(ownerID);
                if (owner == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return null;
                }

                owner.FirstName = ownerFirstName.ToUpper();

                GlobalConfig.mySession.Update(owner);
                GlobalConfig.mySession.Transaction.Commit();
            }

            return owner;
        }

        public Owner ChangeOwnerLastName(int ownerID, string ownerLastName)
        {
            Owner owner;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                owner = GlobalConfig.mySession.Get<Owner>(ownerID);
                if (owner == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return null;
                }

                owner.LastName = ownerLastName.ToUpper();

                GlobalConfig.mySession.Update(owner);
                GlobalConfig.mySession.Transaction.Commit();
            }

            return owner;
        }

        public List<Owner> GetOwnerByFirstName(string firstName)
        {
            List<Owner> output = null;
            using (GlobalConfig.mySession.BeginTransaction())
            {
                ICriteria criteria = GlobalConfig.mySession.CreateCriteria<Owner>();
                IList<Owner> owners = criteria.List<Owner>().Where(x => x.FirstName.Contains(firstName.ToUpper())).ToList();

                output = (List<Owner>)owners;
                GlobalConfig.mySession.Transaction.Commit();
            }
            return output;
        }

        public void DeleteCar(int carID)
        {
            using (GlobalConfig.mySession.BeginTransaction())
            {
                var car = GlobalConfig.mySession.Get<Car>(carID);
                if (car == null)
                {
                    Console.WriteLine("No such Car in DataBase");
                    return;
                }


                GlobalConfig.mySession.Delete(car);
                GlobalConfig.mySession.Transaction.Commit();
            }
        }

        public void DeleteOwner(int ownerID)
        {
            using (GlobalConfig.mySession.BeginTransaction())
            {
                var owner = GlobalConfig.mySession.Get<Owner>(ownerID);
                if (owner == null)
                {
                    Console.WriteLine("No such Person in DataBase");
                    return;
                }
                GlobalConfig.mySession.Delete(owner);
                GlobalConfig.mySession.Transaction.Commit();
            }
        }
    }
}
