using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.DataSources.MessageConvertors
{
    public interface IMessageConvertor
    {
        string[] ConvertToStrings(byte[] data);
    }
}
