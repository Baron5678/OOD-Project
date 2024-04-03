using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.Commands;
using OODProj.Repository;
using OODProj.NewsReport;

namespace OODProj.Commands.Functionality
{
    public interface IExecutor
    {
        void Visit(Print printCommand, DataContainer data);
        void Visit(Report reportCommand, INewsIterator data);
    }
}
