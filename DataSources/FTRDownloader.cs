using OODProj.AbstractFactories;
using OODProj.Data;
using OODProj.Repository;
using OODProj.ApplicationConfiguration;

namespace OODProj.DataSources
{
    public class FTRDownloader : IDataDownloader
    {
        FTRDownloaderSettings _settings;
        public FTRDownloader(DownloaderSettings settings)
            => _settings = (FTRDownloaderSettings)settings;

        public void Download()
        {
            try
            {
                StreamReader sr = new(_settings.SourceFile);
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
                    var pkObject = _settings.Factories[splittingLine[0]].SetObjectData(splittingLine[1..]).Create();
                    _settings.Repositories[splittingLine[0]].AddToRepo(pkObject);
                    if (splittingLine[0] == "AI")
                        _settings.Managers[splittingLine[0]].AddPrimaryKeyedObject(pkObject);
                    if (_settings.ReportableIDs.Contains(splittingLine[0]))
                        _settings.Reportables.Add((IReportable)pkObject);
                    _settings.Factories[splittingLine[0]].ResetObjectData();
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
