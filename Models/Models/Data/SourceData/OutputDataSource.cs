using ModelsMl.Models.Data.SourceData.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Data.SourceData
{
    internal class OutputDataSource : IDataSource
    {
        public required string Format { get; set; }
        public required IEnumerable<string> Emotions { get; set; }
        public required IEnumerable<string> Informations { get; set; }
        public string Output { get; set; }

        public InputDataPair ToPair()
        {
            return new InputDataPair()
            {
                InputText = $"Format:'{this.Format}', " +
                    $"Emotions:'{string.Join(", ", this.Emotions)}', " +
                    $"Informations:'{string.Join(", ", this.Informations)}'",
                Label = this.Format
            };
        }
    }
}
