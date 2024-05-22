using OODProj.Data.Observers;
using OODProj.Logging;
using System.Text.Json.Serialization;

namespace OODProj.Data.Users
{
    public class Crew : IUser, ICloneable, ISubject
    {
        static public string ClassID { get => "C"; }

        private ulong _id;
        private string _name;
        private ulong _age;
        private string _phone;
        private string _email;
        private ushort _practice;
        private string _role;

        public ulong ID
        {
            get => _id;
            set
            {
                var state = new State<ulong>();
                state.ObjectName = "Crew";
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
                state.ObjectName = "Crew";
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
                state.ObjectName = "Crew";
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
                state.ObjectName = "Crew";
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
                state.ObjectName = "Crew";
                state.PropertyName = "Email";
                state.PrevValue = _email;
                _email = value;
                state.UpdatedValue = _email;
                Log.Instance.LogWrite(state);
            }
        }
        public ushort Practice
        {
            get => _practice;
            set
            {
                var state = new State<ushort>();
                state.ObjectName = "Crew";
                state.PropertyName = "Practice";
                state.PrevValue = _practice;
                _practice = value;
                state.UpdatedValue = _practice;
                Log.Instance.LogWrite(state);
            }
        }
        public string Role
        {
            get => _role;
            set
            {
                var state = new State<string>();
                state.ObjectName = "Crew";
                state.PropertyName = "Role";
                state.PrevValue = _role;
                _role = value;
                state.UpdatedValue = _role;
                Log.Instance.LogWrite(state);
            }
        }


        private ulong _prevID;
        [JsonIgnore]
        public List<IObserver> Observers { get; set; }
        [JsonIgnore]
        public ulong PrevID { get => _prevID; set => _prevID = value; }


        public Crew()
        {
            _id = default;
            _name = string.Empty;
            _age = default;
            _phone = string.Empty;
            _email = string.Empty;
            _practice = default;
            _role = string.Empty;
            _prevID = default;
            Observers = [];
        }

        public Crew(ulong id, string name, ulong age, string phone, string email, ushort practice, string role)
        {
            _id = id;
            _name = name;
            _age = age;
            _phone = phone;
            _email = email;
            _practice = practice;
            _role = role;
            _prevID = default;
            Observers = [];
        }

        public Dictionary<string, Func<IPrimaryKeyed, string>> PropertySet
        {
            get => new()
            {
                { "ID", crew => ((Crew)crew).ID.ToString() },
                { "Name", crew => ((Crew)crew).Name },
                { "Age", crew => ((Crew)crew).Age.ToString() },
                { "Phone", crew => ((Crew)crew).Phone },
                { "Email", crew => ((Crew)crew).Email },
                { "Practice", crew => ((Crew)crew).Practice.ToString() },
                { "Role", crew => ((Crew)crew).Role }
            };
                
        } 

        public override string ToString()
        {
            return $"[Crew]\nID: {_id}\n Name: {_name}\n Age: {_age}\n Phone: {_phone}\n Email: {_email}\n Practice: {_practice}\n Role: {_role}\n";
        }

        public object Clone()
        {
            return new Crew(_id, _name, _age, _phone, _email, _practice, _role);
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
