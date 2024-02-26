using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data
{
    public class Airport: IPrimaryKeyed, ICloneable
    {
        static public string ObjectID { get => "AI"; }

        private UInt64 _id;
        private string _name;
        private string _code;
        private float _longitude;
        private float _latitude;
        private float _AMSL;
        private string _country;

    
        public UInt64 ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Code { get => _code; set => _code = value; }
        public float Longitude { get => _longitude; set => _longitude = value; }
        public float Latitude { get => _latitude; set => _latitude = value; }
        public float AMSL { get => _AMSL; set => _AMSL = value; }
        public string Country { get => _country; set => _country = value; }

        public Airport()
        {
            _id = default;
            _name = string.Empty;
            _code = string.Empty;
            _longitude = default;
            _latitude = default;
            _AMSL = default;
            _country = string.Empty;
        }


        public Airport(UInt64 id, string name, string code, float longitude, float latitude, float amsl, string country)
        {
            _id = id;
            _name = name;
            _code = code;
            _longitude = longitude;
            _latitude = latitude;
            _AMSL = amsl;
            _country = country;
        }

        public override string ToString()
        {
            return $"ID: {_id}\n Name: {_name}\n Code: {_code}\n Longitude: {_longitude}\n Latitude: {_latitude}\n AMSL: {_AMSL}\n Country: {_country}";
        }

        public object Clone()
        {
            return new Airport(_id, _name, _code, _longitude, _latitude, _AMSL, _country);
        }

        public string GetObjectID()
        {
            return ObjectID;
        }
    }
}
