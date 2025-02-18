using ModelsMl.Models.Data.SourceData.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Data.SourceData
{
    internal class IntendsDataSource : IDataSource
    {
        public required string Input { get; set; }
        public IEnumerable<string> Intends { get; set; }

        public InputDataPair ToPair()
        {
            return new InputDataPair()
            {
                InputText = this.Input,
                Label = string.Join(", ", Intends)
            };
        }
    }
}
