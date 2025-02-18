using ModelsMl.Data;
using ModelsMl.Data.Tables;
using ModelsMl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Pairs
{
    public record IntendPair(
        string Input,
        List<string> Intends,

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
            var intends = new Intends()
            {
                Intend = this.Intends.ToList(),
            };

            db.Inputs.Add(input);
            db.Intends.Add(intends);

            Conversations conversations = new Conversations()
            {
                Input = input,
                Intends = intends,

                Loaded = this.Loaded,
                Ignored = this.Ignored,
                UsedByModel = this.Model
            };

            db.Conversations.Add(conversations);
        }
    }
}
