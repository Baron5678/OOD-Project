using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Repository;
using OODProj.Repository.UserRepositories;  
using OODProj.Repository.PlaneRepositories;  
using OODProj.Data;
using OODProj.Data.Users;
using OODProj.Data.Planes;

namespace OODProj.Repository
{
    public class DataContainer
    {

        //Private fields
        private AirportRepository _airportData;
        private FlightRepository _flightData;
        private PassengerRepository _passengerData;
        private CrewRepository _crewData;
        private CargoRepository _ticketData;
        private CargoPlaneRepository _cargoPlaneData;
        private PassengerPlaneRepository _passengerPlaneData;

        public AirportRepository AirportData { get => _airportData; }
        public FlightRepository FlightData { get => _flightData; }
        public PassengerRepository PassengerData { get => _passengerData; }
        public CrewRepository CrewData { get => _crewData; }
        public CargoRepository TicketData { get => _ticketData; }
        public CargoPlaneRepository CargoPlaneData { get => _cargoPlaneData; }
        public PassengerPlaneRepository PassengerPlaneData { get => _passengerPlaneData; }


        public DataContainer(Dictionary<string, IRepository> repos)
        {
            _airportData = (AirportRepository)repos[Airport.ClassID];
            _flightData = (FlightRepository)repos[Flight.ClassID];
            _passengerData = (PassengerRepository)repos[Passenger.ClassID];
            _crewData = (CrewRepository)repos[Crew.ClassID];
            _ticketData = (CargoRepository)repos[Cargo.ClassID];
            _cargoPlaneData = (CargoPlaneRepository)repos[CargoPlane.ClassID];
            _passengerPlaneData = (PassengerPlaneRepository)repos[PassengerPlane.ClassID];                      
        }
    }
}
