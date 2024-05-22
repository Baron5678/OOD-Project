using OODProj.Data;
using OODProj.Utilities;

namespace OODProj.DataSources.MessageConvertors
{
    public class CargoPlaneMessageConvertor : IMessageConvertor
    {
        private short ML = 0;

        public string[] ConvertToStrings(byte[] data)
        {
            ML = BitConverter.ToInt16(data[28..30]);

            return [IDToString(data[7..15]),
                   SerialToString(data[15..25]),
                   CountryToString(data[25..28]),
                   ModelToString(data[30..(30 + ML)]),
                   MaxLoadToString(data[(30 + ML)..(34 + ML)])];
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

        private string MaxLoadToString(byte[] value)
        {
            return BitConverter.ToSingle(value).ToString();
        }

    }
}