using OODProj.Data.Planes;
using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.StorageData
{
    public interface IAddStrategy
    {
        void AddToContainer(DataContainer data, IDisplayable obj);
    }


    public class CargoPlaneAddStrategy : IAddStrategy
    {
        public void AddToContainer(DataContainer data, IDisplayable obj)
        {
            var x = obj as CargoPlane;

            if (x is null)
                throw new ArgumentException("Object is not a CargoPlane");
    
            data.DataCargoPlane.Add(x);
        }
    }

    public class PassengerPlaneAddStrategy : IAddStrategy
    {
        public void AddToContainer(DataContainer data, IDisplayable obj)
        {
            var x = obj as PassengerPlane;

            if (x is not PassengerPlane)
                throw new ArgumentException("Object is not a PassengerPlane");

            data.DataPassengerPlane.Add(x as PassengerPlane);
        }
    }
}
