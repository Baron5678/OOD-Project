using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Planes;

namespace OODProj.NewsReport
{
    public class Television : INewsProvider
    {
        private string _name;
        public string Name { get => _name; init => _name = value; }

        public Television(string name)
        {
            _name = name;
        }

        public string Visit(Airport airport)
            =>
        $"<An image of {airport.Name} airport>";
        

        public string Visit(CargoPlane cargoPlane)
            =>
        $"<An image of {cargoPlane.Serial} cargo plane>";
        

        public string Visit(PassengerPlane passengerPlane)
            =>
        $"<An image of {passengerPlane.Serial} passenger plane";
    }
}
