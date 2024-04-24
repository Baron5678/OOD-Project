using OODProj.AbstractFactories;
using OODProj.Data;
using OODProj.Repository;
using OODProj.IDManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.ApplicationConfiguration
{
    public class FTRDownloaderSettings : DownloaderSettings
    {
        public string DownloaderID { get => _downloaderID; }
        public string SourceFile { get => _sourceFile; set => _sourceFile = value; }
        public List<IReportable> Reportables { get => _reportables; }
        public List<string> ReportableIDs { get => _reportableIDs; }
        public Dictionary<string, IFactory> Factories { get => _factories; }
        public Dictionary<string, IRepository> Repositories { get => _repos; }
        public Dictionary<string, IManagerID> Managers { get => _managers; }

        public FTRDownloaderSettings(string sourceFile, 
                                     Dictionary<string, IFactory> factories,
                                     Dictionary<string, IRepository> repos,
                                     Dictionary<string, IManagerID> managers,
                                     List<IReportable> reportables,
                                     List<string> reportableIDs) : base(sourceFile, factories, repos, reportables, managers, reportableIDs) 
        {
            _downloaderID = "FTR";
            _reportables = reportables;
            _reportableIDs = reportableIDs;
        }
    }
}
