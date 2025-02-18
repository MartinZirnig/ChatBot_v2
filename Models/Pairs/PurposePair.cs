using ModelsMl.Data;
using ModelsMl.Data.Tables;
using ModelsMl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Pairs
{
    public record PurposePair(
        string Input,
        List<string> Purposes,

        bool Loaded,
        bool Ignored
        )
        : StateInfo(Loaded, Ignored)
    {
        internal override void PushToDb(DatabaseConnection db)
        {
            var input = new Inputs()
            {
                Input = this.Input,
            };
            var purposes = new Purposes()
            {
                Purpose = this.Purposes.ToList(),
            };

            db.Inputs.Add(input);
            db.Purposes.Add(purposes);

            Conversations conversations = new Conversations()
            {
                Input = input,
                Purposes = purposes,

                Loaded = this.Loaded,
                Ignored = this.Ignored,
                UsedByModel = this.Model
            };
        }
    }
}
