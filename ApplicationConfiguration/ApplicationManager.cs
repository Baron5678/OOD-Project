using OODProj.AbstractFactories;
using OODProj.AbstractFactories.PlaneFactories;
using OODProj.AbstractFactories.UserFactories;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.Repository;
using OODProj.Repository.PlaneRepositories;
using OODProj.Repository.UserRepositories;
using OODProj.Commands;
using OODProj.IDManagement;
using OODProj.DataSources;
using OODProj.DataSources.MessageConvertors;
using FlightTrackerGUI;
using OODProj.GUI;

namespace OODProj.ApplicationConfiguration
{
    public class ApplicationManager
    {
        private static readonly Lazy<ApplicationManager> Application = new Lazy<ApplicationManager>(() => new ApplicationManager());

        private readonly Dictionary<string, IFactory> _factories;
        private readonly Dictionary<string, IRepository> _repos;
        private readonly Dictionary<string, IMessageConvertor> _convertors;
        private readonly Dictionary<string, IPCommand> _commands;
        private readonly Dictionary<string, string> _jSONPaths;
        private readonly List<string> _readerPaths;
        private readonly DataContainer _container;
        private AirportIDManager _airportIDManager;
        private FlightUpdateService _service;
        private IDataDownloader? _downloader;

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
                { "PA", new PassengerFactory() },
                { Crew.ClassID, new CrewFactory() },
                { "CR", new CrewFactory() },
                { Airport.ClassID, new AirportFactory() },
                { Flight.ClassID, new FlightFactory() },
            };

            _repos = new()
            {
                { CargoPlane.ClassID, new CargoPlaneRepository() },
                { PassengerPlane.ClassID, new PassengerPlaneRepository() },
                { Cargo.ClassID, new CargoRepository() },
                { Passenger.ClassID, new PassengerRepository() },
                { "PA", new PassengerRepository() },
                { Crew.ClassID, new CrewRepository() },
                { "CR", new CrewRepository() },
                { Airport.ClassID, new AirportRepository() },
                { Flight.ClassID, new FlightRepository() }
            };

            _convertors = new()
            {
                { CargoPlane.ClassID, new CargoPlaneMessageConvertor() },
                { PassengerPlane.ClassID, new PassengerPlaneMessageConvertor() },
                { Cargo.ClassID, new CargoMessageConvertor() },
                { Passenger.ClassID, new PassengerMessageConvertor() },
                { "PA", new PassengerMessageConvertor() },
                { Crew.ClassID, new CrewMessageConvertor() },
                { "CR", new CrewMessageConvertor() },
                { Airport.ClassID, new AirportMessageConvertor() },
                { Flight.ClassID, new FlightMessageConvertor() }
            };

            _container = new DataContainer(_repos);

            _commands = new()
            {
                { "print", new Print(_container) },
            };

            _airportIDManager = new();
            _downloader = null;
            _service = new FlightUpdateService(_container.FlightData, _airportIDManager);
        }

        public static ApplicationManager Instance { get => Application.Value; }


        public void LoadFTRData()
        { 
           _downloader = new FTRDownloader(_readerPaths[0], _factories, _repos);
           _downloader.Download();
           _airportIDManager.InitializeByRepo(_container.AirportData);
        }

        public void LoadNetworkData()
        {
            _downloader = new ByteDownloader(_readerPaths[1], _factories, _repos, _convertors);
            _downloader.Download();
        }

        public void StartCommandInterpreter()
        {
            Console.Write($"{Environment.UserName}$: ");

            string command;
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

        public void StartGUI() 
        {
            _service.StartUpdateGUI();
            Runner.Run();
        }

        //for Debug Purposes 
        public void ShowLoadedData()
        {
            _repos[Flight.ClassID].DisplayObjects();
        }
    }
}
