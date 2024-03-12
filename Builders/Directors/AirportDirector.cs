using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Builders.Directors
{
    public class AirportDirector : IDirector
    {
        private AirportBuilder _builder;

        public AirportDirector(AirportBuilder builder)
        {
            _builder = builder;
        }

        public IBuilder Construct(byte[] values)
        {
            short NL = BitConverter.ToInt16(values[15..17]);

            _builder.BuildID(values[7..15]);
            _builder.BuildName(values[17..(17 + NL)]);
            _builder.BuildCode(values[(17 + NL)..(20 + NL)]);
            _builder.BuildLongitude(values[(20 + NL)..(24 + NL)]);
            _builder.BuildLatitude(values[(24 + NL)..(28 + NL)]);
            _builder.BuildAMSL(values[(28 + NL)..(32 + NL)]);
            _builder.BuildCountry(values[(32 + NL)..(35 + NL)]);  
  
            return _builder;
        }
    }
}
