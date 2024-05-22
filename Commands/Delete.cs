using OODProj.Commands.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Repository;

namespace OODProj.Commands
{
    public class Delete : IPCommand
    {
        private Dictionary<string, IRepository> _repos;
        public IExecutor Executor { get; init; }
        public List<string>? Parameters { get; set; }

        public Delete(Dictionary<string, IRepository> repos)
        {
            Executor = new CommandExecutor();
            _repos = repos;
        }

        public void Execute()
        {
            Executor.Visit(this, _repos, Parameters);
        }
    }
}
