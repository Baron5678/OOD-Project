using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data.Users
{
    public class Passenger : IUser, ICloneable
    {
        static public string ClassID { get => "P"; }

        private ulong _id;
        private string _name;
        private ulong _age;
        private string _phone;
        private string _email;
        private string _class;
        private ulong _miles;

        public ulong ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public ulong Age { get => _age; set => _age = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Email { get => _email; set => _email = value; }
        public string Class { get => _class; set => _class = value; }
        public ulong Miles { get => _miles; set => _miles = value; }

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
        }

        public override string ToString()
        {
            return $"ID: {_id}\n Name: {_name}\n Age: {_age}\n Phone: {_phone}\n Email: {_email}\n Practice: {_class}\n Role: {_miles}";
        }

        public object Clone()
        {
            return new Passenger(_id, _name, _age, _phone, _email, _class, _miles);
        }

    }
}
