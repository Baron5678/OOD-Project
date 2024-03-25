using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstractFactories
{
    public class AirportFactory : IFactory
    {
        private List<string> _objectData = [];

        public IFactory SetObjectData(string[] data)
        {
            _objectData = [.. data];
            return this;
        }

        public IPrimaryKeyed Create()
        {
            return new Airport(ulong.Parse(_objectData[0]),
                                _objectData[1],
                                _objectData[2],
                                float.Parse(_objectData[3]),
                                float.Parse(_objectData[4]),
                                float.Parse(_objectData[5]),
                                _objectData[6]);
        }

        public void ResetObjectData() => _objectData = [];

    }
}
