using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OODProj.Data;
using OODProj.Utilities;

namespace OODProj.Builders
{
    public class CargoBuilder : IBuilder
    {
        private Cargo _cargo = new();

        public void BuildID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            _cargo.ID = BitConverter.ToUInt64(value);
        }
   
        public void BuildWeight(byte[] value)
        {
            if (value.Length != 4)
                throw new ArgumentException("Weight must be 8 bytes long");
            _cargo.Weight = BitConverter.ToSingle(value);
        }

        public void BuildCode(byte[] value)
        { 
            _cargo.Code = Utility.BytesToString(value);
        }

        public void BuildDescription(byte[] value)
        {
            _cargo.Description = Utility.BytesToString(value);
        }

        public IPrimaryKeyed GetResult() => _cargo; 
    }
}
