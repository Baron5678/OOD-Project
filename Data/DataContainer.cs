using OODProj.Data.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data
{
    public class DataContainer
    {
        private List<CargoPlane> _dataCargoPlane;
        private List<PassengerPlane> _dataPassengerPlane;

        public List<CargoPlane> DataCargoPlane { get => _dataCargoPlane; set => _dataCargoPlane = value; }
        public List<PassengerPlane> DataPassengerPlane { get => _dataPassengerPlane; set => _dataPassengerPlane = value; }

        public DataContainer() 
        {
            _dataCargoPlane = new List<CargoPlane>();
            _dataPassengerPlane = new List<PassengerPlane>();
        }

    }
}
