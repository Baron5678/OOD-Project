using OODProj.Repository;
using OODProj.Repository.PlaneRepositories;
using OODProj.Repository.UserRepositories;
using System.Text.Json;

namespace OODProj.DataSerializers
{
    public class JSONSerializer : ISerializer
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

        private void WriteToFile(string jsonString)
        {
            var fileStream = File.Create(_path);
            var writer = new StreamWriter(fileStream);
            writer.Write(jsonString);
            writer.Close();
            fileStream.Close();
        }

        public void Serialize(CargoPlaneRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.CargoPlanes, _options);

            WriteToFile(jsonString);
        }

        public void Serialize(PassengerPlaneRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.PassengerPlane, _options);

            WriteToFile(jsonString);
        }

        public void Serialize(PassengerRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Passengers, _options);

            WriteToFile(jsonString);
        }

        public void Serialize(CrewRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Crews, _options);

            WriteToFile(jsonString);
        }

        public void Serialize(FlightRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Flights, _options);

            WriteToFile(jsonString);
        }

        public void Serialize(CargoRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Cargos, _options);

            WriteToFile(jsonString);
        }

        public void Serialize(AirportRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.Airports, _options);

            WriteToFile(jsonString);
        }
    }
}
