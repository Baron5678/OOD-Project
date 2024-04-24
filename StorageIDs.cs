using OODProj.Data;
using OODProj.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OODProj
{
    public static class StorageIDs
    {
        public static List<ulong> IDset { get; set; } = [];
        public static Dictionary<ulong, IPrimaryKeyed> Objectsset { get; set; } = [];
        public static Dictionary<ulong, IPositioned> PositionedObjects { get; set; } = [];
        public static Dictionary<ulong, IUser> UserObjects { get; set; } = [];
    }  
}
