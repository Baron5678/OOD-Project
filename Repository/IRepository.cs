﻿using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.DataSerializers;

namespace OODProj.Repository
{
    public interface IRepository
    {
        ISerializer SerializeFormat { get; init; }
        void AddToRepo(IPrimaryKeyed keyedObject);
        void DeleteFromRepo(IPrimaryKeyed keyedObject);
        void DeleteAll();
        void DisplayObjects();
        void SerializeRepository();
        List<IPrimaryKeyed> GetPrimaryKeyedObjects();
    }
}
