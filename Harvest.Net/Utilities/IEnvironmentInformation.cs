﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net.Utilities
{
    public interface IEnvironmentInformation
    {
        Version Version { get; }
    }
}
