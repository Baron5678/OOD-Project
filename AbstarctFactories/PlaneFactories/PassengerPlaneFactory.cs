using OODProj.Data;
using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstarctFactories.PlaneFactories
{
    public class PassengerPlaneFactory : IFactory
    {
        public IPrimaryKeyed Create(List<string> atomicVals, List<List<string>>? arrayVals)
        {
            return new PassengerPlane(ulong.Parse(atomicVals[1]),
                                      atomicVals[2],
                                      atomicVals[3],
                                      atomicVals[4],
                                     ushort.Parse(atomicVals[6]),
                                     ushort.Parse(atomicVals[7]),
                                     ushort.Parse(atomicVals[8]));
        }
    }
}
