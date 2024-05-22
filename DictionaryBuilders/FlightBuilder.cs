using OODProj.Data;
using OODProj.Utilities;
using OODProj.IDManagement;

namespace OODProj.DictionaryBuilders
{
    public class FlightBuilder(IManagerID manager) : IDictionaryBuilder
    {
        private Flight _flight = new();
        private AirportManagerID _airportManagerID = (AirportManagerID)manager;

        public Dictionary<string, Action<string>> BuilderMethods
            => new()
            {
                { "ID", BuildID },
                { "IDOrigin", BuildOriginID },
                { "IDTarget", BuildTargetID },
                { "TakeoffTime", BuildTakeoffTime },
                { "LandingTime", BuildLandingTime },
                { "WorldPosition.Lat", BuildLat },
                { "WorldPosition.Long", BuildLong },
                { "PlaneID", BuildPlaneID },
            };

        public void BuildID(string value)
            => StorageIDs.AssignID(ulong.Parse(value), _flight, "Flight");

        public void BuildOriginID(string value)
            => _flight.IDOrigin = _airportManagerID.AssignPrimaryKeyedID(ulong.Parse(value), "Flight");

        public void BuildTargetID(string value)
            => _flight.IDTarget = _airportManagerID.AssignPrimaryKeyedID(ulong.Parse(value), "Flight");

        public void BuildTakeoffTime(string value)
            => _flight.TakeoffTime = TimeOnly.Parse(value);

        public void BuildLandingTime(string value)
            => _flight.LandingTime = TimeOnly.Parse(value);

        public void BuildLat(string value)
            => _flight.Latitude = float.Parse(value);

        public void BuildLong(string value)
            => _flight.Longitude = float.Parse(value);

        public void BuildPlaneID(string value)
            => _flight.IDPlane = ulong.Parse(value);

        public IPrimaryKeyed GetObject() => _flight;
    }
}
