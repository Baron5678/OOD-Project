using OODProj.Data;
using OODProj.Repository.PlaneRepositories;
using OODProj.Repository.UserRepositories;
using OODProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace OODProj.StrategiesGettingData.DataSerializers
{
    public interface ISerializer
    {
        string Path { get; set; }
        JsonSerializerOptions Options { get; set; }

        void Serialize(CargoPlaneRepository repo);
        void Serialize(PassengerPlaneRepository repo);
        void Serialize(PassengerRepository repo);
        void Serialize(CrewRepository repo);
        void Serialize(FlightRepository repo);
        void Serialize(CargoRepository repo);
        void Serialize(AirportRepository repo);
    }
}
