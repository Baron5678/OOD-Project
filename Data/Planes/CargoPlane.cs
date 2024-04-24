using OODProj.Data.Observers;
using OODProj.Logging;
using OODProj.NewsReport;
using System.Text.Json.Serialization;

namespace OODProj.Data.Planes
{
    public class CargoPlane : IPlane, ICloneable, IReportable, ISubject
    {
        static public string ClassID { get => "CP"; }

        private ulong _id;
        private string _serial;
        private string _country;
        private string _model;
        private float _maxload;

        public ulong ID
        {
            get => _id;
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "CargoPlane";
                state.PropertyName = "ID";
                state.PrevValue = _id;
                _id = value;
                state.UpdatedValue = _id;
                Log.Instance.LogWrite(state);
                Notify();
            }
        }
        public string Serial
        {
            get => _serial;
            set
            {
                var state = new State<string>();
                state.ObjectName = "CargoPlane";
                state.PropertyName = "Serial";
                state.PrevValue = _serial;
                _serial = value;
                state.UpdatedValue = _serial;
                Log.Instance.LogWrite(state);
            }
        }
        public string Country
        {
            get => _country;
            set
            {
                var state = new State<string>();
                state.ObjectName = "CargoPlane";
                state.PropertyName = "Country";
                state.PrevValue = _country;
                _country = value;
                state.UpdatedValue = _country;
                Log.Instance.LogWrite(state);
            }
        }
        public string Model
        {
            get => _model;
            set
            {
                var state = new State<string>();
                state.ObjectName = "CargoPlane";
                state.PropertyName = "Model";
                state.PrevValue = _model;
                _model = value;
                state.UpdatedValue = _model;
                Log.Instance.LogWrite(state);
            }
        }
        public float MaxLoad
        {
            get => _maxload;
            set
            {
                var state = new State<float>();
                state.ObjectName = "CargoPlane";
                state.PropertyName = "MaxLoad";
                state.PrevValue = _maxload;
                _maxload = value;
                state.UpdatedValue = _maxload;
                Log.Instance.LogWrite(state);
            }
        }

        [JsonIgnore]
        private List<IObserver> _observers { get; init; }

        private ulong _prevID;
        [JsonIgnore]
        public ulong PrevID { get => _prevID; set => _prevID = value; }

        public CargoPlane()
        {
            _id = default;
            _serial = string.Empty;
            _country = string.Empty;
            _model = string.Empty;
            _maxload = default;
            _observers = [];
        }

        public CargoPlane(ulong id, string serial, string country, string model, float maxload)
        {
            _id = id;
            _serial = serial;
            _country = country;
            _model = model;
            _maxload = maxload;
            _observers = [];
        }

        public override string ToString()
        {
            return $"[CargoPlane]\n ID: {_id}\n Serial: {_serial}\n Country: {_country}\n Model: {_model}\n Max Load: {_maxload}\n";
        }

        public object Clone()
        {
            return new CargoPlane(_id, _serial, _country, _model, _maxload);
        }

        public string Accept(INewsProvider provider)
            => provider.Visit(this);

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateID(this);
            }
        }
    }
}
