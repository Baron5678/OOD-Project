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
    public class PassengerBuilder : IBuilder
    {
        private Passenger _passenger = new();

        public void BuildID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            _passenger.ID = BitConverter.ToUInt64(value);
        }

        public void BuildName(byte[] value)
        {
            _passenger.Name = Utility.BytesToString(value);
        }

        public void BuildAge(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("Age must be 2 bytes long");
            _passenger.Age = BitConverter.ToUInt16(value);
        }

        public void BuildPhone(byte[] value)
        {
            _passenger.Phone = Utility.BytesToString(value);
        }

        public void BuildEmail(byte[] value)
        {
            _passenger.Email = Utility.BytesToString(value);
        }

        public void BuildClass(byte[] value)
        {
            _passenger.Class = Utility.BytesToString(value);
        }

        public void BuildMiles(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("Seat must be 2 bytes long");

            _passenger.Miles = BitConverter.ToUInt64(value);
        }
        public IPrimaryKeyed GetResult() => _passenger;
    }
}
