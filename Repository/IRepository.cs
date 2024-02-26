using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.StrategiesGettingData.DataSerializers;

namespace OODProj.Repository
{
    public interface IRepository
    {
        void IAddToRepo(IPrimaryKeyed keyedObject);
        List<IPrimaryKeyed> GetAll();
        IPrimaryKeyed FindById(ulong id);
        void Delete(ulong id);
        void Accept(IVisitor visitor);
    }
}
