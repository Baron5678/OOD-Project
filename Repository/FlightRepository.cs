using OODProj.Data;
using OODProj.StrategiesGettingData.DataSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Repository
{
    public class FlightRepository : IRepository
    {
        private List<Flight> _flights;
        private ISerializer _serializeFormat;

        public List<Flight> Flights { get => _flights; set => _flights = value; }
        public ISerializer SerializeFormat { get => _serializeFormat; set => _serializeFormat = value; }

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
            var temp = keyedObject as Flight;

            if (temp is null)
                throw new ArgumentException("Object cannot be added to Flight Repository");

            _flights.Add(temp);
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
