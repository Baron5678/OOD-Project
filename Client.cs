using OODProj.AbstarctFactories;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.StorageData;

namespace OODProj
{
    internal class Client
    {
        static void Main(string[] args)
        {
            DataContainer data = new();

            Dictionary<string, ICreateFactory> factories = new()
            {
                { CargoPlane.ObjectID, new CargoPlaneFactory() },
                { PassengerPlane.ObjectID, new PassengerPlaneFactory() }
            };

            Dictionary<string, IAddStrategy> strategies = new()
            {
                { CargoPlane.ObjectID, new CargoPlaneAddStrategy() },
                { PassengerPlane.ObjectID, new PassengerPlaneAddStrategy() }
            };

            Dictionary<string, IReader> reader = new()
            {
                { "FTR", new FTRReader("data.csv", data, factories, strategies) },
            };

            reader["FTR"].Read();
            
        }
    }

}

