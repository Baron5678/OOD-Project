using OODProj.Repository;
using OODProj.Commands.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OODProj.DictionaryBuilders;

namespace OODProj.Commands
{
    public class Add : IPCommand
    {
        Dictionary<string, IRepository> _repos;
        Dictionary<string, IDictionaryBuilder> _builders;
        public IExecutor Executor { get; init; }
        public List<string>? Parameters { get; set; }

        public Add( Dictionary<string, IRepository> repos, Dictionary<string, IDictionaryBuilder> builders )
        {
            Executor = new CommandExecutor();
            _repos = repos;
            _builders = builders;
        }

        public void Execute()
        {
            Executor.Visit(this, _repos, _builders,  Parameters);
        }
    }
}
