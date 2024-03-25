using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Builders;


namespace OODProj.Builders.Directors
{
    public class FlightDirector : IDirector
    {
        private FlightBuilder _builder;

        public FlightDirector(FlightBuilder builder)
        {
            _builder = builder;
        }

        public IBuilder Construct(byte[] values)
        {
            short CC = BitConverter.ToInt16(values[55..57]);
            short PCC = BitConverter.ToInt16(values[(57 + 8*CC)..(59 + 8*CC)]);

            _builder.BuildID(values[7..15]);
            _builder.BuildOriginID(values[15..23]);
            _builder.BuildTargetID(values[23..31]);
            _builder.BuildTakeoffTime(values[31..39]);
            _builder.BuildLandingTime(values[39..47]);
            _builder.BuildPlaneID(values[47..55]);
            _builder.BuildCrew(values[57..(57 + 8*CC)]);
            _builder.BuildLoad(values[(59 + 8 * CC)..(59 + 8 * CC + 8 * PCC)]);

            return _builder;
        }
    }
}
