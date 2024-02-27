using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;

namespace OODProj.AbstarctFactories
{
    public class FlightFactory : IFactory
    {
        public IPrimaryKeyed Create(List<string> atomicVals, List<List<string>>? arrayVals)
        {
            List<ulong> idCargos = new();
            List<ulong> idLoads = new();

            if (arrayVals is null)
                throw new ArgumentNullException("Object contains array properties");
            
                
           foreach (string idCargo in arrayVals[0])
               idCargos.Add(ulong.Parse(idCargo));
           

           foreach (string idLoad in arrayVals[1])
               idLoads.Add(ulong.Parse(idLoad));
            
            return new Flight(ulong.Parse(atomicVals[1]),
                              ulong.Parse(atomicVals[2]),
                              ulong.Parse(atomicVals[3]),
                              atomicVals[4],
                              atomicVals[5],
                              float.Parse(atomicVals[6]),
                              float.Parse(atomicVals[7]),
                              float.Parse(atomicVals[8]),
                              ulong.Parse(atomicVals[9]),
                              idCargos.ToArray(),
                              idLoads.ToArray());
        }
    }
}
