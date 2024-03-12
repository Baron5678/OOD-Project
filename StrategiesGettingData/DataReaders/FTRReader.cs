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
                //Getting each line representing an object
                while ((line = sr.ReadLine()!) != null)
                {
                        //Splitting the line into string values
                        //IMPORTANT: first string value is the classID in each line,
                        //so it is used to determine the type of object to be created
                        //and splittedLine[0] is ClassID
                        string[] splittedLine = line.Split(",");

                        List<List<string>> arrayVals = new();

                        foreach (var item in splittedLine)
                        {
                            //Checking if the item is an array
                            if (item.IndexOf('[') != -1)
                            {
                                //Adding the array to the list of arrays
                                var arraySplittedVals = item.Substring(1, item.Length - 2).Split(";");
                                arrayVals.Add(arraySplittedVals.ToList());
                            }
                        }
                        // Adding the object to the repository initialized with values from file to being processed
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
