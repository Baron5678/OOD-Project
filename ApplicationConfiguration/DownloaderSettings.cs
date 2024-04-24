using OODProj.AbstractFactories;
using OODProj.AbstractFactories.PlaneFactories;
using OODProj.AbstractFactories.UserFactories;
using OODProj.Data.Planes;
using OODProj.Data.Users;
using OODProj.Data;
using OODProj.DataSources.MessageConvertors;
using OODProj.IDManagement;
using OODProj.Repository;
using OODProj.Repository.PlaneRepositories;
using OODProj.Repository.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.ApplicationConfiguration
{
    public abstract class DownloaderSettings
    { 
        protected string _downloaderID;
        protected string _sourceFile;
        protected List<IReportable> _reportables;
        protected List<string> _reportableIDs;
        protected readonly Dictionary<string, IFactory> _factories;
        protected readonly Dictionary<string, IRepository> _repos;
        protected readonly Dictionary<string, IManagerID> _managers;

        public DownloaderSettings(string sourceFile, 
                                  Dictionary<string, IFactory> factories,
                                  Dictionary<string, IRepository> repos,
                                  List<IReportable> reportables,
                                  Dictionary<string, IManagerID> managers,
                                  List<string> reportableIDs)
        {
            _downloaderID = string.Empty;
            _sourceFile = sourceFile;
            _factories = factories;
            _repos = repos;
            _reportables = reportables;
            _reportableIDs = reportableIDs;
            _managers = managers;
        }
    }
}
