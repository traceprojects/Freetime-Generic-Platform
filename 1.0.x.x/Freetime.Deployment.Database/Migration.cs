﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Freetime.Deployment.Database
{
    public abstract class Migration
    {
        public IMigrator Migrator { get; set; }

    }
}
