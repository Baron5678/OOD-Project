﻿using OODProj.Commands.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProj.NewsReport;
using BruTile.Wms;

namespace OODProj.Commands
{
    public class Report : IPCommand
    {
        public IExecutor Executor { get; init; }
        private INewsIterator _newsGenerator;
        public List<string>? Parameters { get; set; } = null;

        public Report(INewsIterator newsGenerator)
        {
            _newsGenerator = newsGenerator;
            Executor = new CommandExecutor();
        }

        public void Execute()
            => Executor.Visit(this, _newsGenerator);
         
    }
}
