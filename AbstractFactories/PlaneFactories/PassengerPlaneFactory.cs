﻿using OODProj.Data;
using OODProj.Data.Observers;
using OODProj.Data.Planes;

namespace OODProj.AbstractFactories.PlaneFactories
{
    public class PassengerPlaneFactory : IFactory
    {
        private List<string> _objectData = [];
        private ObserverInitializator _observerInitializator;

        public PassengerPlaneFactory(ObserverInitializator observerInit)
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
            PassengerPlane pplane = new(ulong.Parse(_objectData[0]),
                                       _objectData[1],
                                       _objectData[2],
                                       _objectData[3],
                                       ushort.Parse(_objectData[4]),
                                       ushort.Parse(_objectData[5]),
                                       ushort.Parse(_objectData[6]));
            StorageIDs.IDset.Add(ulong.Parse(_objectData[0]));
            StorageIDs.Objectsset.Add(ulong.Parse(_objectData[0]), pplane);
            _observerInitializator.AddSubject(pplane);
            return pplane;
        }

        public void ResetObjectData() => _objectData = [];

    }
}
