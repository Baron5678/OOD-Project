using OODProj.Data;
using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using OODProj.Repository.PlaneRepositories;
using OODProj.Repository.UserRepositories;
using OODProj.Repository;

namespace OODProj.StrategiesGettingData.DataSerializers
{
    public class JSONSerializer: ISerializer
    {
        private string _path;
        private JsonSerializerOptions _options;

        public string Path { get => _path; set => _path = value; }
        public JsonSerializerOptions Options { get => _options; set => _options = value; }

        public JSONSerializer()
        {
            _path = string.Empty;
            _options = new JsonSerializerOptions();
            _options.WriteIndented = true;
        }
       
        public void Serialize(CargoPlaneRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.CargoPlanes, _options);

            File.WriteAllText(_path, jsonString);
        }

        public void Serialize(PassengerPlaneRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.PassengerPlane, _options);

            File.WriteAllText(_path, jsonString);
        }

        public void Serialize(PassengerRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Passengers, _options);
            File.WriteAllText(_path, jsonString);
        }

        public void Serialize(CrewRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Crews, _options);
            File.WriteAllText(_path, jsonString);
        }

        public void Serialize(FlightRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Flights, _options);
            File.WriteAllText(_path, jsonString);
        }

        public void Serialize(CargoRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Cargos, _options);
            File.WriteAllText(_path, jsonString);
        }

        public void Serialize(AirportRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Airports, _options);
            File.WriteAllText(_path, jsonString);
        }
    }
}
