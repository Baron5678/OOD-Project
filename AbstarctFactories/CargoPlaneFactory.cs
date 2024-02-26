using OODProj.Data;
using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstarctFactories
{

    public class CargoPlaneFactory : IFactory
    {
        private CargoPlane _plane;

        public CargoPlaneFactory() => _plane = new CargoPlane();

        public CargoPlaneFactory SetID(string val) 
        {
            ulong id = ulong.Parse(val);

            return this;
        }

        public CargoPlaneFactory SetSerial(string val)
        {
            _plane.Serial = val;
            return this;
        }

        public CargoPlaneFactory SetCountry(string val)
        {
            _plane.Country = val;
            return this;
        }

        public CargoPlaneFactory SetModel(string val)
        {
            _plane.Model = val;
            return this;
        }

        public CargoPlaneFactory SetMaxLoad(string val)
        {
            float maxload = float.Parse(val);
            _plane.MaxLoad = maxload;
            return this;
        }

        public ICreateFactory SetValues(List<string> args)
        {
            if (args.Count != 6)
            {
                throw new ArgumentException("Invalid number of arguments");
            }
            SetID(args[1])
                .SetSerial(args[2])
                .SetCountry(args[3])
                .SetModel(args[4])
                .SetMaxLoad(args[5]);

            return this;
        }

        public IPrimaryKeyed Create()
        {
            return _plane;
        }

        public IPrimaryKeyed Create(List<string> atomicVals, List<List<string>> arrayVals)
        {
            throw new NotImplementedException();
        }
    }  
}
