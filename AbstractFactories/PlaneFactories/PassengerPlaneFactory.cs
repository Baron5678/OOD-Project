using OODProj.Data;
using OODProj.Data.Planes;

namespace OODProj.AbstractFactories.PlaneFactories
{
    public class PassengerPlaneFactory : IFactory
    {
        private List<string> _objectData = [];

        public IFactory SetObjectData(string[] data)
        {
            _objectData = [.. data];
            return this;
        }

        public IPrimaryKeyed Create()
        {
            return new PassengerPlane(ulong.Parse(_objectData[0]),
                                       _objectData[1], 
                                       _objectData[2], 
                                       _objectData[3], 
                                       ushort.Parse(_objectData[4]), 
                                       ushort.Parse(_objectData[5]),
                                       ushort.Parse(_objectData[6]));
        }

        public void ResetObjectData() => _objectData = [];

    }
}
