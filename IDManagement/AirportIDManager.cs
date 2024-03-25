using BruTile.Wms;
using OODProj.Data;
using OODProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.IDManagement
{
    public class AirportIDManager
    {
        private Dictionary<ulong, Airport> airportHashTable;

        public AirportIDManager()
        {
            airportHashTable = new();
        }

        public void AddAirport(Airport airport)
        {
            if (airportHashTable.ContainsKey(airport.ID))
                throw new ArgumentException("Airport with this ID already exists");
            airportHashTable.Add(airport.ID, airport);
        }

        public Airport GetAirport(ulong id)
        {
            if (!airportHashTable.ContainsKey(id))
                throw new ArgumentException("Airport with this ID does not exist");
            return airportHashTable[id];
        }

        public void InitializeByRepo(AirportRepository repo) 
        {
            foreach (var airport in repo.Airports)
                AddAirport(airport);
        }
    }
}
