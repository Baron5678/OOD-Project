using OODProj.Data;
using OODProj.Data.Users;
using OODProj.DataSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OODProj.Repository.UserRepositories
{
    public class CrewRepository : IRepository
    {
        private List<Crew> _passengers;
        private ISerializer _serializeFormat;

        public List<Crew> Crews { get => _passengers; set => _passengers = value; }

        [JsonIgnore]
        public ISerializer SerializeFormat { get => _serializeFormat; init => _serializeFormat = value; }

        public CrewRepository()
        {
            _passengers = new List<Crew>();
            _serializeFormat = new JSONSerializer();
        }

        public void SerializeRepository()
        {
            _serializeFormat.Serialize(this);
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        {
            _passengers.Add((Crew)keyedObject);
        }

        public void DisplayObjects()
        {
            foreach (var passenger in _passengers)
            {
                Console.WriteLine(passenger.ToString());
            }
        }

        public List<IPrimaryKeyed> GetPrimaryKeyedObjects()
        {
            return _passengers.Cast<IPrimaryKeyed>().ToList();
        }

        public void DeleteFromRepo(IPrimaryKeyed keyedObject)
        {
            _passengers.Remove((Crew)keyedObject);
        }

        public void DeleteAll()
          => _passengers.Clear();
    }
}
