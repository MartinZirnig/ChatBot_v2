using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using ModelsMl.Models.Data.SourceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Models.Models
{
    internal class EmotionsDetector : GeneralMlModel
    {
        protected override IEnumerable<IDataSource> DefaultTrain()
        {
            return [ new EmotionsDataSource()
                {
                    Input = "I am happy",
                    Emotions =  ["joy"]
                }
            ];
        }
    }
}
