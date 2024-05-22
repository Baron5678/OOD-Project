using OODProj.Data;
using OODProj.Data.Users;
using OODProj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.DictionaryBuilders.UserBuilders
{
    public class PassengerBuilder : IDictionaryBuilder
    {
        private Passenger _passenger = new();

        public Dictionary<string, Action<string>> BuilderMethods
            => new()
            {
                { "ID", BuildID },
                { "Name", BuildName },
                { "Age", BuildAge },
                { "Phone", BuildPhone },
                { "Email", BuildEmail },
                { "Class", BuildClass },
                { "Miles", BuildMiles }
            };

        public void BuildID(string value)
            => StorageIDs.AssignID(ulong.Parse(value), _passenger, "Passenger");

        public void BuildName(string value)
            => _passenger.Name = value;

        public void BuildAge(string value)
            => _passenger.Age = ulong.Parse(value);

        public void BuildPhone(string value)
            => _passenger.Phone = value;

        public void BuildEmail(string value)
            => _passenger.Email = value;

        public void BuildClass(string value)
            => _passenger.Class = value;

        public void BuildMiles(string value)
            => _passenger.Miles = ulong.Parse(value);

        public IPrimaryKeyed GetObject() => _passenger;
    }
}
