using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OODProj.Data.Observers;
using OODProj.Logging;

namespace OODProj.Data.Users
{
    public class Passenger : IUser, ICloneable, ISubject
    {
        static public string ClassID { get => "P"; }

        private ulong _id;
        private string _name;
        private ulong _age;
        private string _phone;
        private string _email;
        private string _class;
        private ulong _miles;

        public ulong ID 
        { 
            get => _id; 
            set 
            {
                var state = new State<ulong>();
                state.ObjectName = "Passenger";
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
                state.ObjectName = "Passenger";
                state.PropertyName = "Name";
                state.PrevValue = _name;
                _name = value;
                state.UpdatedValue = _name;
                Log.Instance.LogWrite(state);
            }
        }
        public ulong Age
        {
            get => _age;
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "Passenger";
                state.PropertyName = "Age";
                state.PrevValue = _age;
                _age = value;
                state.UpdatedValue = _age;
                Log.Instance.LogWrite(state);
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                var state = new State<string>();
                state.ObjectName = "Passenger";
                state.PropertyName = "Phone";
                state.PrevValue = _phone;
                _phone = value;
                state.UpdatedValue = _phone;
                Log.Instance.LogWrite(state);
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                var state = new State<string>();
                state.ObjectName = "Passenger";
                state.PropertyName = "Email";
                state.PrevValue = _email;
                _email = value;
                state.UpdatedValue = _email;
                Log.Instance.LogWrite(state);
            }
        }
        public string Class 
        { 
            get => _class; 
            set
            {
                var state = new State<string>();
                state.ObjectName = "Passenger";
                state.PropertyName = "Class";
                state.PrevValue = _class;
                _class = value;
                state.UpdatedValue = _class;
                Log.Instance.LogWrite(state);
            }
        }
        public ulong Miles 
        { 
            get => _miles; 
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "Passenger";
                state.PropertyName = "Miles";
                state.PrevValue = _miles;
                _miles = value;
                state.UpdatedValue = _miles;
                Log.Instance.LogWrite(state);
            }
        }

        // list of observers
        private ulong _prevID;
        [JsonIgnore]
        public List<IObserver> Observers { get; set; }
        [JsonIgnore]
        public ulong PrevID { get => _prevID; set => _prevID = value; }


        //Default ctor
        public Passenger()
        {
            _id = default;
            _name = string.Empty;
            _age = default;
            _phone = string.Empty;
            _email = string.Empty;
            _class = string.Empty;
            _miles = default;
            _prevID = default;
            Observers = [];
        }

        public Passenger(ulong id, string name, ulong age, string phone, string email, string @class, ulong miles)
        {
            _id = id;
            _name = name;
            _age = age;
            _phone = phone;
            _email = email;
            _class = @class;
            _miles = miles;
            _prevID = default;
            Observers = [];
        }

        public Dictionary<string, Func<IPrimaryKeyed, string>> PropertySet 
        {
            get => new()
            {
                { "ID", p => ((Passenger)p).ID.ToString() },
                { "Name", p => ((Passenger)p).Name },
                { "Age", p => ((Passenger)p).Age.ToString() },
                { "Phone", p => ((Passenger)p).Phone },
                { "Email", p => ((Passenger)p).Email },
                { "Class", p => ((Passenger)p).Class },
                { "Miles", p => ((Passenger)p).Miles.ToString() }
            };
        }

        public override string ToString()
        {
            return $"[Passenger]\nID: {_id}\n Name: {_name}\n Age: {_age}\n Phone: {_phone}\n Email: {_email}\n Practice: {_class}\n Role: {_miles}\n";
        }

        public object Clone()
        {
            return new Passenger(_id, _name, _age, _phone, _email, _class, _miles);
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
