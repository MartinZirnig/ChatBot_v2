using ModelsMl.Models.Data.SourceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Models.Models
{
    internal class PurposeIdentifier : GeneralMlModel
    {
        protected override IEnumerable<IDataSource> DefaultTrain()
        {
            return [ new PurposeDataSource()
                {
                    Input = "I am happy",
                    Purposes = ["nothing"]
            }];
        }
    }
}
