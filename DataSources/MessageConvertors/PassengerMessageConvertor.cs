using OODProj.Builders;
using OODProj.Data.Users;
using OODProj.Utilities;

namespace OODProj.DataSources.MessageConvertors
{
    public class PassengerMessageConvertor : IMessageConvertor
    {
        private short NL = 0;
        private short EL = 0;

        public string[] ConvertToStrings(byte[] data)
        {
            NL = BitConverter.ToInt16(data[15..17]);
            EL = BitConverter.ToInt16(data[(31 + NL)..(33 + NL)]);

            return [IDToString(data[7..15]),
                    NameToString(data[17..(17 + NL)]),
                    AgeToString(data[(17 + NL)..(19 + NL)]),
                    PhoneToString(data[(19 + NL)..(31 + NL)]),
                    EmailToString(data[(33 + NL)..(33 + NL + EL)]),
                    ClassToString(data[(33 + NL + EL)..(34 + NL + EL)]),
                    MilesToString(data[(34 + NL + EL)..(42 + NL + EL)])];

        }

        private string IDToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("ID must be 8 bytes long");
            return BitConverter.ToUInt64(value).ToString();
        }

        private string NameToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        private string AgeToString(byte[] value)
        {
            if (value.Length != 2)
                throw new ArgumentException("Age must be 2 bytes long");
            return BitConverter.ToUInt16(value).ToString();
        }

        private string PhoneToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        private string EmailToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        private string ClassToString(byte[] value)
        {
            return Utility.BytesToString(value);
        }

        private string MilesToString(byte[] value)
        {
            if (value.Length != 8)
                throw new ArgumentException("Seat must be 2 bytes long");
            return BitConverter.ToUInt64(value).ToString();
        }
    }
}