using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Builders.UserBuilders;


namespace OODProj.Builders.Directors.UserDirectors
{
    public class PassengerDirector : IDirector
    {
        private PassengerBuilder _builder;

        public PassengerDirector(PassengerBuilder builder)
        {
            _builder = builder;
        }

        public IBuilder Construct(byte[] values)
        {
            short NL = BitConverter.ToInt16(values[15..17]);
            short EL = BitConverter.ToInt16(values[(31 + NL)..(33 + NL)]);

            _builder.BuildID(values[7..15]);
            _builder.BuildName(values[17..(17 + NL)]);
            _builder.BuildAge(values[(17 + NL)..(19 + NL)]);
            _builder.BuildPhone(values[(19 + NL)..(31 + NL)]);
            _builder.BuildEmail(values[(33 + NL)..(33 + NL + EL)]);
            _builder.BuildClass(values[(33 + NL + EL)..(34 + NL + EL)]);
            _builder.BuildMiles(values[(34 + NL + EL)..(42 + NL + EL)]);

            return _builder;
        }
    }
}
