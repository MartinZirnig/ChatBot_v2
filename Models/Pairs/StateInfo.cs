using Microsoft.EntityFrameworkCore;
using ModelsMl.Data;
using ModelsMl.Data.Tables;
using ModelsMl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Pairs
{
    public abstract record StateInfo(
        bool Loaded,
        bool Ignored
        )
    {
        public Model Model { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        internal abstract void PushToDb(DatabaseConnection db);
    }
}
