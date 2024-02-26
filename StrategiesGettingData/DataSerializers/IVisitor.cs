using OODProj.Data;
using OODProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.StrategiesGettingData.DataSerializers
{
    public interface IVisitor
    {
        string Path { get; set; }
        void Visit(CargoPlaneRepository repo);
        void Visit(PassengerPlaneRepository repo);
    }
}
