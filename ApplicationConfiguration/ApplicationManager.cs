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
using OODProj.UpdateDataService;
using OODProj.Data.Observers;
using OODProj.DictionaryBuilders;
using OODProj.DictionaryBuilders.PlanesBuilders;
using OODProj.DictionaryBuilders.UserBuilders;

namespace OODProj.ApplicationConfiguration
{
    public class ApplicationManager
    {
        private static readonly Lazy<ApplicationManager> Application = new Lazy<ApplicationManager>(() => new ApplicationManager());

        private readonly Dictionary<string, IFactory> _factories;
        private readonly Dictionary<string, IDictionaryBuilder> _builders;
        private readonly Dictionary<string, IRepository> _repos;
        private readonly Dictionary<string, IMessageConvertor> _convertors;
        private readonly Dictionary<string, IManagerID> _managers;
        private readonly Dictionary<string, IPCommand> _commands;
        private readonly Dictionary<string, string> _jSONPaths;
        private readonly List<string> _readerPaths;
        private readonly DataContainer _container;
        private FlightUpdateService _service;
        private IDataDownloader? _downloader;
        private List<INewsProvider> _newsProviders;
        private List<IReportable> _reportables;
        private List<string> _reportableIDs;
        private NewsGenerator _newsGenerator;
        private DownloaderSettings? _downloaderSettings;
        private UpdateService _updater;
        private ObserverInitializator _observerInitializator;

        private ApplicationManager()
        {
            _readerPaths = new()
            {
                @"..\..\..\DataFiles\Source\example_data.ftr",
                @"..\..\..\DataFiles\Source\Test.ftr",
                @"..\..\..\DataFiles\Source\example.ftre"
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
            _observerInitializator = new();
            _factories = new()
            {
                { CargoPlane.ClassID, new CargoPlaneFactory(_observerInitializator) },
                { PassengerPlane.ClassID, new PassengerPlaneFactory(_observerInitializator) },
                { Cargo.ClassID, new CargoFactory(_observerInitializator) },
                { Passenger.ClassID, new PassengerFactory(_observerInitializator) },
                { "PA", new PassengerFactory(_observerInitializator) },
                { Crew.ClassID, new CrewFactory(_observerInitializator) },
                { "CR", new CrewFactory(_observerInitializator) },
                { Airport.ClassID, new AirportFactory(_observerInitializator) },
                { Flight.ClassID, new FlightFactory(_observerInitializator) },
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

            _managers = new() 
            {
                { Airport.ClassID, new AirportManagerID() }
            };

            _builders = new()
            {
                { "CargoPlane", new CargoPlaneBuilder() },
                { "PassengerPlane", new PassengerPlaneBuilder() },
                { "Cargo", new CargoBuilder() },
                { "Passenger", new PassengerBuilder() },
                { "Crew", new CrewBuilder() },
                { "Airport", new AirportBuilder() },
                { "Flight", new FlightBuilder(_managers[Airport.ClassID]) }
            };

            _newsProviders = new()
            {
                new Television("Abelian Television"),
                new Television("Channel TV-Tensor"),
                new Radio("Quantifier radio"),
                new Radio("Shmem radio"),
                new Newspaper("Categories Journal"),
                new Newspaper("Polytechnical Gazette")
            };
            _reportables = [];
            _reportableIDs = ["AI", "CP", "PP"];
            _container = new DataContainer(_repos);
            _newsGenerator = new(_newsProviders, _reportables);
            _commands = new()
            {
                { "print", new Print(_container) },
                { "report", new Report(_newsGenerator) },
                { "display", new Display(_repos) },
                { "update", new Update(_repos) },
                { "delete", new Delete(_repos) },
                { "add", new Add(_repos, _builders) },
            };
            _repos.Add("Cargo", _repos[Cargo.ClassID]);
            _repos.Add("CargoPlane", _repos[CargoPlane.ClassID]);
            _repos.Add("Passenger", _repos[Passenger.ClassID]);
            _repos.Add("PassengerPlane", _repos[PassengerPlane.ClassID]);
            _repos.Add("Crew", _repos[Crew.ClassID]);
            _repos.Add("Airport", _repos[Airport.ClassID]);
            _repos.Add("Flight", _repos[Flight.ClassID]);
            _downloader = null;
            _downloaderSettings = null;
            _service = new FlightUpdateService(_container.FlightData, _managers[Airport.ClassID]);
            _updater = new UpdateService(_readerPaths[2]);
        }

        public static ApplicationManager Instance { get => Application.Value; }


        public void LoadFTRData()
        {
            if (_downloaderSettings is ByteDownloaderSettings)
                _downloaderSettings = null;
            if (_downloaderSettings is null) 
                _downloaderSettings = new FTRDownloaderSettings(_readerPaths[0], 
                                                                _factories, 
                                                                _repos, 
                                                                _managers,
                                                                _reportables,
                                                                _reportableIDs);
           _downloader = new FTRDownloader(_downloaderSettings);
           _downloader.Download();
            _observerInitializator.SetUpRelation();

        }

        public void LoadNetworkData()
        {
            if (_downloaderSettings is FTRDownloaderSettings)
                _downloaderSettings = null;
            if (_downloaderSettings is null)
                _downloaderSettings = new ByteDownloaderSettings(_readerPaths[0], 
                                                                _factories, 
                                                                _repos, 
                                                                _convertors, 
                                                                _managers, 
                                                                _reportables, 
                                                                _reportableIDs);
            _downloader = new ByteDownloader(_downloaderSettings);
            _downloader.Download();
        }

        public void StartCommandInterpreter()
        {
            Console.Write($"{Environment.UserName}$: ");
            string command;
            List<string> set;
            while ((command = Console.ReadLine()!) != "exit")
            {
                try
                {
                    set = [.. command.Split(' ')];
                    if (!_commands.ContainsKey(set[0]))
                        Console.WriteLine("Command not found");
                    if (set.Count != 1)
                    {
                        _commands[set[0]].Parameters = set[1..];
                    }

                    _commands[set[0]].Execute();
                    Console.Write($"{Environment.UserName}$: ");
                }
                catch (ArgumentException ex)
                {
                    Console.Write($"{Environment.UserName}$: ");
                    Console.WriteLine(ex.Message);
                }
                catch (KeyNotFoundException ex)
                {
                    Console.Write($"{Environment.UserName}$: ");
                    Console.WriteLine(ex.Message);

                }
            }
        }

        public void UpdateData() 
        { 
           _updater.Update();
        }

        public void StartGUI() 
        {
            _service.StartUpdateGUI();
            Runner.Run();
        }

        public void StartGUIAsync()
        {
            var guiRunner = new Thread(StartGUI);
            guiRunner.IsBackground = true;
            guiRunner.Start();
        }

        //for Debug Purposes 
        public void ShowLoadedData()
        {
            _repos[Flight.ClassID].DisplayObjects();
        }
    }
}
