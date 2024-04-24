using OODProj.Data.Observers;
using OODProj.Logging;
using OODProj.NewsReport;
using System.Text.Json.Serialization;

namespace OODProj.Data.Planes
{
    public class PassengerPlane : IPlane, ICloneable, IReportable, ISubject
    {
        static public string ClassID { get => "PP"; }

        private ulong _id;
        private string _serial;
        private string _country;
        private string _model;
        private ushort _firstClassSize;
        private ushort _businessClassSize;
        private ushort _economyClassSize;

        public ulong ID
        {
            get => _id;
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "PassengerPlane";
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
                state.ObjectName = "PassengerPlane";
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
                state.ObjectName = "PassengerPlane";
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
                state.ObjectName = "PassengerPlane";
                state.PropertyName = "Model";
                state.PrevValue = _model;
                _model = value;
                state.UpdatedValue = _model;
                Log.Instance.LogWrite(state);
            }
        }
        public ushort FirstClassSize
        {
            get => _firstClassSize;
            set
            {
                var state = new State<ushort>();
                state.ObjectName = "PassengerPlane";
                state.PropertyName = "FirstClassSize";
                state.PrevValue = _firstClassSize;
                _firstClassSize = value;
                state.UpdatedValue = _firstClassSize;
                Log.Instance.LogWrite(state);
            }
        }
        public ushort BusinessClassSize
        {
            get => _businessClassSize;
            set
            {
                var state = new State<ushort>();
                state.ObjectName = "PassengerPlane";
                state.PropertyName = "BusinessClassSize";
                state.PrevValue = _businessClassSize;
                _businessClassSize = value;
                state.UpdatedValue = _businessClassSize;
                Log.Instance.LogWrite(state);
            }
        }
        public ushort EconomyClassSize
        {
            get => _economyClassSize;
            set
            {
                var state = new State<ushort>();
                state.ObjectName = "PassengerPlane";
                state.PropertyName = "EconomyClassSize";
                state.PrevValue = _economyClassSize;
                _economyClassSize = value;
                state.UpdatedValue = _economyClassSize;
                Log.Instance.LogWrite(state);
            }
        }

        private ulong _prevID;
        [JsonIgnore]
        public List<IObserver> Observers { get; set; }
        [JsonIgnore]
        public ulong PrevID { get => _prevID; set => _prevID = value; }


        public PassengerPlane()
        {
            _id = default;
            _serial = string.Empty;
            _country = string.Empty;
            _model = string.Empty;
            _firstClassSize = default;
            _businessClassSize = default;
            _economyClassSize = default;
            Observers = [];
        }

        public PassengerPlane(ulong id, string serial, string country, string model, ushort firstClassSize, ushort businessClassSize, ushort economyClassSize)
        {
            _id = id;
            _serial = serial;
            _country = country;
            _model = model;
            _firstClassSize = firstClassSize;
            _businessClassSize = businessClassSize;
            _economyClassSize = economyClassSize;
            Observers = [];
        }

        public override string ToString()
        {
            return $"[PassengerPlane]\n ID: {_id}\n Serial: {_serial}\n Country: {_country}\n Model: {_model}\n First Class Size: {_firstClassSize}\n Business Class Size: {_businessClassSize}\n Economy Class Size: {_economyClassSize}\n";
        }

        public object Clone()
        {
            return new PassengerPlane(_id, _serial, _country, _model, _firstClassSize, _businessClassSize, _economyClassSize);
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
