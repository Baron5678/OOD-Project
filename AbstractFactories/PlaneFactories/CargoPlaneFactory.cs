using OODProj.Data;
using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstractFactories.PlaneFactories
{
    public class CargoPlaneFactory : IFactory
    {
        private List<string> _objectData = [];

        public IFactory SetObjectData(string[] data)
        {
            _objectData = [.. data];
            return this;
        }

        public IPrimaryKeyed Create()
        {
            return new CargoPlane(ulong.Parse(_objectData[0]),
                                   _objectData[1],
                                   _objectData[2],
                                   _objectData[3],
                                   float.Parse(_objectData[4]));
        }

        public void ResetObjectData() => _objectData = [];

    }
}
