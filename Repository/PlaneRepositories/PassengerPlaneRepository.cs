using OODProj.Data;
using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using OODProj.DataSerializers;

namespace OODProj.Repository.PlaneRepositories
{
    public class PassengerPlaneRepository : IRepository
    {
        private List<PassengerPlane> _passengerPlanes;
        private ISerializer _serializeFormat;

        [JsonIgnore]
        public ISerializer SerializeFormat { get => _serializeFormat; init => _serializeFormat = value; }
        public List<PassengerPlane> PassengerPlane { get => _passengerPlanes; init => _passengerPlanes = value; }

        public PassengerPlaneRepository()
        {
            _passengerPlanes = new List<PassengerPlane>();
            _serializeFormat = new JSONSerializer();
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            _passengerPlanes.Add((PassengerPlane)keyedObject);
        }

        public void SerializeRepository()
        {
            _serializeFormat.Serialize(this);
        }

        public void DisplayObjects()
        {
            foreach (var plane in _passengerPlanes)
            {
                Console.WriteLine(plane.ToString());
            }
        }

        public List<IPrimaryKeyed> GetPrimaryKeyedObjects()
        {
            return _passengerPlanes.Cast<IPrimaryKeyed>().ToList();
        }

        public void DeleteFromRepo(IPrimaryKeyed keyedObject)
        {
            _passengerPlanes.Remove((PassengerPlane)keyedObject);
        }


        public void DeleteAll()
          =>_passengerPlanes.Clear();
        

    }
}
