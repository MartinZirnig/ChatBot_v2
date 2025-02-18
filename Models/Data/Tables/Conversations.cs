using Microsoft.EntityFrameworkCore.Query.Internal;
using ModelsMl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Data.Tables
{
    internal class Conversations : ReferedTable
    {
        public Inputs? Input { get; set; }
        public Outputs? Output { get; set; }

        public Intends? Intends { get; set; }
        public Emotions? Emotions { get; set; }
        public Purposes? Purposes { get; set; }
        public Informations? Informations { get; set; }
        public Formats? Format { get; set; }

        public bool Loaded { get; set; }
        public bool Ignored { get; set; }

        public Model UsedByModel { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
