using OODProj.Data;
using OODProj.DataSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OODProj.Repository
{
    public class FlightRepository : IRepository
    {
        private List<Flight> _flights;
        private ISerializer _serializeFormat;

        public List<Flight> Flights { get => _flights; set => _flights = value; }

        [JsonIgnore]
        public ISerializer SerializeFormat { get => _serializeFormat; init => _serializeFormat = value; }

        public FlightRepository()
        {
            _flights = new List<Flight>();
            _serializeFormat = new JSONSerializer();
        }

        public void SerializeRepository()
        {
            _serializeFormat.Serialize(this);
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            _flights.Add((Flight)keyedObject);
        }

        public void DisplayObjects()
        {
            foreach (var flight in _flights)
            {
                Console.WriteLine(flight.ToString());
            }
        }
    }
}
