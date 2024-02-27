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
    public class CargoPlaneRepository : IRepository
    {
        private List<CargoPlane> _cargoPlanes;

        public IVisitor SerializeFormat { get; set; }

        public List<CargoPlane> CargoPlanes { get => _cargoPlanes; set => _cargoPlanes = value; }

        public CargoPlaneRepository()
        {
            _cargoPlanes = new List<CargoPlane>();
            SerializeFormat = new JSONSerializer("./DataFiles/Default");
        }

        public List<IPrimaryKeyed> GetAll() 
        {
            return _cargoPlanes.Cast<IPrimaryKeyed>().ToList();
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            var temp = keyedObject as CargoPlane;

            if (temp is null)
                throw new ArgumentException("Object cannot be added to Cargo Plane Repository");

            _cargoPlanes.Add(temp);
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
