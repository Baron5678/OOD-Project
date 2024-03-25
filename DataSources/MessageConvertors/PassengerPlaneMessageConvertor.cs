using OODProj.Builders;
using OODProj.Data.Planes;
using OODProj.Utilities;

namespace OODProj.DataSources.MessageConvertors
{
    public class PassengerPlaneMessageConvertor : IMessageConvertor
    {
        private short ML = 0;
        public string[] ConvertToStrings(byte[] data)
        {
            ML = BitConverter.ToInt16(data[28..30]);

            return [IDToString(data[7..15]),
                   SerialToString(data[15..25]),
                   CountryToString(data[25..28]),
                   ModelToString(data[30..(30 + ML)]),
                   FirstClassSizeToString(data[(30 + ML)..(32 + ML)]),
                   EconomyClassSizeToString(data[(32 + ML)..(34 + ML)]),
                   BusinessClassSizeToString(data[(34 + ML)..(36 + ML)])];
        }

        private string IDToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            return BitConverter.ToUInt64(value).ToString();
        }

        private string SerialToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        private string CountryToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        private string ModelToString(byte[] value)
        {
            return Utility.BytesToString(value);

        }

        private string FirstClassSizeToString(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("FirstClassSize must be 2 bytes long");
            return BitConverter.ToUInt16(value).ToString();
        }

        private string BusinessClassSizeToString(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("BusinessClassSize must be 2 bytes long");
            return BitConverter.ToUInt16(value).ToString();
        }

        private string EconomyClassSizeToString(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("EconomyClassSize must be 2 bytes long");
            return BitConverter.ToUInt16(value).ToString();
        }
    }
}