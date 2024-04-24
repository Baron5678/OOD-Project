using Mapsui.Projections;
using OODProj.Data;
using OODProj.IDManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.GUI
{
    public class FlightGUISetupDecorator(IManagerID manager) : FlightGUISetup(manager)
    {
    
        public override FlightGUI UpdateInfo(Flight flight, TimeOnly current)
        {
            var target = GetAirport(flight.IDTarget);

            // Using flight's current position as 'origin'
            var position = CalculateWorldPosition(flight.Longitude, flight.Latitude, target.Longitude, target.Latitude, flight, current);
            return new FlightGUI
            {
                ID = flight.ID,
                WorldPosition = position,
                MapCoordRotation = CalculateMapCoordRotation(flight.Longitude, flight.Latitude, target.Longitude, target.Latitude)
            };
        }
    }
}
