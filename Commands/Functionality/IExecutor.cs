using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Commands;
using OODProj.Repository;
using OODProj.NewsReport;
using OODProj.DictionaryBuilders;

namespace OODProj.Commands.Functionality
{
    public interface IExecutor
    {
        void Visit(Print printCommand, DataContainer data);
        void Visit(Report reportCommand, INewsIterator data);
        void Visit(Display display, Dictionary<string, IRepository> repos, List<string>? Parameters);
        void Visit(Update update, Dictionary<string, IRepository> repos, List<string>? Parameters);
        void Visit(Delete delete, Dictionary<string, IRepository> repos, List<string>? Parameters);
        void Visit(Add add, Dictionary<string, IRepository> repos, Dictionary<string, IDictionaryBuilder> builders, List<string>? Parameters);
    }
}
