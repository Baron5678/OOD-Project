using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.StrategiesGettingData.DataSerializers;

namespace OODProj.Repository.PlaneRepositories
{
    public class CargoPlaneRepository : IRepository
    {
        private List<CargoPlane> _cargoPlanes;
        private ISerializer _serializeFormat;

        public ISerializer SerializeFormat { get => _serializeFormat; set => _serializeFormat = value; }
        public List<CargoPlane> CargoPlanes { get => _cargoPlanes; set => _cargoPlanes = value; }

        public CargoPlaneRepository()
        {
            _cargoPlanes = new List<CargoPlane>();
            _serializeFormat = new JSONSerializer();
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            var temp = keyedObject as CargoPlane;

            if (temp is null)
                throw new ArgumentException("Object cannot be added to Cargo Plane Repository");

            _cargoPlanes.Add(temp);
        }

        public void SerializeRepository()
        {
            SerializeFormat.Serialize(this);
        }

        public void DisplayObjects()
        {
            foreach (var plane in _cargoPlanes)
            {
                Console.WriteLine(plane.ToString());
            }
        }
    }
}
