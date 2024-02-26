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
        public IPrimaryKeyed Create(List<string> atomicVals, List<List<string>>? arrayVals)
        {
            return new CargoPlane(ulong.Parse(atomicVals[1]), 
                                  atomicVals[2], 
                                  atomicVals[3], 
                                  atomicVals[4], 
                                  float.Parse(atomicVals[5])
                                  );
        }
    }  
}
