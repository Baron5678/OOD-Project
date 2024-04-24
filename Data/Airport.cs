using OODProj.Data.Observers;
using OODProj.Logging;
using OODProj.NewsReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OODProj.Data
{
    public class Airport: IPrimaryKeyed, ICloneable, IReportable, ISubject, IPositioned
    {
        static public string ClassID { get => "AI"; }

        private ulong _id;
        private string _name;
        private string _code;
        private float _longitude;
        private float _latitude;
        private float _AMSL;
        private string _country;
    
        public ulong ID 
        { 
            get => _id; 
            set 
            {
                var state = new State<ulong>();
                state.ObjectName = "Airport";
                state.PropertyName = "ID";
                state.PrevValue = _id;
                _id = value;
                state.UpdatedValue = _id;
                Log.Instance.LogWrite(state);
                Notify(); 
            } 
        }
        public string Name
        {
            get => _name;
            set
            {
                var state = new State<string>();
                state.ObjectName = "Airport";
                state.PropertyName = "Name";
                state.PrevValue = _name;
                _name = value;
                state.UpdatedValue = _name;
                Log.Instance.LogWrite(state);
            }
        }
        public string Code 
        { 
            get => _code; 
            set
            {
                var state = new State<string>();
                state.ObjectName = "Airport";
                state.PropertyName = "Code";
                state.PrevValue = _code;
                _code = value;
                state.UpdatedValue = _code;
                Log.Instance.LogWrite(state);
            }
        }
        public float Longitude 
        { 
            get => _longitude; 
            set
            {
                var state = new State<float>();
                state.ObjectName = "Airport";
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
                var state = new State<float>();
                state.ObjectName = "Airport";
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
                state.ObjectName = "Airport";
                state.PropertyName = "AMSL";
                state.PrevValue = _AMSL;
                _AMSL = value;
                state.UpdatedValue = _AMSL;
                Log.Instance.LogWrite(state);
            }
        }
        public string Country 
        { 
            get => _country; 
            set
            {
                var state = new State<string>();
                state.ObjectName = "Airport";
                state.PropertyName = "Country";
                state.PrevValue = Country;
                Country = value;
                state.UpdatedValue = Country;
                Log.Instance.LogWrite(state);
            }
        }

        private ulong _prevID;
        [JsonIgnore]
        public List<IObserver> Observers { get; set; }
        [JsonIgnore]
        public ulong PrevID { get => _prevID; set => _prevID = value; }


        public Airport()
        {
            _id = default;
            _name = string.Empty;
            _code = string.Empty;
            _longitude = default;
            _latitude = default;
            _AMSL = default;
            _country = string.Empty;
            _prevID = default;
            Observers = [];
        }


        public Airport(UInt64 id, string name, string code, float longitude, float latitude, float amsl, string country)
        {
            _id = id;
            _name = name;
            _code = code;
            _longitude = longitude;
            _latitude = latitude;
            _AMSL = amsl;
            _country = country;
            _prevID = default;
            Observers = [];
        }

        public override string ToString()
        {
            return $"[Airport]\nID: {_id}\n Name: {_name}\n Code: {_code}\n Longitude: {_longitude}\n Latitude: {_latitude}\n AMSL: {_AMSL}\n Country: {_country}\n";
        }

        public object Clone()
        {
            return new Airport(_id, _name, _code, _longitude, _latitude, _AMSL, _country);
        }

        public string Accept(INewsProvider provider)
            => provider.Visit(this);

        public void Attach(IObserver observer)
        {
             Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.UpdateID(this);
            }
        }
    }
}
