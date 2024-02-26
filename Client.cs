using OODProj.AbstarctFactories;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.StorageData;
using OODProj.Repository;

namespace OODProj
{
    internal class Client
    {
        static void Main(string[] args)
        {
            DataContainer data = new();

            Dictionary<string, IFactory> factories = new()
            {
                { CargoPlane.ObjectID, new CargoPlaneFactory() },
                { PassengerPlane.ObjectID, new PassengerPlaneFactory() }
            };

            Dictionary<string, IRepository> repos = new()
            {
                { CargoPlane.ObjectID, new CargoPlaneRepository() },
                { PassengerPlane.ObjectID, new PassengerPlaneRepository() }
            };

            Dictionary<string, IReader> reader = new()
            {
                { "FTR", new FTRReader("data.csv", factories, repos) },
            };

            reader["FTR"].Read();
            
        }
    }

}

