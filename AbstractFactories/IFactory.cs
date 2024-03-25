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

namespace OODProj.AbstractFactories
{
    public interface IFactory
    {
        IPrimaryKeyed Create();
        IFactory SetObjectData(string[] data);
        void ResetObjectData();
    }   
}
