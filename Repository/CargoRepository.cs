using OODProj.Data;
using OODProj.StrategiesGettingData.DataSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Repository
{
    public class CargoRepository: IRepository
    {
        private List<Cargo> _airports;
        private ISerializer _serializeFormat;

        public List<Cargo> Cargos { get => _airports; set => _airports = value; }
        public ISerializer SerializeFormat { get => _serializeFormat; set => _serializeFormat = value; }

        public CargoRepository()
        {
            _airports = new List<Cargo>();
            _serializeFormat = new JSONSerializer();
        }

        public void SerializeRepository()
        {
            _serializeFormat.Serialize(this);
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            var temp = keyedObject as Cargo;
            
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
