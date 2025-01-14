﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Observers;
using OODProj.Utilities;

namespace OODProj.AbstractFactories
{
    public class FlightFactory : IFactory
    {
        private List<string> _objectData = [];
        private ObserverInitializator _observerInitializator;

        public FlightFactory(ObserverInitializator observerInit)
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
            StorageIDs.IDset.Add(ulong.Parse(_objectData[0]));
            ulong[] uInt64Cargos = [];
            if (!Utility.TryParseUlongs(_objectData[9], out uInt64Cargos))
                    throw new ArgumentException("Invalid cargo IDs");

            ulong[] uInt64Load = []; 
            if (!Utility.TryParseUlongs(_objectData[10], out uInt64Load))
                throw new ArgumentException("Invalid cargo IDs");
 
            Flight flight = new(ulong.Parse(_objectData[0]),
                              ulong.Parse(_objectData[1]),
                              ulong.Parse(_objectData[2]),
                              TimeOnly.Parse(_objectData[3]),
                              TimeOnly.Parse(_objectData[4]),
                              float.Parse(_objectData[5]),
                              float.Parse(_objectData[6]),
                              float.Parse(_objectData[7]),
                              ulong.Parse(_objectData[8]),
                              uInt64Cargos,
                              uInt64Load);
            StorageIDs.Objectsset.Add(ulong.Parse(_objectData[0]), flight);
            StorageIDs.PositionedObjects.Add(ulong.Parse(_objectData[0]), flight);
            _observerInitializator.AddObserver(flight);
            return flight;  
        }

        public void ResetObjectData() => _objectData = [];

    }
}
