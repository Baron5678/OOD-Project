using System.Collections;

namespace OODProj.Data
{
    public interface IPrimaryKeyed 
    {
         ulong ID { get; set; }
         ulong PrevID { get; set; }
         Dictionary<string, Func<IPrimaryKeyed, string>> PropertySet { get; }
    }
}