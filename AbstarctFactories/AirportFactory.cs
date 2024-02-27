using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstarctFactories
{
    public class AirportFactory : IFactory
    {
        public IPrimaryKeyed Create(List<string> atomicVals, List<List<string>>? arrayVals)
        {
            return new Airport(ulong.Parse(atomicVals[1]),
                                atomicVals[2],
                                atomicVals[3],
                                float.Parse(atomicVals[4]),
                                float.Parse(atomicVals[5]),
                                float.Parse(atomicVals[6]),
                                atomicVals[7]);
        }
    }
}
