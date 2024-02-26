using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.AbstarctFactories;

namespace OODProj.StorageData
{
    public interface IReader
    {
        void Read();
    }

    public class FTRReader : IReader
    {
        private string _path;

        private Dictionary<string, ICreateFactory> _factories;

        private Dictionary<string, IAddStrategy> _strategies;
        private DataContainer _data = new();

        public FTRReader(string path, DataContainer data, Dictionary<string, ICreateFactory> factories, Dictionary<string, IAddStrategy> strategies) 
            => (_path, _data, _factories, _strategies) = (path, data, factories, strategies);

        public void Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    string line;

                    while ((line = sr.ReadLine()!) != null)
                    {
                        string[] splittedLine = line.Split(",");

                        var obj = _factories[splittedLine[0]].SetValues(splittedLine.ToList()).Create();

                        _strategies[splittedLine[0]].AddToContainer(_data, obj);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
