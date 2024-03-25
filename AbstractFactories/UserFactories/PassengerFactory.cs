using OODProj.Data;
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

        public IFactory SetObjectData(string[] data)
        {
            _objectData = [.. data];
            return this;
        }

        public IPrimaryKeyed Create()
        {
            return new Passenger(ulong.Parse(_objectData[0]),
                                 _objectData[1],
                                 ulong.Parse(_objectData[2]),
                                 _objectData[3],
                                 _objectData[4],
                                 _objectData[5],
                                 ulong.Parse(_objectData[6]));   
        }

        public void ResetObjectData() => _objectData = [];

    }
}
