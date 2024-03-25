﻿using OODProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Builders.Directors
{
    public interface IDirector
    {
       IBuilder Construct(byte[] values);
    }
}