using OODProj.Builders;
using OODProj.Data;
using OODProj.Utilities;
using System.Text;

namespace OODProj.DataSources.MessageConvertors
{
    internal class FlightMessageConvertor : IMessageConvertor
    {
        private short CC = 0;
        private short PCC = 0;

        public string[] ConvertToStrings(byte[] data)
        {
            CC = BitConverter.ToInt16(data[55..57]);
            PCC = BitConverter.ToInt16(data[(57 + 8 * CC)..(59 + 8 * CC)]);

            return [IDToString(data[7..15]),
                           OriginIDToString(data[15..23]),
                           TargetIDToString(data[23..31]),
                           TakeoffTimeToString(data[31..39]),
                           LandingTimeToString(data[39..47]),
                           "0.0",
                           "0.0",
                           "0.0",
                           PlaneIDToString(data[47..55]),
                           CrewToString(data[57..(57 + 8 * CC)]),
                           LoadToString(data[(59 + 8 * CC)..(59 + 8 * CC + 8 * PCC)])];

        }

        private string IDToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            return BitConverter.ToUInt64(value).ToString();
        }

        private string OriginIDToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            return BitConverter.ToUInt64(value).ToString();
        }

        private string TargetIDToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            return BitConverter.ToUInt64(value).ToString();
        }

        private string TakeoffTimeToString(byte[] value)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(BitConverter.ToInt64(value));
            return dateTimeOffset.ToLocalTime().ToString("HH:mm");
        }

        private string LandingTimeToString(byte[] value)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(BitConverter.ToInt64(value));
            return dateTimeOffset.ToLocalTime().ToString("HH:mm");
        }

        private string PlaneIDToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("PlaneID must be 8 bytes long");
            return BitConverter.ToUInt64(value).ToString();
        }

        private string CrewToString(byte[] value)
        {
            ulong[] uint64Crew = Utility.ConvertToUInt64Array(value);

            StringBuilder arrayCrew = new();

            arrayCrew.Append('[');  

            for (int i = 0; i < uint64Crew.Length; i++)
            {
                arrayCrew.Append(uint64Crew[i].ToString());
                if (i != uint64Crew.Length - 1)
                    arrayCrew.Append(';');
            }

            arrayCrew.Append(']');

            return arrayCrew.ToString();

        }

        private string LoadToString(byte[] value)
        {

            ulong[] uint64Load = Utility.ConvertToUInt64Array(value);
            StringBuilder arrayLoad = new();
            arrayLoad.Append('[');  
            for (int i = 0; i < uint64Load.Length; i++)
            {
                arrayLoad.Append(uint64Load[i].ToString());
                if (i != uint64Load.Length - 1)
                    arrayLoad.Append(';');
            }
            arrayLoad.Append(']');
            return arrayLoad.ToString();

        }

    }
}