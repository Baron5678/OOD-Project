using OODProj.Builders.PlanesBuilders;
using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Builders.Directors.PlaneDirectories
{
    public class CargoPlaneDirector : IDirector
    {
        private CargoPlaneBuilder _builder;

        public CargoPlaneDirector(CargoPlaneBuilder builder)
        {
            _builder = builder;
        }
        public IBuilder Construct(byte[] values)
        {
            short ML = BitConverter.ToInt16(values[28..30]);

            _builder.BuildID(values[7..15]);
            _builder.BuildSerial(values[15..25]);
            _builder.BuildCountry(values[25..28]);
            _builder.BuildModel(values[30..(30 + ML)]);
            _builder.BuildMaxLoad(values[(30 + ML)..(34 + ML)]);

            return _builder;
        }
    }
}
