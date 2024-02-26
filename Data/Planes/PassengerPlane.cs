using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data.Planes
{
    public class PassengerPlane : IPlane, ICloneable
    {
        static public string ObjectID { get => "PP"; }

        private ulong _id;
        private string _serial;
        private string _country;
        private string _model;
        private ushort _firstClassSize;
        private ushort _businessClassSize;
        private ushort _economyClassSize;

        public ulong ID { get => _id; set => _id = value; }
        public string Serial { get => _serial; set => _serial = value; }
        public string Country { get => _country; set => _country = value; }
        public string Model { get => _model; set => _model = value; }
        public ushort FirstClassSize { get => _firstClassSize; set => _firstClassSize = value; }
        public ushort BusinessClassSize { get => _businessClassSize; set => _businessClassSize = value; }
        public ushort EconomyClassSize { get => _economyClassSize; set => _economyClassSize = value; }

        public PassengerPlane()
        {
            _id = default;
            _serial = string.Empty;
            _country = string.Empty;
            _model = string.Empty;
            _firstClassSize = default;
            _businessClassSize = default;
            _economyClassSize = default;
        }

        public PassengerPlane(ulong id, string serial, string country, string model, ushort firstClassSize, ushort businessClassSize, ushort economyClassSize)
        {
            _id = id;
            _serial = serial;
            _country = country;
            _model = model;
            _firstClassSize = firstClassSize;
            _businessClassSize = businessClassSize;
            _economyClassSize = economyClassSize;
        }

        public override string ToString()
        {
            return $"ID: {_id}\n Serial: {_serial}\n Country: {_country}\n Model: {_model}\n First Class Size: {_firstClassSize}\n Business Class Size: {_businessClassSize}\n Economy Class Size: {_economyClassSize}";
        }

        public object Clone()
        {
            return new PassengerPlane(_id, _serial, _country, _model, _firstClassSize, _businessClassSize, _economyClassSize);
        }

    }
}
