using OODProj.Data;
using OODProj.Utilities;


namespace OODProj.Builders
{
    public class FlightBuilder : IBuilder
    {
        private Flight _flight = new();

        public void BuildID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            _flight.ID = BitConverter.ToUInt64(value);
        }

        public void BuildOriginID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");

            _flight.IDOrigin = BitConverter.ToUInt64(value);
        }
        public void BuildTargetID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");

            _flight.IDTarget = BitConverter.ToUInt64(value);
        }
        public void BuildTakeoffTime(byte[] value)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(BitConverter.ToInt64(value));

            _flight.TakeoffTime = TimeOnly.Parse(dateTimeOffset.ToLocalTime().ToString("HH:mm"));
        }
        public void BuildLandingTime(byte[] value)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(BitConverter.ToInt64(value));

            _flight.LandingTime = TimeOnly.Parse(dateTimeOffset.ToLocalTime().ToString("HH:mm"));
        }
        public void BuildPlaneID(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("PlaneID must be 8 bytes long");

            _flight.IDPlane = BitConverter.ToUInt64(value);
        }
        public void BuildCrew(byte[] value)
        {
            _flight.IDCargos = Utility.ConvertToUInt64Array(value);
        }
        public void BuildLoad(byte[] value)
        {
            _flight.IDLoad = Utility.ConvertToUInt64Array(value);
        }
        public IPrimaryKeyed GetResult() => _flight;
    }
}
