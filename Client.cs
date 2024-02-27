using OODProj.AbstarctFactories;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.Repository;
using OODProj.StrategiesGettingData.DataReaders;
using OODProj.StrategiesGettingData.DataSerializers;

namespace OODProj
{
    internal class Client
    {
        static void Main(string[] args)
        {
            string readerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "Test.txt");

            List<string> JSONPaths = new()
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "CargoPlanes"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "PassengerPlanes")
            };

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
                { "FTR", new FTRReader(readerPath, factories, repos) },
            };

            Dictionary<string , IVisitor> repoActions = new()
            {
                { "JSON", new JSONSerializer("./DataFiles/Default") }
            };

            reader["FTR"].Read();

            foreach (var item in repos[CargoPlane.ObjectID].GetAll())
            {
                Console.WriteLine(item);
            }

            repos[CargoPlane.ObjectID].SerializeFormat.Path = JSONPaths[0];

            repos[CargoPlane.ObjectID].Accept();

          

            
        
        }
    }

}

