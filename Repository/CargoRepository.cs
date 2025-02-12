﻿using OODProj.Data;
using OODProj.DataSerializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OODProj.Repository
{
    public class CargoRepository: IRepository
    {
        private List<Cargo> _airports;
        private ISerializer _serializeFormat;

        public List<Cargo> Cargos { get => _airports; init => _airports = value; }

        [JsonIgnore]
        public ISerializer SerializeFormat { get => _serializeFormat; init => _serializeFormat = value; }

        public CargoRepository()
        {
            _airports = new List<Cargo>();
            _serializeFormat = new JSONSerializer();
        }

        public void SerializeRepository()
        {
            _serializeFormat.Serialize(this);
        }

        public void AddToRepo(IPrimaryKeyed keyedObject)
        { 
            _airports.Add((Cargo)keyedObject);
        }

        public void DisplayObjects()
        {
            foreach (var airport in _airports)
            {
                Console.WriteLine(airport.ToString());
            }
        }

        public List<IPrimaryKeyed> GetPrimaryKeyedObjects()
        {
            return _airports.Cast<IPrimaryKeyed>().ToList();
        }

        public void DeleteFromRepo(IPrimaryKeyed keyedObject)
        {
            _airports.Remove((Cargo)keyedObject);
        }

        public void DeleteAll()
          =>_airports.Clear();
    }
}
