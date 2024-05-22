using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OODProj.Commands.Functionality;
using OODProj.Repository;

namespace OODProj.Commands
{
    public class Print : IPCommand
    {
        private DataContainer _data;
        public IExecutor Executor { get; init; }
        public List<string>? Parameters { get; set; } = null;

        public IExecutor _executor => throw new NotImplementedException();

        public Print(DataContainer data)
        {
            _data = data;
            Executor = new CommandExecutor();
        }

        public void Execute()
        {
            Executor.Visit(this, _data);
        }
        
    }
}
