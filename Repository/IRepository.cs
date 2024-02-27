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
        void AddToRepo(IPrimaryKeyed keyedObject);
        List<IPrimaryKeyed> GetAll();
        IVisitor SerializeFormat { get; set; }
        void Accept(IVisitor visitor);
        void Accept();
    }
}
