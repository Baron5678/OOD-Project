using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data
{
    public class Cargo : IDisplayable, ICloneable
    {
        static public string ObjectID { get => "CA"; }

        private UInt64 _id;
        private string _weight;
        private string _code;
        private string _description;

        public UInt64 ID { get => _id; set => _id = value; }
        public string Weight { get => _weight; set => _weight = value; }
        public string Code { get => _code; set => _code = value; }
        public string Description { get => _description; set => _description = value; }

        public Cargo()
        {
            _id = default;
            _weight = string.Empty;
            _code = string.Empty;
            _description = string.Empty;
        }

        public Cargo(UInt64 id, string weight, string code, string description)
        {
            _id = id;
            _weight = weight;
            _code = code;
            _description = description;
        }

        public override string ToString()
        {
            return $"ID: {_id}\n Weight: {_weight}\n Code: {_code}\n Description: {_description}";
        }

        public object Clone()
        {
            return new Cargo(_id, _weight, _code, _description);
        }
    }
}
