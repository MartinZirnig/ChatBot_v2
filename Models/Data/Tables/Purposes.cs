﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Data.Tables
{
    internal class Purposes : ReferedTable
    {
        public List<string> Purpose { get; set; }
    }
}
