using ModelsMl.Models.Data.SourceData.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Data.SourceData
{
    internal class FormatDataSource : IDataSource
    {
        public required string Input { get; set; }
        public required IEnumerable<string> Emotions { get; set; }
        public string Format { get; set; } 

        public InputDataPair ToPair()
        {
            return new InputDataPair()
            {
                InputText = $"Input:'{this.Input}', Emotions:'{string.Join(", ", this.Emotions)}'",
                Label = this.Format
            };
        }
    }
}
