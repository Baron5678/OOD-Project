using OODProj.Builders.UserBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Builders.Directors.UserDirectors
{
    public class CrewDirector : IDirector
    {
        private CrewBuilder _builder;

        public CrewDirector(CrewBuilder builder)
        {
            _builder = builder;
        }

        public IBuilder Construct(byte[] bytes)
        {
            short NL = BitConverter.ToInt16(bytes[15..17]);
            short EL = BitConverter.ToInt16(bytes[(31 + NL)..(33 + NL)]);

            _builder.BuildID(bytes[7..15]);
            _builder.BuildName(bytes[17..(17 + NL)]);
            _builder.BuildAge(bytes[(17 + NL)..(19 + NL)]);
            _builder.BuildPhone(bytes[(19 + NL)..(31 + NL)]);
            _builder.BuildEmail(bytes[(33 + NL)..(33 + NL + EL)]);
            _builder.BuildPractice(bytes[(33 + NL + EL)..(35 + NL + EL)]);
            _builder.BuildRole(bytes[(35 + NL + EL)..(36 + NL + EL)]);

            return _builder;
        }
    }
}
