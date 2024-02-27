using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;

namespace OODProj.AbstarctFactories
{
    public interface IFactory
    {
        IPrimaryKeyed Create(List<string> atomicVals, List<List<string>>? arrayVals);
    }   
}
