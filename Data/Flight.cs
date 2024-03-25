using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data
{
    public class Flight : IPrimaryKeyed, ICloneable
    {
        static public string ClassID { get => "FL"; }

        private UInt64 _id;
        private UInt64 _idOrigin;
        private UInt64 _idTarget;
        private TimeOnly _takeoffTime;
        private TimeOnly _landingTime;
        private float _longitude;
        private float _latitude;
        private float _AMSL;
        private UInt64 _idPlane;
        private UInt64[] _idCargos;
        private UInt64[] _idLoad;

        // Properties
        public UInt64 ID { get => _id; set => _id = value; }
        public UInt64 IDOrigin { get => _idOrigin; set => _idOrigin = value; }
        public UInt64 IDTarget { get => _idTarget; set => _idTarget = value; }
        public TimeOnly TakeoffTime { get => _takeoffTime; set => _takeoffTime = value; }
        public TimeOnly LandingTime { get => _landingTime; set => _landingTime = value; }
        public float Longitude { get => _longitude; set => _longitude = value; }
        public float Latitude { get => _latitude; set => _latitude = value; }
        public float AMSL { get => _AMSL; set => _AMSL = value; }
        public UInt64 IDPlane { get => _idPlane; set => _idPlane = value; }
        public UInt64[] IDCargos { get => _idCargos; set => _idCargos = value; }
        public UInt64[] IDLoad { get => _idLoad; set => _idLoad = value; }

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

    }
}
