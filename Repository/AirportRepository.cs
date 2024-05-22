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
    public class AirportRepository: IRepository
    {
        private List<Airport> _airports;
        private ISerializer _serializeFormat;

        public List<Airport> Airports { get => _airports; set => _airports = value; }

        [JsonIgnore]
        public ISerializer SerializeFormat { get => _serializeFormat; init => _serializeFormat = value; }

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
            _airports.Add((Airport)keyedObject);
        }

        public void DisplayObjects()
        {
            foreach (var airport in _airports)
            {
                Console.WriteLine(airport.ToString());
            }
        }

        public List<IPrimaryKeyed> GetPrimaryKeyedObjects()
        {
            return _airports.Cast<IPrimaryKeyed>().ToList();
        }

        public void DeleteFromRepo(IPrimaryKeyed keyedObject)
        {
            _airports.Remove((Airport)keyedObject);
        }

        public void DeleteAll()
          =>_airports.Clear();
    }
}

