using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
namespace OODProj.NewsReport
{
    public class Newspaper : INewsProvider
    {
        private string _name;
        public string Name { get => _name; init => _name = value; }

        public Newspaper(string name) 
        {
            _name = name;
        }

        public string Visit(Airport airport)
            =>
        $"{_name} - A report from the {airport.Name} airport, {airport.Country}.";
        

        public string Visit(CargoPlane cargoPlane)
            =>
        $"{_name} - An interview with the crew of { cargoPlane.Serial}.";
        

        public string Visit(PassengerPlane passengerPlane)
             =>
        $"{_name} - Breaking news! {passengerPlane.Model} aircraft loses EASA fails certification after inspection of {passengerPlane.Serial}";
        
    }
}
