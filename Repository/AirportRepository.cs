using OODProj.Data;
using OODProj.StrategiesGettingData.DataSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Repository
{
    public class AirportRepository: IRepository
    {
        private List<Airport> _airports;
        private ISerializer _serializeFormat;

        public List<Airport> Airports { get => _airports; set => _airports = value; }
        public ISerializer SerializeFormat { get => _serializeFormat; set => _serializeFormat = value; }

        public AirportRepository()
        {
            _airports = new List<Airport>();
            _serializeFormat = new JSONSerializer();
        }

        public void SerializeRepository()
        {
            _serializeFormat.Serialize(this);
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            var temp = keyedObject as Airport;

            if (temp is null)
                throw new ArgumentException("Object cannot be added to Cargo Repository");

            _airports.Add(temp);
        }

        public void DisplayObjects()
        {
            foreach (var airport in _airports)
            {
                Console.WriteLine(airport.ToString());
            }
        }
    }
}

