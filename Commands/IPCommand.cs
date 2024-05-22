using OODProj.Commands.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Commands
{
    public interface IPCommand
    {
        public IExecutor Executor { get; init; }
        public List<string>? Parameters { get; set; }
        public void Execute();
    }
}
