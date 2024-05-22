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
    public class CrewBuilder : IDictionaryBuilder
    {
        private Crew _crew = new();

        public Dictionary<string, Action<string>> BuilderMethods
            => new()
            {
                { "ID", BuildID },
                { "Name", BuildName },
                { "Age", BuildAge },
                { "Phone", BuildPhone },
                { "Email", BuildEmail },
                { "Practice", BuildPractice },
                { "Role", BuildRole }
            };

        public void BuildID(string value)
            => StorageIDs.AssignID(ulong.Parse(value), _crew, "Crew");

        public void BuildName(string value)
            => _crew.Name = value;

        public void BuildAge(string value)
            => _crew.Age = ulong.Parse(value);

        public void BuildPhone(string value)
            => _crew.Phone = value;

        public void BuildEmail(string value)
            => _crew.Email = value;

        public void BuildPractice(string value)
            => _crew.Practice = ushort.Parse(value);

        public void BuildRole(string value)
            => _crew.Role = value;

        public IPrimaryKeyed GetObject() => _crew;

    }
}
