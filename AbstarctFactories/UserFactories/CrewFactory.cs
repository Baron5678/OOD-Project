using OODProj.Data;
using OODProj.Data.Users;
namespace OODProj.AbstarctFactories.UserFactories
{
    public class CrewFactory : IFactory
    {
        public IPrimaryKeyed Create(List<string> atomicVals, List<List<string>>? arrayVals)
        {
            return new Crew(ulong.Parse(atomicVals[1]),
                            atomicVals[2],
                            ulong.Parse(atomicVals[3]),
                            atomicVals[4],
                            atomicVals[5],
                            ushort.Parse(atomicVals[6]),
                            atomicVals[7]);
        }
    }
}
