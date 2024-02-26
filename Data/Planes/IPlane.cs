using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data.Planes
{
    public interface IPlane : IPrimaryKeyed
    {
        public string Serial { get; set; }
        public string Country { get; set; }
        public string Model { get; set; }
    }
}
