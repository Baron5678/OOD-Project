using Mapsui.Projections;
using OODProj.Data;
using OODProj.IDManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.GUI
{
    public class FlightGUISetup 
    {
        private AirportIDManager _manager;
     
        public FlightGUISetup(AirportIDManager manager)
           => _manager = manager;

        public FlightGUI UpdateInfo(Flight flight, TimeOnly current)
        {
            var position = SetCurrentWorldPosition(flight, current);

           return new FlightGUI
           {
               ID = flight.ID,
               WorldPosition = position,
               MapCoordRotation = SetMapCoordRotation(_manager.GetAirport(flight.IDOrigin), _manager.GetAirport(flight.IDTarget))
           };
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

        private double SetMapCoordRotation(Airport airportOrigin, Airport airportTarget)
        {
            (double currenX, double currentY) = SphericalMercator.FromLonLat(airportTarget.Longitude, airportTarget.Latitude);
            (double originX, double originY) = SphericalMercator.FromLonLat(airportOrigin.Longitude, airportOrigin.Latitude);

            double deltaY = airportTarget.Latitude - airportOrigin.Latitude;
            double deltaX = airportTarget.Longitude - airportOrigin.Longitude;

            return Math.Atan2(deltaY, deltaX);
        }

    }
}
