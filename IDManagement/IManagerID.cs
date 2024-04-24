using OODProj.Data;
using OODProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.IDManagement
{
    public interface IManagerID
    {
        public void AddPrimaryKeyedObject(IPrimaryKeyed pkobj);
        public IPrimaryKeyed GetPrimaryKeyedObject(ulong id);
        public void InitializeByRepo(IRepository repo);
    }
}
