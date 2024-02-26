using OODProj.Data;
using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstarctFactories
{
    internal class PassengerPlaneFactory : ICreateFactory
    {
        private PassengerPlane _plane;

        public PassengerPlaneFactory() => _plane = new PassengerPlane();

        public PassengerPlaneFactory SetID(string val)
        {
            ulong id = ulong.Parse(val);
            return this;
        }

        public PassengerPlaneFactory SetSerial(string val)
        {
            _plane.Serial = val;
            return this;
        }

        public PassengerPlaneFactory SetCountry(string val)
        {
            _plane.Country = val;
            return this;
        }

        public PassengerPlaneFactory SetModel(string val)
        {
            _plane.Model = val;
            return this;
        }

        public PassengerPlaneFactory SetFirstClassSize(string val) 
        {
            _plane.FirstClassSize = ushort.Parse(val);
            return this;
        }
        
        public PassengerPlaneFactory SetEconomyClassSize(string val)
        {
            _plane.EconomyClassSize = ushort.Parse(val);
            return this;
        }

        public PassengerPlaneFactory SetBusinessClassSize(string val)
        {
            _plane.BusinessClassSize = ushort.Parse(val);
            return this;
        }


        public ICreateFactory SetValues(List<string> args)
        {
            if (args.Count != 8)
            {
                throw new ArgumentException("Invalid number of arguments");
            }
            SetID(args[1])
                .SetSerial(args[2])
                .SetCountry(args[3])
                .SetModel(args[4])
                .SetFirstClassSize(args[5])
                .SetEconomyClassSize(args[6])
                .SetBusinessClassSize(args[7]);
            return this;
            
        }

        public IDisplayable Create()
        {
            return _plane;
        }
    }
}
