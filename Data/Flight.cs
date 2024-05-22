using OODProj.Data.Observers;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.GUI;
using OODProj.Logging;
using System.Text;
using System.Text.Json.Serialization;

namespace OODProj.Data
{
    public class Flight : IPrimaryKeyed, ICloneable, IObserver, IPositioned
    {
        static public string ClassID { get => "FL"; }

        private ulong _id;
        private ulong _prevID;
        private ulong _idOrigin;
        private ulong _idTarget;
        private TimeOnly _takeoffTime;
        private TimeOnly _landingTime;
        private float _longitude;
        private float _latitude;
        private float _AMSL;
        private ulong _idPlane;
        private ulong[] _idCargos;
        private ulong[] _idLoad;


        // Properties
        public ulong ID
        {
            get => _id;
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "ID";
                state.PrevValue = _id;
                _id = value;
                state.UpdatedValue = _id;
                Log.Instance.LogWrite(state);
            }
        }
        public ulong IDOrigin
        {
            get => _idOrigin;
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDOrigin";
                state.PrevValue = _idOrigin;
                _idOrigin = value;
                state.UpdatedValue = _idOrigin;
                Log.Instance.LogWrite(state);
            }
        }
        public ulong IDTarget
        {
            get => _idTarget;
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDTarget";
                state.PrevValue = _idTarget;
                _idTarget = value;
                state.UpdatedValue = _idTarget;
                Log.Instance.LogWrite(state);
            }
        }
        public TimeOnly TakeoffTime
        {
            get => _takeoffTime;
            set
            {
                var state = new State<TimeOnly>();
                state.ObjectName = "Flight";
                state.PropertyName = "TakeoffTime";
                state.PrevValue = _takeoffTime;
                _takeoffTime = value;
                state.UpdatedValue = _takeoffTime;
                Log.Instance.LogWrite(state);
            }
        }
        public TimeOnly LandingTime
        {
            get => _landingTime;
            set
            {
                var state = new State<TimeOnly>();
                state.ObjectName = "Flight";
                state.PropertyName = "LandingTime";
                state.PrevValue = _landingTime;
                _landingTime = value;
                state.UpdatedValue = _landingTime;
                Log.Instance.LogWrite(state);
            }
        }
        public float Longitude
        {
            get => _longitude;
            set
            {
                IsUpdated = true;
                var state = new State<float>();
                state.ObjectName = "Flight";
                state.PropertyName = "Longitude";
                state.PrevValue = _longitude;
                _longitude = value;
                state.UpdatedValue = _longitude;
                Log.Instance.LogWrite(state);
            }
        }
        public float Latitude
        {
            get => _latitude;
            set
            {
                IsUpdated = true;
                var state = new State<float>();
                state.ObjectName = "Flight";
                state.PropertyName = "Latitude";
                state.PrevValue = _latitude;
                _latitude = value;
                state.UpdatedValue = _latitude;
                Log.Instance.LogWrite(state);
            }
        }
        public float AMSL
        {
            get => _AMSL;
            set
            {
                var state = new State<float>();
                state.ObjectName = "Flight";
                state.PropertyName = "AMSL";
                state.PrevValue = _AMSL;
                _AMSL = value;
                state.UpdatedValue = _AMSL;
                Log.Instance.LogWrite(state);
            }
        }
        public ulong IDPlane
        {
            get => _idPlane;
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDPlane";
                state.PrevValue = _idPlane;
                _idPlane = value;
                state.UpdatedValue = _idPlane;
                Log.Instance.LogWrite(state);
            }
        }
        public ulong[] IDCargos { get => _idCargos; set => _idCargos = value; }
        public ulong[] IDLoad { get => _idLoad; set => _idLoad = value; }
        [JsonIgnore]
        public ulong PrevID { get => _prevID; set => _prevID = value; }
        [JsonIgnore]
        public bool IsUpdated { get; set; } = false;

        public Dictionary<string, Func<IPrimaryKeyed, string>> PropertySet
            => new()
            {
                { "ID", (x) => ((Flight)x).ID.ToString() },
                { "IDOrigin", (x) => ((Flight)x).IDOrigin.ToString() },
                { "IDTarget", (x) => ((Flight)x).IDTarget.ToString() },
                { "TakeoffTime", (x) => ((Flight)x).TakeoffTime.ToString() },
                { "LandingTime", (x) => ((Flight)x).LandingTime.ToString() },
                { "Longitude", (x) => ((Flight)x).Longitude.ToString() },
                { "Latitude", (x) => ((Flight)x).Latitude.ToString() },
                { "AMSL", (x) => ((Flight)x).AMSL.ToString() },
                { "IDPlane", (x) => ((Flight)x).IDPlane.ToString() }  
            };

        //Default constructor
        public Flight()
        {
            _id = default;
            _idOrigin = default;
            _idTarget = default;
            _takeoffTime = new();
            _landingTime = new();
            _longitude = default;
            _latitude = default;
            _AMSL = default;
            _idPlane = default;
            _idCargos = [];
            _idLoad = [];
        }


        // Constructor
        public Flight(UInt64 id,
                      UInt64 idOrigin,
                      UInt64 idTarget,
                      TimeOnly takeoffTime,
                      TimeOnly landingTime,
                      float longitude,
                      float latitude,
                      float amsl,
                      UInt64 idPlane,
                      UInt64[] idCargos,
                      UInt64[] idLoad)
        {
            _id = id;
            _idOrigin = idOrigin;
            _idTarget = idTarget;
            _takeoffTime = takeoffTime;
            _landingTime = landingTime;
            _longitude = longitude;
            _latitude = latitude;
            _AMSL = amsl;
            _idPlane = idPlane;
            _idCargos = idCargos;
            _idLoad = idLoad;
        }

        // ToString
        public override string ToString()
        {
            StringBuilder sbIdCargos = new StringBuilder();
            StringBuilder sbIdLoads = new StringBuilder();

            foreach (var item in _idCargos)
            {
                sbIdCargos.Append($"{item} ");
            }

            foreach (var item in _idLoad)
            {
                sbIdLoads.Append($"{item} ");
            }

            return $"[Flight]\n" +
                   $"ID: {_id}\n" +
                   $"Origin: {_idOrigin}\n" +
                   $"Target: {_idTarget}\n" +
                   $"Takeoff Time: {_takeoffTime}\n" +
                   $"Landing Time: {_landingTime}\n" +
                   $"Longitude: {_longitude}\n" +
                   $"Latitude: {_latitude}\n" +
                   $"AMSL: {_AMSL}\n" +
                   $"Plane: {_idPlane}\n" +
                   $"Cargo: {sbIdCargos}\n" +
                   $"Load: {sbIdLoads}\n";
        }

        // Clone
        public object Clone()
        {
            return new Flight(_id, _idOrigin, _idTarget, _takeoffTime, _landingTime, _longitude, _latitude, _AMSL, _idPlane, _idCargos, _idLoad);
        }

        public void UpdateID(Airport airport)
        {
            if (airport.PrevID == _idOrigin)
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDOrigin";
                state.PrevValue = _idOrigin;
                _idOrigin = airport.ID;
                state.UpdatedValue = _idOrigin;
                Log.Instance.LogWrite(state);
            }

            if (airport.PrevID == _idTarget)
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDTarget";
                state.PrevValue = _idTarget;
                _idTarget = airport.ID;
                state.UpdatedValue = _idTarget;
                Log.Instance.LogWrite(state);
            }
        }

        public void UpdateID(CargoPlane cargoPlane)
        {
            if (cargoPlane.PrevID == _idPlane)
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDPlane";
                state.PrevValue = _idPlane;
                _idPlane = cargoPlane.ID;
                state.UpdatedValue = _idPlane;
                Log.Instance.LogWrite(state);
            }
        }

        public void UpdateID(PassengerPlane passengerPlane)
        {
            if (passengerPlane.PrevID == _idPlane)
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDPlane";
                state.PrevValue = _idPlane;
                _idPlane = passengerPlane.ID;
                state.UpdatedValue = _idPlane;
                Log.Instance.LogWrite(state);
            }
        }

        public void UpdateID(Cargo cargo)
        {
            var index = Array.IndexOf(_idLoad, cargo.PrevID);
            if (index != -1)
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDLoad";
                state.PrevValue = _idLoad[index];
                _idLoad[index] = cargo.ID;
                state.UpdatedValue = _idLoad[index];
                Log.Instance.LogWrite(state);
            }
            else
            {
                var err_state = new ErrorState();
                err_state.ObjectName = "Flight";
                err_state.ErrorMessage = "Cargo not found in collection property IDLoads";
                Log.Instance.LogWrite(err_state);
            }
        }

        public void UpdateID(Passenger passenger)
        {
            var index = Array.IndexOf(_idLoad, passenger.PrevID);
            if (index != -1)
            {
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDLoad";
                state.PrevValue = _idLoad[index];
                _idLoad[index] = passenger.ID;
                state.UpdatedValue = _idLoad[index];
                Log.Instance.LogWrite(state);
            }
            else
            {
                var err_state = new ErrorState();
                err_state.ObjectName = "Flight";
                err_state.ErrorMessage = "Passenger not found in collection property IDLoads";
                Log.Instance.LogWrite(err_state);
            }
        }

        public void UpdateID(Crew crew)
        {
            var index = Array.IndexOf(_idCargos, crew.PrevID);
            if (index != -1)
            { 
                var state = new State<ulong>();
                state.ObjectName = "Flight";
                state.PropertyName = "IDCargo";
                state.PrevValue = _idCargos[index];
                _idCargos[index] = crew.ID;
                state.UpdatedValue = _idCargos[index];
                Log.Instance.LogWrite(state);
            }
            else 
            {
                var err_state = new ErrorState();
                err_state.ObjectName = "Flight";
                err_state.ErrorMessage = "Crew not found in collection property IDCargos";
                Log.Instance.LogWrite(err_state);
            } 

        }
    }
}
