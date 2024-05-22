using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.DictionaryBuilders
{
    public interface IDictionaryBuilder
    {
        IPrimaryKeyed GetObject();
        Dictionary<string, Action<string>> BuilderMethods { get; }
    }
}
