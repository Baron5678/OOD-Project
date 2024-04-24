using OODProj.Data.Planes;
using OODProj.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data.Observers
{
    public interface IObserver
    {
        void UpdateID(Airport airport){}
        void UpdateID(CargoPlane cargoPlane){}
        void UpdateID(PassengerPlane passengerPlane){}
        void UpdateID(Passenger passenger){}
        void UpdateID(Cargo cargo){}
        void UpdateID(Crew crew){}
    }
}
