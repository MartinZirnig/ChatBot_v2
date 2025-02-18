using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Data.SourceData.General
{
    internal class OutputDataPair
    {
        public string PredictedLabel { get; set; }
        public float[] Score { get; set; }
    }
}
