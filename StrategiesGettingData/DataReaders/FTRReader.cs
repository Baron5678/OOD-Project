using OODProj.AbstarctFactories;
using OODProj.Repository;

namespace OODProj.StrategiesGettingData.DataReaders
{
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
                StreamReader sr = new StreamReader(_path);
                
                string line;

                while ((line = sr.ReadLine()!) != null)
                {
                        string[] splittedLine = line.Split(",");

                        List<List<string>> arrayVals = new();

                        foreach (var item in splittedLine)
                        {
                            if (item.IndexOf('[') != -1)
                            {
                                var arraySplittedVals = item.Substring(1, item.Length - 2).Split(";");
                                arrayVals.Add(arraySplittedVals.ToList());
                            }
                        }
                        _repos[splittedLine[0]].AddToRepo(_factories[splittedLine[0]].Create(splittedLine.ToList(), arrayVals));
                }
               sr.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
