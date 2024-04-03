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
using OODProj.NewsReport;

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
        private List<INewsProvider> _newsProviders;
        private List<IReportable> _reportables;
        private NewsGenerator _newsGenerator;

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
            _newsProviders = new()
            {
                new Television("Abelian Television"),
                new Television("Channel TV-Tensor"),
                new Radio("Quantifier radio"),
                new Radio("Shmem radio"),
                new Newspaper("Categories Journal"),
                new Newspaper("Polytechnical Gazette")
            };
            _reportables = new();
            _newsGenerator = new(_newsProviders, _reportables );

            _commands = new()
            {
                { "print", new Print(_container) },
                { "report", new Report(_newsGenerator) },
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
           _reportables.AddRange(_container.AirportData.Airports);
           _reportables.AddRange(_container.CargoPlaneData.CargoPlanes);
           _reportables.AddRange(_container.PassengerPlaneData.PassengerPlane);
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
                    Console.Write($"{Environment.UserName}$: ");
                }
                catch (ArgumentException ex)
                {
                    Console.Write($"{Environment.UserName}$: ");
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
