using OODProj.Data;
using OODProj.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstractFactories
{
    public class CargoFactory : IFactory
    { 
        private List<string> _objectData = new();

        public IFactory SetObjectData (string[] data)
        {
            _objectData = [.. data];

            return this;
        }

        public void ResetObjectData() 
        {
            _objectData = new();
        }

        public IPrimaryKeyed Create()
        {
            return new Cargo(ulong.Parse(_objectData[0]),
                              float.Parse(_objectData[1]),
                              _objectData[2],
                              _objectData[3]);
        }
    }
}
