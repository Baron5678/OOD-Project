using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.Utilities;
using OODProj.Data;

namespace OODProj.Builders.PlanesBuilders
{
    public class CargoPlaneBuilder : IBuilder
    {
        private CargoPlane _plane = new();

        public void BuildID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");

            _plane.ID = BitConverter.ToUInt64(value);
        }

        public void BuildSerial(byte[] values)
        {
            _plane.Serial = Utility.BytesToString(values);
        }

        public void BuildCountry(byte[] values)
        {
            _plane.Country = Utility.BytesToString(values);
        }

        public void BuildModel(byte[] values)
        {
            _plane.Model = Utility.BytesToString(values);
        }

        public void BuildMaxLoad(byte[] values)
        {
            _plane.MaxLoad = BitConverter.ToSingle(values);
        }

        public IPrimaryKeyed GetResult()
        {
            return _plane;
        }
    }
}