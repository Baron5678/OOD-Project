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
        protected IManagerID _manager;

        public FlightGUISetup(IManagerID manager)
        {
            _manager = manager as AirportManagerID ?? throw new InvalidCastException("Manager must be of type AirportManagerID");
        }

        virtual public FlightGUI UpdateInfo(Flight flight, TimeOnly current)
        {
            var origin = GetAirport(flight.IDOrigin);
            var target = GetAirport(flight.IDTarget);

            var position = CalculateWorldPosition(origin.Longitude, origin.Latitude, target.Longitude, target.Latitude, flight, current);
            return new FlightGUI
            {
                ID = flight.ID,
                WorldPosition = position,
                MapCoordRotation = CalculateMapCoordRotation(origin.Longitude, origin.Latitude, target.Longitude, target.Latitude)
            };
        }

        protected WorldPosition CalculateWorldPosition(double originLongitude, double originLatitude, double targetLongitude, double targetLatitude, Flight flight, TimeOnly currentTime)
        {
            var totalDuration = (flight.LandingTime - flight.TakeoffTime).TotalSeconds;
            var elapsedTime = (currentTime - flight.TakeoffTime).TotalSeconds;
            var factor = elapsedTime / totalDuration;

            var interpolatedLongitude = double.Lerp(originLongitude, targetLongitude, factor);
            var interpolatedLatitude = double.Lerp(originLatitude, targetLatitude, factor);

            return new WorldPosition(interpolatedLongitude, interpolatedLatitude);
        }

        protected double CalculateMapCoordRotation(double originLongitude, double originLatitude, double targetLongitude, double targetLatitude)
        {
            double deltaY = targetLatitude - originLatitude;
            double deltaX = targetLongitude - originLongitude;

            return Math.Atan2(deltaY, deltaX);
        }

        protected Airport GetAirport(ulong airportId)
        {
            return _manager.GetPrimaryKeyedObject(airportId) as Airport ?? throw new InvalidOperationException("Object is not an Airport");
        }

    }
}
