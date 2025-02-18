using ModelsMl.Models.Data.SourceData.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Data.SourceData
{
    internal class EmotionsDataSource : IDataSource
    {
        public required string Input { get; set; }
        public IEnumerable<string> Emotions { get; set; }

        public InputDataPair ToPair()
        {
            return new InputDataPair()
            {
                InputText = Input,
                Label = string.Join(", ", Emotions)
            };
        }
    }
}
