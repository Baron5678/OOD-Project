using OODProj.Data;
using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.StrategiesGettingData.DataSerializers;

namespace OODProj.Repository.PlaneRepositories
{
    public class PassengerPlaneRepository : IRepository
    {
        private List<PassengerPlane> _passengerPlanes;
        private ISerializer _serializeFormat;

        public ISerializer SerializeFormat { get => _serializeFormat; set => _serializeFormat = value; }
        public List<PassengerPlane> PassengerPlane { get => _passengerPlanes; set => _passengerPlanes = value; }

        public PassengerPlaneRepository()
        {
            _passengerPlanes = new List<PassengerPlane>();
            _serializeFormat = new JSONSerializer();
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            var temp = keyedObject as PassengerPlane;

            if (temp is null)
                throw new ArgumentException("Object cannot be added to Passenger Plane Repository");

            _passengerPlanes.Add(temp);
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
    }
}
