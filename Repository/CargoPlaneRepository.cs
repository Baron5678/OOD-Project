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

        public List<CargoPlane> CargoPlanes { get => _cargoPlanes; set => _cargoPlanes = value; }

        public CargoPlaneRepository()
        {
            _cargoPlanes = new List<CargoPlane>();
        }

        public void Delete(ulong id)
        {
            var temp =_cargoPlanes.Where(x => x.ID == id).ToList()[0];
            _cargoPlanes.Remove(temp);
        }

        public IPrimaryKeyed FindById(ulong id)
        {
            return _cargoPlanes.Where(x => x.ID == id).ToList()[0];
        }

        public List<IPrimaryKeyed> GetAll() 
        {
            return _cargoPlanes.Cast<IPrimaryKeyed>().ToList();
        }

        public void IAddToRepo(IPrimaryKeyed keyedObject)
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
    }
}
