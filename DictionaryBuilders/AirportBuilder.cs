using OODProj.Data;
using OODProj.Logging;
using OODProj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.DictionaryBuilders
{
    public class AirportBuilder : IDictionaryBuilder
    {
        private Airport _airport = new();

        public Dictionary<string, Action<string>> BuilderMethods
            => new()
            {
                { "ID", BuildID },
                { "Name", BuildName },
                { "Code", BuildCode },
                { "Longitude", BuildLongitude }, 
                { "Latitude", BuildLatitude },
                { "AMSL", BuildAMSL },
                { "Country", BuildCountry }
            };

        public void BuildID(string value)
            => StorageIDs.AssignID(ulong.Parse(value), _airport, "Airport");
      
        public void BuildName(string value)
            => _airport.Name = value;
        
        public void BuildCode(string value)
            => _airport.Code = value;
        
        public void BuildLongitude(string value)
            => _airport.Longitude = float.Parse(value);
        
        public void BuildLatitude(string value)
            => _airport.Latitude = float.Parse(value);
       
        public void BuildAMSL(string value)
            =>  _airport.Longitude = float.Parse(value);
        
        public void BuildCountry(string value)
            => _airport.Country = value;

        public IPrimaryKeyed GetObject() => _airport;
    }
}
