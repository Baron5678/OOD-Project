using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data.Users;
using OODProj.Data.Planes;

namespace OODProj.AbstarctFactories.UserFactories
{
    public class PassengerFactory : IFactory
    {
        public IPrimaryKeyed Create(List<string> atomicVals, List<List<string>>? arrayVals)
        {
            return new Passenger(ulong.Parse(atomicVals[1]),
                                 atomicVals[2],
                                 ulong.Parse(atomicVals[3]),
                                 atomicVals[4],
                                 atomicVals[5],
                                 atomicVals[6],
                                 ulong.Parse(atomicVals[7]));
        }
    }
}
