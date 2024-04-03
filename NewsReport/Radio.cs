using OODProj.NewsReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Planes;

namespace OODProj.NewsReport
{
    public class Radio : INewsProvider
    {
        private string _name;
        public string Name { get => _name; init => _name = value; }

        public Radio(string name)
        {
            _name = name;
        }

        public string Visit(Airport airport)
            => 
        $"Reporting for {_name}, Ladies and Gentlemen, we are at the {airport.Name} airport.";

        public string Visit(CargoPlane cargoPlane)
            =>
        $"Reporting for {_name}, Ladies and Gentlemen, we are seeing the {cargoPlane.Model} aircraft fly above us.";

        public string Visit(PassengerPlane passengerPlane)
            =>
        $"Reporting for {_name}, Ladies and Gentlemen, we’ve just witnessed {passengerPlane.Model} take off";
    }
}
