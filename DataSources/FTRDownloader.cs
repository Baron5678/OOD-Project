using OODProj.AbstractFactories;
using OODProj.Data;
using OODProj.Repository;

namespace OODProj.DataSources
{
    public class FTRDownloader : IDataDownloader
    {
        private string _path;

        private Dictionary<string, IFactory> _factories;

        private Dictionary<string, IRepository> _repos;

        public FTRDownloader(string path, 
                            Dictionary<string, IFactory> factories, 
                            Dictionary<string, IRepository> repos)
            => (_path, _factories, _repos) = (path, factories, repos);

        public void Download()
        {
            try
            {
                StreamReader sr = new StreamReader(_path);
                string line = string.Empty;
                //Getting each line representing an object
                while ((line = sr.ReadLine()!) != null)
                {
                    //Splitting the line into string values
                    //IMPORTANT: first string value is the classID in each line,
                    //so it is used to determine the type of object to be created
                    //and splittingLine[0] is ClassID
                    string[] splittingLine = line.Split(",");

                    // Adding the object to the repository initialized with values from file to being processed
                    _repos[splittingLine[0]].AddToRepo(_factories[splittingLine[0]].SetObjectData(splittingLine[1..]).Create());
                    _factories[splittingLine[0]].ResetObjectData();
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
