using OODProj.Data;
using OODProj.Data.Users;
using OODProj.Logging;
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

        public static void AssignID(ulong id, IPrimaryKeyed obj, string className)
        {
            if (!IDset.Contains(id))
            {
                obj.ID = id;
                IDset.Add(id);
                Objectsset.Add(id, obj);
            }
            else
            {
                ErrorState err = new()
                {
                    ErrorMessage = "ID already exists",
                    ObjectName = className
                };
                Log.Instance.LogWrite(err);
            }
        }
    }  
}
