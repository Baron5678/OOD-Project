using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data.Users
{
    public class Crew : IUser, ICloneable
    {
        static public string ClassID { get => "C"; }

        private ulong _id;
        private string _name;
        private ulong _age;
        private string _phone;
        private string _email;
        private ushort _practice;
        private string _role;

        public ulong ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public ulong Age { get => _age; set => _age = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Email { get => _email; set => _email = value; }
        public ushort Practice { get => _practice; set => _practice = value; }
        public string Role { get => _role; set => _role = value; }

        public Crew()
        {
            _id = default;
            _name = string.Empty;
            _age = default;
            _phone = string.Empty;
            _email = string.Empty;
            _practice = default;
            _role = string.Empty;
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
        }

        public override string ToString()
        {
            return $"[Crew]\nID: {_id}\n Name: {_name}\n Age: {_age}\n Phone: {_phone}\n Email: {_email}\n Practice: {_practice}\n Role: {_role}\n";
        }

        public object Clone()
        {
            return new Crew(_id, _name, _age, _phone, _email, _practice, _role);
        }
    }
}
