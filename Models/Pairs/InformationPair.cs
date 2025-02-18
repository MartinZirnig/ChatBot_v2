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
    public record InformationPair(
        List<string> Intends,
        List<string> Purposes,
        List<string> Informations,

        bool Loaded,
        bool Ignored
        )
        : StateInfo(Loaded, Ignored)
    {
        internal override void PushToDb(DatabaseConnection db)
        {
            var intend = new Intends()
            {
                Intend = this.Intends.ToList(),
            };
            var purpose = new Purposes()
            {
                Purpose = this.Purposes.ToList(),
            };
            var information = new Informations()
            {
                Information = this.Informations.ToList(),
            };

            db.Intends.Add(intend);
            db.Purposes.Add(purpose);
            db.Informations.Add(information);

            Conversations conversations = new Conversations()
            {
                Intends = intend,
                Purposes = purpose,
                Informations = information,

                Loaded = this.Loaded,
                Ignored = this.Ignored,
                UsedByModel = this.Model,
            };

            db.Conversations.Add(conversations);
        }
    }
}
