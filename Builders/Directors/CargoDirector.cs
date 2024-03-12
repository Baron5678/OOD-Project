using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Builders.Directors
{
    public class CargoDirector : IDirector
    {
        private CargoBuilder _builder;

        public CargoDirector(CargoBuilder builder)
        {
            _builder = builder;
        }

        public IBuilder Construct(byte[] values)
        {
            short DL = BitConverter.ToInt16(values[25..27]);

            _builder.BuildID(values[7..15]);
            _builder.BuildWeight(values[15..19]);
            _builder.BuildCode(values[19..25]);
            _builder.BuildDescription(values[27..(27 + DL)]);
        
            return _builder;
        }
    }
}
