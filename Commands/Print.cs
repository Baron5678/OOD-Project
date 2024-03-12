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
        private IExecutor _executor;

        public Print(DataContainer data)
        {
            _data = data;
            _executor = new CommandExecutor();
        }

        public void Execute()
        {
           _executor.Visit(this, _data);
        }
        
    }
}
