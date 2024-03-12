using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data
{
    public class Cargo : IPrimaryKeyed, ICloneable
    {
        static public string ClassID { get => "CA"; }

        private UInt64 _id;
        private float _weight;
        private string _code;
        private string _description;

        public UInt64 ID { get => _id; set => _id = value; }
        public float Weight { get => _weight; internal set => _weight = value; }
        public string Code { get => _code; internal set => _code = value; }
        public string Description { get => _description; internal set => _description = value; }

        public Cargo()
        {
            _id = default;
            _weight = default;
            _code = string.Empty;
            _description = string.Empty;
        }

        public Cargo(UInt64 id, float weight, string code, string description)
        {
            _id = id;
            _weight = weight;
            _code = code;
            _description = description;
        }

        public override string ToString()
        {
            return $"[Cargo]\nID: {_id}\n Weight: {_weight}\n Code: {_code}\n Description: {_description}\n";
        }

        public object Clone()
        {
            return new Cargo(_id, _weight, _code, _description);
        }
    }
}
