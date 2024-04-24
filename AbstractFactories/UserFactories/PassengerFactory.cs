using OODProj.Data;
using OODProj.Data.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data.Users;
using OODProj.Data.Planes;

namespace OODProj.AbstractFactories.UserFactories
{
    public class PassengerFactory : IFactory
    {
        private List<string> _objectData = [];
        private ObserverInitializator _observerInitializator;

        public PassengerFactory(ObserverInitializator observerInit)
        {
            _observerInitializator = observerInit;
        }

        public IFactory SetObjectData(string[] data)
        {
            _objectData = [.. data];
            return this;
        }

        public IPrimaryKeyed Create()
        {
            Passenger passenger = new(ulong.Parse(_objectData[0]),
                                 _objectData[1],
                                 ulong.Parse(_objectData[2]),
                                 _objectData[3],
                                 _objectData[4],
                                 _objectData[5],
                                 ulong.Parse(_objectData[6]));
            StorageIDs.IDset.Add(ulong.Parse(_objectData[0]));
            StorageIDs.Objectsset.Add(ulong.Parse(_objectData[0]), passenger);
            StorageIDs.UserObjects.Add(ulong.Parse(_objectData[0]), passenger);
            _observerInitializator.AddSubject(passenger);
            return passenger;
        }

        public void ResetObjectData() => _objectData = [];

    }
}
