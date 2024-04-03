using OODProj.NewsReport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data
{
    public interface IReportable 
    {
        public string Accept(INewsProvider provider);
    }
}
