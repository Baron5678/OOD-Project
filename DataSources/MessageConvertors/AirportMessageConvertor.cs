using OODProj.Builders;
using OODProj.Data;
using OODProj.Utilities;

namespace OODProj.DataSources.MessageConvertors
{
    public class AirportMessageConvertor : IMessageConvertor
    {
        private short NL = 0;
        
        public string[] ConvertToStrings(byte[] data)
        {
            NL = BitConverter.ToInt16(data[15..17]);

            return [IDToString(data[7..15]),
                    NameToString(data[17..(17 + NL)]),
                    CodeToString(data[(17 + NL)..(20 + NL)]),
                    LongitudeToString(data[(20 + NL)..(24 + NL)]),
                    LatitudeToString(data[(24 + NL)..(28 + NL)]),
                    AMSLToString(data[(28 + NL)..(32 + NL)]),
                    CountryToString(data[(32 + NL)..(35 + NL)])];
        }

       
        private string IDToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            var test = BitConverter.ToUInt64(value);

            return BitConverter.ToUInt64(value).ToString();
        }

        private string NameToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        private string CodeToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        private string LongitudeToString(byte[] value)
        {
            if (value.Length != 4)
                throw new ArgumentException("Longitude must be 4 bytes long");
            return BitConverter.ToSingle(value).ToString();
        }

        private string LatitudeToString(byte[] value)
        {
            if (value.Length != 4)
                throw new ArgumentException("Longitude must be 4 bytes long");
            return BitConverter.ToSingle(value).ToString();
        }

        private string AMSLToString(byte[] value)
        {
            if (value.Length != 4)
                throw new ArgumentException("AMSL must be 4 bytes long");
            return BitConverter.ToSingle(value).ToString();
        }
   
        public string CountryToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }
    }

}
