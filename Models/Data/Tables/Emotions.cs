using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Data.Tables
{
    internal class Emotions : ReferedTable
    {
        public List<string> Emotion { get; set; }
    }
}
