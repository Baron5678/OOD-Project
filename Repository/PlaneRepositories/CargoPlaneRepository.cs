using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.DataSerializers;
using System.Text.Json.Serialization;

namespace OODProj.Repository.PlaneRepositories
{
    public class CargoPlaneRepository : IRepository
    {
        private List<CargoPlane> _cargoPlanes;
        private ISerializer _serializeFormat;

        [JsonIgnore]
        public ISerializer SerializeFormat { get => _serializeFormat; init => _serializeFormat = value; }
        public List<CargoPlane> CargoPlanes { get => _cargoPlanes; init => _cargoPlanes = value; }

        public CargoPlaneRepository()
        {
            _cargoPlanes = new List<CargoPlane>();
            _serializeFormat = new JSONSerializer();
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        { 
            _cargoPlanes.Add((CargoPlane)keyedObject);
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

        public List<IPrimaryKeyed> GetPrimaryKeyedObjects()
        {
            return _cargoPlanes.Cast<IPrimaryKeyed>().ToList();
        }

        public void DeleteFromRepo(IPrimaryKeyed keyedObject)
        {
            _cargoPlanes.Remove((CargoPlane)keyedObject);
        }

        public void DeleteAll()
            => _cargoPlanes.Clear();

    }
}
