using OODProj.Builders;
using OODProj.Data;
using OODProj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.DataSources.MessageConvertors
{
    public class CargoMessageConvertor : IMessageConvertor
    {
        private short DL = 0;

        public string[] ConvertToStrings(byte[] data)
        {
            DL = BitConverter.ToInt16(data[25..27]);

            return [IDToString(data[7..15]),
               WeightToString(data[15..19]),
               CodeToString(data[19..25]),
               DescriptionToString(data[27..(27 + DL)])];
        }

        private string IDToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");

             return BitConverter.ToUInt64(value).ToString();
        }

        private string WeightToString(byte[] value)
        {
            if (value.Length != 4)
                throw new ArgumentException("Weight must be 8 bytes long");
            return BitConverter.ToSingle(value).ToString();
        }

        public string CodeToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        public string DescriptionToString(byte[] value)
        {
            return Utility.BytesToString(value).ToString();
        }
    }
}
