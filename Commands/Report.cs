using OODProj.Commands.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.NewsReport;

namespace OODProj.Commands
{
    public class Report : IPCommand
    {
        private IExecutor _executor;
        private INewsIterator _newsGenerator;

        public Report(INewsIterator newsGenerator)
        {
            _newsGenerator = newsGenerator;
            _executor = new CommandExecutor();
        }

        public void Execute()
            => _executor.Visit(this, _newsGenerator);
         
    }
}
