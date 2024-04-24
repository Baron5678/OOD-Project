using OODProj.Data.Observers;
using OODProj.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OODProj.Data
{
    public class Cargo : IPrimaryKeyed, ICloneable, ISubject
    {
        static public string ClassID { get => "CA"; }

        private ulong _id;
        private float _weight;
        private string _code;
        private string _description;

        public ulong ID 
        { 
            get => _id; 
            set 
            {
                var state = new State<ulong>();
                state.ObjectName = "Cargo";
                state.PropertyName = "ID";
                state.PrevValue = _id;
                _id = value;
                state.UpdatedValue = _id;
                Log.Instance.LogWrite(state);
                Notify(); 
            } 
        }
        public float Weight 
        { 
            get => _weight; 
            set
            {
                var state = new State<float>();
                state.ObjectName = "Cargo";
                state.PropertyName = "Weight";
                state.PrevValue = _weight;
                _weight = value;
                state.UpdatedValue = _weight;
                Log.Instance.LogWrite(state);
            }
        }
        public string Code 
        { 
            get => _code; 
            set
            {
                var state = new State<string>();
                state.ObjectName = "Cargo";
                state.PropertyName = "Code";
                state.PrevValue = _code;
                _code = value;
                state.UpdatedValue = _code;
                Log.Instance.LogWrite(state);
            }
        }
        public string Description 
        { 
            get => _description; 
            set
            {
                var state = new State<string>();
                state.ObjectName = "Cargo";
                state.PropertyName = "Description";
                state.PrevValue = _description;
                _description = value;
                state.UpdatedValue = _description;
                Log.Instance.LogWrite(state);
            }
        }

        private ulong _prevID;
        [JsonIgnore]
        public List<IObserver> Observers { get; set; }
        [JsonIgnore]
        public ulong PrevID { get => _prevID; set => _prevID = value; }

        public Cargo()
        {
            _id = default;
            _weight = default;
            _code = string.Empty;
            _description = string.Empty;
            _prevID = default;
            Observers = [];
        }

        public Cargo(UInt64 id, float weight, string code, string description)
        {
            _id = id;
            _weight = weight;
            _code = code;
            _description = description;
            _prevID = default;
            Observers = [];
        }

        public override string ToString()
        {
            return $"[Cargo]\nID: {_id}\n Weight: {_weight}\n Code: {_code}\n Description: {_description}\n";
        }

        public object Clone()
        {
            return new Cargo(_id, _weight, _code, _description);
        }

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
