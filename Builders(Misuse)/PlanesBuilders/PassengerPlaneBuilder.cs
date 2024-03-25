using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Utilities;

namespace OODProj.Builders.PlanesBuilders
{
    public class PassengerPlaneBuilder : IBuilder
    {
        private PassengerPlane _passengerPlane = new();

        public void BuildID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            _passengerPlane.ID = BitConverter.ToUInt64(value);
        }

        public void BuildSerial(byte[] value)
        {
            _passengerPlane.Serial = Utility.BytesToString(value);
        }

        public void BuildCountry(byte[] values)
        {
            _passengerPlane.Country = Utility.BytesToString(values);
        }

        public void BuildModel(byte[] values)
        {
            _passengerPlane.Model = Utility.BytesToString(values);
        }

        public void BuildFirstClassSize(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("FirstClassSize must be 2 bytes long");

            _passengerPlane.FirstClassSize = BitConverter.ToUInt16(value);
        }

        public void BuildBusinessClass(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("BusinessClassSize must be 2 bytes long");

            _passengerPlane.BusinessClassSize = BitConverter.ToUInt16(value);
        }

        public void BuildEconomyClassSize(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("EconomyClassSize must be 2 bytes long");

            _passengerPlane.EconomyClassSize = BitConverter.ToUInt16(value);
        }

        public IPrimaryKeyed GetResult() => _passengerPlane;
    }
}
