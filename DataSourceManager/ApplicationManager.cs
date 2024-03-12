using OODProj.AbstarctFactories;
using OODProj.AbstarctFactories.PlaneFactories;
using OODProj.AbstarctFactories.UserFactories;
using OODProj.Builders.Directors;
using OODProj.Builders.Directors.PlaneDirectories;
using OODProj.Builders.Directors.UserDirectors;
using OODProj.Builders;
using OODProj.Builders.UserBuilders;
using OODProj.Builders.PlanesBuilders;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.Repository;
using OODProj.Repository.PlaneRepositories;
using OODProj.Repository.UserRepositories;
using OODProj.StrategiesGettingData.DataReaders;
using OODProj.Commands;
using NSS = NetworkSourceSimulator;
using System.Windows.Input;

namespace OODProj.DataSourceManager
{
    public class ApplicationManager
    {
        private static readonly Lazy<ApplicationManager> Application = new Lazy<ApplicationManager>(() => new ApplicationManager());

        private Dictionary<string, IFactory> _factories;
        private Dictionary<string, IDirector> _directors;
        private Dictionary<string, IRepository> _repos;
        private readonly Dictionary<string, string> _jSONPaths;
        private readonly Dictionary<string, IPCommand> _commands;
        private readonly DataContainer _container;
        private List<string> _readerPaths;
        private Thread? _server;



        private FTRReader _fTRReader;
        private NetworkReader _netReader;

        private ApplicationManager()
        {
            _readerPaths = new()
            {
                @"..\..\..\DataFiles\Source\example_data.ftr",
                @"..\..\..\DataFiles\Source\Test.ftr"
            };

            _jSONPaths = new() {
                {CargoPlane.ClassID, @"..\..\..\DataFiles\JSON\CargoPlane.json"},
                {PassengerPlane.ClassID, @"..\..\..\DataFiles\JSON\PassengerPlane.json"},
                {Cargo.ClassID, @"..\..\..\DataFiles\JSON\Cargo.json"},
                {Passenger.ClassID, @"..\..\..\DataFiles\JSON\Passenger.json"},
                {Crew.ClassID, @"..\..\..\DataFiles\JSON\Crew.json"},
                {Airport.ClassID, @"..\..\..\DataFiles\JSON\Airport.json"},
                {Flight.ClassID, @"..\..\..\DataFiles\JSON\Flight.json"}
            };

            _factories = new()
            {
                { CargoPlane.ClassID, new CargoPlaneFactory() },
                { PassengerPlane.ClassID, new PassengerPlaneFactory() },
                { Cargo.ClassID, new CargoFactory() },
                { Passenger.ClassID, new PassengerFactory() },
                { Crew.ClassID, new CrewFactory() },
                { Airport.ClassID, new AirportFactory() },
                { Flight.ClassID, new FlightFactory() },
            };

            _directors = new() 
            {
                { CargoPlane.ClassID, new CargoPlaneDirector(new CargoPlaneBuilder()) },
                { PassengerPlane.ClassID, new PassengerPlaneDirector(new PassengerPlaneBuilder()) },
                { Cargo.ClassID, new CargoDirector(new CargoBuilder()) },
                { Passenger.ClassID, new PassengerDirector(new PassengerBuilder()) },
                { Crew.ClassID, new CrewDirector(new CrewBuilder()) },
                { Airport.ClassID, new AirportDirector(new AirportBuilder()) },
                { Flight.ClassID, new FlightDirector(new FlightBuilder()) }
            };

            _repos = new()
            {
                { CargoPlane.ClassID, new CargoPlaneRepository() },
                { PassengerPlane.ClassID, new PassengerPlaneRepository() },
                { Cargo.ClassID, new CargoRepository() },
                { Passenger.ClassID, new PassengerRepository() },
                { Crew.ClassID, new CrewRepository() },
                { Airport.ClassID, new AirportRepository() },
                { Flight.ClassID, new FlightRepository() }
            };

            _container = new DataContainer(_repos);

            _commands = new()
            {
                { "print", new Print(_container) },
            };

            _fTRReader = new FTRReader(_readerPaths[0], _factories, _repos);
            _netReader = new NetworkReader(_directors, _repos);
        }

        public static ApplicationManager Instance { get => Application.Value; }

        public Dictionary<string, IFactory> Factories { get => _factories; }
        public Dictionary<string, IRepository> Repos { get => _repos; }
        public Dictionary<string, string> JSONPaths { get => JSONPaths; }
        public List<string> ReaderPaths { get => _readerPaths; }

        public void LoadFTRData()
            => _fTRReader.Read();

        public void LoadNetworkData()
        {
            NSS.IDataSource dataSource = new NSS.NetworkSourceSimulator(ReaderPaths[0], 100, 1000);

            dataSource.OnNewDataReady += OnNewDataReady;

            _netReader = new NetworkReader(_directors, _repos);

            _server = new Thread(dataSource.Run);

            _server.IsBackground = true;

            _server.Start();
        }

        private void OnNewDataReady(object sender, NSS.NewDataReadyArgs e)
        {
            var nss = sender as NSS.NetworkSourceSimulator;

            if (nss is null)
                throw new ArgumentNullException(nameof(nss));

            _netReader.Message = nss.GetMessageAt(e.MessageIndex);

            _netReader.Read();

        }

        public void StartCommandInterpreter()
        {
            string command = string.Empty;

            Console.Write($"{Environment.UserName}$: ");

            while ((command = Console.ReadLine()!) != "exit")
            {
                try
                {
                    if (!_commands.ContainsKey(command))
                        Console.WriteLine("Command not found");

                    _commands[command].Execute();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ShowLoadedData()
        {
            _repos[CargoPlane.ClassID].DisplayObjects();
            _repos[Flight.ClassID].DisplayObjects();
        }
    }
}
