using ModelsMl.Models.Data.SourceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Models.Models
{
    internal class OutputGenerator : GeneralMlModel
    {
        protected override IEnumerable<IDataSource> DefaultTrain()
        {
            return [ new OutputDataSource()
                {
                    Format = "Nice to be happy",
                    Emotions =  ["joy"],
                    Informations = ["I am happy"],
                    Output = "I am happy and joyful"
            }];
        }
    }
}
