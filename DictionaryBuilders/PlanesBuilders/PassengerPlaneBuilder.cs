using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Logging;
using OODProj.Utilities;

namespace OODProj.DictionaryBuilders.PlanesBuilders
{
    public class PassengerPlaneBuilder : IDictionaryBuilder
    {
        private PassengerPlane _passengerPlane = new();

        public Dictionary<string, Action<string>> BuilderMethods
            => new()
            {
                { "ID", BuildID },
                { "Serial", BuildSerial },
                { "Country", BuildCountry },
                { "Model", BuildModel },
                { "FirstClassSize", BuildFirstClassSize },
                { "BusinessClassSize", BuildBusinessClass },
                { "EconomyClassSize", BuildEconomyClassSize }
            };

        public void BuildID(string value)
             => StorageIDs.AssignID(ulong.Parse(value), _passengerPlane, "PassengerPlane");

        public void BuildSerial(string value)
             => _passengerPlane.Serial = value;
        
        public void BuildCountry(string values)
             => _passengerPlane.Country = values;
       
        public void BuildModel(string values)
             => _passengerPlane.Model = values;
        
        public void BuildFirstClassSize(string value)
             => _passengerPlane.FirstClassSize = ushort.Parse(value);

        public void BuildBusinessClass(string value)
             => _passengerPlane.BusinessClassSize = ushort.Parse(value);

        public void BuildEconomyClassSize(string value)
            => _passengerPlane.EconomyClassSize = ushort.Parse(value);

        public IPrimaryKeyed GetObject() => _passengerPlane;
    }
}
