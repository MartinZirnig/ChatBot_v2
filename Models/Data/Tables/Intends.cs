using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Data.Tables
{
    internal class Intends : ReferedTable
    {
        public List<string> Intend { get; set; }
    }
}
