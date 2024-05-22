using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Utilities;

namespace OODProj.DictionaryBuilders
{
    public class CargoBuilder : IDictionaryBuilder
    {
        private Cargo _cargo = new();

        public Dictionary<string, Action<string>> BuilderMethods
            => new()
            {
                { "ID", BuildID },
                { "Weight", BuildWeight },
                { "Code", BuildCode },
                { "Description", BuildDescription }
            };

        public void BuildID(string value)
            => StorageIDs.AssignID(ulong.Parse(value), _cargo, "Cargo");
   
        public void BuildWeight(string value)
            => _cargo.Weight = float.Parse(value);

        public void BuildCode(string value)
            => _cargo.Code = value;

        public void BuildDescription(string value)
            => _cargo.Description = value;

        public IPrimaryKeyed GetObject() => _cargo; 
    }
}
