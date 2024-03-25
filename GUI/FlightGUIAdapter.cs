using Mapsui.Projections;
using OODProj.Data;
using OODProj.IDManagement;

namespace OODProj.GUI
{
    internal class FlightGUIAdapter : FlightGUI
    {
        private readonly Flight _flight;
        private AirportIDManager _manager;

        public FlightGUIAdapter(Flight flight, AirportIDManager manager, TimeOnly currentTime)
        {
            _manager = manager;
            _flight = flight;

            var position = SetCurrentWorldPosition(flight, currentTime);

            ID = flight.ID;
            WorldPosition = position;
            MapCoordRotation = SetMapCoordRotation(_manager.GetAirport(flight.IDOrigin), position);

        }

        private WorldPosition SetCurrentWorldPosition(Flight flight, TimeOnly currentTime)
        {
            var originAirport = _manager.GetAirport(flight.IDOrigin);
            var targetAirport = _manager.GetAirport(flight.IDTarget);

            var totalDuration = (flight.LandingTime - flight.TakeoffTime).TotalSeconds;
            var elapsedTime = (currentTime - flight.TakeoffTime).TotalSeconds;
            var factor = elapsedTime / totalDuration;

            var interpolatedLongitude = double.Lerp(originAirport.Longitude, targetAirport.Longitude, factor);
            var interpolatedLatitude = double.Lerp(originAirport.Latitude, targetAirport.Latitude, factor);

            Console.WriteLine($"Interpolated position: {interpolatedLatitude};{interpolatedLongitude}");

            return new WorldPosition(interpolatedLongitude, interpolatedLatitude);
        }

        private double SetMapCoordRotation(Airport airportOrigin, WorldPosition current)
        {
            (double currentX, double currentY) = SphericalMercator.FromLonLat(current.Longitude, current.Latitude);
            (double originX, double originY) = SphericalMercator.FromLonLat(airportOrigin.Longitude, airportOrigin.Latitude);

            double deltaY = current.Latitude - airportOrigin.Latitude;
            double deltaX = current.Longitude - airportOrigin.Longitude;

            return Math.Atan2(deltaY, deltaX);
        }
    }
}
