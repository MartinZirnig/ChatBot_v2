using ModelsMl.Data.Tables;
using ModelsMl.Models.Data.SourceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Models.Models
{
    internal class InformationsProvider : GeneralMlModel
    {
        protected override IEnumerable<IDataSource> DefaultTrain()
        {
            return [ new InformationsDataSource()
                {
                Intends = ["smallTalk"],
                Purposes = ["nothing"],
                Informations = ["I am happy"]
            }];
        }
    }
}
