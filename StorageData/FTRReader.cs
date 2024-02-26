using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.AbstarctFactories;
using OODProj.Repository;

namespace OODProj.StorageData
{
    public interface IReader
    {
        void Read();
    }

    public class FTRReader : IReader
    {
        private string _path;

        private Dictionary<string, IFactory> _factories;

        private Dictionary<string, IRepository> _repos;

        public FTRReader(string path, Dictionary<string, IFactory> factories, Dictionary<string, IRepository> repos) 
            => (_path, _factories, _repos) = (path, factories, repos);

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

                        List<List<string>>? arrayVals = null;

                        foreach (var item in splittedLine)
                        {
                            if (item.IndexOf('[') != -1) 
                            {
                                arrayVals = new List<List<string>>();
                                var arraySplittedVals = item.Substring(1, item.Length - 2).Split(";");
                                foreach (var arrayItem in arraySplittedVals)
                                {
                                    arrayVals.Add(arraySplittedVals.ToList());
                                }
                            }
                        }

                        _repos[splittedLine[0]].IAddToRepo(_factories[splittedLine[0]].Create(splittedLine.ToList(), arrayVals));
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
