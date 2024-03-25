using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Builders.PlanesBuilders;

namespace OODProj.Builders.Directors.PlaneDirectories
{
    public class PassengerPlaneDirector : IDirector
    {
        private PassengerPlaneBuilder _builder;

        public PassengerPlaneDirector(PassengerPlaneBuilder builder)
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
            _builder.BuildFirstClassSize(values[(30 + ML)..(32 + ML)]);
            _builder.BuildEconomyClassSize(values[(32 + ML)..(34 + ML)]);
            _builder.BuildBusinessClass(values[(34 + ML)..(36 + ML)]);

            return _builder;
        }
    }
}
