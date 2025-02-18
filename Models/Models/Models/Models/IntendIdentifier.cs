using ModelsMl.Models.Data.SourceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Models.Models
{
    internal class IntendIdentifier : GeneralMlModel
    {
        protected override IEnumerable<IDataSource> DefaultTrain()
        {
            return [ new IntendsDataSource()
                {
                    Input = "I am happy",
                    Intends = ["smallTalk"],
            }];
        }
    }
}
