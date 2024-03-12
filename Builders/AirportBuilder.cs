using OODProj.Data;
using OODProj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Builders
{
    public class AirportBuilder : IBuilder
    {
        private Airport _airport = new();

        public void BuildID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            _airport.ID = BitConverter.ToUInt64(value);
        }
        public void BuildName(byte[] value)
        {
            _airport.Name = Utility.BytesToString(value);
        }
        public void BuildCode(byte[] value)
        {
            _airport.Code = Utility.BytesToString(value);
        }
        public void BuildLongitude(byte[] value)
        {
            if (value.Length != 4)
                throw new ArgumentException("Longitude must be 4 bytes long");
            _airport.Longitude = BitConverter.ToSingle(value);
        }

        public void BuildLatitude(byte[] value)
        {
            if (value.Length != 4)
                throw new ArgumentException("Longitude must be 4 bytes long");
            _airport.Longitude = BitConverter.ToSingle(value);
        }


        public void BuildAMSL(byte[] value)
        {
            if (value.Length != 4)
                throw new ArgumentException("AMSL must be 4 bytes long");
            _airport.Longitude = BitConverter.ToSingle(value);
        }

        public void BuildCountry(byte[] value)
        {
            _airport.Country = Utility.BytesToString(value);
        }

        public IPrimaryKeyed GetResult() => _airport;
    }
}
