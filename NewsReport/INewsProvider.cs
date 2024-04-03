using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Planes;

namespace OODProj.NewsReport
{
    public interface INewsProvider
    {
       public string Visit(Airport airport);
       public string Visit(CargoPlane cargoPlane);
       public string Visit(PassengerPlane passengerPlane);
    }
}
