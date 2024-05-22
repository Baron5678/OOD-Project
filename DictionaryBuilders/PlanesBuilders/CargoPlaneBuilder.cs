using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.Utilities;
using OODProj.Data;
using OODProj.Logging;

namespace OODProj.DictionaryBuilders.PlanesBuilders
{
    public class CargoPlaneBuilder : IDictionaryBuilder
    {
        private CargoPlane _plane = new();

        public Dictionary<string, Action<string>> BuilderMethods 
            =>  new()
            {
                { "ID", BuildID },
                { "Serial", BuildSerial },
                { "Country", BuildCountry },
                { "Model", BuildModel },
                { "MaxLoad", BuildMaxLoad }
            };

      
        public void BuildID(string value)
            => StorageIDs.AssignID(ulong.Parse(value), _plane, "CargoPlane");
        
        public void BuildSerial(string values)
            => _plane.Serial = values;
        
        public void BuildCountry(string values)
            => _plane.Country = values;
        
        public void BuildModel(string values)
            => _plane.Model = values;

        public void BuildMaxLoad(string values)
            => _plane.MaxLoad = float.Parse(values);
       
        public IPrimaryKeyed GetObject() => _plane;
    }
}