using OODProj.Data;
using OODProj.Data.Users;
using OODProj.DataSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OODProj.Repository.UserRepositories
{
    public class PassengerRepository : IRepository
    {
        private List<Passenger> _passengers;
        private ISerializer _serializeFormat;

        public List<Passenger> Passengers { get => _passengers; set => _passengers = value; }

        [JsonIgnore]
        public ISerializer SerializeFormat { get => _serializeFormat; init => _serializeFormat = value; }

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
            _passengers.Add((Passenger)keyedObject);
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
