using OODProj.Data;
using OODProj.Logging;
using OODProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.IDManagement
{
    public class AirportManagerID : IManagerID
    {
        private Dictionary<ulong, Airport> airportHashTable;

        public AirportManagerID()
        {
            airportHashTable = new();
        }

        public void AddPrimaryKeyedObject(IPrimaryKeyed pkobj)
        {
            if (airportHashTable.ContainsKey(pkobj.ID))
                throw new ArgumentException("Airport with this ID already exists");
            var airport = pkobj as Airport;
            if (airport is null)
                throw new ArgumentException("IPrimaryKeyedObject is not an Airport");
            airportHashTable.Add(pkobj.ID, airport);
        }

        public IPrimaryKeyed GetPrimaryKeyedObject(ulong id)
        {
            if (!airportHashTable.ContainsKey(id))
                throw new ArgumentException("IPrimaryKeyedObject with this ID does not exist");
            return airportHashTable[id];
        }

        public void InitializeByRepo(IRepository repo)
        {
            var airportRepo = repo as AirportRepository;
            if (airportRepo is null)
                throw new ArgumentException("Repository is not an AirportRepository");
            foreach (var airport in airportRepo.Airports)
                AddPrimaryKeyedObject(airport);
        }

        public ulong AssignPrimaryKeyedID(ulong newID, string className)
        {
            if (airportHashTable.ContainsKey(newID))
            {
                return newID;
            } 
            else
            {
                ErrorState err = new()
                {
                    ErrorMessage = "This ID is Airport ID, choose Airport ID",
                    ObjectName = className
                };
                Log.Instance.LogWrite(err);
                return default;
            }
        }
    }
}
