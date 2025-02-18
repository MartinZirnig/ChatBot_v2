using ModelsMl.Models.Data.SourceData.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Data.SourceData
{
    internal class InformationsDataSource : IDataSource
    {
        public required IEnumerable<string> Intends { get; set; }
        public required IEnumerable<string> Purposes { get; set; }
        public IEnumerable<string> Informations { get; set; }


        public InputDataPair ToPair()
        {
            return new InputDataPair()
            {
                InputText = $"Intends:'{string.Join(", ", this.Intends)}', Purposes'{string.Join(", ", this.Purposes)}'",
                Label = string.Join(", ", Informations)
            };
        }
    }
}
