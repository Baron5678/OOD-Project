using OODProj.Data;
using OODProj.IDManagement;
using FlightTrackerGUI;
using OODProj.Repository;
using System.Timers;
namespace OODProj.GUI
{
    public class FlightUpdateService
    {
        private readonly FlightRepository _flights;
        private readonly FlightsGUIData _flightsGUIData;
        private readonly FlightGUISetup _setup;
        private readonly System.Timers.Timer _timer;

        public FlightUpdateService(IRepository flights, AirportIDManager airportManager)
        {
            _flights = (FlightRepository)flights;
            _setup = new FlightGUISetup(airportManager);
            _flightsGUIData = new FlightsGUIData();
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

            List<FlightGUI> flightGUIs = new();
            foreach (var flight in _flights.Flights)
            {
                //if(flight.TakeoffTime >= currentTime && flight.LandingTime <= currentTime)
                 flightGUIs.Add(_setup.UpdateInfo(flight, currentTime));
            }

            _flightsGUIData.UpdateFlights(flightGUIs);

            Runner.UpdateGUI(_flightsGUIData);
        }

        public void StartUpdateGUI() => _timer.Start();
    }
}
