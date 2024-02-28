using OODProj.AbstarctFactories;
using OODProj.AbstarctFactories.UserFactories;
using OODProj.AbstarctFactories.PlaneFactories;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.Repository;
using OODProj.StrategiesGettingData.DataReaders;
using OODProj.Repository.PlaneRepositories;
using OODProj.Repository.UserRepositories;

namespace OODProj
{
    internal class Client
    {
        static void Main(string[] args)
        {

            //Configurations
            #region Configurations

            //Paths, where data is retrieved from
            List<string> ReaderPaths = new()
            {
                @"..\..\..\DataFiles\Source\example_data.ftr"
            };

            //Paths, where data is written to
            Dictionary<string, string> JSONPaths = new()
            {
                {CargoPlane.ClassID, @"..\..\..\DataFiles\JSON\CargoPlane.json"},
                {PassengerPlane.ClassID, @"..\..\..\DataFiles\JSON\PassengerPlane.json"},
                {Cargo.ClassID, @"..\..\..\DataFiles\JSON\Cargo.json"},
                {Passenger.ClassID, @"..\..\..\DataFiles\JSON\Passenger.json"},
                {Crew.ClassID, @"..\..\..\DataFiles\JSON\Crew.json"},
                {Airport.ClassID, @"..\..\..\DataFiles\JSON\Airport.json"},
                {Flight.ClassID, @"..\..\..\DataFiles\JSON\Flight.json"}
            };

            Dictionary<string, IFactory> factories = new()
            {
                { CargoPlane.ClassID, new CargoPlaneFactory() },
                { PassengerPlane.ClassID, new PassengerPlaneFactory() },
                { Cargo.ClassID, new CargoFactory() },
                { Passenger.ClassID, new PassengerFactory() },
                { Crew.ClassID, new CrewFactory() },
                { Airport.ClassID, new AirportFactory() },
                { Flight.ClassID, new FlightFactory() },
            };

            Dictionary<string, IRepository> repos = new()
            {
                { CargoPlane.ClassID, new CargoPlaneRepository() },
                { PassengerPlane.ClassID, new PassengerPlaneRepository() },
                { Cargo.ClassID, new CargoRepository() },
                { Passenger.ClassID, new PassengerRepository() },
                { Crew.ClassID, new CrewRepository() },
                { Airport.ClassID, new AirportRepository() },
                { Flight.ClassID, new FlightRepository() }
            };

            Dictionary<string, IReader> reader = new()
            {
                { "FTR", new FTRReader(ReaderPaths[0], factories, repos) },
            };
            #endregion

            reader["FTR"].Read();

            //Checking if data was read correctly
            foreach (var repo in repos)
            {
                repo.Value.DisplayObjects();
            }

            //Setting paths for serialization
            foreach (var repo in repos)
            {
                repo.Value.SerializeFormat.Path = JSONPaths[repo.Key];
            }

            //Serialization objects 
            foreach (var repo in repos)
            {
                repo.Value.SerializeRepository();
            }
        }
    }
}

