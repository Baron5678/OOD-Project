using OODProj.Data;
using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.StrategiesGettingData.DataSerializers;

namespace OODProj.Repository
{
    public class PassengerPlaneRepository : IRepository
    {
        private List<PassengerPlane> _passengerPlanes;

        public IVisitor SerializeFormat { get; set; }

        public List<PassengerPlane> PassengerPlane { get => _passengerPlanes; set => _passengerPlanes = value; }

        public PassengerPlaneRepository()
        {
            _passengerPlanes = new List<PassengerPlane>();
            SerializeFormat = new JSONSerializer("./DataFiles/Default.json");
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            var temp = keyedObject as PassengerPlane;

            if (temp is null)
                throw new ArgumentException("Object cannot be added to Passenger Plane Repository");

            _passengerPlanes.Add(temp);
        }

        public List<IPrimaryKeyed> GetAll()
        {
            return _passengerPlanes.Cast<IPrimaryKeyed>().ToList();
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Accept()
        {
            SerializeFormat.Visit(this);
        }
    }
}
