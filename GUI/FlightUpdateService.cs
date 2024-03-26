using OODProj.Data;
using OODProj.IDManagement;
using FlightTrackerGUI;
using OODProj.Repository;
using System.Timers;
using DynamicData;
namespace OODProj.GUI
{
    public class FlightUpdateService
    {
        private readonly FlightRepository _flights;
        private readonly FlightsGUIData _flightsGUIData;
        private readonly FlightGUISetup _setup;
        private readonly System.Timers.Timer _timer;
        private readonly AirportIDManager _airportManager;
        private readonly List<FlightGUI> _flightGUIs;
        public FlightUpdateService(IRepository flights, AirportIDManager airportManager)
        {
            _flightGUIs = new();
            _airportManager = airportManager;
            _flights = (FlightRepository)flights;
            _setup = new FlightGUISetup(airportManager);
            _flightsGUIData = new FlightsGUIData(_flightGUIs);
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            foreach (var flight in _flights.Flights)
            {
               if (flight.TakeoffTime >= currentTime && flight.LandingTime <= currentTime)
                { 
                    var guiItem = _setup.UpdateInfo(flight,  currentTime);

                    if (guiItem.WorldPosition.Latitude <= 90 && guiItem.WorldPosition.Latitude >= -90 &&
                                               guiItem.WorldPosition.Longitude <= 180 && guiItem.WorldPosition.Longitude >= -180)
                    {
                        _flightGUIs.Add(guiItem);
                    }
                }
            }

            _flightsGUIData.UpdateFlights(_flightGUIs);

            Runner.UpdateGUI(_flightsGUIData);
            _flightGUIs.Clear();
        }

        public void StartUpdateGUI() => _timer.Start();
    }
}
