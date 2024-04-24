using OODProj.Data;
using OODProj.Data.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.AbstractFactories
{
    public class AirportFactory : IFactory
    {
        private List<string> _objectData = [];
        private ObserverInitializator _observerInitializator;
        public AirportFactory(ObserverInitializator observerInit)
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
            Airport airport = new(ulong.Parse(_objectData[0]),
                                _objectData[1],
                                _objectData[2],
                                float.Parse(_objectData[3]),
                                float.Parse(_objectData[4]),
                                float.Parse(_objectData[5]),
                                _objectData[6]);
            StorageIDs.IDset.Add(ulong.Parse(_objectData[0]));
            StorageIDs.Objectsset.Add(ulong.Parse(_objectData[0]), airport);
            StorageIDs.PositionedObjects.Add(ulong.Parse(_objectData[0]), airport);
            _observerInitializator.AddSubject(airport);
            return airport;      
        }

        public void ResetObjectData() => _objectData = [];

    }
}
