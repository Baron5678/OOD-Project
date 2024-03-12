using OODProj.Data;
using OODProj.Data.Users;
using OODProj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Builders.UserBuilders
{
    public class CrewBuilder : IBuilder
    {
        private Crew _crew = new();

        public void BuildID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");

            _crew.ID = BitConverter.ToUInt64(value);
        }
        public void BuildName(byte[] value)
        {
            _crew.Name = Utility.BytesToString(value);
        }

        public void BuildAge(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("Age must be 2 bytes long");

            _crew.Age = BitConverter.ToUInt16(value);
        }

        public void BuildPhone(byte[] value)
        {
            _crew.Phone = Utility.BytesToString(value);
        }

        public void BuildEmail(byte[] value)
        {
            _crew.Email = Utility.BytesToString(value);
        }

        public void BuildPractice(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("Practice must be 2 bytes long");

            _crew.Practice = BitConverter.ToUInt16(value);
        }

        public void BuildRole(byte[] value)
        {
            _crew.Role = Utility.BytesToString(value);
        }

        public IPrimaryKeyed GetResult() => _crew;

    }
}
