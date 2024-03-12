using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstarctFactories
{
    public class CargoFactory : IFactory
    {
        public IPrimaryKeyed Create(List<string> atomicVals, List<List<string>>? arrayVals)
        {
            return new Cargo(ulong.Parse(atomicVals[1]),
                              float.Parse(atomicVals[2]),
                              atomicVals[3],
                              atomicVals[4]);
        }
    }
}
