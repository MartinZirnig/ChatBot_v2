using ModelsMl.Models.Data.SourceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Models.Models
{
    internal class FormatProvider : GeneralMlModel
    {
        protected override IEnumerable<IDataSource> DefaultTrain()
        {
            return [ new FormatDataSource()
                {
                    Input = "I am happy",
                    Emotions =  ["joy"],
                    Format = "Nice to be happy"
                }];
        }
    }
}
