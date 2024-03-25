using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Utilities
{
    static public class Utility
    {
        public static string BytesToString(byte[] bytes)
        {
            StringBuilder s = new();
            foreach (byte item in bytes)
            {
                s.Append((char)item);
            }
            return s.ToString();
        }

        public static ulong[] ConvertToUInt64Array(byte[] byteArray)
        {
            if (byteArray is null) 
                throw new ArgumentNullException(nameof(byteArray));
            if (byteArray.Length % 8 != 0) 
                throw new ArgumentException("The length of the byte array must be a multiple of 8.");

            ulong[] uint64Array = new ulong[byteArray.Length / 8];

            for (int i = 0; i < uint64Array.Length; i++)
                uint64Array[i] = BitConverter.ToUInt64(byteArray, i * 8);
         
            return uint64Array;
        }

        public static bool TryParseUlongs(string array, out ulong[] ulongArray) {

            if (array.IndexOf('[') == -1)
            {
                ulongArray = [];
                return false;
            }

           string[] arrayElements = array.Substring(1, array.Length - 2).Split(";");
           List<ulong> result = new List<ulong>();

           foreach (string element in arrayElements)
                result.Add(ulong.Parse(element));

           ulongArray = result.ToArray();

           return true;
        }
    }
}
