using OODProj.NewsReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data.Planes
{
    public class CargoPlane : IPlane, ICloneable, IReportable
    {
        static public string ClassID { get => "CP"; }

        private ulong _id;
        private string _serial;
        private string _country;
        private string _model;
        private float _maxload;

        public ulong ID { get => _id; set => _id = value; }
        public string Serial { get => _serial; set => _serial = value; }
        public string Country { get => _country; set => _country = value; }
        public string Model { get => _model; set => _model = value; }
        public float MaxLoad { get => _maxload; set => _maxload = value; }
    
        public CargoPlane()
        {
            _id = default;
            _serial = string.Empty;
            _country = string.Empty;
            _model = string.Empty;
            _maxload = default;
        }

        public CargoPlane(ulong id, string serial, string country, string model, float maxload)
        {
            _id = id;
            _serial = serial;
            _country = country;
            _model = model;
            _maxload = maxload;
        }

        public override string ToString()
        {
            return $"[CargoPlane]\n ID: {_id}\n Serial: {_serial}\n Country: {_country}\n Model: {_model}\n Max Load: {_maxload}\n";
        }

        public object Clone()
        {
            return new CargoPlane(_id, _serial, _country, _model, _maxload);
        }

        public string Accept(INewsProvider provider)
            => provider.Visit(this);
        
    }
}
