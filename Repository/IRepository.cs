using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Repository
{
    public interface IRepository
    {
        void IAddToRepo(IPrimaryKeyed keyedObject);
        IPrimaryKeyed FindById(ulong id);
        void Delete(ulong id);
    }
}
