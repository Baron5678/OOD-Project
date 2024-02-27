using OODProj.Data;
using OODProj.Data.Users;
using OODProj.StrategiesGettingData.DataSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Repository.UserRepositories
{
    public class PassengerRepository : IRepository
    {
        private List<Passenger> _passengers;
        private ISerializer _serializeFormat;

        public List<Passenger> Passengers { get => _passengers; set => _passengers = value; } 
        public ISerializer SerializeFormat { get => _serializeFormat; set => _serializeFormat = value; }

        public PassengerRepository()
        {
            _passengers = new List<Passenger>();
            _serializeFormat = new JSONSerializer();
        }

        public void SerializeRepository()
        {
            _serializeFormat.Serialize(this);
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            var temp = keyedObject as Passenger;
            if (temp is null)
                throw new ArgumentException("Object cannot be added to Passenger Repository");

            _passengers.Add(temp);
        }

        public void DisplayObjects()
        {
            foreach(var passenger in _passengers)
            {
               Console.WriteLine(passenger.ToString());
            }
        }
    }
}
